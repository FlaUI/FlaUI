using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ScrollPattern : PatternBaseWithInformation<UIA.ScrollPattern, ScrollPatternInformation>, IScrollPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ScrollPattern.Pattern.Id, "Scroll", AutomationObjectIds.IsScrollPatternAvailableProperty);
        public static readonly PropertyId HorizontallyScrollableProperty = PropertyId.Register(AutomationType.UIA2, UIA.ScrollPattern.HorizontallyScrollableProperty.Id, "HorizontallyScrollable");
        public static readonly PropertyId HorizontalScrollPercentProperty = PropertyId.Register(AutomationType.UIA2, UIA.ScrollPattern.HorizontalScrollPercentProperty.Id, "HorizontalScrollPercent");
        public static readonly PropertyId HorizontalViewSizeProperty = PropertyId.Register(AutomationType.UIA2, UIA.ScrollPattern.HorizontalViewSizeProperty.Id, "HorizontalViewSize");
        public static readonly PropertyId VerticallyScrollableProperty = PropertyId.Register(AutomationType.UIA2, UIA.ScrollPattern.VerticallyScrollableProperty.Id, "VerticallyScrollable");
        public static readonly PropertyId VerticalScrollPercentProperty = PropertyId.Register(AutomationType.UIA2, UIA.ScrollPattern.VerticalScrollPercentProperty.Id, "VerticalScrollPercent");
        public static readonly PropertyId VerticalViewSizeProperty = PropertyId.Register(AutomationType.UIA2, UIA.ScrollPattern.VerticalViewSizeProperty.Id, "VerticalViewSize");

        public ScrollPattern(BasicAutomationElementBase basicAutomationElement, UIA.ScrollPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IScrollPatternInformation IPatternWithInformation<IScrollPatternInformation>.Cached => Cached;

        IScrollPatternInformation IPatternWithInformation<IScrollPatternInformation>.Current => Current;

        public IScrollPatternProperties Properties => Automation.PropertyLibrary.Scroll;

        protected override ScrollPatternInformation CreateInformation(bool cached)
        {
            return new ScrollPatternInformation(BasicAutomationElement, cached);
        }

        public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
        {
            NativePattern.Scroll((UIA.ScrollAmount)horizontalAmount, (UIA.ScrollAmount)verticalAmount);
        }

        public void SetScrollPercent(double horizontalPercent, double verticalPercent)
        {
            NativePattern.SetScrollPercent(horizontalPercent, verticalPercent);
        }
    }

    public class ScrollPatternInformation : InformationBase, IScrollPatternInformation
    {
        public ScrollPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public bool HorizontallyScrollable => Get<bool>(ScrollPattern.HorizontallyScrollableProperty);

        public double HorizontalScrollPercent => Get<double>(ScrollPattern.HorizontalScrollPercentProperty);

        public double HorizontalViewSize => Get<double>(ScrollPattern.HorizontalViewSizeProperty);

        public bool VerticallyScrollable => Get<bool>(ScrollPattern.VerticallyScrollableProperty);

        public double VerticalScrollPercent => Get<double>(ScrollPattern.VerticalScrollPercentProperty);

        public double VerticalViewSize => Get<double>(ScrollPattern.VerticalViewSizeProperty);
    }

    public class ScrollPatternProperties : IScrollPatternProperties
    {
        public PropertyId HorizontallyScrollableProperty => ScrollPattern.HorizontallyScrollableProperty;

        public PropertyId HorizontalScrollPercentProperty => ScrollPattern.HorizontalScrollPercentProperty;

        public PropertyId HorizontalViewSizeProperty => ScrollPattern.HorizontalViewSizeProperty;

        public PropertyId VerticallyScrollableProperty => ScrollPattern.VerticallyScrollableProperty;

        public PropertyId VerticalScrollPercentProperty => ScrollPattern.VerticalScrollPercentProperty;

        public PropertyId VerticalViewSizeProperty => ScrollPattern.VerticalViewSizeProperty;
    }
}
