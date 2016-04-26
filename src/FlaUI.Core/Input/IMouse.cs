using System.Windows;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Interface for the mouse
    /// </summary>
    public interface IMouse
    {
        /// <summary>
        /// Current position of the mouse cursor
        /// </summary>
        Point Position { get; set; }

        /// <summary>
        /// Flag to indicate if the buttons are swapped (left-handed)
        /// </summary>
        bool AreButtonsSwapped { get; }

        /// <summary>
        /// Moves the mouse by a given delta from the current position
        /// </summary>
        /// <param name="deltaX">The delta for the x-axis</param>
        /// <param name="deltaY">The delta for the y-axis</param>
        void MoveBy(int deltaX, int deltaY);

        /// <summary>
        /// Moves the mouse to a new position
        /// </summary>
        /// <param name="newX">The new position on the x-axis</param>
        /// <param name="newY">The new position on the y-axis</param>
        void MoveTo(int newX, int newY);

        /// <summary>
        /// Clicks the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to click</param>
        void Click(MouseButton mouseButton);

        /// <summary>
        /// Moves to a specific position and clicks the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to click</param>
        /// <param name="point">The position to move to before clicking</param>
        void Click(MouseButton mouseButton, Point point);

        /// <summary>
        /// Double-clicks the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to double-click</param>
        void DoubleClick(MouseButton mouseButton);

        /// <summary>
        /// Moves to a specific position and double-clicks the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to double-click</param>
        /// <param name="point">The position to move to before double-clicking</param>
        void DoubleClick(MouseButton mouseButton, Point point);

        /// <summary>
        /// Sends a mouse down command for the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to press</param>
        void MouseDown(MouseButton mouseButton);

        /// <summary>
        /// Sends a mouse up command for the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to release</param>
        void MouseUp(MouseButton mouseButton);
    }
}
