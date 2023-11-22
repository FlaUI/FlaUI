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
        public void GetWindowHandle_Default_ReturnsStableValue()
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
        public void Close_Default_ClosesTopMostWindow()
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
            Assert.That(currentWindowHandle, Throws.Exception.TypeOf<WebDriverException>());        }

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

        private static void OpenAnotherWindow(RemoteWebDriver driver)
        {
            driver.FindElement(ExtendedBy.NonCssName("_File")).Click();
            driver.FindElement(ExtendedBy.NonCssName("Open Window 1")).Click();
        }
    }
}
