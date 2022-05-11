using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class PopupTests : UITestBase
    {
        public PopupTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void CheckBoxInPopupTest()
        {
            var window = Application.GetMainWindow(Automation);
            var btn = window.FindFirstDescendant(cf => cf.ByAutomationId("PopupToggleButton1"));
            btn.Click();
            Wait.UntilInputIsProcessed();
            var popup = window.Popup;
            popup.Should().NotBeNull();
            var popupChildren = popup.FindAllChildren();
            popupChildren.Should().HaveCount(1);
            var check = popupChildren[0].AsCheckBox();
            check.Text.Should().Be("This is a popup");
        }

        [Test]
        public void MenuInPopupTest()
        {
            var window = Application.GetMainWindow(Automation);
            var btn = window.FindFirstDescendant(cf => cf.ByAutomationId("PopupToggleButton2"));
            btn.Click();
            Wait.UntilInputIsProcessed();
            var popup = window.Popup;
            popup.Should().NotBeNull();
            var popupChildren = popup.FindAllChildren();
            popupChildren.Should().HaveCount(1);
            var menu = popupChildren[0].AsMenu();
            menu.Items.Should().HaveCount(1);
            var menuItem = menu.Items[0];
            menuItem.Text.Should().Be("Some MenuItem");
        }
    }
}
