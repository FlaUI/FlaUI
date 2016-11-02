using System;
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

        public int RowCount
        {
            get
            {
                var gridPattern = GridPattern;
                if (gridPattern != null)
                {
                    return GridPattern.Current.RowCount;
                }
                return Rows.Length;
            }
        }

        public int ColumnCount
        {
            get
            {
                var gridPattern = GridPattern;
                if (gridPattern != null)
                {
                    return GridPattern.Current.ColumnCount;
                }
                return Header.Columns.Length;
            }
        }

        public GridHeader Header
        {
            get
            {
                var header = FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Header));
                return new GridHeader(header.BasicAutomationElement);
            }
        }

        public GridRow[] Rows
        {
            get
            {
                var rows = FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.DataItem).Or(ConditionFactory.ByControlType(ControlType.ListItem)));
                return rows.Select(x => new GridRow(x.BasicAutomationElement)).ToArray();
            }
        }

        public GridRow Select(int index)
        {
            var rows = Rows;
            PreCheckRow(rows.Length, index);
            var rowToSelect = rows[index];
            rowToSelect.ScrollIntoView();
            rowToSelect.Select();
            return rowToSelect;
        }

        public GridRow AddToSelection(int index)
        {
            var rows = Rows;
            PreCheckRow(rows.Length, index);
            var rowToSelect = rows[index];
            rowToSelect.ScrollIntoView();
            rowToSelect.AddToSelection();
            return rowToSelect;
        }

        public GridRow RemoveFromSelection(int index)
        {
            var rows = Rows;
            PreCheckRow(rows.Length, index);
            var rowToSelect = rows[index];
            rowToSelect.ScrollIntoView();
            rowToSelect.RemoveFromSelection();
            return rowToSelect;
        }

        private void PreCheckRow(int numRows, int index)
        {
            if (numRows <= index)
            {
                throw new Exception($"Grid contains only {numRows} rows but index {index} were requested");
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
                var headerItems = FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.HeaderItem));
                return headerItems.Select(x => new GridHeaderItem(x.BasicAutomationElement)).ToArray();
            }
        }
    }

    public class GridHeaderItem : AutomationElement
    {
        public GridHeaderItem(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public string Text => Current.Name;
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
                var cells = FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.HeaderItem).Not());
                return cells.Select(x => new GridCell(x.BasicAutomationElement)).ToArray();
            }
        }

        public GridHeaderItem Header
        {
            get
            {
                var headerItem = FindFirstChild(ConditionFactory.ByControlType(ControlType.HeaderItem));
                return headerItem == null ? null : new GridHeaderItem(headerItem.BasicAutomationElement);
            }
        }

        public GridRow ScrollIntoView()
        {
            var scrollItemPattern = ScrollItemPattern;
            if (scrollItemPattern != null)
            {
                scrollItemPattern.ScrollIntoView();
            }
            return this;
        }
    }

    public class GridCell : AutomationElement
    {
        public GridCell(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public IGridItemPattern GridItemPattern => PatternFactory.GetGridItemPattern();
    }
}