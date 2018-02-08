using System;
using System.Globalization;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Shapes;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Converters
{
    public static class ValueConverter
    {
        /// <summary>
        /// Converts the given object to an object the native client expects
        /// </summary>
        public static object ToNative(object val)
        {
            if (val == null)
            {
                return null;
            }
            if (val is ControlType)
            {
                val = (UIA.ControlType)ControlTypeConverter.ToControlTypeNative((ControlType)val);
            }
            else if (val is AutomationElement)
            {
                val = ToNative((AutomationElement)val);
            }
            return val;
        }

        public static object ToRectangle(object rectangle)
        {
            var origValue = (System.Windows.Rect)rectangle;
            return new Rectangle(origValue.X, origValue.Y, origValue.Width, origValue.Height);
        }

        public static object ToPoint(object point)
        {
            var origValue = (System.Windows.Point)point;
            return new Point(origValue.X, origValue.Y);
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
