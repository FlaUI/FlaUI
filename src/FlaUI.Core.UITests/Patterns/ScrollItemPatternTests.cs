using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
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
            var mainWindow = App.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(1);
            _grid = tab.FindFirstDescendant(cf => cf.ByAutomationId("LargeListView"));
        }

        [Test]
        public void Test()
        {
            var grid = _grid;
            Assert.That(grid, Is.Not.Null);
            var gridPattern = _grid.Patterns.Grid.Pattern;
            Assert.That(gridPattern, Is.Not.Null);
            Assert.That(gridPattern.ColumnCount.Value, Is.EqualTo(2));
            Assert.That(gridPattern.RowCount.Value, Is.EqualTo(7));
            ItemRealizer.RealizeItems(grid);
            var items = grid.AsGrid().Rows;
            Assert.That(items, Has.Length.EqualTo(gridPattern.RowCount.Value));
            var scrollPattern = grid.Patterns.Scroll.Pattern;
            Assert.That(scrollPattern, Is.Not.Null);
            Assert.That(scrollPattern.VerticalScrollPercent.Value, Is.EqualTo(0));
            foreach (var item in items)
            {
                var scrollItemPattern = item.Patterns.ScrollItem.Pattern;
                Assert.That(scrollItemPattern, Is.Not.Null);
                item.ScrollIntoView();
            }
            Assert.That(scrollPattern.VerticalScrollPercent.Value, Is.GreaterThan(0));
        }
    }
}
