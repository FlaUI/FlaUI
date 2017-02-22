using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Patterns
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class GridPatternTests : UITestBase
    {
        private AutomationElement _dataGrid;

        public GridPatternTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = App.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            var tabItem = tab.SelectTabItem(1);
            _dataGrid = tabItem.FindFirstDescendant(cf => cf.ByAutomationId("dataGrid1"));
        }

        [Test]
        public void ExpanderTest()
        {
            var dataGrid = _dataGrid;
            Assert.That(dataGrid, Is.Not.Null);
            var gridPattern = dataGrid.PatternFactory.GetGridPattern();
            Assert.That(gridPattern, Is.Not.Null);
            Assert.That(gridPattern.Current.ColumnCount, Is.EqualTo(2));
            Assert.That(gridPattern.Current.RowCount, Is.EqualTo(3));
            var item = gridPattern.GetItem(1, 1);
            Assert.That(item.Information.Name, Is.EqualTo("Patrick"));
        }
    }
}
