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
        PropertyId IsReadOnlyProperty { get; }
        PropertyId LargeChangeProperty { get; }
        PropertyId MaximumProperty { get; }
        PropertyId MinimumProperty { get; }
        PropertyId SmallChangeProperty { get; }
        PropertyId ValueProperty { get; }
    }

    public abstract class RangeValuePatternBase<TNativePattern> : PatternBase<TNativePattern>, IRangeValuePattern
    {
        protected RangeValuePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            IsReadOnly = new AutomationProperty<bool>(() => Properties.IsReadOnlyProperty, BasicAutomationElement);
            LargeChange = new AutomationProperty<double>(() => Properties.LargeChangeProperty, BasicAutomationElement);
            Maximum = new AutomationProperty<double>(() => Properties.MaximumProperty, BasicAutomationElement);
            Minimum = new AutomationProperty<double>(() => Properties.MinimumProperty, BasicAutomationElement);
            SmallChange = new AutomationProperty<double>(() => Properties.SmallChangeProperty, BasicAutomationElement);
            Value = new AutomationProperty<double>(() => Properties.ValueProperty, BasicAutomationElement);
        }

        public IRangeValuePatternProperties Properties => Automation.PropertyLibrary.RangeValue;

       public AutomationProperty<bool> IsReadOnly { get; }
       public AutomationProperty<double> LargeChange { get; }
       public AutomationProperty<double> Maximum { get; }
       public AutomationProperty<double> Minimum { get; }
       public AutomationProperty<double> SmallChange { get; }
       public AutomationProperty<double> Value { get; }

        public abstract void SetValue(double val);
    }
}
