using FlaUI.Core.Input;
using FlaUI.Core.Tools;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a thumb element.
    /// </summary>
    public class Thumb : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="Thumb"/> element.
        /// </summary>
        public Thumb(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Moves the slider horizontally.
        /// </summary>
        /// <param name="distance">The distance to move the slider, + for right, - for left.</param>
        public void SlideHorizontally(int distance)
        {
            Mouse.DragHorizontally(Properties.BoundingRectangle.Value.Center(), distance);
        }

        /// <summary>
        /// Moves the slider vertically.
        /// </summary>
        /// <param name="distance">The distance to move the slider, + for down, - for up.</param>
        public void SlideVertically(int distance)
        {
            Mouse.DragVertically(Properties.BoundingRectangle.Value.Center(), distance);
        }
    }
}
