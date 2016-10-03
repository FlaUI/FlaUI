using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Shapes;
using System;
using System.Globalization;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Tools
{
    public static class NativeValueConverter
    {
        public static Element[] NativeArrayToManaged(UIA2Automation automation, UIA.AutomationElementCollection nativeElements)
        {
            if (nativeElements == null)
            {
                return new Element[0];
            }
            var retArray = new Element[nativeElements.Count];
            for (var i = 0; i < nativeElements.Count; i++)
            {
                var nativeElement = nativeElements[i];
                var automationObject = automation.WrapNativeElement(nativeElement);
                retArray[i] = new Element(automationObject);
            }
            return retArray;
        }

        public static Element NativeToManaged(UIA2Automation automation, UIA.AutomationElement nativeElement)
        {
            return nativeElement == null ? null : new Element(automation.WrapNativeElement(nativeElement));
        }

        public static object ToPoint(object point)
        {
            var origValue = (System.Windows.Point)point;
            if (origValue == null)
            {
                return null;
            }
            return new Point(origValue.X, origValue.Y);
        }

        public static object ToRectangle(object rectangle)
        {
            var origValue = (System.Windows.Rect)rectangle;
            if (origValue == null) { return null; }
            return new Rectangle(origValue.X, origValue.Y, origValue.Width, origValue.Height);
        }

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
                val = (UIA.ControlType)ToControlTypeId((ControlType)val);
            }
            return val;
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

        public static object ToControlTypeId(ControlType controlType)
        {
            switch (controlType)
            {
                case ControlType.AppBar:
                    throw new NotSupportedByUIA2Exception();
                case ControlType.Button:
                    return UIA.ControlType.Button;
                case ControlType.Calendar:
                    return UIA.ControlType.Calendar;
                case ControlType.CheckBox:
                    return UIA.ControlType.CheckBox;
                case ControlType.ComboBox:
                    return UIA.ControlType.ComboBox;
                case ControlType.Custom:
                    return UIA.ControlType.Custom;
                case ControlType.DataGrid:
                    return UIA.ControlType.DataGrid;
                case ControlType.DataItem:
                    return UIA.ControlType.DataItem;
                case ControlType.Document:
                    return UIA.ControlType.Document;
                case ControlType.Edit:
                    return UIA.ControlType.Edit;
                case ControlType.Group:
                    return UIA.ControlType.Group;
                case ControlType.Header:
                    return UIA.ControlType.Header;
                case ControlType.HeaderItem:
                    return UIA.ControlType.HeaderItem;
                case ControlType.Hyperlink:
                    return UIA.ControlType.Hyperlink;
                case ControlType.Image:
                    return UIA.ControlType.Image;
                case ControlType.List:
                    return UIA.ControlType.List;
                case ControlType.ListItem:
                    return UIA.ControlType.ListItem;
                case ControlType.MenuBar:
                    return UIA.ControlType.MenuBar;
                case ControlType.Menu:
                    return UIA.ControlType.Menu;
                case ControlType.MenuItem:
                    return UIA.ControlType.MenuItem;
                case ControlType.Pane:
                    return UIA.ControlType.Pane;
                case ControlType.ProgressBar:
                    return UIA.ControlType.ProgressBar;
                case ControlType.RadioButton:
                    return UIA.ControlType.RadioButton;
                case ControlType.ScrollBar:
                    return UIA.ControlType.ScrollBar;
                case ControlType.SemanticZoom:
                    throw new NotSupportedByUIA2Exception();
                case ControlType.Separator:
                    return UIA.ControlType.Separator;
                case ControlType.Slider:
                    return UIA.ControlType.Slider;
                case ControlType.Spinner:
                    return UIA.ControlType.Spinner;
                case ControlType.SplitButton:
                    return UIA.ControlType.SplitButton;
                case ControlType.StatusBar:
                    return UIA.ControlType.StatusBar;
                case ControlType.Tab:
                    return UIA.ControlType.Tab;
                case ControlType.TabItem:
                    return UIA.ControlType.TabItem;
                case ControlType.Table:
                    return UIA.ControlType.Table;
                case ControlType.Text:
                    return UIA.ControlType.Text;
                case ControlType.Thumb:
                    return UIA.ControlType.Thumb;
                case ControlType.TitleBar:
                    return UIA.ControlType.TitleBar;
                case ControlType.ToolBar:
                    return UIA.ControlType.ToolBar;
                case ControlType.ToolTip:
                    return UIA.ControlType.ToolTip;
                case ControlType.Tree:
                    return UIA.ControlType.Tree;
                case ControlType.TreeItem:
                    return UIA.ControlType.TreeItem;
                case ControlType.Window:
                    return UIA.ControlType.Window;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}