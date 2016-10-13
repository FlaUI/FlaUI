using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class WindowTests : UITestBase
    {
        public WindowTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void ContextMenuTest()
        {
            RestartApp();
            var window = App.GetMainWindow(Automation);
            var btn = window.FindFirst(TreeScope.Descendants, Automation.ConditionFactory.ByName("ContextMenu")).AsButton();
            Mouse.Instance.Click(MouseButton.Right, btn.GetClickablePoint());
            Helpers.WaitUntilInputIsProcessed();
            var ctxMenu = window.ContextMenu;
            Assert.That(ctxMenu, Is.Not.Null);
            var subMenuLevel1 = ctxMenu.MenuItems;
            Assert.That(subMenuLevel1, Has.Length.EqualTo(2));
            var subMenuLevel2 = subMenuLevel1[1].SubMenuItems;
            Assert.That(subMenuLevel2, Has.Length.EqualTo(1));
            var innerItem = subMenuLevel2[0];
            Assert.That(innerItem.Text, Is.EqualTo("Inner Context"));
        }
    }
}
