using System;
using System.Drawing;
using System.Globalization;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;

namespace FlaUI.UIA3.Converters
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
                val = (int)ControlTypeConverter.ToControlTypeNative((ControlType)val);
            }
            else if (val is AnnotationType)
            {
                val = (int)AnnotationTypeConverter.ToAnnotationTypeNative((AnnotationType)val);
            }
            else if (val is Rectangle)
            {
                var rect = (Rectangle)val;
                val = new[] { rect.Left, rect.Top, rect.Width, rect.Height };
            }
            else if (val is Point)
            {
                var point = (Point)val;
                val = new[] { point.X, point.Y };
            }
            else if (val is CultureInfo)
            {
                val = ((CultureInfo)val).LCID;
            }
            else if (val is AutomationElement)
            {
                val = AutomationElementConverter.ToNative((AutomationElement)val);
            }
            return val;
        }

        public static object ToRectangle(object rectangle)
        {
            var origValue = (double[])rectangle;
            if (rectangle == null)
            {
                return null;
            }
            return new Rectangle(origValue[0].ToInt(), origValue[1].ToInt(), origValue[2].ToInt(), origValue[3].ToInt());
        }

        public static object ToPoint(object point)
        {
            var origValue = (double[])point;
            if (point == null)
            {
                return null;
            }
            return new Point(origValue[0].ToInt(), origValue[1].ToInt());
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
    }
}
