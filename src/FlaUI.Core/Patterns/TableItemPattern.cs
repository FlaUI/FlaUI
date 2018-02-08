using FlaUI.Core.AutomationElements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITableItemPattern : IPattern
    {
        ITableItemPatternPropertyIds PropertyIds { get; }

        AutomationProperty<AutomationElement[]> ColumnHeaderItems { get; }
        AutomationProperty<AutomationElement[]> RowHeaderItems { get; }
    }

    public interface ITableItemPatternPropertyIds
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

        public ITableItemPatternPropertyIds PropertyIds => Automation.PropertyLibrary.TableItem;

        public AutomationProperty<AutomationElement[]> ColumnHeaderItems => GetOrCreate(ref _columnHeaderItems, PropertyIds.ColumnHeaderItems);
        public AutomationProperty<AutomationElement[]> RowHeaderItems => GetOrCreate(ref _rowHeaderItems, PropertyIds.RowHeaderItems);
    }
}
