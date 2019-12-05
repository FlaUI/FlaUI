using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FlaUI.Core.Tools
{
    /// <summary>
    /// Provides various extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Makes sure a comparable object is between a given range.
        /// </summary>
        public static T Clamp<T>(this T source, T min, T max) where T : IComparable
        {
            var isReversed = min.CompareTo(max) > 0;
            var smallest = isReversed ? max : min;
            var biggest = isReversed ? min : max;

            return source.CompareTo(smallest) < 0 ? smallest :
                source.CompareTo(biggest) > 0 ? biggest : source;
        }

        /// <summary>
        /// Converts a boolean to an int
        /// </summary>
        public static int ToInt(this bool value) => value ? 1 : 0;

        /// <summary>
        /// Converts an int to a boolean.
        /// </summary>
        public static bool ToBool(this int value) => value == 1;

        /// <summary>
        /// Converts a double to the nearest int32.
        /// </summary>
        public static int ToInt(this double value) => Convert.ToInt32(value);

        /// <summary>
        /// Converts an enum value to an int.
        /// </summary>
        public static int ToInt(this Enum value) => (int)(object)value;

        /// <summary>
        /// Converts an enum value to an uint.
        /// </summary>
        public static uint ToUInt(this Enum value) => (uint)(object)value;

        /// <summary>
        /// Rounds the number down the the next even number.
        /// </summary>
        public static int Even(this int self) => self % 2 == 1 ? self - 1 : self;

        /// <summary>
        /// Checks if a double is not NaN and not Infinity
        /// </summary>
        public static bool HasValue(this double value) => !Double.IsNaN(value) && !Double.IsInfinity(value);

        /// <summary>
        /// Gets a list of flags which are set in an <see cref="Enum"/>.
        /// </summary>
        public static IEnumerable<Enum> GetFlags(this Enum variable) => Enum.GetValues(variable.GetType()).Cast<Enum>().Where(variable.HasFlag);

        #region Point extensions
        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="self">The first point.</param>
        /// <param name="other">The second point.</param>
        /// <returns>The distance of the points.</returns>
        public static double Distance(this Point self, Point other) => self.Distance(other.X, other.Y);

        /// <summary>
        /// Calculates the distance between a point and an x/y coordinate pair.
        /// </summary>
        /// <param name="self">The first point.</param>
        /// <param name="otherX">The x-coordinate of the second point.</param>
        /// <param name="otherY">The x-coordinate of the second point.</param>
        /// <returns>The distance of the points.</returns>
        public static double Distance(this Point self, double otherX, double otherY) => Math.Sqrt(Math.Pow(self.X - otherX, 2) + Math.Pow(self.Y - otherY, 2));
        #endregion Point extensions

        #region Rectangle extensions
        public static Point Center(this Rectangle self) => new Point(self.Width / 2 + self.Left, self.Height / 2 + self.Top);

        public static Point North(this Rectangle self, int by = 0) => new Point(self.Center().X, self.Top + by);

        public static Point East(this Rectangle self, int by = 0) => new Point(self.Right + by, self.Center().Y);

        public static Point South(this Rectangle self, int by = 0) => new Point(self.Center().X, self.Bottom + by);

        public static Point West(this Rectangle self, int by = 0) => new Point(self.Left + by, self.Center().Y);

        public static Point ImmediateExteriorNorth(this Rectangle self) => self.North(-1);

        public static Point ImmediateInteriorNorth(this Rectangle self) => self.North(1);

        public static Point ImmediateExteriorEast(this Rectangle self) => self.East(1);

        public static Point ImmediateInteriorEast(this Rectangle self) => self.East(-1);

        public static Point ImmediateExteriorSouth(this Rectangle self) => self.South(1);

        public static Point ImmediateInteriorSouth(this Rectangle self) => self.South(-1);

        public static Point ImmediateExteriorWest(this Rectangle self) => self.West(-1);

        public static Point ImmediateInteriorWest(this Rectangle self) => self.West(1);

        /// <summary>
        /// Makes the rectangles dimensions a multiple of 2.
        /// </summary>
        public static Rectangle Even(this Rectangle self)
        {
            if (self.Width % 2 == 1)
            {
                --self.Width;
            }
            if (self.Height % 2 == 1)
            {
                --self.Height;
            }
            return self;
        }
        #endregion Rectangle extensions
    }
}
