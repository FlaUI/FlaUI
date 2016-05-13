using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Shapes;
using interop.UIAutomationCore;
using System;
using System.Globalization;
using System.Linq;

namespace FlaUI.Core.Tools
{
    public static class NativeValueConverter
    {
        /// <summary>
        /// Converts a native element array to an array of <see cref="AutomationElement"/>
        /// </summary>
        public static AutomationElement[] NativeArrayToManaged(Automation automation, IUIAutomationElementArray nativeElements)
        {
            if (nativeElements == null) { return new AutomationElement[0]; }
            var retArray = new AutomationElement[nativeElements.Length];
            for (var i = 0; i < nativeElements.Length; i++)
            {
                retArray[i] = new AutomationElement(automation, nativeElements.GetElement(i));
            }
            return retArray;
        }

        /// <summary>
        /// Converts a native textrange array to an array of <see cref="TextRange"/>
        /// </summary>
        public static TextRange[] NativeArrayToManaged(Automation automation, IUIAutomationTextRangeArray nativeElements)
        {
            if (nativeElements == null) { return new TextRange[0]; }
            var retArray = new TextRange[nativeElements.Length];
            for (var i = 0; i < nativeElements.Length; i++)
            {
                retArray[i] = NativeToManaged(automation, nativeElements.GetElement(i));
            }
            return retArray;
        }

        /// <summary>
        /// Converts a native element to an <see cref="AutomationElement"/>
        /// </summary>
        public static AutomationElement NativeToManaged(Automation automation, IUIAutomationElement nativeElement)
        {
            return nativeElement == null ? null : new AutomationElement(automation, nativeElement);
        }

        /// <summary>
        /// Converts a native textrange to an <see cref="TextRange"/>
        /// </summary>
        public static TextRange NativeToManaged(Automation automation, IUIAutomationTextRange nativeElement)
        {
            return nativeElement == null ? null : new TextRange(automation, nativeElement);
        }

        /// <summary>
        /// Converts a native textrange2 to an <see cref="TextRange2"/>
        /// </summary>
        public static TextRange2 NativeToManaged(Automation automation, IUIAutomationTextRange2 nativeElement)
        {
            return nativeElement == null ? null : new TextRange2(automation, nativeElement);
        }

        /// <summary>
        /// Converts the given object to an object the native client expects
        /// </summary>
        public static object ToNative(object val)
        {
            if (val == null) { return null; }
            if (val is ControlType)
            {
                val = (int)((ControlType)val);
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
                val = ((AutomationElement)val).NativeElement;
            }
            return val;
        }

        /// <summary>
        /// Converts <see cref="T:int[]"/> to <see cref="T:AnnotationType[]"/>
        /// </summary>
        public static object ToAnnotationTypes(object annotationTypes)
        {
            var origValue = (int[])annotationTypes;
            return origValue.Cast<AnnotationType>().ToArray();
        }

        /// <summary>
        ///  Converts <see cref="T:double[4]"/> to <see cref="Rectangle"/>
        /// </summary>
        public static object ToRectangle(object rectangle)
        {
            var origValue = (double[])rectangle;
            if (rectangle == null) { return null; }
            return new Rectangle(origValue[0], origValue[1], origValue[2], origValue[3]);
        }

        /// <summary>
        ///  Converts <see cref="T:double[2]"/> to <see cref="Point"/>
        /// </summary>
        public static object ToPoint(object point)
        {
            var origValue = (double[])point;
            if (point == null) { return null; }
            return new Point(origValue[0], origValue[1]);
        }

        /// <summary>
        ///  Converts <see cref="int"/> to <see cref="CultureInfo"/>
        /// </summary>
        public static object ToCulture(object cultureId)
        {
            var origValue = (int)cultureId;
            return origValue == 0 ? CultureInfo.InvariantCulture : new CultureInfo(origValue);
        }

        /// <summary>
        ///  Converts <see cref="int"/> to <see cref="IntPtr"/>
        /// </summary>
        public static object IntToIntPtr(object intPtrAsInt)
        {
            var origValue = (int)intPtrAsInt;
            return origValue == 0 ? IntPtr.Zero : new IntPtr(origValue);
        }
    }
}
