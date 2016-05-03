using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ScrollPattern : PatternBaseWithInformation<IUIAutomationScrollPattern, ScrollPatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_ScrollPatternId, "Scroll");
        public static readonly AutomationProperty HorizontallyScrollableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ScrollHorizontallyScrollablePropertyId, "HorizontallyScrollable");
        public static readonly AutomationProperty HorizontalScrollPercentProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ScrollHorizontalScrollPercentPropertyId, "HorizontalScrollPercent");
        public static readonly AutomationProperty HorizontalViewSizeProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ScrollHorizontalViewSizePropertyId, "HorizontalViewSize");
        public static readonly AutomationProperty VerticallyScrollableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ScrollVerticallyScrollablePropertyId, "VerticallyScrollable");
        public static readonly AutomationProperty VerticalScrollPercentProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ScrollVerticalScrollPercentPropertyId, "VerticalScrollPercent");
        public static readonly AutomationProperty VerticalViewSizeProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ScrollVerticalViewSizePropertyId, "VerticalViewSize");

        internal ScrollPattern(AutomationElement automationElement, IUIAutomationScrollPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new ScrollPatternInformation(element, cached))
        {
        }

        public void Scroll(Definitions.ScrollAmount horizontalAmount, Definitions.ScrollAmount verticalAmount)
        {
            ComCallWrapper.Call(() => NativePattern.Scroll((ScrollAmount)horizontalAmount, (ScrollAmount)verticalAmount));
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
