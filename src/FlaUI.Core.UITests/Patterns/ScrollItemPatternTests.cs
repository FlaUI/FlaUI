using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Patterns
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class ScrollItemPatternTests : UITestBase
    {
        private AutomationElement _grid;
        public ScrollItemPatternTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(1);
            _grid = tab.FindFirstDescendant(cf => cf.ByAutomationId("LargeListView"));
        }

        [Test]
        public void Test()
        {
            var grid = _grid;
            grid.Should().NotBeNull();
            var gridPattern = _grid.Patterns.Grid.Pattern;
            gridPattern.Should().NotBeNull();
            gridPattern.ColumnCount.Value.Should().Be(2);
            gridPattern.RowCount.Value.Should().Be(7);
            ItemRealizer.RealizeItems(grid);
            var items = grid.AsGrid().Rows;
            items.Should().HaveCount(gridPattern.RowCount.Value);
            var scrollPattern = grid.Patterns.Scroll.Pattern;
            scrollPattern.Should().NotBeNull();
            scrollPattern.VerticalScrollPercent.Value.Should().Be(0);
            foreach (var item in items)
            {
                var scrollItemPattern = item.Patterns.ScrollItem.Pattern;
                scrollItemPattern.Should().NotBeNull();
                item.ScrollIntoView();
            }
            scrollPattern.VerticalScrollPercent.Value.Should().BeGreaterThan(0);
        }
    }
}
