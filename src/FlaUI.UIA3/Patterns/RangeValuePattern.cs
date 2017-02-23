using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class RangeValuePattern : PatternBase<UIA.IUIAutomationRangeValuePattern>, IRangeValuePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_RangeValuePatternId, "RangeValue", AutomationObjectIds.IsRangeValuePatternAvailableProperty);
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_RangeValueIsReadOnlyPropertyId, "IsReadOnly");
        public static readonly PropertyId LargeChangeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_RangeValueLargeChangePropertyId, "LargeChange");
        public static readonly PropertyId MaximumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_RangeValueMaximumPropertyId, "Maximum");
        public static readonly PropertyId MinimumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_RangeValueMinimumPropertyId, "Minimum");
        public static readonly PropertyId SmallChangeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_RangeValueSmallChangePropertyId, "SmallChange");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_RangeValueValuePropertyId, "Value");

        public RangeValuePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationRangeValuePattern nativePattern) : base(basicAutomationElement, nativePattern)
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
            ComCallWrapper.Call(() => NativePattern.SetValue(val));
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
