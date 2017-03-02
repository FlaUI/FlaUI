using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IRangeValuePattern : IPattern
    {
        IRangeValuePatternProperties Properties { get; }

        AutomationProperty<bool> IsReadOnly { get; }
        AutomationProperty<double> LargeChange { get; }
        AutomationProperty<double> Maximum { get; }
        AutomationProperty<double> Minimum { get; }
        AutomationProperty<double> SmallChange { get; }
        AutomationProperty<double> Value { get; }

        void SetValue(double val);
    }

    public interface IRangeValuePatternProperties
    {
        PropertyId IsReadOnly { get; }
        PropertyId LargeChange { get; }
        PropertyId Maximum { get; }
        PropertyId Minimum { get; }
        PropertyId SmallChange { get; }
        PropertyId Value { get; }
    }

    public abstract class RangeValuePatternBase<TNativePattern> : PatternBase<TNativePattern>, IRangeValuePattern
    {
        private AutomationProperty<bool> _isReadOnly;
        private AutomationProperty<double> _largeChange;
        private AutomationProperty<double> _maximum;
        private AutomationProperty<double> _minimum;
        private AutomationProperty<double> _smallChange;
        private AutomationProperty<double> _value;

        protected RangeValuePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IRangeValuePatternProperties Properties => Automation.PropertyLibrary.RangeValue;

        public AutomationProperty<bool> IsReadOnly => GetOrCreate(ref _isReadOnly, Properties.IsReadOnly);
        public AutomationProperty<double> LargeChange => GetOrCreate(ref _largeChange, Properties.LargeChange);
        public AutomationProperty<double> Maximum => GetOrCreate(ref _maximum, Properties.Maximum);
        public AutomationProperty<double> Minimum => GetOrCreate(ref _minimum, Properties.Minimum);
        public AutomationProperty<double> SmallChange => GetOrCreate(ref _smallChange, Properties.SmallChange);
        public AutomationProperty<double> Value => GetOrCreate(ref _value, Properties.Value);

        public abstract void SetValue(double val);
    }
}
