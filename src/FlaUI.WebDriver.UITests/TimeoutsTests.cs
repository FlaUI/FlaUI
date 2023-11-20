using FlaUI.WebDriver.UITests.TestUtil;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;

namespace FlaUI.WebDriver.UITests
{
    [TestFixture]
    public class TimeoutsTests
    {
        [Test]
        public void SetTimeouts_Default_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.RootApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            Assert.That(driver.Manage().Timeouts().ImplicitWait, Is.EqualTo(TimeSpan.FromSeconds(3)));
        }

        [Test]
        public void GetTimeouts_Default_ReturnsDefaultTimeouts()
        {
            var driverOptions = FlaUIDriverOptions.RootApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var timeouts = driver.Manage().Timeouts();

            Assert.That(timeouts.ImplicitWait, Is.EqualTo(TimeSpan.Zero));
            Assert.That(timeouts.PageLoad, Is.EqualTo(TimeSpan.FromMilliseconds(300000)));
            Assert.That(timeouts.AsynchronousJavaScript, Is.EqualTo(TimeSpan.FromMilliseconds(30000)));
        }
    }
}
