using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class RangeValuePattern : PatternBaseWithInformation<IUIAutomationRangeValuePattern, RangeValuePatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_RangeValuePatternId, "RangeValue");
        public static readonly AutomationProperty IsReadOnlyProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_RangeValueIsReadOnlyPropertyId, "IsReadOnly");
        public static readonly AutomationProperty LargeChangeProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_RangeValueLargeChangePropertyId, "LargeChange");
        public static readonly AutomationProperty MaximumProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_RangeValueMaximumPropertyId, "Maximum");
        public static readonly AutomationProperty MinimumProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_RangeValueMinimumPropertyId, "Minimum");
        public static readonly AutomationProperty SmallChangeProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_RangeValueSmallChangePropertyId, "SmallChange");
        public static readonly AutomationProperty ValueProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_RangeValueValuePropertyId, "Value");

        internal RangeValuePattern(AutomationElement automationElement, IUIAutomationRangeValuePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new RangeValuePatternInformation(element, cached))
        {
        }

        public void SetValue(double val)
        {
            ComCallWrapper.Call(() => NativePattern.SetValue(val));
        }
    }

    public class RangeValuePatternInformation : InformationBase
    {
        public RangeValuePatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public bool IsReadOnly
        {
            get { return Get<bool>(RangeValuePattern.IsReadOnlyProperty); }
        }

        public double LargeChange
        {
            get { return Get<double>(RangeValuePattern.LargeChangeProperty); }
        }

        public double Maximum
        {
            get { return Get<double>(RangeValuePattern.MaximumProperty); }
        }

        public double Minimum
        {
            get { return Get<double>(RangeValuePattern.MinimumProperty); }
        }

        public double SmallChange
        {
            get { return Get<double>(RangeValuePattern.SmallChangeProperty); }
        }

        public double Value
        {
            get { return Get<double>(RangeValuePattern.ValueProperty); }
        }
    }
}
