using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
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
            header.Should().NotBeNull();
            columns.Should().HaveCount(3);
            columns[0].Text.Should().Be("Name");
            columns[1].Text.Should().Be("Number");
            columns[2].Text.Should().Be("IsChecked");
        }

        [Test]
        public void RowsAndCellsTest()
        {
            var dataGridView = _dataGridView;
            var rows = dataGridView.Rows;
            rows.Should().HaveCount(2);
            CheckRow(rows[0], "John", "12", "False");
            CheckRow(rows[1], "Doe", "24", "True");
        }

        private void CheckRow(DataGridViewRow dataGridViewRow, string cell1Value, string cell2Value, string cell3Value)
        {
            var cells = dataGridViewRow.Cells;
            cells.Should().HaveCount(3);
            cells[0].Value.Should().Be(cell1Value);
            cells[1].Value.Should().Be(cell2Value);
            cells[2].Value.Should().Be(cell3Value);
        }
    }
}
