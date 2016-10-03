using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Input;

namespace FlaUI.Core.Elements
{
    public class Thumb : Element
    {
        public Thumb(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        /// <summary>
        /// Moves the slider horizontally
        /// </summary>
        /// <param name="distance">+ for right, - for left</param>
        public void SlideHorizontally(int distance)
        {
            Mouse.Instance.DragHorizontally(MouseButton.Left, Current.BoundingRectangle.Center, distance);
        }

        /// <summary>
        /// Moves the slider vertically
        /// </summary>
        /// <param name="distance">+ for down, - for up</param>
        public void SlideVertically(int distance)
        {
            Mouse.Instance.DragVertically(MouseButton.Left, Current.BoundingRectangle.Center, distance);
        }
    }
}
