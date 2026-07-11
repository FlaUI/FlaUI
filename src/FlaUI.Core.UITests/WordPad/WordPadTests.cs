using System;
using System.ComponentModel;
using System.Diagnostics;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.UITests.WordPad.Screens;
using FlaUI.TestUtilities;
using FlaUI.UIA3;
using NUnit.Framework;

namespace FlaUI.Core.UITests.WordPad
{
    [TestFixture]
    public class WordPadTests : FlaUITestBase
    {
        protected override AutomationBase GetAutomation()
        {
            var automation = new UIA3Automation();
            // Increase some timeouts
            automation.ConnectionTimeout = TimeSpan.FromSeconds(automation.ConnectionTimeout.TotalSeconds * 2);
            automation.TransactionTimeout = TimeSpan.FromSeconds(automation.TransactionTimeout.TotalSeconds * 2);
            return automation;
        }

        protected override Application StartApplication()
        {
            try
            {
                var startInfo = new ProcessStartInfo("wordpad.exe")
                {
                    UseShellExecute = true
                };
                var application = Application.Launch(startInfo);
                application.WaitWhileMainHandleIsMissing();
                // Give the application some additional time to start
                System.Threading.Thread.Sleep(1000);
                return application;
            }
            catch (Win32Exception exception) when (exception.NativeErrorCode == 2 || exception.NativeErrorCode == 3)
            {
                Assert.Ignore("WordPad is not installed on this Windows environment and no repository-owned replacement covers its ribbon UI.");
                throw;
            }
        }

        [Test]
        public void ZoomTest()
        {
            var mainScreen = Application.GetMainWindow(Automation).As<MainScreen>();
            Assert.That(mainScreen.GetCurrentZoomPercent(), Is.EqualTo(100));
            mainScreen.ZoomIn();
            Assert.That(mainScreen.GetCurrentZoomPercent(), Is.EqualTo(110));
            mainScreen.ZoomOut();
            mainScreen.ZoomOut();
            Assert.That(mainScreen.GetCurrentZoomPercent(), Is.EqualTo(90));
        }

        [Test]
        public void InfoScreenTest()
        {
            var mainScreen = Application.GetMainWindow(Automation).As<MainScreen>();

            Assert.DoesNotThrow(() =>
            {
                var infoScreen = mainScreen.OpenAndGetInfoScreen();
                infoScreen.OkButton.Invoke();
            });
        }
    }
}
