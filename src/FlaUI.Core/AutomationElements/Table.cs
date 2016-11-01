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
    }
}
