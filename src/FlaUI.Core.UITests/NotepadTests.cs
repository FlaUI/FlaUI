using System.Diagnostics;
using FlaUI.Core.Tools;
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
            using (var app = Application.Launch("notepad.exe"))
            {
                using (var automation = new UIA3Automation())
                {
                    var window = app.GetMainWindow(automation);
                    Assert.That(window, Is.Not.Null);
                    Assert.That(window.Title, Is.Not.Null);
                }
                app.Close();
            }
        }

        [Test]
        public void NotepadAttachByNameTest()
        {
            using (var launchedApp = Application.Launch("notepad.exe"))
            {
                using (var automation = new UIA3Automation())
                {
                    var launchedWindow = launchedApp.GetMainWindow(automation, System.TimeSpan.FromSeconds(5));
                    Assert.That(launchedWindow, Is.Not.Null);

                    var app = Retry.WhileNull(() =>
                    {
                        var candidate = Application.Attach("notepad.exe");
                        if (candidate.ProcessId == launchedApp.ProcessId)
                        {
                            return candidate;
                        }
                        candidate.Dispose();
                        return null;
                    }, timeout: System.TimeSpan.FromSeconds(5), interval: System.TimeSpan.FromMilliseconds(50)).Result;

                    Assert.That(app, Is.Not.Null,
                        $"Attach by name did not resolve to the launched Notepad process {launchedApp.ProcessId}.");
                    using (app)
                    {
                        var window = app.GetMainWindow(automation);
                        Assert.That(window, Is.Not.Null);
                        Assert.That(window.Title, Is.Not.Null);
                        app.Close();
                    }
                }
            }
        }

        [Test]
        public void NotepadAttachByProcessIdTest()
        {
            using (var launchedApp = Application.Launch("notepad.exe"))
            {
                using (var app = Application.Attach(launchedApp.ProcessId))
                {
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

        [TestCase(@"C:\WINDOWS\system32\notepad.exe")]
        [TestCase("notepad.exe")]
        public void NotepadAttachOrLauchIdTest(string name)
        {
            using (Application.Launch("notepad.exe"))
            {
                using (var app = Application.AttachOrLaunch(new ProcessStartInfo(name)))
                {
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

        [Test]
        public void NotepadAttachWithAbsoluteExePath()
        {
            using (Application.Launch("notepad.exe"))
            {
                using (var app = Application.Attach(@"C:\WINDOWS\system32\notepad.exe"))
                {
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
    }
}
