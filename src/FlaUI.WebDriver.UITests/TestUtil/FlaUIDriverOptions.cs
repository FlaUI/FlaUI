using OpenQA.Selenium;
using System;

namespace FlaUI.WebDriver.UITests.TestUtil
{
    internal class FlaUIDriverOptions : DriverOptions
    {
        public const string TestAppPath = "..\\..\\..\\TestApplications\\WpfApplication\\bin\\WpfApplication.exe";

        public override ICapabilities ToCapabilities()
        {
            return GenerateDesiredCapabilities(true);
        }

        public static FlaUIDriverOptions TestApp() => App(TestAppPath);

        public static DriverOptions RootApp() => App("Root");

        public static FlaUIDriverOptions App(string path)
        {
            var options = new FlaUIDriverOptions()
            {
                PlatformName = "Windows"
            };
            options.AddAdditionalOption("appium:app", path);
            return options;
        }

    }
}
