using FlaUI.WebDriver.UITests.TestUtil;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Linq;

namespace FlaUI.WebDriver.UITests
{
    [TestFixture]
    public class WindowTests
    {
        [Test]
        public void GetWindowRect_Default_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var position = driver.Manage().Window.Position;
            var size = driver.Manage().Window.Size;

            Assert.That(position.X, Is.GreaterThanOrEqualTo(0));
            Assert.That(position.Y, Is.GreaterThanOrEqualTo(0));
            Assert.That(size.Width, Is.EqualTo(629));
            Assert.That(size.Height, Is.EqualTo(516));
        }

        [Test]
        public void SetWindowRect_Position_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            driver.Manage().Window.Position = new System.Drawing.Point(100, 100);

            var newPosition = driver.Manage().Window.Position;
            Assert.That(newPosition.X, Is.EqualTo(100));
            Assert.That(newPosition.Y, Is.EqualTo(100));
        }

        [Test]
        public void SetWindowRect_Size_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            driver.Manage().Window.Size = new System.Drawing.Size(650, 650);

            var newSize = driver.Manage().Window.Size;
            Assert.That(newSize.Width, Is.EqualTo(650));
            Assert.That(newSize.Height, Is.EqualTo(650));
        }

        [Test]
        public void GetWindowHandle_AppOpensNewWindow_DoesNotSwitchToNewWindow()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var initialWindowHandle = driver.CurrentWindowHandle;
            OpenAnotherWindow(driver);

            var windowHandleAfterOpenCloseOtherWindow = driver.CurrentWindowHandle;

            Assert.That(windowHandleAfterOpenCloseOtherWindow, Is.EqualTo(initialWindowHandle));
        }

        [Test, Ignore("https://github.com/FlaUI/FlaUI/issues/596")]
        public void GetWindowHandle_WindowClosed_ReturnsNoSuchWindow()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            OpenAndSwitchToNewWindow(driver);
            driver.Close();

            var getWindowHandle = () => driver.CurrentWindowHandle;

            Assert.That(getWindowHandle, Throws.TypeOf<NoSuchWindowException>());
        }

        [Test, Ignore("https://github.com/FlaUI/FlaUI/issues/596")]
        public void GetWindowHandles_Default_ReturnsUniqueHandlePerWindow()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var initialWindowHandle = driver.CurrentWindowHandle;
            OpenAnotherWindow(driver);

            var windowHandles = driver.WindowHandles;

            Assert.That(windowHandles, Has.Count.EqualTo(2));
            Assert.That(windowHandles[1], Is.Not.EqualTo(windowHandles[0]));
        }

        [Test]
        public void Close_Default_DoesNotChangeWindowHandle()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var initialWindowHandle = driver.CurrentWindowHandle;
            OpenAnotherWindow(driver);

            driver.Close();

            var windowHandleAfterOpenCloseOtherWindow = driver.CurrentWindowHandle;
            Assert.That(windowHandleAfterOpenCloseOtherWindow, Is.EqualTo(initialWindowHandle));
        }

        [Test]
        public void Close_LastWindow_EndsSession()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            driver.Close();

            var currentWindowHandle = () => driver.CurrentWindowHandle;
            Assert.That(currentWindowHandle, Throws.Exception.TypeOf<WebDriverException>());        
        }

        [Test]
        public void SwitchWindow_Default_SwitchesToWindow()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var initialWindowHandle = driver.CurrentWindowHandle;
            OpenAnotherWindow(driver);
            var newWindowHandle = driver.WindowHandles.Except(new[] { initialWindowHandle }).Single();

            driver.SwitchTo().Window(newWindowHandle);

            Assert.That(driver.CurrentWindowHandle, Is.EqualTo(newWindowHandle));
        }

        [Test]
        public void SwitchWindow_Default_MovesWindowToForeground()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var initialWindowHandle = driver.CurrentWindowHandle;
            OpenAnotherWindow(driver);

            driver.SwitchTo().Window(initialWindowHandle);

            // We assert that it is in the foreground by checking if a button can be clicked without an error
            var element = driver.FindElement(ExtendedBy.AccessibilityId("InvokableButton"));
            element.Click();
            Assert.That(element.Text, Is.EqualTo("Invoked!"));
        }

        private static void OpenAndSwitchToNewWindow(RemoteWebDriver driver)
        {
            var initialWindowHandle = driver.CurrentWindowHandle;
            OpenAnotherWindow(driver);
            var newWindowHandle = driver.WindowHandles.Except(new[] { initialWindowHandle }).Single();
            driver.SwitchTo().Window(newWindowHandle);
        }

        private static void OpenAnotherWindow(RemoteWebDriver driver)
        {
            driver.FindElement(ExtendedBy.NonCssName("_File")).Click();
            driver.FindElement(ExtendedBy.NonCssName("Open Window 1")).Click();
        }
    }
}
