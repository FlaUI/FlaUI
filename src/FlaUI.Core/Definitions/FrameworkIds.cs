using System;
using System.Collections.Generic;
using System.Linq;

namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Helper class to convert between <see cref="FrameworkType"/> and string.
    /// </summary>
    public static class FrameworkIds
    {
        private static readonly Dictionary<FrameworkType, string> TypeMapping = new Dictionary<FrameworkType, string>
        {
            {FrameworkType.None, ""},
            {FrameworkType.Wpf, "WPF"},
            {FrameworkType.WinForms, "WinForm"},
            {FrameworkType.Win32, "Win32"},
            {FrameworkType.Xaml, "XAML"},
            {FrameworkType.Qt, "Qt"}
        };
        private static readonly Dictionary<string, FrameworkType> StringMapping = TypeMapping.ToDictionary(x => x.Value, x => x.Key);

        /// <summary>
        /// Converts a string to a <see cref="FrameworkType"/>.
        /// </summary>
        /// <param name="frameworkId">The string to convert.</param>
        /// <returns>The matched <see cref="FrameworkType"/>. Defaults to <see cref="FrameworkType.Unknown"/>.</returns>
        public static FrameworkType Convert(string frameworkId)
        {
            if (StringMapping.TryGetValue(frameworkId, out var frameworkType))
            {
                return frameworkType;
            }
            return FrameworkType.Unknown;
        }

        /// <summary>
        /// Converts a <see cref="FrameworkType"/> to a string.
        /// </summary>
        /// <param name="frameworkType">The <see cref="FrameworkType"/> to convert.</param>
        /// <returns>The matched string.</returns>
        public static string Convert(FrameworkType frameworkType)
        {
            if (TypeMapping.TryGetValue(frameworkType, out var frameworkId))
            {
                return frameworkId;
            }
            return null;
        }
    }
}
