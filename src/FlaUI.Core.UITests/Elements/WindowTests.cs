using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
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
            RestartApplication();
            var window = Application.GetMainWindow(Automation);
            var btn = window.FindFirstDescendant(cf => cf.ByName("ContextMenu")).AsButton();
            Mouse.Click(btn.GetClickablePoint(), MouseButton.Right);
            Wait.UntilInputIsProcessed();
            var ctxMenu = window.ContextMenu;
            ctxMenu.Should().NotBeNull();
            var subMenuLevel1 = ctxMenu.Items;
            subMenuLevel1.Should().HaveCount(2);
            var subMenuLevel2 = subMenuLevel1[1].Items;
            subMenuLevel2.Should().HaveCount(1);
            var innerItem = subMenuLevel2[0];
            innerItem.Text.Should().Be("Inner Context");
        }
    }
}
