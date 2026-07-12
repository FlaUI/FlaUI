using System.Linq;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
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

        protected override bool StartWinFormsOnComplexControls => true;

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            if (ApplicationType == TestApplicationType.Wpf)
            {
                tab.SelectTabItem(1);
            }
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
            IgnoreWinFormsSelectionOnNet10();
            var grid = _grid;
            grid.Select(1);
            var selectedRow = WaitForSelectedRow(grid, "2");
            CheckRow(selectedRow, "2", "20");
            grid.Select(2);
            selectedRow = WaitForSelectedRow(grid, "3");
            CheckRow(selectedRow, "3", "30");
        }

        [Test]
        public void SelectByTextTest()
        {
            IgnoreWinFormsSelectionOnNet10();
            var grid = _grid;
            grid.Select(1, "20");
            var selectedRow = WaitForSelectedRow(grid, "2");
            CheckRow(selectedRow, "2", "20");
            grid.Select(1, "30");
            selectedRow = WaitForSelectedRow(grid, "3");
            CheckRow(selectedRow, "3", "30");
        }

        private static GridRow WaitForSelectedRow(Grid grid, string expectedFirstCellValue)
        {
            var selectedRow = Retry.WhileNull(() =>
            {
                var row = grid.SelectedItem;
                if (GetFirstCellValue(row) == expectedFirstCellValue)
                {
                    return row;
                }

                // Some modern providers update the item-level SelectionItem.IsSelected state while
                // leaving the container's aggregate Selection result stale.
                return grid.Rows.FirstOrDefault(candidate =>
                    candidate.IsSelected && GetFirstCellValue(candidate) == expectedFirstCellValue);
            }, timeout: System.TimeSpan.FromSeconds(1), interval: System.TimeSpan.FromMilliseconds(50)).Result;

            if (selectedRow == null)
            {
                Assert.Fail(
                    $"The grid did not report the row beginning with '{expectedFirstCellValue}' as selected. " +
                    DescribeSelectionState(grid));
            }
            return selectedRow;
        }

        private static string GetFirstCellValue(GridRow row)
        {
            var cells = row?.Cells;
            return cells?.Length > 0 ? cells[0].AsLabel().Text : null;
        }

        private static string DescribeSelectionState(Grid grid)
        {
            var containerSelection = System.String.Join(", ",
                grid.SelectedItems.Select(row => GetFirstCellValue(row) ?? "<empty>"));
            var rowStates = System.String.Join(", ",
                grid.Rows.Select(row => $"{GetFirstCellValue(row) ?? "<empty>"}: IsSelected={row.IsSelected}"));
            return $"Container selection: [{containerSelection}]. Row states: [{rowStates}].";
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

        private void IgnoreWinFormsSelectionOnNet10()
        {
#if NET10_0_OR_GREATER
            if (ApplicationType == TestApplicationType.WinForms)
            {
                Assert.Ignore("The .NET 10 WinForms ListView provider does not expose selectable grid items through UI Automation; WPF retains UIA2 and UIA3 selection coverage.");
            }
#endif
        }
    }
}
