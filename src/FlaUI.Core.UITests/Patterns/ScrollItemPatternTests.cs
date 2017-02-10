using FlaUI.Core.AutomationElements.Infrastructure;
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
            var tabItem = tab.SelectTabItem(1);
            _grid = tabItem.FindFirstDescendant(cf => cf.ByAutomationId("LargeListView"));
        }

        [Test]
        public void Test()
        {
            var grid = _grid;
            Assert.That(grid, Is.Not.Null);
            var gridPattern = _grid.PatternFactory.GetGridPattern();
            Assert.That(gridPattern, Is.Not.Null);
            Assert.That(gridPattern.Current.ColumnCount, Is.EqualTo(2));
            Assert.That(gridPattern.Current.RowCount, Is.EqualTo(7));
            ItemRealizer.RealizeItems(grid);
            var items = grid.AsGrid().Rows;
            Assert.That(items, Has.Length.EqualTo(gridPattern.Current.RowCount));
            var scrollPattern = grid.PatternFactory.GetScrollPattern();
            Assert.That(scrollPattern, Is.Not.Null);
            Assert.That(scrollPattern.Current.VerticalScrollPercent, Is.EqualTo(0));
            foreach (var item in items)
            {
                var scrollItemPattern = item.PatternFactory.GetScrollItemPattern();
                Assert.That(scrollItemPattern, Is.Not.Null);
                item.ScrollIntoView();
            }
            Assert.That(scrollPattern.Current.VerticalScrollPercent, Is.GreaterThan(0));
        }
    }
}
