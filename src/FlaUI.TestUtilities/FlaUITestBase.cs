using System;
using System.IO;
using System.Threading.Tasks;
using FlaUI.Core;
using FlaUI.Core.Capturing;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace FlaUI.TestUtilities
{
    /// <summary>
    /// Base class for ui tests with some helper methods.
    /// This class allows recording videos, taking screen shots on failed tests and
    /// starts and stops the application under test for each test or fixture.
    /// </summary>
    public abstract class FlaUITestBase
    {
        /// <summary>
        /// Member which holds the current video recorder.
        /// </summary>
        private VideoRecorder _recorder;

        /// <summary>
        /// The name of the current test method. Used for the video recorder.
        /// </summary>
        private string _testMethodName;

        /// <summary>
        /// Instance of the current used automation object.
        /// </summary>
        protected AutomationBase Automation { get; private set; }

        /// <summary>
        /// Instance of the current running application.
        /// </summary>
        protected Application Application { get; set; }

        /// <summary>
        /// Specifies the starting mode of the application to test.
        /// Defaults to OncePerTest.
        /// </summary>
        protected virtual ApplicationStartMode ApplicationStartMode => ApplicationStartMode.OncePerTest;

        /// <summary>
        /// Flag to indicate if videos should be kept even if the test did not fail.
        /// Defaults to false.
        /// </summary>
        protected virtual bool KeepVideoForSuccessfulTests => false;

        /// <summary>
        /// Specifies the mode of the video recorder.
        /// Defaults to OnePerTest.
        /// </summary>
        protected virtual VideoRecordingMode VideoRecordingMode => VideoRecordingMode.OnePerTest;

        /// <summary>
        /// static member which holds the current execution date and time
        /// </summary> 
        private static string _testDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

        /// <summary>
        /// Path of the directory for the screenshots and videos for the tests.
        /// Defaults to c:\temp\testsmedia.
        /// </summary>
        protected virtual string TestsMediaPath => $@"c:\temp\testsmedia\{SanitizeFileName(TestContext.CurrentContext.Test.Name)}\{_testDateTime}";

        /// <summary>
        /// Gets the automation instance that should be used.
        /// </summary>
        protected abstract AutomationBase GetAutomation();

        /// <summary>
        /// Starts the application which should be tested.
        /// </summary>
        protected abstract Application StartApplication();

        /// <summary>
        /// Setup method for the test fixture.
        /// </summary>
        [OneTimeSetUp]
        public virtual async Task UITestBaseOneTimeSetUp()
        {
            Logger.Default = new NUnitProgressLogger();
            Automation = GetAutomation();
            if (VideoRecordingMode == VideoRecordingMode.OnePerFixture)
            {
                await StartVideoRecorder(SanitizeFileName(TestContext.CurrentContext.Test.FullName));
            }

            if (ApplicationStartMode == ApplicationStartMode.OncePerFixture)
            {
                Application = StartApplication();
            }
        }

        /// <summary>
        /// Teardown method of the test fixture.
        /// </summary>
        [OneTimeTearDown]
        public virtual void UITestBaseOneTimeTearDown()
        {
            if (VideoRecordingMode == VideoRecordingMode.OnePerFixture)
            {
                StopVideoRecorder();
            }
            if (ApplicationStartMode == ApplicationStartMode.OncePerFixture)
            {
                CloseApplication();
            }
            if (Automation != null)
            {
                Automation.Dispose();
                Automation = null;
            }
        }

        /// <summary>
        /// Setup method for each test.
        /// </summary>
        [SetUp]
        public virtual async Task UITestBaseSetUp()
        {
            // Due to the recorder running in an own thread, it is necessary to save the current method name for that thread
            _testMethodName = TestContext.CurrentContext.Test.MethodName;

            if (VideoRecordingMode == VideoRecordingMode.OnePerTest)
            {
                await StartVideoRecorder(SanitizeFileName(TestContext.CurrentContext.Test.FullName));
            }

            if (ApplicationStartMode == ApplicationStartMode.OncePerTest)
            {
                Application = StartApplication();
            }
        }

        /// <summary>
        /// Teardown method for each test.
        /// </summary>
        [TearDown]
        public virtual void UITestBaseTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                TakeScreenShot(TestContext.CurrentContext.Test.FullName);
                TestContext.AddTestAttachment(
                    CreateScreenShotPath(TestContext.CurrentContext.Test.FullName),
                    TestContext.CurrentContext.Test.FullName);
            }

            if (ApplicationStartMode == ApplicationStartMode.OncePerTest)
            {
                CloseApplication();
            }

            if (VideoRecordingMode == VideoRecordingMode.OnePerTest)
            {
                StopVideoRecorder();
            }

            _testMethodName = null;
        }

        /// <summary>
        /// Closes and starts the application.
        /// </summary>
        protected void RestartApplication()
        {
            CloseApplication();
            Application = StartApplication();
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        private void CloseApplication()
        {
            if (Application != null)
            {
                Application.Close();
                Retry.WhileFalse(() => Application.HasExited, TimeSpan.FromSeconds(2), ignoreException: true);
                Application.Dispose();
                Application = null;
            }
        }

        /// <summary>
        /// Method which captures the image for the video and screen shots.
        /// By default captures the main screen.
        /// </summary>
        protected virtual CaptureImage CaptureImage()
        {
            return Capture.MainScreen();
        }

        /// <summary>
        /// Method which allows customizing the settings for the video recorder.
        /// By default downloads ffmpeg and sets the path to ffmpeg.
        /// </summary>
        protected virtual async Task AdjustRecorderSettings(VideoRecorderSettings videoRecorderSettings)
        {
            // Download FFMpeg
            var ffmpegPath = await VideoRecorder.DownloadFFMpeg(@"C:\temp");
            videoRecorderSettings.ffmpegPath = ffmpegPath;
        }

        /// <summary>
        /// Starts the video recorder.
        /// </summary>
        /// <param name="videoName">The unique name of the video file.</param>
        private async Task StartVideoRecorder(string videoName)
        {
            // Refresh all the system information
            SystemInfo.RefreshAll();

            // Start the recorder
            var videoRecorderSettings = new VideoRecorderSettings
            {
                VideoFormat = VideoFormat.xvid,
                VideoQuality = 6,
                TargetVideoPath = Path.Combine(TestsMediaPath, $"{SanitizeFileName(videoName)}.avi")
            };
            await AdjustRecorderSettings(videoRecorderSettings);
            _recorder = new VideoRecorder(videoRecorderSettings, r =>
            {
                var testName = TestContext.CurrentContext.Test.ClassName + "." + (_testMethodName ?? "[SetUp]");
                var img = CaptureImage();
                img.ApplyOverlays(new InfoOverlay(img)
                {
                    RecordTimeSpan = r.RecordTimeSpan,
                    OverlayStringFormat = @"{rt:hh\:mm\:ss\.fff} / {name} / CPU: {cpu} / RAM: {mem.p.used}/{mem.p.tot} ({mem.p.used.perc}) / " + testName
                }, new MouseOverlay(img));
                return img;
            });
            await Task.Delay(500);
        }

        /// <summary>
        /// Stops the video recorder.
        /// </summary>
        private void StopVideoRecorder()
        {
            if (_recorder != null)
            {
                _recorder.Stop();
                if (!KeepVideoForSuccessfulTests && TestContext.CurrentContext.Result.FailCount == 0)
                {
                    File.Delete(_recorder.TargetVideoPath);
                }
                _recorder.Dispose();
                _recorder = null;
            }
        }

        /// <summary>
        /// Takes a screen shot.
        /// </summary>
        private void TakeScreenShot(string testName)
        {
            var imagePath = CreateScreenShotPath(testName);
            try
            {
                Directory.CreateDirectory(TestsMediaPath);
                CaptureImage().ToFile(imagePath);
            }
            catch (Exception ex)
            {
                Logger.Default.Warn("Failed to save screen shot to directory: {0}, filename: {1}, Ex: {2}", TestsMediaPath, imagePath, ex);
            }
        }

        /// <summary>
        /// Replaces all invalid characters with underlines.
        /// </summary>
        private string SanitizeFileName(string fileName)
        {
            fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
            return fileName;
        }
        
        /// <summary>
        /// Generates full path for screenshot.
        /// </summary>
        private string CreateScreenShotPath(string testName)
        {
            var imageName = SanitizeFileName(testName) + ".png";
            imageName = imageName.Replace("\"", String.Empty);
            return Path.Combine(TestsMediaPath, imageName);
        }
    }
}
