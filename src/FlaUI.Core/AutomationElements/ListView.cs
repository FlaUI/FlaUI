using System;
using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    public class ListView : AutomationElement
    {
        public ListView(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
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

        public ListViewHeader Header
        {
            get
            {
                var header = FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Header));
                return new ListViewHeader(header.BasicAutomationElement);
            }
        }

        public ListViewRow[] Rows
        {
            get
            {
                var rows = FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.DataItem).Or(ConditionFactory.ByControlType(ControlType.ListItem)));
                return rows.Select(x => new ListViewRow(x.BasicAutomationElement)).ToArray();
            }
        }

        public ListViewRow Select(int index)
        {
            var rows = Rows;
            PreCheckRow(rows.Length, index);
            var rowToSelect = rows[index];
            rowToSelect.ScrollIntoView();
            rowToSelect.Select();
            return rowToSelect;
        }

        public ListViewRow AddToSelection(int index)
        {
            var rows = Rows;
            PreCheckRow(rows.Length, index);
            var rowToSelect = rows[index];
            rowToSelect.ScrollIntoView();
            rowToSelect.AddToSelection();
            return rowToSelect;
        }

        public ListViewRow RemoveFromSelection(int index)
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
                throw new Exception($"ListView contains only {numRows} rows but index {index} were requested");
            }
        }
    }

    public class ListViewHeader : AutomationElement
    {
        public ListViewHeader(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public ListViewColumn[] Columns
        {
            get
            {
                var columns = FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.HeaderItem));
                return columns.Select(x => new ListViewColumn(x.BasicAutomationElement)).ToArray();
            }
        }
    }

    public class ListViewColumn : AutomationElement
    {
        public ListViewColumn(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public string Text => Current.Name;
    }

    public class ListViewRow : SelectionItemAutomationElement
    {
        public ListViewRow(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public IScrollItemPattern ScrollItemPattern => PatternFactory.GetScrollItemPattern();

        public AutomationElement[] Cells
        {
            get
            {
                var cells = FindAll(TreeScope.Children, new BoolCondition(true));
                return cells.ToArray();
            }
        }

        public ListViewRow ScrollIntoView()
        {
            var scrollItemPattern = ScrollItemPattern;
            if (scrollItemPattern != null)
            {
                scrollItemPattern.ScrollIntoView();
            }
            return this;
        }
    }
}