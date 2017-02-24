#if !NET35
using System;
#endif
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;
#if NET35
using FlaUI.Core.Tools;
#endif

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
        PropertyId CanMaximizeProperty { get; }
        PropertyId CanMinimizeProperty { get; }
        PropertyId IsModalProperty { get; }
        PropertyId IsTopmostProperty { get; }
        PropertyId WindowInteractionStateProperty { get; }
        PropertyId WindowVisualStateProperty { get; }
    }

    public interface IWindowPatternEvents
    {
        EventId WindowClosedEvent { get; }
        EventId WindowOpenedEvent { get; }
    }

    public abstract class WindowPatternBase<TNativePattern> : PatternBase<TNativePattern>, IWindowPattern
    {
        private readonly Lazy<AutomationProperty<bool>> _canMaximizeLazy;
        private readonly Lazy<AutomationProperty<bool>> _canMinimizeLazy;
        private readonly Lazy<AutomationProperty<bool>> _isModalLazy;
        private readonly Lazy<AutomationProperty<bool>> _isTopmostLazy;
        private readonly Lazy<AutomationProperty<WindowInteractionState>> _windowInteractionStateLazy;
        private readonly Lazy<AutomationProperty<WindowVisualState>> _windowVisualStateLazy;

        protected WindowPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            _canMaximizeLazy = new Lazy<AutomationProperty<bool>>(() => new AutomationProperty<bool>(Properties.CanMaximizeProperty, BasicAutomationElement));
            _canMinimizeLazy = new Lazy<AutomationProperty<bool>>(() => new AutomationProperty<bool>(Properties.CanMinimizeProperty, BasicAutomationElement));
            _isModalLazy = new Lazy<AutomationProperty<bool>>(() => new AutomationProperty<bool>(Properties.IsModalProperty, BasicAutomationElement));
            _isTopmostLazy = new Lazy<AutomationProperty<bool>>(() => new AutomationProperty<bool>(Properties.IsTopmostProperty, BasicAutomationElement));
            _windowInteractionStateLazy = new Lazy<AutomationProperty<WindowInteractionState>>(() => new AutomationProperty<WindowInteractionState>(Properties.WindowInteractionStateProperty, BasicAutomationElement));
            _windowVisualStateLazy = new Lazy<AutomationProperty<WindowVisualState>>(() => new AutomationProperty<WindowVisualState>(Properties.WindowVisualStateProperty, BasicAutomationElement));
        }

        public IWindowPatternProperties Properties => Automation.PropertyLibrary.Window;
        public IWindowPatternEvents Events => Automation.EventLibrary.Window;

        public AutomationProperty<bool> CanMaximize => _canMaximizeLazy.Value;
        public AutomationProperty<bool> CanMinimize => _canMinimizeLazy.Value;
        public AutomationProperty<bool> IsModal => _isModalLazy.Value;
        public AutomationProperty<bool> IsTopmost => _isTopmostLazy.Value;
        public AutomationProperty<WindowInteractionState> WindowInteractionState => _windowInteractionStateLazy.Value;
        public AutomationProperty<WindowVisualState> WindowVisualState => _windowVisualStateLazy.Value;

        public abstract void Close();

        public abstract void SetWindowVisualState(WindowVisualState state);

        public abstract bool WaitForInputIdle(int milliseconds);
    }
}
