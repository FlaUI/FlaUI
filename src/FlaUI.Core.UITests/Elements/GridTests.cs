using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class GridTests : UITestBase
    {
        private Grid _grid;

        public GridTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(1);
            var grid = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("listView1")).AsGrid();
            _grid = grid;
        }

        [Test]
        public void GridPatternTest()
        {
            var grid = _grid;
            Assert.That(grid.ColumnCount, Is.EqualTo(2));
            Assert.That(grid.RowCount, Is.EqualTo(3));
        }

        [Test]
        public void HeaderAndColumnsTest()
        {
            var grid = _grid;
            var header = grid.Header;
            var columns = header.Columns;
            Assert.That(header, Is.Not.Null);
            Assert.That(columns, Has.Length.EqualTo(2));
            Assert.That(columns[0].Text, Is.EqualTo("Key"));
            Assert.That(columns[1].Text, Is.EqualTo("Value"));
        }

        [Test]
        public void RowsAndCellsTest()
        {
            var grid = _grid;
            var rows = grid.Rows;
            Assert.That(rows, Has.Length.EqualTo(3));
            CheckRow(rows[0], "1", "10");
            CheckRow(rows[1], "2", "20");
            CheckRow(rows[2], "3", "30");
        }

        [Test]
        public void SelectByIndexTest()
        {
            var grid = _grid;
            grid.Select(1);
            var selectedRow = grid.SelectedItem;
            CheckRow(selectedRow, "2", "20");
            grid.Select(2);
            selectedRow = grid.SelectedItem;
            CheckRow(selectedRow, "3", "30");
        }

        [Test]
        public void SelectByTextTest()
        {
            var grid = _grid;
            grid.Select(1, "20");
            var selectedRow = grid.SelectedItem;
            CheckRow(selectedRow, "2", "20");
            grid.Select(1, "30");
            selectedRow = grid.SelectedItem;
            CheckRow(selectedRow, "3", "30");
        }

        private void CheckRow(GridRow gridRow, string cell1Value, string cell2Value)
        {
            var cells = gridRow.Cells;
            Assert.That(cells, Has.Length.EqualTo(2));
            CheckCellValue(cells[0], cell1Value);
            CheckCellValue(cells[1], cell2Value);
        }

        private void CheckCellValue(AutomationElement cell, string cellValue)
        {
            var cellText = cell.AsLabel();
            Assert.That(cellText.Text, Is.EqualTo(cellValue));
        }
    }
}
