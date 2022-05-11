using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
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
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            var tabItem = tab.SelectTabItem(1);
            _dataGrid = tabItem.FindFirstDescendant(cf => cf.ByAutomationId("dataGridView"));
        }

        [Test]
        public void GridTest()
        {
            var dataGrid = _dataGrid;
            dataGrid.Should().NotBeNull();
            var gridPattern = dataGrid.Patterns.Grid.Pattern;
            gridPattern.Should().NotBeNull();
            gridPattern.ColumnCount.Value.Should().Be(3);
            gridPattern.RowCount.Value.Should().Be(3);
            var item = gridPattern.GetItem(1, 1);
            item.Properties.Name.Value.Should().Be("24");
        }
    }
}
