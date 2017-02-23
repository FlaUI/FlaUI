using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.Tools
{
    /// <summary>
    /// Helper class which tries to load all items for an item container
    /// </summary>
    public static class ItemRealizer
    {
        public static void RealizeItems(AutomationElement itemContainerElement)
        {
            // We save the scroll value to restore it afterwards
            var scrollPattern = itemContainerElement.PatternFactory.GetScrollPattern();
            double currHScroll = 0;
            double currVScroll = 0;
            if (scrollPattern != null)
            {
                currHScroll = scrollPattern.HorizontalScrollPercent;
                currVScroll = scrollPattern.VerticalScrollPercent;
            }

            // First we try with the item container pattern and realize each item
            var itemContainerPattern = itemContainerElement.PatternFactory.GetItemContainerPattern();
            if (itemContainerPattern != null)
            {
                // There's the item container pattern so we can go thru all elements and just realize them
                AutomationElement currElement = null;
                while (true)
                {
                    currElement = itemContainerPattern.FindItemByProperty(currElement, null, null);
                    if (currElement == null)
                    {
                        break;
                    }
                    var vp = currElement.PatternFactory.GetVirtualizedItemPattern();
                    if (vp != null)
                    {
                        vp.Realize();
                    }
                }
                ResetScroll(scrollPattern, currHScroll, currVScroll);
                return;
            }

            // Second we use the scroll pattern to scroll from top to bottom
            if (scrollPattern != null)
            {
                scrollPattern.SetScrollPercent(0, 0);
                do
                {
                    scrollPattern.Scroll(ScrollAmount.NoAmount, ScrollAmount.SmallIncrement);
                } while (scrollPattern.VerticalScrollPercent < 100);
                ResetScroll(scrollPattern, currHScroll, currVScroll);
                return;
            }

            // Third we try by using the scrollbar controls itself
            // TODO
        }

        private static void ResetScroll(IScrollPattern scrollPattern, double hScrollPercentage, double vScrollPercentage)
        {
            scrollPattern?.SetScrollPercent(hScrollPercentage, vScrollPercentage);
        }
    }
}
