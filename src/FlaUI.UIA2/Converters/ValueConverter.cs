using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Converters
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
                val = (UIA.ControlType)ControlTypeConverter.ToControlTypeNative(controlType);
            }
            else if (val is AutomationElement automationElement)
            {
                val = ToNative(automationElement);
            }
            return val;
        }

        /// <summary>
        /// Converts a native rectangle to a <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="rectangle">The native rectangle to convert.</param>
        /// <returns>The converted managed rectangle.</returns>
        public static object ToRectangle(object rectangle)
        {
            var origValue = (System.Windows.Rect)rectangle;
            return new Rectangle(origValue.X.ToInt(), origValue.Y.ToInt(), origValue.Width.ToInt(), origValue.Height.ToInt());
        }

        public static object ToPoint(object point)
        {
            var origValue = (System.Windows.Point)point;
            return new Point(origValue.X.ToInt(), origValue.Y.ToInt());
        }

        public static object ToCulture(object cultureId)
        {
            var origValue = (int)cultureId;
            return origValue == 0 ? CultureInfo.InvariantCulture : new CultureInfo(origValue);
        }

        public static object IntToIntPtr(object intPtrAsInt)
        {
            var origValue = (int)intPtrAsInt;
            return origValue == 0 ? IntPtr.Zero : new IntPtr(origValue);
        }

        public static System.Windows.Point ToNative(Point point)
        {
            return new System.Windows.Point(point.X, point.Y);
        }
    }
}
