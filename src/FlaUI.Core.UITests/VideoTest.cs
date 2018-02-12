using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Threading;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    class VideoTest
    {
        [Test]
        public void Main()
        {
            var videoPipeName = $"flaui-capture-{Guid.NewGuid()}";
            NamedPipeServerStream _ffmpegIn = new NamedPipeServerStream(videoPipeName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 10000, 10000);

            const string PipePrefix = @"\\.\pipe\";
            var FrameRate = 5;

            var tmp = FlaUI.Core.Capture.Screen(0).Bitmap;

            var Width = tmp.Width;
            var Height = tmp.Height;
            var videoInArgs = $"-framerate {FrameRate} -f rawvideo -pix_fmt rgb32 -video_size {Width}x{Height} -i {PipePrefix}{videoPipeName}";
            var videoOutArgs = $"-vcodec libx264 -crf 23 -pix_fmt yuv420p -preset ultrafast -r {FrameRate}";
            var outFile = @"C:\temp\out.mp4";
            var _ffmpegProcess = StartFFMpeg($"-y {videoInArgs} {videoOutArgs} \"{outFile}\"");
            _ffmpegIn.WaitForConnection();


            for (int i = 0; i < 20; i++)
            {
                var img = FlaUI.Core.Capture.Screen(0).AddCursor().AddTimestamp();
                var imgData = BitmapToByteArray((Bitmap)img.Bitmap);
                img.Dispose();
                _ffmpegIn.WriteAsync(imgData, 0, imgData.Length);
                Thread.Sleep(100);
            }

            TestContext.Progress.WriteLine("Disposing");
            _ffmpegIn.Flush();
            _ffmpegIn.Close();
            _ffmpegIn.Dispose();
            TestContext.Progress.WriteLine("Disposed");

            _ffmpegProcess.WaitForExit();
            TestContext.Progress.WriteLine("End waited");
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
