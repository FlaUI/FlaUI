using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;
using ScrollAmount = FlaUI.Core.Definitions.ScrollAmount;

namespace FlaUI.Core.Patterns
{
    public class ScrollPattern : PatternBaseWithInformation<IUIAutomationScrollPattern, ScrollPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_ScrollPatternId, "Scroll");
        public static readonly PropertyId HorizontallyScrollableProperty = PropertyId.Register(UIA_PropertyIds.UIA_ScrollHorizontallyScrollablePropertyId, "HorizontallyScrollable");
        public static readonly PropertyId HorizontalScrollPercentProperty = PropertyId.Register(UIA_PropertyIds.UIA_ScrollHorizontalScrollPercentPropertyId, "HorizontalScrollPercent");
        public static readonly PropertyId HorizontalViewSizeProperty = PropertyId.Register(UIA_PropertyIds.UIA_ScrollHorizontalViewSizePropertyId, "HorizontalViewSize");
        public static readonly PropertyId VerticallyScrollableProperty = PropertyId.Register(UIA_PropertyIds.UIA_ScrollVerticallyScrollablePropertyId, "VerticallyScrollable");
        public static readonly PropertyId VerticalScrollPercentProperty = PropertyId.Register(UIA_PropertyIds.UIA_ScrollVerticalScrollPercentPropertyId, "VerticalScrollPercent");
        public static readonly PropertyId VerticalViewSizeProperty = PropertyId.Register(UIA_PropertyIds.UIA_ScrollVerticalViewSizePropertyId, "VerticalViewSize");

        internal ScrollPattern(AutomationElement automationElement, IUIAutomationScrollPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new ScrollPatternInformation(element, cached))
        {
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
        public ScrollPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
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
