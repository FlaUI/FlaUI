using FlaUI.Core.Input;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class Thumb : AutomationElement
    {
        public Thumb(Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        /// <summary>
        /// Moves the slider horizontally
        /// </summary>
        /// <param name="distance">+ for right, - for left</param>
        public void SlideHorizontally(int distance)
        {
            Automation.Mouse.DragHorizontally(MouseButton.Left, Current.BoundingRectangle.Center, distance);
        }

        /// <summary>
        /// Moves the slider vertically
        /// </summary>
        /// <param name="distance">+ for down, - for up</param>
        public void SlideVertically(int distance)
        {
            Automation.Mouse.DragVertically(MouseButton.Left, Current.BoundingRectangle.Center, distance);
        }
    }
}
