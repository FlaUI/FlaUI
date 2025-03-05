using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public class ScrollPatternConstants
    {
        public const double NoScroll = -1.0;
    }

    public interface IScrollPattern : IPattern
    {
        IScrollPatternPropertyIds PropertyIds { get; }

        AutomationProperty<bool> HorizontallyScrollable { get; }
        AutomationProperty<double> HorizontalScrollPercent { get; }
        AutomationProperty<double> HorizontalViewSize { get; }
        AutomationProperty<bool> VerticallyScrollable { get; }
        AutomationProperty<double> VerticalScrollPercent { get; }
        AutomationProperty<double> VerticalViewSize { get; }

        void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
        void SetScrollPercent(double horizontalPercent, double verticalPercent);
    }

    public interface IScrollPatternPropertyIds
    {
        PropertyId HorizontallyScrollable { get; }
        PropertyId HorizontalScrollPercent { get; }
        PropertyId HorizontalViewSize { get; }
        PropertyId VerticallyScrollable { get; }
        PropertyId VerticalScrollPercent { get; }
        PropertyId VerticalViewSize { get; }
    }

    public abstract class ScrollPatternBase<TNativePattern> : PatternBase<TNativePattern>, IScrollPattern
        where TNativePattern : class
    {
        private AutomationProperty<bool>? _horizontallyScrollable;
        private AutomationProperty<double>? _horizontalScrollPercent;
        private AutomationProperty<double>? _horizontalViewSize;
        private AutomationProperty<bool>? _verticallyScrollable;
        private AutomationProperty<double>? _verticalScrollPercent;
        private AutomationProperty<double>? _verticalViewSize;

        protected ScrollPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public IScrollPatternPropertyIds PropertyIds => Automation.PropertyLibrary.Scroll;

        public AutomationProperty<bool> HorizontallyScrollable => GetOrCreate(ref _horizontallyScrollable, PropertyIds.HorizontallyScrollable);
        public AutomationProperty<double> HorizontalScrollPercent => GetOrCreate(ref _horizontalScrollPercent, PropertyIds.HorizontalScrollPercent);
        public AutomationProperty<double> HorizontalViewSize => GetOrCreate(ref _horizontalViewSize, PropertyIds.HorizontalViewSize);
        public AutomationProperty<bool> VerticallyScrollable => GetOrCreate(ref _verticallyScrollable, PropertyIds.VerticallyScrollable);
        public AutomationProperty<double> VerticalScrollPercent => GetOrCreate(ref _verticalScrollPercent, PropertyIds.VerticalScrollPercent);
        public AutomationProperty<double> VerticalViewSize => GetOrCreate(ref _verticalViewSize, PropertyIds.VerticalViewSize);

        public abstract void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
        public abstract void SetScrollPercent(double horizontalPercent, double verticalPercent);
    }
}
