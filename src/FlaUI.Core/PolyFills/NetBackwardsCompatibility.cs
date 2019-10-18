// This file contains things that were not available in older .Net versions.
#if NET35

using System;

namespace System
{
    public delegate void Action<T1, T2, T3, T4, T5>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5);

    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Overload for <see cref="TimeSpan.ToString"/> because <see cref="TimeSpan"/> in .Net3.5 does not take a format parameter.
        /// </summary>
        public static string ToString(this TimeSpan self, string format) => self.ToString();
    }
}

public static class EnumExtensions
{
    /// <summary>
    /// Extension method for the missing HasFlag on an <see cref="Enum"/>.
    /// </summary>
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

    /// <summary>
    /// Extension method for the missing TryParse on an <see cref="Enum"/>.
    /// </summary>
    public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct
    {
        try
        {
            result = (TEnum)Enum.Parse(typeof(TEnum), value);
        }
        catch
        {
            result = default;
            return false;
        }
        return true;
    }
}
#endif
