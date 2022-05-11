using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
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
    public class TabTests : UITestBase
    {
        public TabTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void TabSelectTest()
        {
            RestartApplication();
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            if (ApplicationType == TestApplicationType.Wpf)
            {
                tab.TabItems.Should().HaveCount(3);
            }
            else
            {
              tab.TabItems.Should().HaveCount(2);
            }
            tab.SelectedTabItemIndex.Should().Be(0);
            tab.SelectTabItem(1);
            Wait.UntilInputIsProcessed();
            tab.SelectedTabItemIndex.Should().Be(1);
            tab.SelectTabItem(0);
            Wait.UntilInputIsProcessed();
            tab.SelectedTabItemIndex.Should().Be(0);
        }
    }
}
