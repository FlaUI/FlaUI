using FlaUI.Core.WindowsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

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
                User32.SetCursorPos((int)value.X, (int)value.Y);
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

            // Setup variables
            var duration = 200; // Speed
            var steps = 20; // Smoothness
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
            MouseDown(mouseButton);
            MouseUp(mouseButton);
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
        /// Implementation of <see cref="IMouse.MouseDown(MouseButton)" />
        /// </summary>
        public void MouseDown(MouseButton mouseButton)
        {
            var mouseInput = GetInputForButton(mouseButton, true);
            SendInput(mouseInput);
        }

        /// <summary>
        /// Implementation of <see cref="IMouse.MouseUp(MouseButton)" />
        /// </summary>
        public void MouseUp(MouseButton mouseButton)
        {
            var mouseInput = GetInputForButton(mouseButton, false);
            SendInput(mouseInput);
        }

        /// <summary>
        /// Converts the button to the correct <see cref="MOUSEINPUT"/> object
        /// </summary>
        private MOUSEINPUT GetInputForButton(MouseButton mouseButton, bool isDown)
        {
            MouseEventFlags mouseEventFlags;
            uint mouseData = 0;
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
                    mouseData = (uint)MouseEventDataXButtons.XBUTTON1;
                    break;
                case MouseButton.XButton2:
                    mouseEventFlags = isDown ? MouseEventFlags.MOUSEEVENTF_XDOWN : MouseEventFlags.MOUSEEVENTF_XUP;
                    mouseData = (uint)MouseEventDataXButtons.XBUTTON2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mouseButton");
            }
            var messageInfo = User32.GetMessageExtraInfo();
            return new MOUSEINPUT(mouseEventFlags, messageInfo, mouseData);
        }

        /// <summary>
        /// Swaps the left/right button if <see cref="AreButtonsSwapped"/> is set
        /// </summary>
        private MouseButton SwapButtonIfNeeded(MouseButton mouseButton)
        {
            if (!AreButtonsSwapped) return mouseButton;
            if (mouseButton == MouseButton.Left)
            {
                return MouseButton.Right;
            }
            if (mouseButton == MouseButton.Right)
            {
                return MouseButton.Left;
            }
            return mouseButton;
        }

        /// <summary>
        /// Effectively sends the mouse input command
        /// </summary>
        private void SendInput(MOUSEINPUT mouseInput)
        {
            var input = INPUT.MouseInput(mouseInput);
            User32.SendInput(1, new[] { input }, Marshal.SizeOf(typeof(INPUT)));
            // Let the thread some time to process the system's hardware input queue.
            // For details see this post: http://blogs.msdn.com/b/oldnewthing/archive/2014/02/13/10499047.aspx
            // TODO: Should this be configurable?
            Thread.Sleep(50);
        }
    }
}
