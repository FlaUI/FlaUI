using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class CacheTests : UITestBase
    {
        private Grid _grid;

        public CacheTests(AutomationType automationType, TestApplicationType appType)
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
        public void RowsAndCellsTest()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.TreeScope = TreeScope.Descendants;
            cacheRequest.Add(Automation.PropertyLibrary.Element.Name);
            using (cacheRequest.Activate())
            {
                var rows = _grid.Rows;
                Assert.That(rows, Has.Length.EqualTo(3));
                CheckRow(rows[0], "1", "10");
                CheckRow(rows[1], "2", "20");
                CheckRow(rows[2], "3", "30");
            }
        }

        private void CheckRow(GridRow gridRow, string cell1Value, string cell2Value)
        {
            var cells = gridRow.CachedChildren;
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
