using FlaUI.WebDriver.UITests.TestUtil;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace FlaUI.WebDriver.UITests
{
    [TestFixture]
    public class WindowTests
    {
        [Test]
        public void Close_Default_IsSupported()
        {
            var driverOptions = FlaUIDriverOptions.TestApp();
            using var driver = new RemoteWebDriver(WebDriverFixture.WebDriverUrl, driverOptions);

            var closeWindow = () => driver.Close();

            Assert.That(closeWindow, Throws.Nothing);
        }
    }
}
