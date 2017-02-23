using System;
using System.Collections.Generic;
using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    public class Grid : AutomationElement
    {
        public Grid(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public IGridPattern GridPattern => PatternFactory.GetGridPattern();

        public ITablePattern TablePattern => PatternFactory.GetTablePattern();

        public int RowCount => GridPattern.RowCount;

        public int ColumnCount => GridPattern.ColumnCount;

        public AutomationElement[] ColumnHeaders => TablePattern.ColumnHeaders;

        public AutomationElement[] RowHeaders => TablePattern.RowHeaders;

        public RowOrColumnMajor RowOrColumnMajor => TablePattern.RowOrColumnMajor;

        public GridHeader Header
        {
            get
            {
                var header = FindFirstChild(cf => cf.ByControlType(ControlType.Header));
                return header.AsGridHeader();
            }
        }

        /// <summary>
        /// Returns the rows which are currently visible to UIA. Might not be the full list!
        /// Use <see cref="GetRowByIndex" /> to make sure to get the correct row.
        /// </summary>
        public GridRow[] Rows
        {
            get
            {
                var rows = FindAllChildren(cf => cf.ByControlType(ControlType.DataItem).Or(cf.ByControlType(ControlType.ListItem)));
                return rows.Select(x => x.AsGridRow()).ToArray();
            }
        }

        public GridRow Select(int rowIndex)
        {
            var gridRow = GetRowByIndex(rowIndex);
            gridRow.Select();
            return gridRow;
        }

        public GridRow AddToSelection(int rowIndex)
        {
            var gridRow = GetRowByIndex(rowIndex);
            gridRow.AddToSelection();
            return gridRow;
        }

        public GridRow RemoveFromSelection(int rowIndex)
        {
            var gridRow = GetRowByIndex(rowIndex);
            gridRow.RemoveFromSelection();
            return gridRow;
        }

        public GridRow GetRowByIndex(int rowIndex)
        {
            PreCheckRow(rowIndex);
            var gridCell = GridPattern.GetItem(rowIndex, 0).AsGridCell();
            return gridCell.ContainingRow;
        }

        public GridRow GetRowByValue(int columnIndex, string value)
        {
            return GetRowsByValue(columnIndex, value, 1).FirstOrDefault();
        }

        /// <summary>
        /// Get all rows where the value of the given column matches the given value
        /// </summary>
        /// <param name="columnIndex">The column index to check</param>
        /// <param name="value">The value to check</param>
        /// <param name="maxItems">Maximum numbers of items to return, 0 for all</param>
        /// <returns>List of found rows</returns>
        public GridRow[] GetRowsByValue(int columnIndex, string value, int maxItems = 0)
        {
            PreCheckColumn(columnIndex);
            var gridPattern = GridPattern;
            var returnList = new List<GridRow>();
            for (var rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                var currentCell = gridPattern.GetItem(rowIndex, columnIndex).AsGridCell();
                if (currentCell.Value == value)
                {
                    returnList.Add(currentCell.ContainingRow);
                    if (maxItems > 0 && returnList.Count >= maxItems)
                    {
                        break;
                    }
                }
            }
            return returnList.ToArray();
        }

        private void PreCheckRow(int rowIndex)
        {
            if (RowCount <= rowIndex)
            {
                throw new Exception($"Grid contains only {RowCount} row(s) but index {rowIndex} was requested");
            }
        }

        private void PreCheckColumn(int columnIndex)
        {
            if (ColumnCount <= columnIndex)
            {
                throw new Exception($"Grid contains only {ColumnCount} columns(s) but index {columnIndex} was requested");
            }
        }
    }

    public class GridHeader : AutomationElement
    {
        public GridHeader(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public GridHeaderItem[] Columns
        {
            get
            {
                var headerItems = FindAllChildren(cf => cf.ByControlType(ControlType.HeaderItem));
                return headerItems.Select(x => x.AsGridHeaderItem()).ToArray();
            }
        }
    }

    public class GridHeaderItem : AutomationElement
    {
        public GridHeaderItem(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public string Text => Info.Name;
    }

    public class GridRow : SelectionItemAutomationElement
    {
        public GridRow(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public IScrollItemPattern ScrollItemPattern => PatternFactory.GetScrollItemPattern();

        public GridCell[] Cells
        {
            get
            {
                var cells = FindAllChildren(cf => cf.ByControlType(ControlType.HeaderItem).Not());
                return cells.Select(x => x.AsGridCell()).ToArray();
            }
        }

        public GridHeaderItem Header
        {
            get
            {
                var headerItem = FindFirstChild(ConditionFactory.ByControlType(ControlType.HeaderItem));
                return headerItem.AsGridHeaderItem();
            }
        }

        public GridRow ScrollIntoView()
        {
            ScrollItemPattern?.ScrollIntoView();
            return this;
        }
    }

    public class GridCell : AutomationElement
    {
        public GridCell(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public IGridItemPattern GridItemPattern => PatternFactory.GetGridItemPattern();

        public ITableItemPattern TableItemPattern => PatternFactory.GetTableItemPattern();

        public IValuePattern ValuePattern => PatternFactory.GetValuePattern();

        public Grid ContainingGrid => GridItemPattern.ContainingGrid.AsGrid();

        public GridRow ContainingRow
        {
            get
            {
                // Get the parent of the cell (which should be the row)
                var rowElement = Automation.TreeWalkerFactory.GetControlViewWalker().GetParent(this);
                return rowElement.AsGridRow();
            }
        }

        public string Value
        {
            get { return ValuePattern.Value; }
            set { ValuePattern.SetValue(value); }
        }
    }
}