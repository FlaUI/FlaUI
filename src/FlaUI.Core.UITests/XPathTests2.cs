using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class XPathTests2 : UITestBase
    {
        public XPathTests2(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void IsPassword()
        {
            RestartApplication();

            var window = Application.GetMainWindow(Automation);
            var passwordBox = window.FindFirstByXPath($"//*[@IsPassword=true()]");
            passwordBox.Should().NotBeNull();
        }
    }
}
