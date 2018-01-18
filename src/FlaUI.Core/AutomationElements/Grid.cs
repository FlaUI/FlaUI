using System;
using System.Collections.Generic;
using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Element for grids and tables.
    /// </summary>
    public class Grid : AutomationElement
    {
        public Grid(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        protected IGridPattern GridPattern => Patterns.Grid.Pattern;

        protected ITablePattern TablePattern => Patterns.Table.Pattern;

        protected ISelectionPattern SelectionPattern => Patterns.Selection.Pattern;

        /// <summary>
        /// Gets the total row count.
        /// </summary>
        public int RowCount => GridPattern.RowCount.Value;

        /// <summary>
        /// Gets the total column count.
        /// </summary>
        public int ColumnCount => GridPattern.ColumnCount.Value;

        /// <summary>
        /// Gets all column header elements.
        /// </summary>
        public AutomationElement[] ColumnHeaders => TablePattern.ColumnHeaders.Value;

        /// <summary>
        /// Gets all row header elements.
        /// </summary>
        public AutomationElement[] RowHeaders => TablePattern.RowHeaders.Value;

        /// <summary>
        /// Gets whether the data should be read primarily by row or by column.
        /// </summary>
        public RowOrColumnMajor RowOrColumnMajor => TablePattern.RowOrColumnMajor.Value;

        /// <summary>
        /// Gets the header item.
        /// </summary>
        public virtual GridHeader Header
        {
            get
            {
                var header = FindFirstChild(cf => cf.ByControlType(ControlType.Header));
                return header?.AsGridHeader();
            }
        }

        /// <summary>
        /// Returns the rows which are currently visible to UIA. Might not be the full list (eg. in virtualized lists)!
        /// Use <see cref="GetRowByIndex" /> to make sure to get the correct row.
        /// </summary>
        public virtual GridRow[] Rows
        {
            get
            {
                var rows = FindAllChildren(cf => cf.ByControlType(ControlType.DataItem).Or(cf.ByControlType(ControlType.ListItem)));
                return rows.Select(x => x.AsGridRow()).ToArray();
            }
        }

        /// <summary>
        /// Gets all selected items.
        /// </summary>
        public GridRow[] SelectedItems => SelectionPattern.Selection.Value.Select(x => new GridRow(x.FrameworkAutomationElement)).ToArray();

        /// <summary>
        /// Gets the first selected item or null otherwise.
        /// </summary>
        public GridRow SelectedItem => SelectedItems?.FirstOrDefault();

        /// <summary>
        /// Select a row by index.
        /// </summary>
        public GridRow Select(int rowIndex)
        {
            var gridRow = GetRowByIndex(rowIndex);
            gridRow.Select();
            return gridRow;
        }

        /// <summary>
        /// Select the first row by text in the given column.
        /// </summary>
        public GridRow Select(int columnIndex, string textToFind)
        {
            var gridRow = GetRowByValue(columnIndex, textToFind);
            gridRow.Select();
            return gridRow;
        }

        /// <summary>
        /// Add a row to the selection by index.
        /// </summary>
        public GridRow AddToSelection(int rowIndex)
        {
            var gridRow = GetRowByIndex(rowIndex);
            gridRow.AddToSelection();
            return gridRow;
        }

        /// <summary>
        /// Add a row to the selection by text in the given column.
        /// </summary>
        public GridRow AddToSelection(int columnIndex, string textToFind)
        {
            var gridRow = GetRowByValue(columnIndex, textToFind);
            gridRow.AddToSelection();
            return gridRow;
        }

        /// <summary>
        /// Remove a row from the selection by index.
        /// </summary>
        public GridRow RemoveFromSelection(int rowIndex)
        {
            var gridRow = GetRowByIndex(rowIndex);
            gridRow.RemoveFromSelection();
            return gridRow;
        }

        /// <summary>
        /// Remove a row from the selection by text in the given column.
        /// </summary>
        public GridRow RemoveFromSelection(int columnIndex, string textToFind)
        {
            var gridRow = GetRowByValue(columnIndex, textToFind);
            gridRow.RemoveFromSelection();
            return gridRow;
        }

        /// <summary>
        /// Get a row by index.
        /// </summary>
        public GridRow GetRowByIndex(int rowIndex)
        {
            PreCheckRow(rowIndex);
            var gridCell = GridPattern.GetItem(rowIndex, 0).AsGridCell();
            return gridCell.ContainingRow;
        }

        /// <summary>
        /// Get a row by text in the given column.
        /// </summary>
        public GridRow GetRowByValue(int columnIndex, string value)
        {
            return GetRowsByValue(columnIndex, value, 1).FirstOrDefault();
        }

        /// <summary>
        /// Get all rows where the value of the given column matches the given value.
        /// </summary>
        /// <param name="columnIndex">The column index to check.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="maxItems">Maximum numbers of items to return, 0 for all.</param>
        /// <returns>List of found rows.</returns>
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

    /// <summary>
    /// Header element for grids and tables.
    /// </summary>
    public class GridHeader : AutomationElement
    {
        public GridHeader(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
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

    /// <summary>
    /// Header item for grids and tables.
    /// </summary>
    public class GridHeaderItem : AutomationElement
    {
        public GridHeaderItem(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        public string Text => Properties.Name.Value;
    }

    /// <summary>
    /// Row element for grids and tables.
    /// </summary>
    public class GridRow : SelectionItemAutomationElement
    {
        public GridRow(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        protected IScrollItemPattern ScrollItemPattern => Patterns.ScrollItem.Pattern;

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
                return headerItem?.AsGridHeaderItem();
            }
        }

        /// <summary>
        /// Find a cell by a given text.
        /// </summary>
        public GridCell FindCellByText(string textToFind)
        {
            return Cells.FirstOrDefault(cell => cell.Value.Equals(textToFind));
        }

        public GridRow ScrollIntoView()
        {
            ScrollItemPattern?.ScrollIntoView();
            return this;
        }
    }

    /// <summary>
    /// Cell element for grids and tables.
    /// </summary>
    public class GridCell : AutomationElement
    {
        public GridCell(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        protected IGridItemPattern GridItemPattern => Patterns.GridItem.Pattern;

        protected ITableItemPattern TableItemPattern => Patterns.TableItem.Pattern;

        public Grid ContainingGrid => GridItemPattern.ContainingGrid.Value.AsGrid();

        public GridRow ContainingRow
        {
            get
            {
                // Get the parent of the cell (which should be the row)
                var rowElement = Automation.TreeWalkerFactory.GetControlViewWalker().GetParent(this);
                return rowElement?.AsGridRow();
            }
        }

        public string Value => Properties.Name.Value;
    }
}