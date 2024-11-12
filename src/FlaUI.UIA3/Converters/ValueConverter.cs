using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.UIA3.Converters
{
    /// <summary>
    /// Class that helps converting various values between native and FlaUIs format.
    /// </summary>
    public static class ValueConverter
    {
        /// <summary>
        /// Converts the given object to an object the native client expects
        /// </summary>
        [return: NotNullIfNotNull(nameof(val))]
        public static object? ToNative(object? val)
        {
            if (val == null)
            {
                return null;
            }
            if (val is ControlType controlType)
            {
                val = (int)ControlTypeConverter.ToControlTypeNative(controlType);
            }
            else if (val is AnnotationType annotationType)
            {
                val = (int)AnnotationTypeConverter.ToAnnotationTypeNative(annotationType);
            }
            else if (val is AccessibilityRole accessibilityRole)
            {
                val = (int)accessibilityRole;
            }
            else if (val is Rectangle rect)
            {
                val = new[] { rect.Left, rect.Top, rect.Width, rect.Height };
            }
            else if (val is Point point)
            {
                val = new[] { point.X, point.Y };
            }
            else if (val is CultureInfo cultureInfo)
            {
                val = cultureInfo.LCID;
            }
            else if (val is AutomationElement automationElement)
            {
                val = automationElement.ToNative();
            }
            return val;
        }

        /// <summary>
        /// Converts a native rectangle to a <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="rectangle">The native rectangle to convert.</param>
        /// <returns>The converted managed rectangle.</returns>
        [return: NotNullIfNotNull(nameof(rectangle))]
        public static object? ToRectangle(object? rectangle)
        {
            if (rectangle == null)
            {
                return null;
            }

            var origValue = (double[])rectangle;
            return new Rectangle(origValue[0].ToInt(), origValue[1].ToInt(), origValue[2].ToInt(), origValue[3].ToInt());
        }

        /// <summary>
        /// Converts a native point to a <see cref="Point"/>.
        /// </summary>
        /// <param name="point">The native point to convert.</param>
        /// <returns>The converted managed point.</returns>
        [return: NotNullIfNotNull(nameof(point))]
        public static object? ToPoint(object? point)
        {
            if (point == null)
            {
                return null;
            }

            var origValue = (double[])point;
            return new Point(origValue[0].ToInt(), origValue[1].ToInt());
        }

        /// <summary>
        /// Converts a native culture to a <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="cultureId">The native culture to convert.</param>
        /// <returns>The converted managed culture.</returns>
        public static object ToCulture(object cultureId)
        {
            var origValue = (int)cultureId;
            return origValue == 0 ? CultureInfo.InvariantCulture : new CultureInfo(origValue);
        }

        /// <summary>
        /// Converts an integer to an <see cref="IntPtr"/>.
        /// </summary>
        /// <param name="intPtrAsInt">The integer to convert.</param>
        /// <returns>The converted IntPtr.</returns>
        public static object IntToIntPtr(object intPtrAsInt)
        {
            var origValue = (int)intPtrAsInt;
            return origValue == 0 ? IntPtr.Zero : new IntPtr(origValue);
        }
    }
}
