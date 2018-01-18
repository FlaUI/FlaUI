using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IWindowPattern : IPattern
    {
        IWindowPatternPropertyIds PropertyIds { get; }
        IWindowPatternEventIds EventIds { get; }

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

    public interface IWindowPatternPropertyIds
    {
        PropertyId CanMaximize { get; }
        PropertyId CanMinimize { get; }
        PropertyId IsModal { get; }
        PropertyId IsTopmost { get; }
        PropertyId WindowInteractionState { get; }
        PropertyId WindowVisualState { get; }
    }

    public interface IWindowPatternEventIds
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

        protected WindowPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public IWindowPatternPropertyIds PropertyIds => Automation.PropertyLibrary.Window;
        public IWindowPatternEventIds EventIds => Automation.EventLibrary.Window;

        public AutomationProperty<bool> CanMaximize => GetOrCreate(ref _canMaximize, PropertyIds.CanMaximize);
        public AutomationProperty<bool> CanMinimize => GetOrCreate(ref _canMinimize, PropertyIds.CanMinimize);
        public AutomationProperty<bool> IsModal => GetOrCreate(ref _isModal, PropertyIds.IsModal);
        public AutomationProperty<bool> IsTopmost => GetOrCreate(ref _isTopmost, PropertyIds.IsTopmost);
        public AutomationProperty<WindowInteractionState> WindowInteractionState => GetOrCreate(ref _windowInteractionState, PropertyIds.WindowInteractionState);
        public AutomationProperty<WindowVisualState> WindowVisualState => GetOrCreate(ref _windowVisualState, PropertyIds.WindowVisualState);

        public abstract void Close();
        public abstract void SetWindowVisualState(WindowVisualState state);
        public abstract bool WaitForInputIdle(int milliseconds);
    }
}
