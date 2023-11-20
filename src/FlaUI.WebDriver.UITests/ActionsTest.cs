using FlaUI.WebDriver.UITests.TestUtil;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace FlaUI.WebDriver.UITests
{
    [TestFixture]
    public class ActionsTests
    {
        [Test]
        public void PerformActions_KeyDownKeyUp_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("TextBox"));
            element.Click();

            new Actions(driver).KeyDown(Keys.Control).KeyDown(Keys.Backspace).KeyUp(Keys.Backspace).KeyUp(Keys.Control).Perform();

            Assert.That(driver.SwitchTo().ActiveElement().Text, Is.EqualTo("Test "));
        }

        [Test]
        public void ReleaseActions_Default_ReleasesKeys()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("TextBox"));
            element.Click();
            new Actions(driver).KeyDown(Keys.Control).Perform();

            driver.ResetInputState();

            new Actions(driver).KeyDown(Keys.Backspace).KeyUp(Keys.Backspace).Perform();
            Assert.That(driver.SwitchTo().ActiveElement().Text, Is.EqualTo("Test TextBo"));
        }
    }
}
