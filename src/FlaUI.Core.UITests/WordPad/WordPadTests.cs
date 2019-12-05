using System;
using System.IO;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Capturing;
using FlaUI.Core.UITests.WordPad.Screens;
using FlaUI.UIA3;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace FlaUI.Core.UITests.WordPad
{
    [TestFixture]
    public class WordPadTests
    {
        private Application application;
        private AutomationBase automation;

        [SetUp]
        public void TestSetup()
        {
            application = Application.Launch("wordpad.exe");
            // Give the application some time to start
            System.Threading.Thread.Sleep(1000);
            automation = new UIA3Automation();
        }

        [TearDown]
        public void TestTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                TakeScreenshot(TestContext.CurrentContext.Test.FullName);
            }
            
            application.Close();
            application.Dispose();
            application = null;
            automation.Dispose();
            automation = null;
        }

        [Test]
        public void ZoomTest()
        {
            var mainScreen = application.GetMainWindow(automation).As<MainScreen>();
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
            var mainScreen = application.GetMainWindow(automation).As<MainScreen>();

            Assert.DoesNotThrow(() =>
            {
                var infoScreen = mainScreen.OpenAndGetInfoScreen();
                infoScreen.OkButton.Invoke();
            });
        }

        private void TakeScreenshot(string screenshotName)
        {
            const string failedTestsData = @"c:\FailedTestsData";

            var imagename = screenshotName + ".png";
            imagename = imagename.Replace("\"", String.Empty);
            var imagePath = Path.Combine(failedTestsData, imagename);
            try
            {
                Directory.CreateDirectory(failedTestsData);
                Capture.Screen().ToFile(imagePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save screenshot to directory: {0}, filename: {1}, Ex: {2}", failedTestsData, imagePath, ex);
            }
        }
    }
}
