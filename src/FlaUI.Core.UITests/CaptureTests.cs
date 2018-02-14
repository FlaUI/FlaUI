using System.Drawing;
using FlaUI.Core.Capturing;
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
                    Capture.Screen().ToFile(@"c:\temp\screen.png");
                    Capture.Element(window).ToFile(@"c:\temp\window.png");
                    Capture.Rectangle(new Rectangle(0, 0, 500, 300)).ToFile(@"c:\temp\rect.png");
                    Capture.ElementRectangle(window, new Rectangle(0, 0, 50, 150)).ToFile(@"c:\temp\elemrect.png");
                }
                app.Close();
            }
        }
    }
}
