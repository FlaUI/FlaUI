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
        PropertyId ColumnHeaderItemsProperty { get; }
        PropertyId RowHeaderItemsProperty { get; }
    }

    public abstract class TableItemPatternBase<TNativePattern> : PatternBase<TNativePattern>, ITableItemPattern
    {
        protected TableItemPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ColumnHeaderItems = new AutomationProperty<AutomationElement[]>(() => Properties.ColumnHeaderItemsProperty, BasicAutomationElement);
            RowHeaderItems = new AutomationProperty<AutomationElement[]>(() => Properties.RowHeaderItemsProperty, BasicAutomationElement);
        }

        public ITableItemPatternProperties Properties => Automation.PropertyLibrary.TableItem;

        public AutomationProperty<AutomationElement[]> ColumnHeaderItems { get; }
        public AutomationProperty<AutomationElement[]> RowHeaderItems { get; }
    }
}
