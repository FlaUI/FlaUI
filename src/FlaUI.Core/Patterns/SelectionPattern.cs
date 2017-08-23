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
        where TNativePattern : class
    {
        private AutomationProperty<bool> _canSelectMultiple;
        private AutomationProperty<bool> _isSelectionRequired;
        private AutomationProperty<AutomationElement[]> _selection;

        protected SelectionPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ISelectionPatternProperties Properties => Automation.PropertyLibrary.Selection;
        public ISelectionPatternEvents Events => Automation.EventLibrary.Selection;

        public AutomationProperty<bool> CanSelectMultiple => GetOrCreate(ref _canSelectMultiple, Properties.CanSelectMultiple);
        public AutomationProperty<bool> IsSelectionRequired => GetOrCreate(ref _isSelectionRequired, Properties.IsSelectionRequired);
        public AutomationProperty<AutomationElement[]> Selection => GetOrCreate(ref _selection, Properties.Selection);
    }
}
