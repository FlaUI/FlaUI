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
        PropertyId CanSelectMultiple { get; }
        PropertyId IsSelectionRequired { get; }
        PropertyId Selection { get; }
    }

    public interface ISelectionPatternEvents
    {
        EventId InvalidatedEvent { get; }
    }

    public abstract class SelectionPatternBase<TNativePattern> : PatternBase<TNativePattern>, ISelectionPattern
    {
        protected SelectionPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            CanSelectMultiple = new AutomationProperty<bool>(() => Properties.CanSelectMultiple, BasicAutomationElement);
            IsSelectionRequired = new AutomationProperty<bool>(() => Properties.IsSelectionRequired, BasicAutomationElement);
            Selection = new AutomationProperty<AutomationElement[]>(() => Properties.Selection, BasicAutomationElement);
        }

        public ISelectionPatternProperties Properties => Automation.PropertyLibrary.Selection;
        public ISelectionPatternEvents Events => Automation.EventLibrary.Selection;

        public AutomationProperty<bool> CanSelectMultiple { get; }
        public AutomationProperty<bool> IsSelectionRequired { get; }
        public AutomationProperty<AutomationElement[]> Selection { get; }
    }
}
