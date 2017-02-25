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
        protected TablePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ColumnHeaders = new AutomationProperty<AutomationElement[]>(() => Properties.ColumnHeaders, BasicAutomationElement);
            RowHeaders = new AutomationProperty<AutomationElement[]>(() => Properties.RowHeaders, BasicAutomationElement);
            RowOrColumnMajor = new AutomationProperty<RowOrColumnMajor>(() => Properties.RowOrColumnMajor, BasicAutomationElement);
        }

        public ITablePatternProperties Properties => Automation.PropertyLibrary.Table;

        public AutomationProperty<AutomationElement[]> ColumnHeaders { get; }
        public AutomationProperty<AutomationElement[]> RowHeaders { get; }
        public AutomationProperty<RowOrColumnMajor> RowOrColumnMajor { get; }
    }
}
