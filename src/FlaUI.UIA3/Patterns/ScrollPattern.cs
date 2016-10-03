using FlaUI.Core;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ScrollPattern : PatternBaseWithInformation<ScrollPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ScrollPatternId, "Scroll");
        public static readonly PropertyId HorizontallyScrollableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollHorizontallyScrollablePropertyId, "HorizontallyScrollable");
        public static readonly PropertyId HorizontalScrollPercentProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollHorizontalScrollPercentPropertyId, "HorizontalScrollPercent");
        public static readonly PropertyId HorizontalViewSizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollHorizontalViewSizePropertyId, "HorizontalViewSize");
        public static readonly PropertyId VerticallyScrollableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollVerticallyScrollablePropertyId, "VerticallyScrollable");
        public static readonly PropertyId VerticalScrollPercentProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollVerticalScrollPercentPropertyId, "VerticalScrollPercent");
        public static readonly PropertyId VerticalViewSizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollVerticalViewSizePropertyId, "VerticalViewSize");

        internal ScrollPattern(AutomationElement automationAutomationElement, UIA.IUIAutomationScrollPattern nativePattern)
            : base(automationAutomationElement, nativePattern, (element, cached) => new ScrollPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationScrollPattern NativePattern
        {
            get { return (UIA.IUIAutomationScrollPattern)base.NativePattern; }
        }

        public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
        {
            ComCallWrapper.Call(() => NativePattern.Scroll((interop.UIAutomationCore.ScrollAmount)horizontalAmount, (interop.UIAutomationCore.ScrollAmount)verticalAmount));
        }

        public void SetScrollPercent(double horizontalPercent, double verticalPercent)
        {
            ComCallWrapper.Call(() => NativePattern.SetScrollPercent(horizontalPercent, verticalPercent));
        }
    }

    public class ScrollPatternInformation : InformationBase
    {
        public ScrollPatternInformation(AutomationElement automationAutomationElement, bool cached)
            : base(automationAutomationElement, cached)
        {
        }

        public bool HorizontallyScrollable
        {
            get { return Get<bool>(ScrollPattern.HorizontallyScrollableProperty); }
        }

        public double HorizontalScrollPercent
        {
            get { return Get<double>(ScrollPattern.HorizontalScrollPercentProperty); }
        }

        public double HorizontalViewSize
        {
            get { return Get<double>(ScrollPattern.HorizontalViewSizeProperty); }
        }

        public bool VerticallyScrollable
        {
            get { return Get<bool>(ScrollPattern.VerticallyScrollableProperty); }
        }

        public double VerticalScrollPercent
        {
            get { return Get<double>(ScrollPattern.VerticalScrollPercentProperty); }
        }

        public double VerticalViewSize
        {
            get { return Get<double>(ScrollPattern.VerticalViewSizeProperty); }
        }
    }
}
