using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IMultipleViewPattern : IPattern
    {
        IMultipleViewPatternProperties Properties { get; }

        AutomationProperty<int> CurrentView { get; }
        AutomationProperty<int[]> SupportedViews { get; }

        string GetViewName(int view);
        void SetCurrentView(int view);
    }

    public interface IMultipleViewPatternProperties
    {
        PropertyId CurrentView { get; }
        PropertyId SupportedViews { get; }
    }

    public abstract class MultipleViewPatternBase<TNativePattern> : PatternBase<TNativePattern>, IMultipleViewPattern
    {
        protected MultipleViewPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            CurrentView = new AutomationProperty<int>(() => Properties.CurrentView, BasicAutomationElement);
            SupportedViews = new AutomationProperty<int[]>(() => Properties.SupportedViews, BasicAutomationElement);
        }

        public IMultipleViewPatternProperties Properties => Automation.PropertyLibrary.MultipleView;

        public AutomationProperty<int> CurrentView { get; }
        public AutomationProperty<int[]> SupportedViews { get; }

        public abstract string GetViewName(int view);
        public abstract void SetCurrentView(int view);
    }
}
