using System;
using FlaUI.Core.Capturing;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestTools;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    class VideoTest
    {
        [Test]
        public void Main()
        {
            Logger.Default = new NUnitProgressLogger();
            Logger.Default.SetLevel(LogLevel.Debug);
            SystemInfo.Refresh();
            var recordingStartTime = DateTime.UtcNow;
            var recorder = new VideoRecorder(10, 26, @"C:\Users\rbl\Documents\ffmpeg.exe", @"C:\temp\out.mp4", () =>
            {
                var img = Capture.Screen(1);
                img.ApplyOverlays(new InfoOverlay(img.DesktopBounds) { CustomTimeSpan = DateTime.UtcNow - recordingStartTime, OverlayStringFormat = @"{ct:hh\:mm\:ss\.fff} / {name} / CPU: {cpu} / RAM: {mem.p.used}/{mem.p.tot} ({mem.p.used.perc})" }, new MouseOverlay(img.DesktopBounds));
                return img;
            });
            System.Threading.Thread.Sleep(5000);
            recorder.Dispose();
        }
    }
}
