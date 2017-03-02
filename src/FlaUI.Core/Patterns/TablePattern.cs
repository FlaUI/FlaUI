using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITablePattern : IPattern
    {
        ITablePatternProperties Properties { get; }

        AutomationProperty<AutomationElement[]> ColumnHeaders { get; }
        AutomationProperty<AutomationElement[]> RowHeaders { get; }
        AutomationProperty<RowOrColumnMajor> RowOrColumnMajor { get; }
    }

    public interface ITablePatternProperties
    {
        PropertyId ColumnHeaders { get; }
        PropertyId RowHeaders { get; }
        PropertyId RowOrColumnMajor { get; }
    }

    public abstract class TablePatternBase<TNativePattern> : PatternBase<TNativePattern>, ITablePattern
    {
        private AutomationProperty<AutomationElement[]> _columnHeaders;
        private AutomationProperty<AutomationElement[]> _rowHeaders;
        private AutomationProperty<RowOrColumnMajor> _rowOrColumnMajor;

        protected TablePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ITablePatternProperties Properties => Automation.PropertyLibrary.Table;

        public AutomationProperty<AutomationElement[]> ColumnHeaders => GetOrCreate(ref _columnHeaders, Properties.ColumnHeaders);
        public AutomationProperty<AutomationElement[]> RowHeaders => GetOrCreate(ref _rowHeaders, Properties.RowHeaders);
        public AutomationProperty<RowOrColumnMajor> RowOrColumnMajor => GetOrCreate(ref _rowOrColumnMajor, Properties.RowOrColumnMajor);
    }
}
