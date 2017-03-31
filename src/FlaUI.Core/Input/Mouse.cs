using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Mouse class to simulate mouse input
    /// </summary>
    public static class Mouse
    {
        /// <summary>
        /// Time to add to the double click time to prevent false double clicks
        /// </summary>
        private const int ExtraMillisecondsBecauseOfBugInWindows = 13;

        /// <summary>
        /// Numer which defines one wheel "click" of the mouse wheel
        /// </summary>
        private const int WheelDelta = 120;

        /// <summary>
        /// The current max timespan (in milliseconds) for double clicks
        /// </summary>
        private static readonly int CurrentDoubleClickTime;

        /// <summary>
        /// Dictionary which holds the last click time for each button
        /// </summary>
        private static readonly Dictionary<MouseButton, DateTime> LastClickTimes;

        /// <summary>
        /// Dictionary which holds the last click position for each button
        /// </summary>
        private static readonly Dictionary<MouseButton, Point> LastClickPositions;

        /// <summary>
        /// Static constructor
        /// </summary>
        static Mouse()
        {
            CurrentDoubleClickTime = (int)User32.GetDoubleClickTime();
            LastClickTimes = new Dictionary<MouseButton, DateTime>();
            LastClickPositions = new Dictionary<MouseButton, Point>();
            foreach (MouseButton mouseButton in Enum.GetValues(typeof(MouseButton)))
            {
                LastClickTimes.Add(mouseButton, DateTime.Now);
                LastClickPositions.Add(mouseButton, new Point(0, 0));
            }
        }

        /// <summary>
        /// Current position of the mouse cursor
        /// </summary>
        public static Point Position
        {
            get
            {
                POINT point;
                User32.GetCursorPos(out point);
                return point;
            }
            set
            {
                POINT point = value;
                User32.SetCursorPos(point.X, point.Y);
            }
        }

        /// <summary>
        /// Flag to indicate if the buttons are swapped (left-handed)
        /// </summary>
        public static bool AreButtonsSwapped => User32.GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) != 0;

        /// <summary>
        /// Moves the mouse by a given delta from the current position
        /// </summary>
        /// <param name="deltaX">The delta for the x-axis</param>
        /// <param name="deltaY">The delta for the y-axis</param>
        public static void MoveBy(int deltaX, int deltaY)
        {
            var currPos = Position;
            MoveTo((int)currPos.X + deltaX, (int)currPos.Y + deltaY);
        }

        /// <summary>
        /// Moves the mouse to a new position
        /// </summary>
        /// <param name="newX">The new position on the x-axis</param>
        /// <param name="newY">The new position on the y-axis</param>
        public static void MoveTo(int newX, int newY)
        {
            // Get starting position
            var startPos = Position;
            var startX = (int)startPos.X;
            var startY = (int)startPos.Y;

            // Prepare variables
            var totalDistance = startPos.Distance(newX, newY);

            // Calculate the duration for the speed
            var optimalPixelsPerMillisecond = 1;
            var minDuration = 200;
            var maxDuration = 500;
            var duration = Convert.ToInt32(totalDistance / optimalPixelsPerMillisecond).Clamp(minDuration, maxDuration);

            // Calculate the steps for the smoothness
            var optimalPixelsPerStep = 10;
            var minSteps = 10;
            var maxSteps = 50;
            var steps = Convert.ToInt32(totalDistance / optimalPixelsPerStep).Clamp(minSteps, maxSteps);

            // Calculate the interval and the step size
            var interval = duration / steps;
            var stepX = (double)(newX - startX) / steps;
            var stepY = (double)(newY - startY) / steps;

            // Build a list of movement points (except the last one, to set that one perfectly)
            var movements = new List<Point>();
            for (var i = 1; i < steps; i++)
            {
                var tempX = startX + i * stepX;
                var tempY = startY + i * stepY;
                movements.Add(new Point(tempX, tempY));
            }

            // Add an exact point for the last one, if it does not fit exactly
            var lastPoint = movements.Last();
            if ((int)lastPoint.X != newX || (int)lastPoint.Y != newY)
            {
                movements.Add(new Point(newX, newY));
            }

            // Loop thru the steps and set them
            foreach (var point in movements)
            {
                Position = point;
                Thread.Sleep(interval);
            }
            Helpers.WaitUntilInputIsProcessed();
        }

        /// <summary>
        /// Moves the mouse to a new position
        /// </summary>
        /// <param name="newPosition">The new position for the mouse</param>
        public static void MoveTo(Point newPosition)
        {
            MoveTo(newPosition.X.ToInt(), newPosition.Y.ToInt());
        }

        /// <summary>
        /// Clicks the specified mouse button at the current location
        /// </summary>
        /// <param name="mouseButton">The mouse button to click</param>
        public static void Click(MouseButton mouseButton)
        {
            var currClickPosition = Position;
            // Check if the position is the same as with last click
            if (LastClickPositions[mouseButton].Equals(currClickPosition))
            {
                // Get the timeout needed to not fire a double click
                var timeout = CurrentDoubleClickTime - DateTime.Now.Subtract(LastClickTimes[mouseButton]).Milliseconds;
                // Wait the needed time to prevent the double click
                if (timeout > 0) Thread.Sleep(timeout + ExtraMillisecondsBecauseOfBugInWindows);
            }
            // Perform the click
            Down(mouseButton);
            Up(mouseButton);
            // Update the time and location
            LastClickTimes[mouseButton] = DateTime.Now;
            LastClickPositions[mouseButton] = Position;
        }

        /// <summary>
        /// Moves to a specific position and clicks the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to click</param>
        /// <param name="point">The position to move to before clicking</param>
        public static void Click(MouseButton mouseButton, Point point)
        {
            Position = point;
            Click(mouseButton);
        }

        /// <summary>
        /// Double-clicks the specified mouse button at the current location
        /// </summary>
        /// <param name="mouseButton">The mouse button to double-click</param>
        public static void DoubleClick(MouseButton mouseButton)
        {
            Down(mouseButton);
            Up(mouseButton);
            Down(mouseButton);
            Up(mouseButton);
        }

        /// <summary>
        /// Moves to a specific position and double-clicks the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to double-click</param>
        /// <param name="point">The position to move to before double-clicking</param>
        public static void DoubleClick(MouseButton mouseButton, Point point)
        {
            Position = point;
            DoubleClick(mouseButton);
        }

        /// <summary>
        /// Sends a mouse down command for the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to press</param>
        public static void Down(MouseButton mouseButton)
        {
            uint data;
            var flags = GetFlagsAndDataForButton(mouseButton, true, out data);
            SendInput(0, 0, data, flags);
        }

        /// <summary>
        /// Sends a mouse up command for the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button to release</param>
        public static void Up(MouseButton mouseButton)
        {
            uint data;
            var flags = GetFlagsAndDataForButton(mouseButton, false, out data);
            SendInput(0, 0, data, flags);
        }

        /// <summary>
        /// Simulates scrolling of the mouse wheel up or down
        /// </summary>
        public static void Scroll(double lines)
        {
            var amount = (uint)(WheelDelta * lines);
            SendInput(0, 0, amount, MouseEventFlags.MOUSEEVENTF_WHEEL);
        }

        /// <summary>
        /// Simulates scrolling of the horizontal mouse wheel left or right
        /// </summary>
        public static void HorizontalScroll(double lines)
        {
            var amount = (uint)(WheelDelta * lines);
            SendInput(0, 0, amount, MouseEventFlags.MOUSEEVENTF_HWHEEL);
        }

        /// <summary>
        /// Drags the mouse horizontally
        /// </summary>
        /// <param name="mouseButton">The mouse button to use for dragging</param>
        /// <param name="startingPoint">Starting point of the drag</param>
        /// <param name="distance">The distance to drag, + for right, - for left</param>
        public static void DragHorizontally(MouseButton mouseButton, Point startingPoint, double distance)
        {
            Position = startingPoint;
            var currentX = Position.X;
            var currentY = Position.Y;
            Down(mouseButton);
            Position = new Point(currentX + distance, currentY);
            Up(mouseButton);
        }

        /// <summary>
        /// Drags the mouse vertically
        /// </summary>
        /// <param name="mouseButton">The mouse button to use for dragging</param>
        /// <param name="startingPoint">Starting point of the drag</param>
        /// <param name="distance">The distance to drag, + for down, - for up</param>
        public static void DragVertically(MouseButton mouseButton, Point startingPoint, double distance)
        {
            Position = startingPoint;
            var currentX = Position.X;
            var currentY = Position.Y;
            Down(mouseButton);
            Position = new Point(currentX, currentY + distance);
            Up(mouseButton);
        }

        /// <summary>
        /// Converts the button to the correct <see cref="MouseEventFlags" /> object
        /// and fills the additional data if needed
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
                    throw new ArgumentOutOfRangeException("mouseButton");
            }
            data = (uint)mouseData;
            return mouseEventFlags;
        }

        /// <summary>
        /// Swaps the left/right button if <see cref="AreButtonsSwapped" /> is set
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
        /// Effectively sends the mouse input command
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
            }
        }

        /// <summary>
        /// Normalizes the coordinates to get the absolute values from 0 to 65536
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
        public static void LeftClick()
        {
            Click(MouseButton.Left);
        }

        public static void LeftClick(Point point)
        {
            Click(MouseButton.Left, point);
        }

        public static void LeftDoubleClick()
        {
            DoubleClick(MouseButton.Left);
        }

        public static void LeftDoubleClick(Point point)
        {
            DoubleClick(MouseButton.Left, point);
        }

        public static void RightClick()
        {
            Click(MouseButton.Right);
        }

        public static void RightClick(Point point)
        {
            Click(MouseButton.Right, point);
        }

        public static void RightDoubleClick()
        {
            DoubleClick(MouseButton.Right);
        }

        public static void RightDoubleClick(Point point)
        {
            DoubleClick(MouseButton.Right, point);
        }
        #endregion Convenience methods
    }
}
