using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IRangeValuePattern : IPattern
    {
        IRangeValuePatternPropertyIds PropertyIds { get; }

        AutomationProperty<bool> IsReadOnly { get; }
        AutomationProperty<double> LargeChange { get; }
        AutomationProperty<double> Maximum { get; }
        AutomationProperty<double> Minimum { get; }
        AutomationProperty<double> SmallChange { get; }
        AutomationProperty<double> Value { get; }

        void SetValue(double val);
    }

    public interface IRangeValuePatternPropertyIds
    {
        PropertyId IsReadOnly { get; }
        PropertyId LargeChange { get; }
        PropertyId Maximum { get; }
        PropertyId Minimum { get; }
        PropertyId SmallChange { get; }
        PropertyId Value { get; }
    }

    public abstract class RangeValuePatternBase<TNativePattern> : PatternBase<TNativePattern>, IRangeValuePattern
        where TNativePattern : class
    {
        private AutomationProperty<bool> _isReadOnly;
        private AutomationProperty<double> _largeChange;
        private AutomationProperty<double> _maximum;
        private AutomationProperty<double> _minimum;
        private AutomationProperty<double> _smallChange;
        private AutomationProperty<double> _value;

        protected RangeValuePatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public IRangeValuePatternPropertyIds PropertyIds => Automation.PropertyLibrary.RangeValue;

        public AutomationProperty<bool> IsReadOnly => GetOrCreate(ref _isReadOnly, PropertyIds.IsReadOnly);
        public AutomationProperty<double> LargeChange => GetOrCreate(ref _largeChange, PropertyIds.LargeChange);
        public AutomationProperty<double> Maximum => GetOrCreate(ref _maximum, PropertyIds.Maximum);
        public AutomationProperty<double> Minimum => GetOrCreate(ref _minimum, PropertyIds.Minimum);
        public AutomationProperty<double> SmallChange => GetOrCreate(ref _smallChange, PropertyIds.SmallChange);
        public AutomationProperty<double> Value => GetOrCreate(ref _value, PropertyIds.Value);

        public abstract void SetValue(double val);
    }
}
