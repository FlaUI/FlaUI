using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    public class Table : AutomationElement
    {
        public Table(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public ITablePattern TablePattern => PatternFactory.GetTablePattern();

        public AutomationElement[] ColumnHeaders => TablePattern.Current.ColumnHeaders;

        public AutomationElement[] RowHeaders => TablePattern.Current.RowHeaders;

        public RowOrColumnMajor RowOrColumnMajor => TablePattern.Current.RowOrColumnMajor;

        public TableHeader Header
        {
            get
            {
                var header = FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Header));
                return new TableHeader(header.BasicAutomationElement);
            }
        }

        public TableRow[] Rows
        {
            get
            {
                var rows = FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.DataItem).Or(ConditionFactory.ByControlType(ControlType.ListItem)));
                return rows.Select(x => new TableRow(x.BasicAutomationElement)).ToArray();
            }
        }
    }

    public class TableHeader : AutomationElement
    {
        public TableHeader(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public TableHeaderItem[] Items
        {
            get
            {
                var headerItems = FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.HeaderItem));
                return headerItems.Select(x => new TableHeaderItem(x.BasicAutomationElement)).ToArray();
            }
        }
    }

    public class TableHeaderItem : AutomationElement
    {
        public TableHeaderItem(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public string Text => Current.Name;
    }

    public class TableRow : SelectionItemAutomationElement
    {
        public TableRow(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public IScrollItemPattern ScrollItemPattern => PatternFactory.GetScrollItemPattern();

        public TableCell[] Cells
        {
            get
            {
                var cells = FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.HeaderItem).Not());
                return cells.Select(x => new TableCell(x.BasicAutomationElement)).ToArray();
            }
        }

        public TableHeaderItem Header
        {
            get
            {
                var headerItem = FindFirstChild(ConditionFactory.ByControlType(ControlType.HeaderItem));
                return headerItem == null ? null : new TableHeaderItem(headerItem.BasicAutomationElement);
            }
        }

        public TableRow ScrollIntoView()
        {
            var scrollItemPattern = ScrollItemPattern;
            if (scrollItemPattern != null)
            {
                scrollItemPattern.ScrollIntoView();
            }
            return this;
        }
    }

    public class TableCell : AutomationElement
    {
        public TableCell(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public ITableItemPattern TableItemPattern => PatternFactory.GetTableItemPattern();
    }
}
