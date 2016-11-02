using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
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
}
