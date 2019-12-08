using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Interpolation tool to transition one or more points to another location during a time frame.
    /// </summary>
    public static class Interpolation
    {
        /// <summary>
        /// Transitions the given points from start to end in the given duration. Calls action for each interval with all new points.
        /// </summary>
        /// <param name="action">The action to execute for each interval.</param>
        /// <param name="startEndPoints">A list of tuples with start/end points.</param>
        /// <param name="duration">The total duration for the transition.</param>
        /// <param name="interval">The interval of each step.</param>
        /// <param name="skipInitialPosition">A flag to indicate if the initial position should be skipped from firing the action.</param>
        public static void Execute(Action<Point[]> action, Tuple<Point, Point>[] startEndPoints, TimeSpan duration, TimeSpan interval, bool skipInitialPosition = false)
        {
            // Run for the starting point
            if (!skipInitialPosition)
            {
                action(startEndPoints.Select(x => x.Item1).ToArray());
            }
            // Start the timer
            var stopwatch = Stopwatch.StartNew();
            // Loop until we're finished
            while (true)
            {
                Thread.Sleep(interval);
                var factor = GetFactor(duration, stopwatch);
                var newPoints = startEndPoints.Select(x => GetNewPoint(x.Item1, x.Item2, factor)).ToArray();
                action(newPoints);
                if (factor == 1)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Transitions the given point from start to end in the given duration. Calls action for each interval with the new point.
        /// </summary>
        /// <param name="action">The action to execute for each interval.</param>
        /// <param name="startPoint">The starting point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="duration">The total duration for the transition.</param>
        /// <param name="interval">The interval of each step.</param>
        /// <param name="skipInitialPosition">A flag to indicate if the initial position should be skipped from firing the action.</param>
        public static void Execute(Action<Point> action, Point startPoint, Point endPoint, TimeSpan duration, TimeSpan interval, bool skipInitialPosition = false)
        {
            Execute((points) =>
            {
                action(points[0]);
            }, new[] { Tuple.Create(startPoint, endPoint) }, duration, interval, skipInitialPosition);
        }

        /// <summary>
        /// Performs a rotation transition around the given point with a given radius.
        /// </summary>
        /// <param name="action">The action to execute for each interval.</param>
        /// <param name="centerPoint">The center point of the rotation.</param>
        /// <param name="radius">The radius of the rotation.</param>
        /// <param name="startAngle">The starting angle (in rad).</param>
        /// <param name="endAngle">The ending angle (in rad).</param>
        /// <param name="duration">The total duration for the transition.</param>
        /// <param name="interval">The interval of each step.</param>
        /// <param name="skipInitialPosition">A flag to indicate if the initial position should be skipped from firing the action.</param>
        public static void ExecuteRotation(Action<Point> action, Point centerPoint, double radius, double startAngle, double endAngle, TimeSpan duration, TimeSpan interval, bool skipInitialPosition = false)
        {
            // Run for the starting point
            if (!skipInitialPosition)
            {
                var newPoint = GetNewPoint(centerPoint, radius, 0);
                action(newPoint);
            }
            // Start the timer
            var stopwatch = Stopwatch.StartNew();
            // Loop until we're finished
            while (true)
            {
                Thread.Sleep(interval);
                var factor = GetFactor(duration, stopwatch);
                var angle = startAngle + (factor * (endAngle - startAngle));
                var newPoint = GetNewPoint(centerPoint, radius, angle);
                action(newPoint);
                if (factor == 1)
                {
                    break;
                }
            }
        }

        internal static Point GetNewPoint(Point start, Point end, double factor)
        {
            var newPoint = new Point
            {
                X = (int)(start.X + (factor * (end.X - start.X))),
                Y = (int)(start.Y + (factor * (end.Y - start.Y))),
            };
            return newPoint;
        }

        internal static Point GetNewPoint(Point centerPoint, double radius, double angle)
        {
            var x = centerPoint.X + radius * Math.Cos(angle);
            var y = centerPoint.Y + radius * Math.Sin(angle);
            var newPoint = new Point((int)x, (int)y);
            return newPoint;
        }

        private static double GetFactor(TimeSpan duration, Stopwatch stopwatch)
        {
            if (duration.TotalMilliseconds == 0)
            {
                return 1;
            }
            var factor = stopwatch.ElapsedMilliseconds / duration.TotalMilliseconds;
            if (factor > 1)
            {
                factor = 1;
            }
            return factor;
        }
    }
}
