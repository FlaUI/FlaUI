using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;

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
        /// Moves the slider horizontally
        /// </summary>
        /// <param name="distance">+ for right, - for left</param>
        public void SlideHorizontally(int distance)
        {
            Mouse.DragHorizontally(MouseButton.Left, Properties.BoundingRectangle.Value.Center, distance);
        }

        /// <summary>
        /// Moves the slider vertically
        /// </summary>
        /// <param name="distance">+ for down, - for up</param>
        public void SlideVertically(int distance)
        {
            Mouse.DragVertically(MouseButton.Left, Properties.BoundingRectangle.Value.Center, distance);
        }
    }
}
