using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class PopupTests : FlaUITestBase
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
            Assert.That(popup, Is.Not.Null);
            var popupChildren = popup.FindAllChildren();
            Assert.That(popupChildren, Has.Length.EqualTo(1));
            var check = popupChildren[0].AsCheckBox();
            Assert.That(check.Text, Is.EqualTo("This is a popup"));
        }

        [Test]
        public void MenuInPopupTest()
        {
            var window = Application.GetMainWindow(Automation);
            var btn = window.FindFirstDescendant(cf => cf.ByAutomationId("PopupToggleButton2"));
            btn.Click();
            Wait.UntilInputIsProcessed();
            var popup = window.Popup;
            Assert.That(popup, Is.Not.Null);
            var popupChildren = popup.FindAllChildren();
            Assert.That(popupChildren, Has.Length.EqualTo(1));
            var menu = popupChildren[0].AsMenu();
            Assert.That(menu.Items, Has.Length.EqualTo(1));
            var menuItem = menu.Items[0];
            Assert.That(menuItem.Text, Is.EqualTo("Some MenuItem"));
        }
    }
}
