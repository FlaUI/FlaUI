using FlaUI.Core.AutomationElements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISelectionItemPattern : IPattern
    {
        ISelectionItemPatternPropertyIds PropertyIds { get; }
        ISelectionItemPatternEventIds EventIds { get; }

        AutomationProperty<bool> IsSelected { get; }
        AutomationProperty<AutomationElement> SelectionContainer { get; }

        void AddToSelection();
        void RemoveFromSelection();
        void Select();
    }

    public interface ISelectionItemPatternPropertyIds
    {
        PropertyId IsSelected { get; }
        PropertyId SelectionContainer { get; }
    }

    public interface ISelectionItemPatternEventIds
    {
        EventId ElementAddedToSelectionEvent { get; }
        EventId ElementRemovedFromSelectionEvent { get; }
        EventId ElementSelectedEvent { get; }
    }

    public abstract class SelectionItemPatternBase<TNativePattern> : PatternBase<TNativePattern>, ISelectionItemPattern
        where TNativePattern : class
    {
        private AutomationProperty<bool>? _isSelected;
        private AutomationProperty<AutomationElement>? _selectionContainer;

        protected SelectionItemPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ISelectionItemPatternPropertyIds PropertyIds => Automation.PropertyLibrary.SelectionItem;
        public ISelectionItemPatternEventIds EventIds => Automation.EventLibrary.SelectionItem;

        public AutomationProperty<bool> IsSelected => GetOrCreate(ref _isSelected, PropertyIds.IsSelected);
        public AutomationProperty<AutomationElement> SelectionContainer => GetOrCreate(ref _selectionContainer, PropertyIds.SelectionContainer);

        public abstract void AddToSelection();
        public abstract void RemoveFromSelection();
        public abstract void Select();
    }
}
