using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Implementation for the mouse
    /// </summary>
    public class Mouse : IMouse
    {
        /// <summary>
        /// The current max timespan (in milliseconds) for double clicks
        /// </summary>
        private readonly int _currentDoubleClickTime;

        /// <summary>
        /// Time to add to the double click time to prevent false double clicks
        /// </summary>
        private const int ExtraMillisecondsBecauseOfBugInWindows = 13;

        /// <summary>
        /// Numer which defines one wheel "click" of the mouse wheel
        /// </summary>
        private const int WheelDelta = 120;

        /// <summary>
        /// Dictionary which holds the last click time for each button
        /// </summary>
        private readonly Dictionary<MouseButton, DateTime> _lastClickTimes;

        /// <summary>
        /// Dictionary which holds the last click position for each button
        /// </summary>
        private readonly Dictionary<MouseButton, Point> _lastClickPositions;

        /// <summary>
        /// Implementation of <see cref="IMouse.Position" />
        /// </summary>
        public Point Position
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
        /// Implementation of <see cref="IMouse.AreButtonsSwapped" />
        /// </summary>
        public bool AreButtonsSwapped
        {
            get { return User32.GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) != 0; }
        }

        /// <summary>
        /// Creates an instance
        /// </summary>
        public Mouse()
        {
            _currentDoubleClickTime = (int)User32.GetDoubleClickTime();
            _lastClickTimes = new Dictionary<MouseButton, DateTime>();
            _lastClickPositions = new Dictionary<MouseButton, Point>();
            foreach (MouseButton mouseButton in Enum.GetValues(typeof(MouseButton)))
            {
                _lastClickTimes.Add(mouseButton, DateTime.Now);
                _lastClickPositions.Add(mouseButton, new Point(0, 0));
            }
        }

        /// <summary>
        /// Implementation of <see cref="IMouse.MoveBy" />
        /// </summary>
        public void MoveBy(int deltaX, int deltaY)
        {
            var currPos = Position;
            MoveTo((int)currPos.X + deltaX, (int)currPos.Y + deltaY);
        }

        /// <summary>
        /// Implementation of <see cref="IMouse.MoveBy" />
        /// </summary>
        public void MoveTo(int newX, int newY)
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
        /// Implementation of <see cref="IMouse.Click(FlaUI.Core.Input.MouseButton)" />
        /// </summary>
        public void Click(MouseButton mouseButton)
        {
            var currClickPosition = Position;
            // Check if the position is the same as with last click
            if (_lastClickPositions[mouseButton].Equals(currClickPosition))
            {
                // Get the timeout needed to not fire a double click
                var timeout = _currentDoubleClickTime - DateTime.Now.Subtract(_lastClickTimes[mouseButton]).Milliseconds;
                // Wait the needed time to prevent the double click
                if (timeout > 0) Thread.Sleep(timeout + ExtraMillisecondsBecauseOfBugInWindows);
            }
            // Perform the click
            Down(mouseButton);
            Up(mouseButton);
            // Update the time and location
            _lastClickTimes[mouseButton] = DateTime.Now;
            _lastClickPositions[mouseButton] = Position;
        }

        /// <summary>
        /// Implementation of <see cref="IMouse.Click(MouseButton, Point)" />
        /// </summary>
        public void Click(MouseButton mouseButton, Point point)
        {
            Position = point;
            Click(mouseButton);
        }

        /// <summary>
        /// Implementation of <see cref="IMouse.DoubleClick(MouseButton)" />
        /// </summary>
        public void DoubleClick(MouseButton mouseButton)
        {
            Click(mouseButton);
            Click(mouseButton);
        }

        /// <summary>
        /// Implementation of <see cref="IMouse.DoubleClick(MouseButton, Point)" />
        /// </summary>
        public void DoubleClick(MouseButton mouseButton, Point point)
        {
            Position = point;
            DoubleClick(mouseButton);
        }

        /// <summary>
        /// Implementation of <see cref="IMouse.Down(MouseButton)" />
        /// </summary>
        public void Down(MouseButton mouseButton)
        {
            uint data;
            var flags = GetFlagsAndDataForButton(mouseButton, true, out data);
            SendInput(0, 0, data, flags);
        }

        /// <summary>
        /// Implementation of <see cref="IMouse.Up(MouseButton)" />
        /// </summary>
        public void Up(MouseButton mouseButton)
        {
            uint data;
            var flags = GetFlagsAndDataForButton(mouseButton, false, out data);
            SendInput(0, 0, data, flags);
        }

        /// <summary>
        /// Implementation of <see cref="IMouse.Scroll" />
        /// </summary>
        public void Scroll(double lines)
        {
            var amount = (uint)(WheelDelta * lines);
            SendInput(0, 0, amount, MouseEventFlags.MOUSEEVENTF_WHEEL);
        }

        /// <summary>
        /// Implementation of <see cref="IMouse.HorizontalScroll" />
        /// </summary>
        public void HorizontalScroll(double lines)
        {
            var amount = (uint)(WheelDelta * lines);
            SendInput(0, 0, amount, MouseEventFlags.MOUSEEVENTF_HWHEEL);
        }

        /// <summary>
        /// Converts the button to the correct <see cref="MouseEventFlags"/> object
        /// and fills the additional data if needed
        /// </summary>
        private MouseEventFlags GetFlagsAndDataForButton(MouseButton mouseButton, bool isDown, out uint data)
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
        /// Swaps the left/right button if <see cref="AreButtonsSwapped"/> is set
        /// </summary>
        private MouseButton SwapButtonIfNeeded(MouseButton mouseButton)
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
        private void SendInput(int x, int y, uint data, MouseEventFlags flags)
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
                return;
            }
        }

        /// <summary>
        /// Normalizes the coordinates to get the absolute values from 0 to 65536
        /// </summary>
        private void NormalizeCoordinates(ref int x, ref int y)
        {
            var vScreenWidth = User32.GetSystemMetrics(SystemMetric.SM_CXVIRTUALSCREEN);
            var vScreenHeight = User32.GetSystemMetrics(SystemMetric.SM_CYVIRTUALSCREEN);
            var vScreenLeft = User32.GetSystemMetrics(SystemMetric.SM_XVIRTUALSCREEN);
            var vScreenTop = User32.GetSystemMetrics(SystemMetric.SM_YVIRTUALSCREEN);

            x = ((x - vScreenLeft) * 65536) / vScreenWidth + 65536 / (vScreenWidth * 2);
            y = ((y - vScreenTop) * 65536) / vScreenHeight + 65536 / (vScreenHeight * 2);
        }
    }
}
