using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    // Broken in newer .NET Versions
    //[TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
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
            RestartApplication();
            var window = Application.GetMainWindow(Automation);
            var btn = window.FindFirstDescendant(cf => cf.ByName("ContextMenu")).AsButton();
            Mouse.Click(btn.GetClickablePoint(), MouseButton.Right);
            Wait.UntilInputIsProcessed();
            var ctxMenu = window.ContextMenu;
            Assert.That(ctxMenu, Is.Not.Null);
            var subMenuLevel1 = ctxMenu.Items;
            Assert.That(subMenuLevel1, Has.Length.EqualTo(2));
            var subMenuLevel2 = subMenuLevel1[1].Items;
            Assert.That(subMenuLevel2, Has.Length.EqualTo(1));
            var innerItem = subMenuLevel2[0];
            Assert.That(innerItem.Text, Is.EqualTo("Inner Context"));
        }
    }
}
