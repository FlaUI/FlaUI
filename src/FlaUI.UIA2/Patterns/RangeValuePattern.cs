using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class RangeValuePattern : PatternBase<UIA.RangeValuePattern>, IRangeValuePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.RangeValuePattern.Pattern.Id, "RangeValue", AutomationObjectIds.IsRangeValuePatternAvailableProperty);
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.IsReadOnlyProperty.Id, "IsReadOnly");
        public static readonly PropertyId LargeChangeProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.LargeChangeProperty.Id, "LargeChange");
        public static readonly PropertyId MaximumProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.MaximumProperty.Id, "Maximum");
        public static readonly PropertyId MinimumProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.MinimumProperty.Id, "Minimum");
        public static readonly PropertyId SmallChangeProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.SmallChangeProperty.Id, "SmallChange");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.ValueProperty.Id, "Value");

        public RangeValuePattern(BasicAutomationElementBase basicAutomationElement, UIA.RangeValuePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IRangeValuePatternProperties Properties => Automation.PropertyLibrary.RangeValue;

        public bool IsReadOnly => Get<bool>(IsReadOnlyProperty);

        public double LargeChange => Get<double>(LargeChangeProperty);

        public double Maximum => Get<double>(MaximumProperty);

        public double Minimum => Get<double>(MinimumProperty);

        public double SmallChange => Get<double>(SmallChangeProperty);

        public double Value => Get<double>(ValueProperty);

        public void SetValue(double val)
        {
            NativePattern.SetValue(val);
        }
    }

    public class RangeValuePatternProperties : IRangeValuePatternProperties
    {
        public PropertyId IsReadOnlyProperty => RangeValuePattern.IsReadOnlyProperty;

        public PropertyId LargeChangeProperty => RangeValuePattern.LargeChangeProperty;

        public PropertyId MaximumProperty => RangeValuePattern.MaximumProperty;

        public PropertyId MinimumProperty => RangeValuePattern.MinimumProperty;

        public PropertyId SmallChangeProperty => RangeValuePattern.SmallChangeProperty;

        public PropertyId ValueProperty => RangeValuePattern.ValueProperty;
    }
}
