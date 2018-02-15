#if (!NET35 && !NET40)
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using FlaUI.Core.Logging;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// A video recorder which records the captured images into a video file.
    /// </summary>
    public class VideoRecorder : IDisposable
    {
        private readonly uint _frameRate;
        private readonly uint _quality;
        private readonly string _ffmpegExePath;
        private readonly string _targetVideoPath;
        private readonly Func<CaptureImage> _captureMethod;
        private readonly Task _recordTask;
        private readonly Task _writeTask;
        private readonly CancellationTokenSource _recordTaskCancellation = new CancellationTokenSource();
        private readonly BlockingCollection<ImageData> _frames;

        /// <summary>
        /// Creates the video recorder and starts recording.
        /// </summary>
        /// <param name="frameRate">The wanted framerate of the recording.</param>
        /// <param name="quality">The quality of the recording. Should be 0 (lossless) to 51 (lowest quality).</param>
        /// <param name="ffmpegExePath">The full path to the executable of ffmpeg.</param>
        /// <param name="targetVideoPath">The path to the target video file.</param>
        /// <param name="captureMethod">The method used for capturing the image which is recorder.</param>
        public VideoRecorder(uint frameRate, uint quality, string ffmpegExePath, string targetVideoPath, Func<CaptureImage> captureMethod)
        {
            _frameRate = frameRate;
            _quality = quality;
            _ffmpegExePath = ffmpegExePath;
            _targetVideoPath = targetVideoPath;
            _captureMethod = captureMethod;
            _frames = new BlockingCollection<ImageData>();
            _recordTask = Task.Factory.StartNew(async () => await RecordLoop(_recordTaskCancellation.Token), _recordTaskCancellation.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            _writeTask = Task.Factory.StartNew(WriteLoop, TaskCreationOptions.LongRunning);
        }

        private async Task RecordLoop(CancellationToken ct)
        {
            var frameInterval = TimeSpan.FromSeconds(1.0 / _frameRate);
            var sw = Stopwatch.StartNew();
            var frameCount = 0;
            ImageData lastImage = null;
            while (!ct.IsCancellationRequested)
            {
                var timestamp = DateTime.UtcNow;

                if (lastImage != null)
                {
                    var requiredFrames = (int)Math.Floor(sw.Elapsed.TotalSeconds * _frameRate);
                    var diff = requiredFrames - frameCount;
                    if (diff > 0)
                    {
                        Logger.Default.Warn($"Adding {diff} missing frames");
                    }
                    for (var i = 0; i < diff; ++i)
                    {
                        _frames.Add(lastImage, ct);
                        ++frameCount;
                    }
                }

                using (var img = _captureMethod())
                {
                    var imgData = BitmapToByteArray(img.Bitmap);
                    var image = new ImageData
                    {
                        Data = imgData,
                        Width = img.Bitmap.Width,
                        Height = img.Bitmap.Height
                    };
                    _frames.Add(image, ct);
                    ++frameCount;
                    lastImage = image;
                }

                var timeTillNextFrame = timestamp + frameInterval - DateTime.UtcNow;
                if (timeTillNextFrame > TimeSpan.Zero)
                {
                    await Task.Delay(timeTillNextFrame, ct);
                }
            }
        }

        private void WriteLoop()
        {
            var videoPipeName = $"flaui-capture-{Guid.NewGuid()}";
            var ffmpegIn = new NamedPipeServerStream(videoPipeName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 10000, 10000);
            const string pipePrefix = @"\\.\pipe\";
            Process ffmpegProcess = null;

            var isFirstFrame = true;
            while (!_frames.IsCompleted)
            {
                _frames.TryTake(out var img, -1);
                if (img == null)
                {
                    // Happens when the queue is marked as completed
                    continue;
                }
                if (isFirstFrame)
                {
                    isFirstFrame = false;
                    var videoInArgs = $"-framerate {_frameRate} -f rawvideo -pix_fmt rgb32 -video_size {img.Width}x{img.Height} -i {pipePrefix}{videoPipeName}";
                    var videoOutArgs = $"-vcodec libx264 -crf {_quality} -pix_fmt yuv420p -preset ultrafast -r {_frameRate} -vf \"scale={img.Width}:-2\"";
                    ffmpegProcess = StartFFMpeg(_ffmpegExePath, $"-y {videoInArgs} {videoOutArgs} \"{_targetVideoPath}\"");
                    ffmpegIn.WaitForConnection();
                }
                ffmpegIn.WriteAsync(img.Data, 0, img.Data.Length);
            }

            ffmpegIn.Flush();
            ffmpegIn.Close();
            ffmpegIn.Dispose();
            ffmpegProcess?.WaitForExit();
        }

        public void Dispose()
        {
            _recordTaskCancellation.Cancel();
            _recordTask.Wait();
            _frames.CompleteAdding();
            try
            {
                _writeTask.Wait();
            }
            catch (Exception ex)
            {
                Logger.Default.Warn(ex.Message, ex);
            }
        }

        private Process StartFFMpeg(string exePath, string arguments)
        {
            var process = new Process
            {
                StartInfo =
                    {
                        FileName = exePath,
                        Arguments = arguments,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                        RedirectStandardInput = true
                    },
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += (s, e) => Logger.Default.Debug(e.Data);
            process.ErrorDataReceived += (s, e) => Logger.Default.Info(e.Data);
            process.Start();
            process.BeginErrorReadLine();
            return process;
        }

        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            BitmapData bmpdata = null;
            try
            {
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                var numbytes = Math.Abs(bmpdata.Stride) * bitmap.Height;
                var bytedata = new byte[numbytes];
                var ptr = bmpdata.Scan0;
                Marshal.Copy(ptr, bytedata, 0, numbytes);
                return bytedata;
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }
        }

        public static async Task<string> DownloadFFMpeg(string targetFolder)
        {
            var bits = Environment.Is64BitOperatingSystem ? 64 : 32;
            var uri = new Uri($"http://ffmpeg.zeranoe.com/builds/win{bits}/static/ffmpeg-latest-win{bits}-static.zip");
            var archivePath = Path.Combine(Path.GetTempPath(), "ffmpeg.zip");
            var destPath = Path.Combine(targetFolder, "ffmpeg.exe");
            if (!File.Exists(destPath))
            {
                // Download
                using (var webClient = new WebClient())
                {
                    await webClient.DownloadFileTaskAsync(uri, archivePath);
                }
                // Extract
                await Task.Run(() =>
                {
                    using (var archive = ZipFile.OpenRead(archivePath))
                    {
                        var exeEntry = archive.Entries.First(x => x.Name == "ffmpeg.exe");
                        exeEntry.ExtractToFile(destPath, true);
                    }
                });
                File.Delete(archivePath);
            }
            return destPath;
        }

        private class ImageData
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public byte[] Data { get; set; }
        }
    }
}
#endif
