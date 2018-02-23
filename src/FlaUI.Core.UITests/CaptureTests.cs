using System.Drawing;
using FlaUI.Core.Capturing;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
using FlaUI.UIA3;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    [Ignore("Only for local testing")]
    public class CaptureTests
    {
        [Test]
        public void Test()
        {
            using (var app = Application.Launch("notepad.exe"))
            {
                using (var automation = new UIA3Automation())
                {
                    var window = app.GetMainWindow(automation);
                    Assert.That(window, Is.Not.Null);
                    Assert.That(window.Title, Is.Not.Null);
                    var image = Capture.Screen();
                    image.ApplyOverlays(new MouseOverlay(image));
                    image.ToFile(@"c:\temp\screen.png");
                    Capture.Element(window).ToFile(@"c:\temp\window.png");
                    Capture.Rectangle(new Rectangle(0, 0, 500, 300)).ToFile(@"c:\temp\rect.png");
                    Capture.ElementRectangle(window, new Rectangle(0, 0, 50, 150)).ToFile(@"c:\temp\elemrect.png");
                }
                app.Close();
            }
        }

        [Test]
        public void VideoTest()
        {
            Logger.Default = new NUnitProgressLogger();
            Logger.Default.SetLevel(LogLevel.Debug);
            SystemInfo.RefreshAll();
            var recorder = new VideoRecorder(new VideoRecorderSettings { VideoQuality = 26, ffmpegPath = @"C:\Users\rbl\Documents\ffmpeg.exe", TargetVideoPath = @"C:\temp\out.mp4" }, r =>
            {
                var img = Capture.Screen(1);
                img.ApplyOverlays(new InfoOverlay(img) { RecordTimeSpan = r.RecordTimeSpan, OverlayStringFormat = @"{rt:hh\:mm\:ss\.fff} / {name} / CPU: {cpu} / RAM: {mem.p.used}/{mem.p.tot} ({mem.p.used.perc})" }, new MouseOverlay(img));
                return img;
            });
            System.Threading.Thread.Sleep(5000);
            recorder.Dispose();
        }
    }
}
