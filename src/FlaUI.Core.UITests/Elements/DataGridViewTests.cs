using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class DataGridViewTests : UITestBase
    {
        private DataGridView _dataGridView;

        public DataGridViewTests(AutomationType automationType, TestApplicationType appType)
                : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(1);
            _dataGridView = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("dataGridView")).AsDataGridView();
            _dataGridView.HasAddRow = true;
        }

        [Test]
        public void HeaderAndColumnsTest()
        {
            var dataGridView = _dataGridView;
            var header = dataGridView.Header;
            var columns = header.Columns;
            Assert.That(header, Is.Not.Null);
            Assert.That(columns, Has.Length.EqualTo(3));
            Assert.That(columns[0].Text, Is.EqualTo("Name"));
            Assert.That(columns[1].Text, Is.EqualTo("Number"));
            Assert.That(columns[2].Text, Is.EqualTo("IsChecked"));
        }

        [Test]
        public void RowsAndCellsTest()
        {
            var dataGridView = _dataGridView;
            var rows = dataGridView.Rows;
            Assert.That(rows, Has.Length.EqualTo(2));
            CheckRow(rows[0], "John", "12", "False");
            CheckRow(rows[1], "Doe", "24", "True");
        }

        private void CheckRow(DataGridViewRow dataGridViewRow, string cell1Value, string cell2Value, string cell3Value)
        {
            var cells = dataGridViewRow.Cells;
            Assert.That(cells, Has.Length.EqualTo(3));
            Assert.That(cells[0].Value, Is.EqualTo(cell1Value));
            Assert.That(cells[1].Value, Is.EqualTo(cell2Value));
            Assert.That(cells[2].Value, Is.EqualTo(cell3Value));
        }
    }
}
