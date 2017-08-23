using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IWindowPattern : IPattern
    {
        IWindowPatternProperties Properties { get; }
        IWindowPatternEvents Events { get; }

        AutomationProperty<bool> CanMaximize { get; }
        AutomationProperty<bool> CanMinimize { get; }
        AutomationProperty<bool> IsModal { get; }
        AutomationProperty<bool> IsTopmost { get; }
        AutomationProperty<WindowInteractionState> WindowInteractionState { get; }
        AutomationProperty<WindowVisualState> WindowVisualState { get; }

        void Close();
        void SetWindowVisualState(WindowVisualState state);
        bool WaitForInputIdle(int milliseconds);
    }

    public interface IWindowPatternProperties
    {
        PropertyId CanMaximize { get; }
        PropertyId CanMinimize { get; }
        PropertyId IsModal { get; }
        PropertyId IsTopmost { get; }
        PropertyId WindowInteractionState { get; }
        PropertyId WindowVisualState { get; }
    }

    public interface IWindowPatternEvents
    {
        EventId WindowClosedEvent { get; }
        EventId WindowOpenedEvent { get; }
    }

    public abstract class WindowPatternBase<TNativePattern> : PatternBase<TNativePattern>, IWindowPattern
        where TNativePattern : class
    {
        private AutomationProperty<bool> _canMaximize;
        private AutomationProperty<bool> _canMinimize;
        private AutomationProperty<bool> _isModal;
        private AutomationProperty<bool> _isTopmost;
        private AutomationProperty<WindowInteractionState> _windowInteractionState;
        private AutomationProperty<WindowVisualState> _windowVisualState;

        protected WindowPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IWindowPatternProperties Properties => Automation.PropertyLibrary.Window;
        public IWindowPatternEvents Events => Automation.EventLibrary.Window;

        public AutomationProperty<bool> CanMaximize => GetOrCreate(ref _canMaximize, Properties.CanMaximize);
        public AutomationProperty<bool> CanMinimize => GetOrCreate(ref _canMinimize, Properties.CanMinimize);
        public AutomationProperty<bool> IsModal => GetOrCreate(ref _isModal, Properties.IsModal);
        public AutomationProperty<bool> IsTopmost => GetOrCreate(ref _isTopmost, Properties.IsTopmost);
        public AutomationProperty<WindowInteractionState> WindowInteractionState => GetOrCreate(ref _windowInteractionState, Properties.WindowInteractionState);
        public AutomationProperty<WindowVisualState> WindowVisualState => GetOrCreate(ref _windowVisualState, Properties.WindowVisualState);

        public abstract void Close();
        public abstract void SetWindowVisualState(WindowVisualState state);
        public abstract bool WaitForInputIdle(int milliseconds);
    }
}
