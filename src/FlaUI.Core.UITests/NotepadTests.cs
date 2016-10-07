using System;
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
                Console.WriteLine(window.Title);
                window.DrawHighlight();
                window.Move(100, 100);
                window.DrawHighlight();
                window.Move(200, 200);
                window.DrawHighlight();
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
                Console.WriteLine(window.Title);
                window.DrawHighlight();
                window.Move(100, 100);
                window.DrawHighlight();
                window.Move(200, 200);
                window.DrawHighlight();
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
                Console.WriteLine(window.Title);
                window.DrawHighlight();
                window.Move(100, 100);
                window.DrawHighlight();
                window.Move(200, 200);
                window.DrawHighlight();
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
                Console.WriteLine(window.Title);
                window.DrawHighlight();
                window.Move(100, 100);
                window.DrawHighlight();
                window.Move(200, 200);
                window.DrawHighlight();
            }
            app.Close();

            app = Application.AttachOrLaunch(new ProcessStartInfo("notepad.exe"));

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Console.WriteLine(window.Title);
                window.DrawHighlight();
                window.Move(100, 100);
                window.DrawHighlight();
                window.Move(200, 200);
                window.DrawHighlight();
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
                Console.WriteLine(window.Title);
                window.Move(250, 250);
                window.DrawHighlight();
                window.Move(100, 100);
                window.DrawHighlight();
            }
            app.Close();
        }
    }
}
