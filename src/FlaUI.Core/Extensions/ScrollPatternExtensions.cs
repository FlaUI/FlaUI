using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IScrollPattern"/> objects.
    /// </summary>
    public static class ScrollPatternExtensions
    {
        /// <summary>
        /// Scrolls horizontally by the specified amount.
        /// </summary>
        /// <param name="pattern">Scroll pattern object to act upon.</param>
        /// <param name="horizontalAmount">Amount to scroll horizontally.</param>
        public static void ScrollHorizontally(this IScrollPattern pattern, ScrollAmount horizontalAmount)
        {
            pattern.Scroll(horizontalAmount, ScrollAmount.NoAmount);
        }

        /// <summary>
        /// Scrolls vertically by the specified amount.
        /// </summary>
        /// <param name="pattern">Scroll pattern object to act upon.</param>
        /// <param name="verticalAmount">Amount to scroll vertically.</param>
        public static void ScrollVertically(this IScrollPattern pattern, ScrollAmount verticalAmount)
        {
            pattern.Scroll(ScrollAmount.NoAmount, verticalAmount);
        }

        /// <summary>
        /// Scrolls horizontally by the specified percentage.
        /// </summary>
        /// <param name="pattern">Scroll pattern object to act upon.</param>
        /// <param name="horizontalPercent">Percentage to scroll horizontally.</param>
        public static void SetHorizontalScrollPercent(this IScrollPattern pattern, double horizontalPercent)
        {
            pattern.SetScrollPercent(horizontalPercent, ScrollPatternConstants.NoScroll);
        }

        /// <summary>
        /// Scrolls vertically by the specified percentage.
        /// </summary>
        /// <param name="pattern">Scroll pattern object to act upon.</param>
        /// <param name="verticalPercent">Percentage to scroll vertically.</param>
        public static void SetVerticalScrollPercent(this IScrollPattern pattern, double verticalPercent)
        {
            pattern.SetScrollPercent(ScrollPatternConstants.NoScroll, verticalPercent);
        }
    }
}
