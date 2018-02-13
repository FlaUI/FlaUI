using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using FlaUI.Core.Tools;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    class VideoTest
    {
        [Test]
        public void Main()
        {
            SystemInfo.Refresh();
            var recorder = new VideoRecorder(10, 26);
            System.Threading.Thread.Sleep(10000);
            recorder.Dispose();
        }

        public class VideoRecorder : IDisposable
        {
            private readonly uint _frameRate;
            private readonly uint _quality;
            private readonly Task _recordTask;
            private readonly Task _writeTask;
            private readonly CancellationTokenSource _recordTaskCancellation = new CancellationTokenSource();
            private readonly BlockingCollection<ImageData> _frames;

            /// <summary>
            /// Creates the video recorder and starts recording.
            /// </summary>
            /// <param name="frameRate">The wanted framerate of the recording.</param>
            /// <param name="quality">The quality of the recording. Should be 0 (lossless) to 51 (lowest quality).</param>
            public VideoRecorder(uint frameRate, uint quality)
            {
                _frameRate = frameRate;
                _quality = quality;
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
                            Console.WriteLine($"Adding {diff} missing frames");
                        }
                        for (var i = 0; i < diff; ++i)
                        {
                            _frames.Add(lastImage, ct);
                            ++frameCount;
                        }
                    }

                    using (var img = FlaUI.Core.Capture.Screen(0))
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
                Console.WriteLine("cancelled");
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
                        var videoOutArgs = $"-vcodec libx264 -crf {_quality} -pix_fmt yuv420p -preset ultrafast -r {_frameRate}";
                        var outFile = @"C:\temp\out.mp4";
                        ffmpegProcess = StartFFMpeg($"-y {videoInArgs} {videoOutArgs} \"{outFile}\"");
                        ffmpegIn.WaitForConnection();
                    }
                    ffmpegIn.WriteAsync(img.Data, 0, img.Data.Length);
                }

                ffmpegIn.Flush();
                ffmpegIn.Close();
                ffmpegIn.Dispose();
                ffmpegProcess?.WaitForExit();
                Console.WriteLine("Write finished");
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
                    Console.WriteLine(ex);
                }
            }

            private class ImageData
            {
                public int Width { get; set; }
                public int Height { get; set; }
                public byte[] Data { get; set; }
            }
        }

        public static Process StartFFMpeg(string Arguments)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = @"C:\Users\rbl\Documents\ffmpeg.exe",
                    Arguments = Arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true
                },
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += (s, e) => TestContext.Progress.WriteLine(e.Data);
            process.ErrorDataReceived += (s, e) => TestContext.Progress.WriteLine(e.Data);
            process.Start();
            process.BeginErrorReadLine();
            return process;
        }

        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            BitmapData bmpdata = null;
            try
            {
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                int numbytes = Math.Abs(bmpdata.Stride) * bitmap.Height;
                byte[] bytedata = new byte[numbytes];
                IntPtr ptr = bmpdata.Scan0;
                Marshal.Copy(ptr, bytedata, 0, numbytes);
                return bytedata;
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }
        }
    }
}
