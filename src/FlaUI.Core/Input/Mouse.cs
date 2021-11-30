using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Mouse class to simulate mouse input.
    /// </summary>
    public static class Mouse
    {
        /// <summary>
        /// Time to add to the double click time to prevent false double clicks.
        /// </summary>
        private const int ExtraMillisecondsBecauseOfBugInWindows = 13;

        /// <summary>
        /// Number which defines one wheel "click" of the mouse wheel.
        /// </summary>
        private const int WheelDelta = 120;

        /// <summary>
        /// The current max timespan (in milliseconds) for double clicks.
        /// </summary>
        private static readonly int CurrentDoubleClickTime;

        /// <summary>
        /// Dictionary which holds the last click time for each button.
        /// </summary>
        private static readonly Dictionary<MouseButton, DateTime> LastClickTimes;

        /// <summary>
        /// Dictionary which holds the last click position for each button.
        /// </summary>
        private static readonly Dictionary<MouseButton, Point> LastClickPositions;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Mouse()
        {
            CurrentDoubleClickTime = (int)User32.GetDoubleClickTime();
            LastClickTimes = new Dictionary<MouseButton, DateTime>();
            LastClickPositions = new Dictionary<MouseButton, Point>();
            foreach (MouseButton mouseButton in Enum.GetValues(typeof(MouseButton)))
            {
                LastClickTimes.Add(mouseButton, DateTime.UtcNow);
                LastClickPositions.Add(mouseButton, new Point(0, 0));
            }
        }

        /// <summary>
        /// The number of pixels the mouse is moved per millisecond.
        /// Used to calculate the duration of a mouse move.
        /// </summary>
        public static double MovePixelsPerMillisecond { get; set; } = 0.5;

        /// <summary>
        /// The number of pixels the mouse is moved per step.
        /// Used to calculate the interval of a mouse move.
        /// </summary>
        public static double MovePixelsPerStep { get; set; } = 10;

        /// <summary>
        /// The current position of the mouse cursor.
        /// </summary>
        public static Point Position
        {
            get
            {
                User32.GetCursorPos(out var point);
                return new Point(point.X, point.Y);
            }
            set
            {
                User32.SetCursorPos(value.X, value.Y);
                // There is a bug that in a multi-monitor scenario with different sizes,
                // the mouse is only moved to x=0 on the target monitor.
                // In that case, just redo the move a 2nd time and it works
                // as the mouse is on the correct monitor alreay.
                // See https://stackoverflow.com/questions/58753372/winapi-setcursorpos-seems-like-not-working-properly-on-multiple-monitors-with-di
                User32.GetCursorPos(out var point);
                if (point.X != value.X || point.Y != value.Y)
                {
                    User32.SetCursorPos(value.X, value.Y);
                }
            }
        }

        /// <summary>
        /// Flag to indicate if the buttons are swapped (left-handed).
        /// </summary>
        public static bool AreButtonsSwapped => User32.GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) != 0;

        /// <summary>
        /// Moves the mouse by a given delta from the current position.
        /// </summary>
        /// <param name="deltaX">The delta for the x-axis.</param>
        /// <param name="deltaY">The delta for the y-axis.</param>
        public static void MoveBy(int deltaX, int deltaY)
        {
            var currentPosition = Position;
            MoveTo(currentPosition.X + deltaX, currentPosition.Y + deltaY);
        }

        /// <summary>
        /// Moves the mouse to a new position.
        /// </summary>
        /// <param name="newX">The new position on the x-axis.</param>
        /// <param name="newY">The new position on the y-axis.</param>
        public static void MoveTo(int newX, int newY)
        {
            // Get starting position
            var startPos = Position;
            var endPos = new Point(newX, newY);

            // Break out if there is no positional change
            if (startPos == endPos)
            {
                return;
            }

            // Calculate some values for duration and interval
            var totalDistance = startPos.Distance(newX, newY);
            var duration = TimeSpan.FromMilliseconds(Convert.ToInt32(totalDistance / MovePixelsPerMillisecond));
            var steps = Math.Max(Convert.ToInt32(totalDistance / MovePixelsPerStep), 1); // Make sure to have et least one step
            var interval = TimeSpan.FromMilliseconds(duration.TotalMilliseconds / steps);

            // Execute the movement
            Interpolation.Execute(point => { Position = point; }, startPos, endPos, duration, interval, true);
            Wait.UntilInputIsProcessed();
        }

        /// <summary>
        /// Moves the mouse to a new position.
        /// </summary>
        /// <param name="newPosition">The new position for the mouse.</param>
        public static void MoveTo(Point newPosition)
        {
            MoveTo(newPosition.X, newPosition.Y);
        }

        /// <summary>
        /// Clicks the specified mouse button at the current location.
        /// </summary>
        /// <param name="mouseButton">The mouse button to click. Defaults to the left button.</param>
        public static void Click(MouseButton mouseButton = MouseButton.Left)
        {
            var currentClickPosition = Position;
            // Check if the position is the same as with last click
            if (LastClickPositions[mouseButton].Equals(currentClickPosition))
            {
                // Get the timeout needed to not fire a double click
                var timeout = CurrentDoubleClickTime - DateTime.UtcNow.Subtract(LastClickTimes[mouseButton]).Milliseconds;
                // Wait the needed time to prevent the double click
                if (timeout > 0) Thread.Sleep(timeout + ExtraMillisecondsBecauseOfBugInWindows);
            }
            // Perform the click
            Down(mouseButton);
            Up(mouseButton);
            // Update the time and location
            LastClickTimes[mouseButton] = DateTime.UtcNow;
            LastClickPositions[mouseButton] = Position;
        }

        /// <summary>
        /// Moves to a specific position and clicks the specified mouse button.
        /// </summary>
        /// <param name="point">The position to move to before clicking.</param>
        /// <param name="mouseButton">The mouse button to click. Defaults to the left button.</param>
        public static void Click(Point point, MouseButton mouseButton = MouseButton.Left)
        {
            Position = point;
            Click(mouseButton);
        }

        /// <summary>
        /// Double-clicks the specified mouse button at the current location.
        /// </summary>
        /// <param name="mouseButton">The mouse button to double-click. Defaults to the left button.</param>
        public static void DoubleClick(MouseButton mouseButton = MouseButton.Left)
        {
            Down(mouseButton);
            Up(mouseButton);
            Down(mouseButton);
            Up(mouseButton);
        }

        /// <summary>
        /// Moves to a specific position and double-clicks the specified mouse button.
        /// </summary>
        /// <param name="point">The position to move to before double-clicking.</param>
        /// <param name="mouseButton">The mouse button to double-click. Defaults to the left button.</param>
        public static void DoubleClick(Point point, MouseButton mouseButton = MouseButton.Left)
        {
            Position = point;
            DoubleClick(mouseButton);
        }

        /// <summary>
        /// Sends a mouse down command for the specified mouse button.
        /// </summary>
        /// <param name="mouseButton">The mouse button to press. Defaults to the left button.</param>
        public static void Down(MouseButton mouseButton = MouseButton.Left)
        {
            var flags = GetFlagsAndDataForButton(mouseButton, true, out var data);
            SendInput(0, 0, data, flags);
        }

        /// <summary>
        /// Sends a mouse up command for the specified mouse button.
        /// </summary>
        /// <param name="mouseButton">The mouse button to release. Defaults to the left button.</param>
        public static void Up(MouseButton mouseButton = MouseButton.Left)
        {
            var flags = GetFlagsAndDataForButton(mouseButton, false, out var data);
            SendInput(0, 0, data, flags);
        }

        /// <summary>
        /// Simulates scrolling of the mouse wheel up or down.
        /// </summary>
        public static void Scroll(double lines)
        {
            var amount = (uint)(WheelDelta * lines);
            SendInput(0, 0, amount, MouseEventFlags.MOUSEEVENTF_WHEEL);
        }

        /// <summary>
        /// Simulates scrolling of the horizontal mouse wheel left or right.
        /// </summary>
        public static void HorizontalScroll(double lines)
        {
            var amount = (uint)(WheelDelta * lines);
            SendInput(0, 0, amount, MouseEventFlags.MOUSEEVENTF_HWHEEL);
        }

        /// <summary>
        /// Drags the mouse horizontally.
        /// </summary>
        /// <param name="startingPoint">Starting point of the drag.</param>
        /// <param name="distance">The distance to drag, + for right, - for left.</param>
        /// <param name="mouseButton">The mouse button to use for dragging. Defaults to the left button.</param>
        public static void DragHorizontally(Point startingPoint, int distance, MouseButton mouseButton = MouseButton.Left)
        {
            Drag(startingPoint, distance, 0, mouseButton);
        }

        /// <summary>
        /// Drags the mouse vertically.
        /// </summary>
        /// <param name="startingPoint">Starting point of the drag</param>
        /// <param name="distance">The distance to drag, + for down, - for up</param>
        /// <param name="mouseButton">The mouse button to use for dragging. Defaults to the left button.</param>
        public static void DragVertically(Point startingPoint, int distance, MouseButton mouseButton = MouseButton.Left)
        {
            Drag(startingPoint, 0, distance, mouseButton);
        }

        /// <summary>
        /// Drags the mouse from the starting point with the given distance.
        /// </summary>
        /// <param name="startingPoint">Starting point of the drag.</param>
        /// <param name="distanceX">The x distance to drag, + for down, - for up.</param>
        /// <param name="distanceY">The y distance to drag, + for right, - for left.</param>
        /// <param name="mouseButton">The mouse button to use for dragging. Defaults to the left button.</param>
        public static void Drag(Point startingPoint, int distanceX, int distanceY, MouseButton mouseButton = MouseButton.Left)
        {
            var endingPoint = new Point(startingPoint.X + distanceX, startingPoint.Y + distanceY);
            Drag(startingPoint, endingPoint, mouseButton);
        }

        /// <summary>
        /// Drags the mouse from the starting point to another point.
        /// </summary>
        /// <param name="startingPoint">Starting point of the drag.</param>
        /// <param name="endingPoint">Ending point of the drag.</param>
        /// <param name="mouseButton">The mouse button to use for dragging. Defaults to the left button.</param>
        public static void Drag(Point startingPoint, Point endingPoint, MouseButton mouseButton = MouseButton.Left)
        {
            Position = startingPoint;
            Wait.UntilInputIsProcessed();
            Down(mouseButton);
            Wait.UntilInputIsProcessed();
            Position = endingPoint;
            Wait.UntilInputIsProcessed();
            Up(mouseButton);
            Wait.UntilInputIsProcessed();
        }

        /// <summary>
        /// Converts the button to the correct <see cref="MouseEventFlags" /> object
        /// and fills the additional data if needed.
        /// </summary>
        private static MouseEventFlags GetFlagsAndDataForButton(MouseButton mouseButton, bool isDown, out uint data)
        {
            MouseEventFlags mouseEventFlags;
            var mouseData = MouseEventDataXButtons.NOTHING;
            switch (SwapButtonIfNeeded(mouseButton))
            {
                case MouseButton.Left:
                    mouseEventFlags = isDown ? MouseEventFlags.MOUSEEVENTF_LEFTDOWN : MouseEventFlags.MOUSEEVENTF_LEFTUP;
                    break;
                case MouseButton.Middle:
                    mouseEventFlags = isDown ? MouseEventFlags.MOUSEEVENTF_MIDDLEDOWN : MouseEventFlags.MOUSEEVENTF_MIDDLEUP;
                    break;
                case MouseButton.Right:
                    mouseEventFlags = isDown ? MouseEventFlags.MOUSEEVENTF_RIGHTDOWN : MouseEventFlags.MOUSEEVENTF_RIGHTUP;
                    break;
                case MouseButton.XButton1:
                    mouseEventFlags = isDown ? MouseEventFlags.MOUSEEVENTF_XDOWN : MouseEventFlags.MOUSEEVENTF_XUP;
                    mouseData = MouseEventDataXButtons.XBUTTON1;
                    break;
                case MouseButton.XButton2:
                    mouseEventFlags = isDown ? MouseEventFlags.MOUSEEVENTF_XDOWN : MouseEventFlags.MOUSEEVENTF_XUP;
                    mouseData = MouseEventDataXButtons.XBUTTON2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mouseButton));
            }
            data = (uint)mouseData;
            return mouseEventFlags;
        }

        /// <summary>
        /// Swaps the left/right button if <see cref="AreButtonsSwapped" /> is set.
        /// </summary>
        private static MouseButton SwapButtonIfNeeded(MouseButton mouseButton)
        {
            if (!AreButtonsSwapped) return mouseButton;
            switch (mouseButton)
            {
                case MouseButton.Left:
                    return MouseButton.Right;
                case MouseButton.Right:
                    return MouseButton.Left;
                default:
                    return mouseButton;
            }
        }

        /// <summary>
        /// Effectively sends the mouse input command.
        /// </summary>
        [PermissionSet(SecurityAction.Assert, Name = "FullTrust")]
        private static void SendInput(int x, int y, uint data, MouseEventFlags flags)
        {
            // Demand the correct permissions
            var permissions = new PermissionSet(PermissionState.Unrestricted);
            permissions.Demand();

            // Check if we are trying to do an absolute move
            if (flags.HasFlag(MouseEventFlags.MOUSEEVENTF_ABSOLUTE))
            {
                // Absolute position requires normalized coordinates
                NormalizeCoordinates(ref x, ref y);
                flags |= MouseEventFlags.MOUSEEVENTF_VIRTUALDESK;
            }

            // Build the mouse input object
            var mouseInput = new MOUSEINPUT
            {
                dx = x,
                dy = y,
                mouseData = data,
                dwExtraInfo = User32.GetMessageExtraInfo(),
                time = 0,
                dwFlags = flags
            };

            // Build the input object
            var input = INPUT.MouseInput(mouseInput);
            // Send the command
            if (User32.SendInput(1, new[] { input }, INPUT.Size) == 0)
            {
                // An error occured
                var errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode);
            }
        }

        /// <summary>
        /// Normalizes the coordinates to get the absolute values from 0 to 65536.
        /// </summary>
        private static void NormalizeCoordinates(ref int x, ref int y)
        {
            var vScreenWidth = User32.GetSystemMetrics(SystemMetric.SM_CXVIRTUALSCREEN);
            var vScreenHeight = User32.GetSystemMetrics(SystemMetric.SM_CYVIRTUALSCREEN);
            var vScreenLeft = User32.GetSystemMetrics(SystemMetric.SM_XVIRTUALSCREEN);
            var vScreenTop = User32.GetSystemMetrics(SystemMetric.SM_YVIRTUALSCREEN);

            x = (x - vScreenLeft) * 65536 / vScreenWidth + 65536 / (vScreenWidth * 2);
            y = (y - vScreenTop) * 65536 / vScreenHeight + 65536 / (vScreenHeight * 2);
        }

        #region Convenience methods

        /// <summary>
        /// Performs a left click.
        /// </summary>
        public static void LeftClick()
        {
            Click(MouseButton.Left);
        }

        /// <summary>
        /// Performs a left click on a given point.
        /// </summary>
        /// <param name="point">The position to move to before clicking.</param>
        public static void LeftClick(Point point)
        {
            Click(point, MouseButton.Left);
        }

        /// <summary>
        /// Performs a left double-click.
        /// </summary>
        public static void LeftDoubleClick()
        {
            DoubleClick(MouseButton.Left);
        }

        /// <summary>
        /// Performs a left double-click on a given point.
        /// </summary>
        /// <param name="point">The position to move to before clicking.</param>
        public static void LeftDoubleClick(Point point)
        {
            DoubleClick(point, MouseButton.Left);
        }

        /// <summary>
        /// Performs a right click.
        /// </summary>
        public static void RightClick()
        {
            Click(MouseButton.Right);
        }

        /// <summary>
        /// Performs a right click on a given point.
        /// </summary>
        /// <param name="point">The position to move to before clicking.</param>
        public static void RightClick(Point point)
        {
            Click(point, MouseButton.Right);
        }

        /// <summary>
        /// Performs a right double-click.
        /// </summary>
        public static void RightDoubleClick()
        {
            DoubleClick(MouseButton.Right);
        }

        /// <summary>
        /// Performs a right double-click on a given point.
        /// </summary>
        /// <param name="point">The position to move to before clicking.</param>

        public static void RightDoubleClick(Point point)
        {
            DoubleClick(point, MouseButton.Right);
        }

        #endregion Convenience methods
    }
}
