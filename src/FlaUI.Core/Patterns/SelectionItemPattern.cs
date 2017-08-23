using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISelectionItemPattern : IPattern
    {
        ISelectionItemPatternProperties Properties { get; }
        ISelectionItemPatternEvents Events { get; }

        AutomationProperty<bool> IsSelected { get; }
        AutomationProperty<AutomationElement> SelectionContainer { get; }

        void AddToSelection();
        void RemoveFromSelection();
        void Select();
    }

    public interface ISelectionItemPatternProperties
    {
        PropertyId IsSelected { get; }
        PropertyId SelectionContainer { get; }
    }

    public interface ISelectionItemPatternEvents
    {
        EventId ElementAddedToSelectionEvent { get; }
        EventId ElementRemovedFromSelectionEvent { get; }
        EventId ElementSelectedEvent { get; }
    }

    public abstract class SelectionItemPatternBase<TNativePattern> : PatternBase<TNativePattern>, ISelectionItemPattern
        where TNativePattern : class
    {
        private AutomationProperty<bool> _isSelected;
        private AutomationProperty<AutomationElement> _selectionContainer;

        protected SelectionItemPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ISelectionItemPatternProperties Properties => Automation.PropertyLibrary.SelectionItem;
        public ISelectionItemPatternEvents Events => Automation.EventLibrary.SelectionItem;

        public AutomationProperty<bool> IsSelected => GetOrCreate(ref _isSelected, Properties.IsSelected);
        public AutomationProperty<AutomationElement> SelectionContainer => GetOrCreate(ref _selectionContainer, Properties.SelectionContainer);

        public abstract void AddToSelection();
        public abstract void RemoveFromSelection();
        public abstract void Select();
    }
}
