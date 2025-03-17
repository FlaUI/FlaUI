using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// A video recorder which records the captured images into a video file.
    /// </summary>
    public class VideoRecorder : IDisposable
    {
        private readonly VideoRecorderSettings _settings;
        private readonly Func<VideoRecorder, CaptureImage> _captureMethod;
        private readonly BlockingCollection<ImageData> _frames;
        private Task? _recordTask;
        private bool _shouldRecord;
        private Task? _writeTask;
        private DateTime _recordStartTime;
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Creates the video recorder and starts recording.
        /// </summary>
        /// <param name="settings">The settings used for the recorder.</param>
        /// <param name="captureMethod">The method used for capturing the image which is recorder.</param>
        public VideoRecorder(VideoRecorderSettings settings, Func<VideoRecorder, CaptureImage> captureMethod)
        {
            _settings = settings;
            _captureMethod = captureMethod;
            _frames = new BlockingCollection<ImageData>();
            Start();
        }

        /// <summary>
        /// The path of the video file.
        /// </summary>
        public string TargetVideoPath => _settings.TargetVideoPath;

        /// <summary>
        /// The time since the recording started.
        /// </summary>
        public TimeSpan RecordTimeSpan => DateTime.UtcNow - _recordStartTime;

        private async Task RecordLoop()
        {
            var frameInterval = TimeSpan.FromSeconds(1.0 / _settings.FrameRate);
            var sw = Stopwatch.StartNew();
            var frameCount = 0;
            var totalMissedFrames = 0;
            while (_shouldRecord)
            {
                var timestamp = DateTime.UtcNow;

                if (frameCount > 0)
                {
                    var requiredFrames = (int)Math.Floor(sw.Elapsed.TotalSeconds * _settings.FrameRate);
                    var diff = requiredFrames - frameCount;
                    if (diff >= 5 && _settings.LogMissingFrames)
                    {
                        Logger.Default.Warn($"Adding many ({diff}) missing frame(s) to \"{Path.GetFileName(TargetVideoPath)}\".");
                    }

                    for (var i = 0; i < diff; ++i)
                    {
                        _frames.Add(ImageData.RepeatImage);
                        ++frameCount;
                        ++totalMissedFrames;
                    }
                }

                using (var img = _captureMethod(this))
                {
                    var image = new ImageData
                    {
                        Data = BitmapToByteArray(img.Bitmap),
                        Width = img.Bitmap.Width,
                        Height = img.Bitmap.Height
                    };
                    _frames.Add(image);
                    ++frameCount;
                }

                var timeTillNextFrame = timestamp + frameInterval - DateTime.UtcNow;
                if (timeTillNextFrame > TimeSpan.Zero)
                {
                    if (timeTillNextFrame > TimeSpan.FromSeconds(1))
                    {
                        // Happens when the system date is set to an earlier time during recording
                        await Task.Delay(frameInterval);
                    }
                    else
                    {
                        await Task.Delay(timeTillNextFrame);
                    }
                }
            }
            if (totalMissedFrames > 0 && _settings.LogMissingFrames)
            {
                Logger.Default.Warn($"Totally added {totalMissedFrames} missing frame(s) to \"{Path.GetFileName(TargetVideoPath)}\".");
            }
        }

        private void WriteLoop()
        {
            var videoPipeName = $"flaui-capture-{Guid.NewGuid()}";
            var ffmpegIn = new NamedPipeServerStream(videoPipeName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 10000, 10000);
            const string pipePrefix = @"\\.\pipe\";
            Process? ffmpegProcess = null;

            var isFirstFrame = true;
            ImageData? lastImage = null;
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
                    Directory.CreateDirectory(new FileInfo(TargetVideoPath).Directory.FullName);
                    var videoInFormat = _settings.UseCompressedImages ? "" : "-f rawvideo"; // Used when sending raw bitmaps to the pipe
                    var videoInArgs = $"-framerate {_settings.FrameRate} {videoInFormat} -pix_fmt rgb32 -video_size {img.Width}x{img.Height} -i {pipePrefix}{videoPipeName}";
                    var videouOutCodec = _settings.VideoFormat == VideoFormat.x264
                        ? $"-c:v libx264 -crf {_settings.VideoQuality} -pix_fmt yuv420p -preset ultrafast"
                        : $"-c:v libxvid -qscale:v {_settings.VideoQuality}";
                    var videoOutArgs = $"{videouOutCodec} -r {_settings.FrameRate} -vf \"scale={img.Width.Even()}:{img.Height.Even()}\"";
                    ffmpegProcess = StartFFMpeg(_settings.ffmpegPath, $"-y -hide_banner -loglevel warning {videoInArgs} {videoOutArgs} \"{TargetVideoPath}\"");
                    ffmpegIn.WaitForConnection();
                }
                if (img.IsRepeatFrame)
                {
                    // Repeat the last frame
                    ffmpegIn.WriteAsync(lastImage.Data, 0, lastImage.Data.Length);
                }
                else
                {
                    // Write the received frame and save it as last image
                    ffmpegIn.WriteAsync(img.Data, 0, img.Data.Length);
                    if (lastImage != null)
                    {
                        lastImage.Dispose();
                        lastImage = null;
                        GC.Collect();
                    }
                    lastImage = img;
                }
            }

            ffmpegIn.Flush();
            ffmpegIn.Close();
            ffmpegIn.Dispose();
            ffmpegProcess?.WaitForExit();
            ffmpegProcess?.Dispose();
        }

        /// <summary>
        /// Starts recording.
        /// </summary>
        private void Start()
        {
            _shouldRecord = true;
            _recordStartTime = DateTime.UtcNow;
            _recordTask = Task.Factory.StartNew(async () => await RecordLoop(), TaskCreationOptions.LongRunning);
            _writeTask = Task.Factory.StartNew(WriteLoop, TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// Stops recording and finishes the video file.
        /// </summary>
        public void Stop()
        {
            if (_recordTask != null)
            {
                _shouldRecord = false;
                _recordTask.Wait();
                _recordTask = null;
            }
            _frames.CompleteAdding();
            if (_writeTask != null)
            {
                try
                {
                    _writeTask.Wait();
                    _writeTask = null;
                }
                catch (Exception ex)
                {
                    Logger.Default.Warn(ex.Message, ex);
                }
            }
        }

        public void Dispose()
        {
            Stop();
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
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                    },
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += OnProcessDataReceived;
            process.ErrorDataReceived += OnProcessDataReceived;
            process.Start();
            if (_settings.EncodeWithLowPriority)
            {
                process.PriorityClass = ProcessPriorityClass.BelowNormal;
            }
            process.BeginErrorReadLine();
            return process;
        }

        private void OnProcessDataReceived(object s, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.Data))
            {
                Logger.Default.Info(e.Data);
            }
        }

        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, _settings.UseCompressedImages ? ImageFormat.Png : ImageFormat.Bmp);
                return stream.ToArray();
            }
        }

        public static async Task<string> DownloadFFMpeg(string targetFolder)
        {
            var bits = Environment.Is64BitOperatingSystem ? 64 : 32;
            if (bits == 32)
            {
                throw new NotSupportedException("The current FFMPEG builds to not support 32-bit.");
            }
            var uri = new Uri($"https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip");
            var archivePath = Path.Combine(Path.GetTempPath(), "ffmpeg.zip");
            var destPath = Path.Combine(targetFolder, "ffmpeg.exe");
            if (!File.Exists(destPath))
            {
                // Download
                byte[] fileBytes = await _httpClient.GetByteArrayAsync(uri);
                File.WriteAllBytes(archivePath, fileBytes);
                // Extract
                Directory.CreateDirectory(targetFolder);
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

        private class ImageData : IDisposable
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public bool IsRepeatFrame { get; private set; }
            public byte[]? Data { get; set; }

            public static readonly ImageData RepeatImage = new ImageData { IsRepeatFrame = true };

            public void Dispose()
            {
                Data = null;
            }
        }
    }
}
