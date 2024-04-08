using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.Tools
{
    /// <summary>
    /// Helper class which tries to load all items for an item container.
    /// </summary>
    public static class ItemRealizer
    {
        /// <summary>
        /// Tries to realize all items in the given item container.
        /// </summary>
        /// <param name="itemContainerElement">The item container whose items should be realized.</param>
        public static void RealizeItems(AutomationElement itemContainerElement)
        {
            // We save the scroll value to restore it afterwards
            var scrollPattern = itemContainerElement.Patterns.Scroll.PatternOrDefault;
            double currentHorizontalScrollPercent = 0;
            double currentVerticalScrollPercent = 0;
            if (scrollPattern != null)
            {
                currentHorizontalScrollPercent = scrollPattern.HorizontalScrollPercent;
                currentVerticalScrollPercent = scrollPattern.VerticalScrollPercent;
            }

            // First we try with the item container pattern and realize each item
            var itemContainerPattern = itemContainerElement.Patterns.ItemContainer.PatternOrDefault;
            if (itemContainerPattern != null)
            {
                // There's the item container pattern so we can go thru all elements and just realize them
                AutomationElement? currentElement = null;
                while (true)
                {
                    currentElement = itemContainerPattern.FindItemByProperty(currentElement, null, null);
                    if (currentElement == null)
                    {
                        break;
                    }
                    var vp = currentElement.Patterns.VirtualizedItem.PatternOrDefault;
                    vp?.Realize();
                }
                ResetScroll(scrollPattern, currentHorizontalScrollPercent, currentVerticalScrollPercent);
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
                ResetScroll(scrollPattern, currentHorizontalScrollPercent, currentVerticalScrollPercent);
                return;
            }

            // Third we try by using the scrollbar controls itself
            {
                // TODO
            }
        }

        private static void ResetScroll(IScrollPattern? scrollPattern, double hScrollPercentage, double vScrollPercentage)
        {
            scrollPattern?.SetScrollPercent(hScrollPercentage, vScrollPercentage);
        }
    }
}
