using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Touch class to simulate touch input.
    /// </summary>
    public static class Touch
    {
        /// <summary>
        /// The interval that is used for interpolation/rotation.
        /// </summary>
        public static TimeSpan DefaultInterval = TimeSpan.FromMilliseconds(50);

        static Touch()
        {
            if (!User32.InitializeTouchInjection())
            {
                throw new Win32Exception();
            }
        }

        /// <summary>
        /// Performs a tap on the given point or points.
        /// </summary>
        public static void Tap(params Point[] points)
        {
            var contacts = points.Select((p, i) => CreatePointerTouch(p, PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT, (uint)i)).ToArray();
            InjectTouchInput(contacts);
            Wait.UntilInputIsProcessed();
            ReleaseContacts(contacts);
        }

        /// <summary>
        /// Holds the touch on the given points for the given duration.
        /// </summary>
        /// <param name="duration">The duration of the hold.</param>
        /// <param name="points">The points that should be hold down.</param>
        public static void Hold(TimeSpan duration, params Point[] points)
        {
            var contacts = points.Select((p, i) => CreatePointerTouch(p, PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT, (uint)i)).ToArray();
            InjectTouchInput(contacts);
            Wait.UntilInputIsProcessed();
            // Loop to update the touch points
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed < duration)
            {
                Thread.Sleep(DefaultInterval);
                for (var i = 0; i < points.Length; i++)
                {
                    contacts[i].pointerInfo.pointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                }
                InjectTouchInput(contacts);
            }
            ReleaseContacts(contacts);
        }

        /// <summary>
        /// Performs a pinch with two fingers.
        /// </summary>
        /// <param name="center">The center point of the pinch.</param>
        /// <param name="startRadius">The starting radius.</param>
        /// <param name="endRadius">The end radius.</param>
        /// <param name="duration">The duration of the action.</param>
        /// <param name="angle">The angle of the two points, relative to the x-axis.</param>
        public static void Pinch(Point center, double startRadius, double endRadius, TimeSpan duration, double angle = 45)
        {
            // Prepare the points
            var startPoints = CreatePointsAround(center, startRadius, angle);
            var endPoints = CreatePointsAround(center, endRadius, angle);
            var startEndPoints = new[]
            {
                Tuple.Create(startPoints[0], endPoints[0]),
                Tuple.Create(startPoints[1], endPoints[1])
            };
            // Perform the Transition
            Transition(duration, startEndPoints);
        }

        /// <summary>
        /// Transitions all the points from the start point to the end points.
        /// </summary>
        /// <param name="duration">The duration for the action.</param>
        /// <param name="startEndPoints">The list of start/end point tuples.</param>
        public static void Transition(TimeSpan duration, params Tuple<Point, Point>[] startEndPoints)
        {
            // Simulate the touch-down on the starting points.
            var contacts = startEndPoints.Select((p, i) => CreatePointerTouch(p.Item1, PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT, (uint)i)).ToArray();
            InjectTouchInput(contacts);
            Wait.UntilInputIsProcessed();
            // Interpolate between the start and end point and update the touch points
            Interpolation.Execute(points =>
                {
                    for (var i = 0; i < points.Length; i++)
                    {
                        contacts[i].pointerInfo.pointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                        contacts[i].pointerInfo.ptPixelLocation = points[i].ToPOINT();
                    }
                    InjectTouchInput(contacts);
                },
                startEndPoints, duration, DefaultInterval, true);
            Wait.UntilInputIsProcessed();
            ReleaseContacts(contacts);
        }

        /// <summary>
        /// Performs a touch-drag from the start point to the end point.
        /// </summary>
        /// <param name="duration">The duration of the action.</param>
        /// <param name="startPoint">The starting point of the drag.</param>
        /// <param name="endPoint">The end point of the drag.</param>
        public static void Drag(TimeSpan duration, Point startPoint, Point endPoint)
        {
            Transition(duration, new Tuple<Point, Point>(startPoint, endPoint));
        }

        /// <summary>
        /// Performs a 2-finger rotation around the given point where the first finger is at the center and
        /// the second is rotated around.
        /// </summary>
        /// <param name="center">The center point of the rotation.</param>
        /// <param name="radius">The radius of the rotation.</param>
        /// <param name="startAngle">The starting angle (in rad).</param>
        /// <param name="endAngle">The ending angle (in rad).</param>
        /// <param name="duration">The total duration for the transition.</param>
        public static void Rotate(Point center, double radius, double startAngle, double endAngle, TimeSpan duration)
        {
            // Simulate the touch-down on the starting points.
            var contacts = new[]
            {
                CreatePointerTouch(center, PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT, 0),
                CreatePointerTouch(Interpolation.GetNewPoint(center, radius, startAngle), PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT, 1)
            };
            InjectTouchInput(contacts);
            Wait.UntilInputIsProcessed();

            // Interpolate between the start and end point and update the touch points
            Interpolation.ExecuteRotation(point =>
                {
                    contacts[0].pointerInfo.pointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                    contacts[1].pointerInfo.pointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                    contacts[1].pointerInfo.ptPixelLocation = point.ToPOINT();
                    InjectTouchInput(contacts);
                },
                center, radius, startAngle, endAngle, duration, DefaultInterval, true);
            Wait.UntilInputIsProcessed();
            ReleaseContacts(contacts);
        }

        private static void ReleaseContacts(POINTER_TOUCH_INFO[] contacts)
        {
            for (var i = 0; i < contacts.Length; i++)
            {
                contacts[i].pointerInfo.pointerFlags = PointerFlags.UP;
            }
            InjectTouchInput(contacts.ToArray());
            Wait.UntilInputIsProcessed();
        }

        /// <summary>
        /// Create two points around the given center points.
        /// </summary>
        /// <param name="center">The center point.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="angle">The angle to the x axis.</param>
        /// <returns>An array of the two points.</returns>
        private static Point[] CreatePointsAround(Point center, double radius, double angle)
        {
            var v = new Size((int)(radius * Math.Cos(angle * Math.PI / 180)), (int)(radius * Math.Sin(angle * Math.PI / 180)));
            return new[] {
                center + v,
                center - v
            };
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
            var touchPoint = point.ToPOINT();
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
        /// Effectively executes the touch input action.
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
        }
    }
}
