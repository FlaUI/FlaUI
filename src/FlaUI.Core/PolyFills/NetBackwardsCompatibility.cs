// This file contains things that were not available in older .Net versions.
#if NET35

using System;
using System.Diagnostics;
using System.Security;
using FlaUI.Core.WindowsAPI;

namespace System
{
    /// <summary>
    /// Polyfill for a 5-parameter action.
    /// </summary>
    public delegate void Action<T1, T2, T3, T4, T5>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5);

    /// <summary>
    /// Polyfill for a tuple.
    /// </summary>
    public class Tuple<T1, T2>
    {
        public T1 Item1 { get; }
        public T2 Item2 { get; }

        public Tuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }

    /// <summary>
    /// Polyfill for the tuple factory.
    /// </summary>
    public static class Tuple
    {
        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new Tuple<T1, T2>(item1, item2);
        }
    }

    /// <summary>
    /// Polyfills for the <see cref="TimeSpan" /> class.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Overload for <see cref="TimeSpan.ToString"/> because <see cref="TimeSpan"/> in .Net3.5 does not take a format parameter.
        /// </summary>
        public static string ToString(this TimeSpan self, string format) => self.ToString();
    }

    /// <summary>
    /// Polyfill for missing Environment stuff.
    /// </summary>
    public static class PolyFillEnvironment
    {
        public static bool Is64BitOperatingSystem
        {
            [SecuritySafeCritical]
            get
            {
                if (IntPtr.Size == 8)
                {
                    // The current process is 64 bit
                    return true;
                }
                else
                {
                    // The process is running in the WOW64 emulator
                    return WindowsApiTools.DoesWin32MethodExist(Kernel32.KERNEL32, "IsWow64Process")
                        && Kernel32.IsWow64Process(Process.GetCurrentProcess().Handle, out bool isWow64)
                        && isWow64;
                }
            }
        }
    }
}

/// <summary>
/// Polyfills for enums.
/// </summary>
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
