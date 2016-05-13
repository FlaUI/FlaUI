using FlaUI.Core.Shapes;

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
        /// Moves the mouse to a new position
        /// </summary>
        /// <param name="newPosition">The new position for the mouse</param>
        void MoveTo(Point newPosition);

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
        void Down(MouseButton mouseButton);

        /// <summary>
        /// Sends a mouse up command for the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to release</param>
        void Up(MouseButton mouseButton);

        /// <summary>
        /// Simulates scrolling of the mouse wheel up or down
        /// </summary>
        void Scroll(double lines);

        /// <summary>
        /// Simulates scrolling of the horizontal mouse wheel left or right
        /// </summary>
        void HorizontalScroll(double lines);

        /// <summary>
        /// Drags the mouse horizontally
        /// </summary>
        /// <param name="mouseButton">The mouse button to use for dragging</param>
        /// <param name="startingPoint">Starting point of the drag</param>
        /// <param name="distance">The distance to drag, + for right, - for left</param>
        void DragHorizontally(MouseButton mouseButton, Point startingPoint, double distance);

        /// <summary>
        /// Drags the mouse vertically
        /// </summary>
        /// <param name="mouseButton">The mouse button to use for dragging</param>
        /// <param name="startingPoint">Starting point of the drag</param>
        /// <param name="distance">The distance to drag, + for down, - for up</param>
        void DragVertically(MouseButton mouseButton, Point startingPoint, double distance);
    }
}
