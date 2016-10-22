using System.Diagnostics;
using FlaUI.UIA3;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class NotepadTests
    {
        [Test]
        public void NotepadLaunchTest()
        {
            var app = Application.Launch("notepad.exe");
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
            }
            app.Close();
        }

        [Test]
        public void NotepadAttachByNameTest()
        {
            Application.Launch("notepad.exe");
            var app = Application.Attach("notepad.exe");

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
            }
            app.Close();
        }

        [Test]
        public void NotepadAttachByProcessIdTest()
        {
            var launchedApp = Application.Launch("notepad.exe");
            var app = Application.Attach(launchedApp.ProcessId);

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
            }
            app.Close();
        }

        [Test]
        public void NotepadAttachOrLauchIdTest()
        {
            Application.Launch("notepad.exe");
            var app = Application.AttachOrLaunch(new ProcessStartInfo(@"C:\WINDOWS\system32\notepad.exe"));

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
            }
            app.Close();

            app = Application.AttachOrLaunch(new ProcessStartInfo("notepad.exe"));

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
            }
            app.Close();
        }

        [Test]
        public void NotepadAttachWithAbsoluteExePath()
        {
            Application.Launch("notepad.exe");
            var app = Application.Attach(@"C:\WINDOWS\system32\notepad.exe");

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
            }
            app.Close();
        }
    }
}
