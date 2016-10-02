using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class RangeValuePattern : PatternBaseWithInformation<UIA.RangeValuePattern, RangeValuePatternInformation>, IRangeValuePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.RangeValuePattern.Pattern.Id, "RangeValue");
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.IsReadOnlyProperty.Id, "IsReadOnly");
        public static readonly PropertyId LargeChangeProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.LargeChangeProperty.Id, "LargeChange");
        public static readonly PropertyId MaximumProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.MaximumProperty.Id, "Maximum");
        public static readonly PropertyId MinimumProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.MinimumProperty.Id, "Minimum");
        public static readonly PropertyId SmallChangeProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.SmallChangeProperty.Id, "SmallChange");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA2, UIA.RangeValuePattern.ValueProperty.Id, "Value");

        public RangeValuePattern(AutomationObjectBase automationObject, UIA.RangeValuePattern nativePattern) : base(automationObject, nativePattern)
        {
            Properties = new RangeValuePatternProperties();
        }

        IRangeValuePatternInformation IPatternWithInformation<IRangeValuePatternInformation>.Cached => Cached;

        IRangeValuePatternInformation IPatternWithInformation<IRangeValuePatternInformation>.Current => Current;

        public IRangeValuePatternProperties Properties { get; }

        protected override RangeValuePatternInformation CreateInformation(bool cached)
        {
            return new RangeValuePatternInformation(AutomationObject, cached);
        }

        public void SetValue(double val)
        {
            NativePattern.SetValue(val);
        }
    }

    public class RangeValuePatternInformation : ElementInformationBase, IRangeValuePatternInformation
    {
        public RangeValuePatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool IsReadOnly => Get<bool>(RangeValuePattern.IsReadOnlyProperty);

        public double LargeChange => Get<double>(RangeValuePattern.LargeChangeProperty);

        public double Maximum => Get<double>(RangeValuePattern.MaximumProperty);

        public double Minimum => Get<double>(RangeValuePattern.MinimumProperty);

        public double SmallChange => Get<double>(RangeValuePattern.SmallChangeProperty);

        public double Value => Get<double>(RangeValuePattern.ValueProperty);
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
