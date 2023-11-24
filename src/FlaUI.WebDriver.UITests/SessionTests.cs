using FlaUI.WebDriver.UITests.TestUtil;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace FlaUI.WebDriver.UITests
{
    [TestFixture]
    public class SessionTests
    {
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
