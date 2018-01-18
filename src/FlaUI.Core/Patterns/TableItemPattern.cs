using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITableItemPattern : IPattern
    {
        ITableItemPatternProperties Properties { get; }

        AutomationProperty<AutomationElement[]> ColumnHeaderItems { get; }
        AutomationProperty<AutomationElement[]> RowHeaderItems { get; }
    }

    public interface ITableItemPatternProperties
    {
        PropertyId ColumnHeaderItems { get; }
        PropertyId RowHeaderItems { get; }
    }

    public abstract class TableItemPatternBase<TNativePattern> : PatternBase<TNativePattern>, ITableItemPattern
        where TNativePattern : class
    {
        private AutomationProperty<AutomationElement[]> _columnHeaderItems;
        private AutomationProperty<AutomationElement[]> _rowHeaderItems;

        protected TableItemPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ITableItemPatternProperties Properties => Automation.PropertyLibrary.TableItem;

        public AutomationProperty<AutomationElement[]> ColumnHeaderItems => GetOrCreate(ref _columnHeaderItems, Properties.ColumnHeaderItems);
        public AutomationProperty<AutomationElement[]> RowHeaderItems => GetOrCreate(ref _rowHeaderItems, Properties.RowHeaderItems);
    }
}
