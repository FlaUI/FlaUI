namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the direction and distance to scroll.
    /// </summary>
    public enum ScrollAmount
    {
        /// <summary>
        /// Scrolling is done in large decrements, equivalent to pressing the PAGE UP key or clicking on a blank part of a scroll bar.
        /// If one page up is not a relevant amount for the control and no scroll bar exists, the value represents an amount equal to the current visible window.
        /// </summary>
        LargeDecrement = 0,

        /// <summary>
        /// Scrolling is done in small decrements, equivalent to pressing an arrow key or clicking the arrow button on a scroll bar.
        /// </summary>
        SmallDecrement = 1,

        /// <summary>
        /// No scrolling is done.
        /// </summary>
        NoAmount = 2,

        /// <summary>
        /// Scrolling is done in large increments, equivalent to pressing the PAGE DOWN or PAGE UP key or clicking on a blank part of a scroll bar.
        /// If one page is not a relevant amount for the control and no scroll bar exists, the value represents an amount equal to the current visible window.
        /// </summary>
        LargeIncrement = 3,

        /// <summary>
        /// Scrolling is done in small increments, equivalent to pressing an arrow key or clicking the arrow button on a scroll bar.
        /// </summary>
        SmallIncrement = 4
    }
}
