using FlaUI.WebDriver.UITests.TestUtil;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace FlaUI.WebDriver.UITests
{
    [TestFixture]
    public class ElementTests
    {
        [Test]
        public void GetText_Text_ReturnsRenderedText()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("lblMenuChk"));

            var text = element.Text;

            Assert.That(text, Is.EqualTo("Menu Item Checked"));
        }

        [Test]
        public void GetText_TextBox_ReturnsTextBoxText()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("TextBox"));

            var text = element.Text;
            
            Assert.That(text, Is.EqualTo("Test TextBox"));
        }

        [Test]
        public void GetText_Button_ReturnsButtonText()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("InvokableButton"));

            var text = element.Text;

            Assert.That(text, Is.EqualTo("Invoke me!"));
        }

        [Test]
        public void Selected_NotCheckedCheckbox_ReturnsFalse()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("SimpleCheckBox"));

            var selected = element.Selected;

            Assert.That(selected, Is.False);
        }

        [Test]
        public void Selected_CheckedCheckbox_ReturnsTrue()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("SimpleCheckBox"));
            element.Click();

            var selected = element.Selected;

            Assert.That(selected, Is.True);
        }

        [Test]
        public void Selected_NotCheckedRadioButton_ReturnsFalse()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("RadioButton1"));

            var selected = element.Selected;

            Assert.That(selected, Is.False);
        }

        [Test]
        public void Selected_CheckedRadioButton_ReturnsTrue()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("RadioButton1"));
            element.Click();

            var selected = element.Selected;

            Assert.That(selected, Is.True);
        }

        [Test]
        public void SendKeys_Default_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("TextBox"));

            element.SendKeys("Hello World!");

            Assert.That(element.Text, Is.EqualTo("Hello World!"));
        }

        [Test]
        public void Clear_Default_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("TextBox"));

            element.Clear();

            Assert.That(element.Text, Is.EqualTo(""));
        }

        [Test]
        public void Click_Default_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("InvokableButton"));

            element.Click();

            Assert.That(element.Text, Is.EqualTo("Invoked!"));
        }

        [Test]
        public void ActiveElement_Default_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);
            var element = driver.FindElement(ExtendedBy.AccessibilityId("InvokableButton"));
            element.Click();

            var activeElement = driver.SwitchTo().ActiveElement();

            Assert.That(activeElement.Text, Is.EqualTo("Invoked!"));
        }
    }
}
