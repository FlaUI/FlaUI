using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public class ScrollPatternConstants
    {
        public const double NoScroll = -1.0;
    }

    public interface IScrollPattern : IPattern
    {
        IScrollPatternProperties Properties { get; }
        bool HorizontallyScrollable { get; }
        double HorizontalScrollPercent { get; }
        double HorizontalViewSize { get; }
        bool VerticallyScrollable { get; }
        double VerticalScrollPercent { get; }
        double VerticalViewSize { get; }
        void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
        void SetScrollPercent(double horizontalPercent, double verticalPercent);
    }
    
    public interface IScrollPatternProperties
    {
        PropertyId HorizontallyScrollableProperty { get; }
        PropertyId HorizontalScrollPercentProperty { get; }
        PropertyId HorizontalViewSizeProperty { get; }
        PropertyId VerticallyScrollableProperty { get; }
        PropertyId VerticalScrollPercentProperty { get; }
        PropertyId VerticalViewSizeProperty { get; }
    }
}
