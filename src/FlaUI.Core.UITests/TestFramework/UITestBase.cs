using System;
using System.IO;
using System.Threading.Tasks;
using FlaUI.Core.Capturing;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestTools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace FlaUI.Core.UITests.TestFramework
{
    /// <summary>
    /// Base class for ui test with some helper methods
    /// </summary>
    public abstract class UITestBase
    {
        /// <summary>
        /// Flag which indicates if any test was run on a new instance of the app
        /// </summary>
        private bool _wasTestRun;

        private VideoRecorder _recorder;
        private string _testMethodName;

        protected AutomationType AutomationType { get; }

        protected TestApplicationType ApplicationType { get; }

        /// <summary>
        /// Path of the directory for the screenshots
        /// </summary>
        protected string ScreenshotDir { get; }

        /// <summary>
        /// Instance of the current running application
        /// </summary>
        protected Application App { get; private set; }

        protected AutomationBase Automation { get; }

        protected UITestBase(AutomationType automationType, TestApplicationType appType)
        {
            AutomationType = automationType;
            ApplicationType = appType;
            ScreenshotDir = @"c:\FailedTestsScreenshots";
            _wasTestRun = false;
            Automation = TestUtilities.GetAutomation(automationType);
            Logger.Default = new NUnitProgressLogger();
        }

        /// <summary>
        /// Setup which starts the application (once per test-class)
        /// </summary>
        [OneTimeSetUp]
        public async Task BaseSetup()
        {
            // Start the recorder
            SystemInfo.RefreshAll();
            var ffmpegPath = await VideoRecorder.DownloadFFMpeg(@"C:\temp");
            var recordingStartTime = DateTime.UtcNow;
            _recorder = new VideoRecorder(15, 26, ffmpegPath, @"C:\temp\out.mp4", () =>
            {
                var testName = TestContext.CurrentContext.Test.ClassName + "." + (_testMethodName ?? "[Setup]");
                var img = Capture.Screen(0);
                img.ApplyOverlays(new InfoOverlay(img.DesktopBounds) { CustomTimeSpan = DateTime.UtcNow - recordingStartTime, OverlayStringFormat = @"{ct:hh\:mm\:ss\.fff} / {name} / CPU: {cpu} / RAM: {mem.p.used}/{mem.p.tot} ({mem.p.used.perc}) / " + testName }, new MouseOverlay(img.DesktopBounds));
                return img;
            });
            await Task.Delay(1000);
            StartTestApplication();
        }

        /// <summary>
        /// Closes the application after all tests were run
        /// </summary>
        [OneTimeTearDown]
        public async Task BaseTeardown()
        {
            Automation.Dispose();
            StopTestApplication();
            await Task.Delay(1000);
            _recorder.Dispose();
        }

        [SetUp]
        public void BaseTestSetup()
        {
            _testMethodName = TestContext.CurrentContext.Test.MethodName;
        }

        /// <summary>
        /// Takes screenshot on failed tests
        /// </summary>
        [TearDown]
        public void BaseTestTeardown()
        {
            // Mark that a test was run on this application
            _wasTestRun = true;
            // Make a screenshot if the test failed
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                TakeScreenshot(TestContext.CurrentContext.Test.FullName);
            }
        }

        /// <summary>
        /// Method which starts the custom application to test
        /// </summary>
        protected virtual Application StartApplication()
        {
            return null;
        }

        /// <summary>
        /// Restarts the application to test
        /// </summary>
        protected void RestartApp()
        {
            // Don't restart if no test was already run on it
            if (!_wasTestRun) return;
            // Restart the application
            StopTestApplication();
            StartTestApplication();
            _wasTestRun = false;
        }

        private void StartTestApplication()
        {
            switch (ApplicationType)
            {
                case TestApplicationType.Custom:
                    App = StartApplication();
                    break;
                case TestApplicationType.WinForms:
                    App = Application.Launch(Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\TestApplications\WinFormsApplication\bin\WinFormsApplication.exe"));
                    break;
                case TestApplicationType.Wpf:
                    App = Application.Launch(Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\TestApplications\WpfApplication\bin\WpfApplication.exe"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            App.WaitWhileMainHandleIsMissing();
        }

        private void StopTestApplication()
        {
            App.Close();
            App.Dispose();
            App = null;
        }

        private void TakeScreenshot(string screenshotName)
        {
            var imagename = screenshotName + ".png";
            imagename = imagename.Replace("\"", String.Empty);
            var imagePath = Path.Combine(ScreenshotDir, imagename);
            try
            {
                Directory.CreateDirectory(ScreenshotDir);
                Capture.Screen().ToFile(imagePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save screenshot to directory: {0}, filename: {1}, Ex: {2}", ScreenshotDir, imagePath, ex);
            }
        }
    }
}
