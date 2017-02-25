using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISelectionPattern : IPattern
    {
        ISelectionPatternProperties Properties { get; }
        ISelectionPatternEvents Events { get; }

        AutomationProperty<bool> CanSelectMultiple { get; }
        AutomationProperty<bool> IsSelectionRequired { get; }
        AutomationProperty<AutomationElement[]> Selection { get; }
    }

    public interface ISelectionPatternProperties
    {
        PropertyId CanSelectMultipleProperty { get; }
        PropertyId IsSelectionRequiredProperty { get; }
        PropertyId SelectionProperty { get; }
    }

    public interface ISelectionPatternEvents
    {
        EventId InvalidatedEvent { get; }
    }

    public abstract class SelectionPatternBase<TNativePattern> : PatternBase<TNativePattern>, ISelectionPattern
    {
        protected SelectionPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            CanSelectMultiple = new AutomationProperty<bool>(() => Properties.CanSelectMultipleProperty, BasicAutomationElement);
            IsSelectionRequired = new AutomationProperty<bool>(() => Properties.IsSelectionRequiredProperty, BasicAutomationElement);
            Selection = new AutomationProperty<AutomationElement[]>(() => Properties.SelectionProperty, BasicAutomationElement);
        }

        public ISelectionPatternProperties Properties => Automation.PropertyLibrary.Selection;
        public ISelectionPatternEvents Events => Automation.EventLibrary.Selection;

        public AutomationProperty<bool> CanSelectMultiple { get; }
        public AutomationProperty<bool> IsSelectionRequired { get; }
        public AutomationProperty<AutomationElement[]> Selection { get; }
    }
}
