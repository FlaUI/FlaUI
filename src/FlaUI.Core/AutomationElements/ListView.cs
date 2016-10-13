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
            if (rows.Length <= index)
            {
                throw new Exception($"ListView contains only {rows.Length} rows but index {index} were requested");
            }
            var rowToSelect = rows[index];
            rowToSelect.ScrollIntoView();
            rowToSelect.Select();
            return rowToSelect;
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