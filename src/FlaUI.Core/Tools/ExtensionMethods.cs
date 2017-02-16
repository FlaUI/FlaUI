using System;
using System.Collections.Generic;
using System.Linq;

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
        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }

        /// <summary>
        /// Converts an int to a boolean
        /// </summary>
        public static bool ToBool(this int value)
        {
            return value == 1;
        }

        /// <summary>
        /// Converts a double to the nearest int32
        /// </summary>
        public static int ToInt(this double value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Checks if a double is not NaN and not Infinity
        /// </summary>
        public static bool HasValue(this double value)
        {
            return !Double.IsNaN(value) && !Double.IsInfinity(value);
        }

#if NET35
        public static bool HasFlag(this Enum variable, Enum flag)
        {
            if (flag == null)
            {
                throw new ArgumentNullException(nameof(flag));
            }
            if (variable.GetType() != flag.GetType())
            {
                throw new ArgumentException("The checked flag is not from the same type as the checked variable.");
            }
            var num = Convert.ToUInt64(flag);
            var num2 = Convert.ToUInt64(variable);
            return (num2 & num) == num;
        }

        public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct
        {
            try
            {
                result = (TEnum)Enum.Parse(typeof(TEnum), value);
            }
            catch
            {
                result = default(TEnum);
                return false;
            }
            return true;
        }
#endif

        public static IEnumerable<Enum> GetFlags(this Enum variable)
        {
            return Enum.GetValues(variable.GetType()).Cast<Enum>().Where(variable.HasFlag);
        }
    }
}
