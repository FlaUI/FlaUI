using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Input;

namespace FlaUI.Core.AutomationElements
{
    public class Thumb : AutomationElement
    {
        public Thumb(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// Moves the slider horizontally
        /// </summary>
        /// <param name="distance">+ for right, - for left</param>
        public void SlideHorizontally(int distance)
        {
            Mouse.DragHorizontally(MouseButton.Left, Current.BoundingRectangle.Center, distance);
        }

        /// <summary>
        /// Moves the slider vertically
        /// </summary>
        /// <param name="distance">+ for down, - for up</param>
        public void SlideVertically(int distance)
        {
            Mouse.DragVertically(MouseButton.Left, Current.BoundingRectangle.Center, distance);
        }
    }
}
