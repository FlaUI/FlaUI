using NUnit.Framework;
using OpenQA.Selenium.Remote;
using FlaUI.WebDriver.UITests.TestUtil;
using OpenQA.Selenium;
using System;

namespace FlaUI.WebDriver.UITests
{
    [TestFixture]
    public class SessionTests
    {
        [Test]
        public void NewSession_CapabilitiesDoNotMatch_ReturnsError()
        {
            var emptyOptions = FlaUIDriverOptions.Empty();

            var newSession = () => new RemoteWebDriver(WebDriverFixture.WebDriverUrl, emptyOptions);

            Assert.That(newSession, Throws.TypeOf<InvalidOperationException>().With.Message.EqualTo("Required capabilities did not match. Capability `platformName` with value `windows` is required (SessionNotCreated)"));
        }

        [Test]
        public void NewSession_App_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var title = driver.Title;

            Assert.That(title, Is.EqualTo("FlaUI WPF Test App"));
        }

        [Test]
        public void NewSession_AppNotExists_ReturnsError()
        {
            var driverOptions = FlaUIDriverOptions.App("C:\\NotExisting.exe");

            var newSession = () => new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            Assert.That(newSession, Throws.TypeOf<WebDriverArgumentException>().With.Message.EqualTo("Starting app 'C:\\NotExisting.exe' with arguments '' threw an exception: An error occurred trying to start process 'C:\\NotExisting.exe' with working directory '.'. The system cannot find the file specified."));
        }

        [Test]
        public void NewSession_AppTopLevelWindow_IsSupported()
        {
            using var testAppProcess = new TestAppProcess();
            var windowHandle = string.Format("0x{0:x}", testAppProcess.Process.MainWindowHandle);
            var driverOptions = FlaUIDriverOptions.AppTopLevelWindow(windowHandle);
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var title = driver.Title;

            Assert.That(title, Is.EqualTo("FlaUI WPF Test App"));
        }

        [Test]
        public void NewSession_AppTopLevelWindowNotFound_ReturnsError()
        {
            using var testAppProcess = new TestAppProcess();
            var windowHandle = string.Format("0x{0:x}", testAppProcess.Process.MainWindowHandle);
            var driverOptions = FlaUIDriverOptions.AppTopLevelWindow(windowHandle);
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var title = driver.Title;

            Assert.That(title, Is.EqualTo("FlaUI WPF Test App"));
        }

        [Test]
        public void NewSession_AppTopLevelWindowZero_ReturnsError()
        {
            var driverOptions = FlaUIDriverOptions.AppTopLevelWindow("0x0");

            var newSession = () => new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            Assert.That(newSession, Throws.TypeOf<WebDriverArgumentException>().With.Message.EqualTo("Capability appium:appTopLevelWindow '0x0' should not be zero"));
        }

        [TestCase("FlaUI WPF Test App")]
        [TestCase("FlaUI WPF .*")]
        public void NewSession_AppTopLevelWindowTitleMatch_IsSupported(string match)
        {
            using var testAppProcess = new TestAppProcess();
            var driverOptions = FlaUIDriverOptions.AppTopLevelWindowTitleMatch(match);
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var title = driver.Title;

            Assert.That(title, Is.EqualTo("FlaUI WPF Test App"));
        }

        [Test]
        public void NewSession_MultipleMatchingAppTopLevelWindowTitleMatch_ReturnsError()
        {
            using var testAppProcess = new TestAppProcess();
            using var testAppProcess1 = new TestAppProcess();
            var driverOptions = FlaUIDriverOptions.AppTopLevelWindowTitleMatch("FlaUI WPF Test App");
            
            var newSession = () => new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            Assert.That(newSession, Throws.TypeOf<WebDriverArgumentException>().With.Message.EqualTo("Found multiple (2) processes with main window title matching 'FlaUI WPF Test App'"));
        }

        [Test]
        public void NewSession_AppTopLevelWindowTitleMatchNotFound_ReturnsError()
        {
            using var testAppProcess = new TestAppProcess();
            using var testAppProcess1 = new TestAppProcess();
            var driverOptions = FlaUIDriverOptions.AppTopLevelWindowTitleMatch("FlaUI Not Existing");

            var newSession = () => new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            Assert.That(newSession, Throws.TypeOf<WebDriverArgumentException>().With.Message.EqualTo("Process with main window title matching 'FlaUI Not Existing' could not be found"));
        }

        [TestCase("")]
        [TestCase("FlaUI")]
        public void NewSession_AppTopLevelWindowInvalidFormat_ReturnsError(string appTopLevelWindowString)
        {
            var driverOptions = FlaUIDriverOptions.AppTopLevelWindow(appTopLevelWindowString);

            var newSession = () => new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            Assert.That(newSession, Throws.TypeOf<WebDriverArgumentException>().With.Message.EqualTo($"Capability appium:appTopLevelWindow '{appTopLevelWindowString}' is not a valid hexadecimal string"));
        }

        [Test]
        public void GetTitle_Default_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var title = driver.Title;

            Assert.That(title, Is.EqualTo("FlaUI WPF Test App"));
        }
    }
}
