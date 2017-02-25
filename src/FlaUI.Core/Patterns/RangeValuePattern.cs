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
        protected RangeValuePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            IsReadOnly = new AutomationProperty<bool>(() => Properties.IsReadOnly, BasicAutomationElement);
            LargeChange = new AutomationProperty<double>(() => Properties.LargeChange, BasicAutomationElement);
            Maximum = new AutomationProperty<double>(() => Properties.Maximum, BasicAutomationElement);
            Minimum = new AutomationProperty<double>(() => Properties.Minimum, BasicAutomationElement);
            SmallChange = new AutomationProperty<double>(() => Properties.SmallChange, BasicAutomationElement);
            Value = new AutomationProperty<double>(() => Properties.Value, BasicAutomationElement);
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
