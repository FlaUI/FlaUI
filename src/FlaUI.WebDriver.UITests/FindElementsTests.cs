using FlaUI.WebDriver.UITests.TestUtil;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace FlaUI.WebDriver.UITests
{
    public class FindElementsTests
    {
        [Test]
        public void FindElement_ByAccessibilityId_ReturnsElement()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var element = driver.FindElement(ExtendedBy.AccessibilityId("TextBox"));

            Assert.That(element, Is.Not.Null);
        }

        [Test]
        public void FindElement_ByName_ReturnsElement()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var element = driver.FindElement(ExtendedBy.NonCssName("Test Label"));

            Assert.That(element, Is.Not.Null);
        }

        [Test]
        public void FindElement_ByClassName_ReturnsElement()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var element = driver.FindElement(ExtendedBy.NonCssClassName("TextBlock"));

            Assert.That(element, Is.Not.Null);
        }

        [Test]
        public void FindElement_ByLinkText_ReturnsElement()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var element = driver.FindElement(By.LinkText("Invoke me!"));

            Assert.That(element, Is.Not.Null);
        }

        [Test]
        public void FindElement_ByPartialLinkText_ReturnsElement()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var element = driver.FindElement(By.PartialLinkText("Invoke"));

            Assert.That(element, Is.Not.Null);
        }

        [Test]
        public void FindElement_ByTagName_ReturnsElement()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var element = driver.FindElement(By.TagName("Text"));

            Assert.That(element, Is.Not.Null);
        }

        [Test]
        public void FindElement_NotExisting_TimesOut()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

            var findElement = () => driver.FindElement(ExtendedBy.AccessibilityId("NotExisting"));

            Assert.That(findElement, Throws.Exception.TypeOf<NoSuchElementException>());
        }


        [Test]
        public void FindElements_Default_ReturnsElements()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var elements = driver.FindElements(By.TagName("RadioButton"));

            Assert.That(elements, Has.Count.EqualTo(2));
        }

        [Test]
        public void FindElements_NotExisting_TimesOut()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

            var findElements = () => driver.FindElements(ExtendedBy.AccessibilityId("NotExisting"));

            Assert.That(findElements, Throws.Exception.TypeOf<NoSuchElementException>());
        }
    }
}
