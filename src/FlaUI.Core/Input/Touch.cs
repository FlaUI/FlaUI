using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Touch class to simulate touch input.
    /// </summary>
    public static class Touch
    {
        static Touch()
        {
            if (!User32.InitializeTouchInjection())
            {
                throw new Win32Exception();
            }
        }

        /// <summary>
        /// Performs a tap on the specified point or points.
        /// </summary>
        public static void Tap(params Point[] points)
        {

        }

        /// <summary>
        /// Performs a pinch which is a two-finger gesture.
        /// </summary>
        public static void Pinch()
        {

        }

        /// <summary>
        /// Performs a hold
        /// </summary>
        public static IDisposable Hold(params Point[] points)
        {
            var contacts = points.Select((p, i) => CreatePointerTouch(p, PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT, (uint)i)).ToArray();
            InjectTouchInput(contacts);

            return new ActionDisposable(() =>
            {
                for (var i = 0; i < contacts.Length; i++)
                {
                    contacts[i].pointerInfo.pointerFlags = PointerFlags.UP;
                }
                InjectTouchInput(contacts.Reverse().ToArray());
            });
        }

        public static void Drag()
        {

        }

        public static void Rotate()
        {

        }

        /// <summary>
        /// Helper method to create the most used <see cref="POINTER_TOUCH_INFO"/> structure.
        /// </summary>
        /// <param name="point">The point where the touch action occurs.</param>
        /// <param name="flags">The flags used for the touch action</param>
        /// <param name="id">The id of the point, only needed when more than one.</param>
        /// <returns>A <see cref="POINTER_TOUCH_INFO"/> structure.</returns>
        private static POINTER_TOUCH_INFO CreatePointerTouch(Point point, PointerFlags flags, uint id = 0)
        {
            var touchPoint = new POINT { X = point.X, Y = point.Y };
            var contact = new POINTER_TOUCH_INFO
            {
                pointerInfo =
                {
                    pointerType = PointerInputType.PT_TOUCH,
                    pointerFlags = flags,
                    ptPixelLocation = touchPoint,
                    pointerId = id,
                },
                touchFlags = TouchFlags.NONE,
                touchMask = TouchMask.NONE,
                rcContact = new RECT
                {
                    left = touchPoint.X,
                    right = touchPoint.X,
                    top = touchPoint.Y,
                    bottom = touchPoint.Y
                }
            };

            return contact;
        }

        /// <summary>
        /// Effectifely executes the touch input action.
        /// </summary>
        /// <param name="contacts">The list of input contacts which should be executed.</param>
        private static void InjectTouchInput(POINTER_TOUCH_INFO[] contacts)
        {
            if (contacts == null)
            {
                throw new ArgumentNullException(nameof(contacts));
            }

            if (!User32.InjectTouchInput(contacts.Length, contacts))
            {
                throw new Win32Exception();
            }
            Wait.UntilInputIsProcessed();
        }
    }
}
