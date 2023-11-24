using OpenQA.Selenium;

namespace FlaUI.WebDriver.UITests.TestUtil
{
    internal class ExtendedBy : By
    {
        public ExtendedBy(string mechanism, string criteria) : base(mechanism, criteria)
        {
        }

        public static ExtendedBy AccessibilityId(string accessibilityId) => new ExtendedBy("accessibility id", accessibilityId);

        public static ExtendedBy NonCssName(string name) => new ExtendedBy("name", name);

        public static ExtendedBy NonCssClassName(string name) => new ExtendedBy("class name", name);
    }
}
