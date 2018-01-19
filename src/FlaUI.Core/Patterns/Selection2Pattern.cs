using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Patterns
{
    public interface ISelection2Pattern : ISelectionPattern
    {
        new ISelection2PatternPropertyIds PropertyIds { get; }

        AutomationProperty<AutomationElement> CurrentSelectedItem { get; }
        AutomationProperty<AutomationElement> FirstSelectedItem { get; }
        AutomationProperty<int> ItemCount { get; }
        AutomationProperty<AutomationElement> LastSelectedItem { get; }
    }

    public interface ISelection2PatternPropertyIds : ISelectionPatternPropertyIds
    {
        PropertyId CurrentSelectedItem { get; }
        PropertyId FirstSelectedItem { get; }
        PropertyId ItemCount { get; }
        PropertyId LastSelectedItem { get; }
    }

    public abstract class Selection2PatternBase<TNativePattern> : SelectionPatternBase<TNativePattern>, ISelection2Pattern
        where TNativePattern : class
    {
        private AutomationProperty<AutomationElement> _currentSelectedItem;
        private AutomationProperty<AutomationElement> _firstSelectedItem;
        private AutomationProperty<int> _itemCount;
        private AutomationProperty<AutomationElement> _lastSelectedItem;

        protected Selection2PatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        ISelection2PatternPropertyIds ISelection2Pattern.PropertyIds => Automation.PropertyLibrary.Selection2;

        public AutomationProperty<AutomationElement> CurrentSelectedItem => GetOrCreate(ref _currentSelectedItem, ((ISelection2Pattern)this).PropertyIds.CurrentSelectedItem);
        public AutomationProperty<AutomationElement> FirstSelectedItem => GetOrCreate(ref _firstSelectedItem, ((ISelection2Pattern)this).PropertyIds.FirstSelectedItem);
        public AutomationProperty<int> ItemCount => GetOrCreate(ref _itemCount, ((ISelection2Pattern)this).PropertyIds.ItemCount);
        public AutomationProperty<AutomationElement> LastSelectedItem => GetOrCreate(ref _lastSelectedItem, ((ISelection2Pattern)this).PropertyIds.LastSelectedItem);
    }
}
