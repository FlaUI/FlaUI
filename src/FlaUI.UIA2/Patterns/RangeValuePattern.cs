using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class RangeValuePattern : RangeValuePatternBase<UIA.RangeValuePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.RangeValuePattern.Pattern.Id, "RangeValue", AutomationObjectIds.IsRangeValuePatternAvailableProperty);
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.IsReadOnlyProperty.Id, "IsReadOnly");
        public static readonly PropertyId LargeChangeProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.LargeChangeProperty.Id, "LargeChange");
        public static readonly PropertyId MaximumProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.MaximumProperty.Id, "Maximum");
        public static readonly PropertyId MinimumProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.MinimumProperty.Id, "Minimum");
        public static readonly PropertyId SmallChangeProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.SmallChangeProperty.Id, "SmallChange");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.ValueProperty.Id, "Value");

        public RangeValuePattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.RangeValuePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void SetValue(double val)
        {
            NativePattern.SetValue(val);
        }
    }

    public class RangeValuePatternProperties : IRangeValuePatternProperties
    {
        public PropertyId IsReadOnly => RangeValuePattern.IsReadOnlyProperty;

        public PropertyId LargeChange => RangeValuePattern.LargeChangeProperty;

        public PropertyId Maximum => RangeValuePattern.MaximumProperty;

        public PropertyId Minimum => RangeValuePattern.MinimumProperty;

        public PropertyId SmallChange => RangeValuePattern.SmallChangeProperty;

        public PropertyId Value => RangeValuePattern.ValueProperty;
    }
}
