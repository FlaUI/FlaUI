using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class ListViewTests : UITestBase
    {
        private ListView _listView;

        public ListViewTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = App.GetMainWindow(Automation);
            var tab = mainWindow.FindFirst(TreeScope.Descendants, mainWindow.ConditionFactory.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(1);
            var listView = mainWindow.FindFirst(TreeScope.Descendants, mainWindow.ConditionFactory.ByAutomationId("listView1")).AsListView();
            _listView = listView;
        }

        [Test]
        public void GridPatternTest()
        {
            var listView = _listView;
            Assert.That(listView.ColumnCount, Is.EqualTo(2));
            Assert.That(listView.RowCount, Is.EqualTo(3));
        }

        [Test]
        public void HeaderAndColumnsTest()
        {
            var listView = _listView;
            var header = listView.Header;
            var columns = header.Columns;
            Assert.That(header, Is.Not.Null);
            Assert.That(columns, Has.Length.EqualTo(2));
            Assert.That(columns[0].Text, Is.EqualTo("Key"));
            Assert.That(columns[1].Text, Is.EqualTo("Value"));
        }

        [Test]
        public void RowsAndCellsTest()
        {
            var listView = _listView;
            var rows = listView.Rows;
            Assert.That(rows, Has.Length.EqualTo(3));
            CheckRow(rows[0], "1", "10");
            CheckRow(rows[1], "2", "20");
            CheckRow(rows[2], "3", "30");
        }

        private void CheckRow(ListViewRow listViewRow, string cell1Value, string cell2Value)
        {
            var cells = listViewRow.Cells;
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
