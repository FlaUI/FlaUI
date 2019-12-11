using System;
using System.IO;
using System.Threading.Tasks;
using FlaUI.Core.Capturing;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace FlaUI.Core.UITests.TestFramework
{
    public enum VideoRecordingMode
    {
        NoVideo,
        OnePerTest,
        OnePerFixture,
    }

    public enum ApplicationStartMode
    {
        OncePerTest,
        OncePerFixture
    }

    /// <summary>
    /// Base class for ui test with some helper methods.
    /// </summary>
    public abstract class UITestBase
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
        protected Application Application { get; private set; }

        /// <summary>
        /// Specifies the mode of the application to start.
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
        /// Path of the directory for the screenshots and videos for the tests.
        /// Defaults to c:\FailedTestsData.
        /// </summary>
        protected virtual string TestsMediaPath => @"c:\FailedTestsData";

        /// <summary>
        /// Gets the automation instance that should be used.
        /// </summary>
        protected abstract AutomationBase GetAutomation();

        /// <summary>
        /// Starts the application which should be tested.
        /// </summary>
        protected abstract Application StartApplication();

        [OneTimeSetUp]
        public async Task UITestBaseOneTimeSetUp()
        {
            Logger.Default = new NUnitProgressLogger();
            Automation = GetAutomation();
            if (VideoRecordingMode == VideoRecordingMode.OnePerFixture)
            {
                await StartVideoRecorder(TestContext.CurrentContext.Test.FullName);
            }

            if (ApplicationStartMode == ApplicationStartMode.OncePerFixture)
            {
                Application = StartApplication();
            }
        }

        [OneTimeTearDown]
        public async Task UITestBaseOneTimeTearDown()
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

        [SetUp]
        public async Task UITestBaseSetUp()
        {
            // Due to the recorder running in an own thread, it is necessary to save the current method name for that thread
            _testMethodName = TestContext.CurrentContext.Test.MethodName;

            if (VideoRecordingMode == VideoRecordingMode.OnePerTest)
            {
                await StartVideoRecorder(TestContext.CurrentContext.Test.FullName);
            }
            if (ApplicationStartMode == ApplicationStartMode.OncePerTest)
            {
                Application = StartApplication();
            }
        }

        [TearDown]
        public async Task UITestBaseTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                TakeScreenshot(TestContext.CurrentContext.Test.FullName);
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

        protected virtual async Task StartVideoRecorder(string videoName)
        {
            // Refresh all the system information
            SystemInfo.RefreshAll();
            // Download FFMpeg
            var ffmpegPath = await VideoRecorder.DownloadFFMpeg(@"C:\temp");
            // Start the recorder
            var videoRecorderSettings = new VideoRecorderSettings
            {
                VideoFormat = VideoFormat.xvid,
                VideoQuality = 6,
                ffmpegPath = ffmpegPath,
                TargetVideoPath = Path.Combine(TestsMediaPath, $"{SanitizeFileName(videoName)}.mp4")
            };
            _recorder = new VideoRecorder(videoRecorderSettings, r =>
            {
                var testName = TestContext.CurrentContext.Test.ClassName + "." + (_testMethodName ?? "[SetUp]");
                var img = Capture.MainScreen();
                img.ApplyOverlays(new InfoOverlay(img)
                {
                    RecordTimeSpan = r.RecordTimeSpan,
                    OverlayStringFormat = @"{rt:hh\:mm\:ss\.fff} / {name} / CPU: {cpu} / RAM: {mem.p.used}/{mem.p.tot} ({mem.p.used.perc}) / " + testName
                }, new MouseOverlay(img));
                return img;
            });
            await Task.Delay(500);
        }

        protected void StopVideoRecorder()
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

        private void TakeScreenshot(string testName)
        {
            var imageName = SanitizeFileName(testName) + ".png";
            imageName = imageName.Replace("\"", String.Empty);
            var imagePath = Path.Combine(TestsMediaPath, imageName);
            try
            {
                Directory.CreateDirectory(TestsMediaPath);
                Capture.Screen().ToFile(imagePath);
            }
            catch (Exception ex)
            {
                Logger.Default.Warn("Failed to save screenshot to directory: {0}, filename: {1}, Ex: {2}", TestsMediaPath, imagePath, ex);
            }
        }

        private string SanitizeFileName(string fileName)
        {
            fileName = String.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
            return fileName;
        }
    }
}
