using System;

namespace FlaUI.Core.Tools
{
    /// <summary>
    /// Class with methods that help formatting strings.
    /// </summary>
    public static class StringFormatter
    {
        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        /// <summary>
        /// Adds size suffixes like KB, MB, GB, ...
        /// </summary>
        public static string SizeSuffix(ulong value, int decimalPlaces = 0)
        {
            var mag = (int)Math.Max(0, Math.Log(value, 1024));
            var adjustedSize = Math.Round(value / Math.Pow(1024, mag), decimalPlaces);
            return $"{adjustedSize}{SizeSuffixes[mag]}";
        }
    }
}
