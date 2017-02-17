using FlaUI.UIA3;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class XPathTests
    {
        [Test]
        public void NotepadFindFirst()
        {
            var app = Application.Launch("notepad.exe");
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
                var file = window.FindFirstByXPath("/MenuBar/MenuItem[@Name='File']");
                Assert.That(file, Is.Not.Null);
            }
            app.Close();
        }

        [Test]
        public void NotePadFindAll()
        {
            var app = Application.Launch("notepad.exe");
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
                var items = window.FindAllByXPath("//MenuItem");
                Assert.That(items, Is.Not.Null);
                Assert.That(items, Has.Length.EqualTo(6));
            }
            app.Close();
        }
    }
}
