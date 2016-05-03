using System;

namespace FlaUI.Core.Tools
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Makes sure a comparable object is between a given range
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
        public static int ToInt(this bool b)
        {
            return b ? 1 : 0;
        }
    }
}
