using FlaUI.Core.AutomationElements;
using FlaUI.Core.UITests.WordPad.Screens;
using FlaUI.UIA3;
using NUnit.Framework;

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
    }
}
