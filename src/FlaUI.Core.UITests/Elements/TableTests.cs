using FlaUI.Core.AutomationElements;
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
    public class TableTests : UITestBase
    {
        private Grid _table;

        public TableTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = App.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(1);
            var table = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("listView1")).AsGrid();
            _table = table;
        }

        [Test]
        public void HeadersTest()
        {
            var table = _table;
            Assert.That(table.ColumnHeaders.Length, Is.EqualTo(2));
        }

        [Test]
        public void HeaderAndColumnsTest()
        {
            var table = _table;
            var header = table.Header;
            var columns = header.Columns;
            Assert.That(header, Is.Not.Null);
            Assert.That(columns, Has.Length.EqualTo(2));
            Assert.That(columns[0].Text, Is.EqualTo("Key"));
            Assert.That(columns[1].Text, Is.EqualTo("Value"));
        }

        [Test]
        public void RowsAndCellsTest()
        {
            var table = _table;
            var rows = table.Rows;
            Assert.That(rows, Has.Length.EqualTo(3));
            CheckRow(rows[0], "1", "10");
            CheckRow(rows[1], "2", "20");
            CheckRow(rows[2], "3", "30");
        }

        private void CheckRow(GridRow tableRow, string cell1Value, string cell2Value)
        {
            var cells = tableRow.Cells;
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
