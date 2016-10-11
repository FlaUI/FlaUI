using System;
using System.Globalization;
using System.Windows;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Shapes;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Converters
{
    public static class ValueConverter
    {
        public static AutomationElement[] NativeArrayToManaged(UIA2Automation automation, UIA.AutomationElementCollection nativeElements)
        {
            if (nativeElements == null)
            {
                return new AutomationElement[0];
            }
            var retArray = new AutomationElement[nativeElements.Count];
            for (var i = 0; i < nativeElements.Count; i++)
            {
                var nativeElement = nativeElements[i];
                var basicAutomationElement = automation.WrapNativeElement(nativeElement);
                retArray[i] = new AutomationElement(basicAutomationElement);
            }
            return retArray;
        }

        public static AutomationElement NativeToManaged(UIA2Automation automation, UIA.AutomationElement nativeElement)
        {
            return nativeElement == null ? null : new AutomationElement(automation.WrapNativeElement(nativeElement));
        }

        public static object ToPoint(object point)
        {
            var origValue = (System.Windows.Point)point;
            if (origValue == null)
            {
                return null;
            }
            return new Core.Shapes.Point(origValue.X, origValue.Y);
        }

        public static object ToRectangle(object rectangle)
        {
            var origValue = (Rect)rectangle;
            if (origValue == null)
            {
                return null;
            }
            return new Rectangle(origValue.X, origValue.Y, origValue.Width, origValue.Height);
        }

        public static UIA.AutomationElement ToNative(AutomationElement automationElement)
        {
            var basicAutomationElement = (UIA2BasicAutomationElement)automationElement.BasicAutomationElement;
            return basicAutomationElement.NativeElement;
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
            if (val is Core.Definitions.ControlType)
            {
                val = (UIA.ControlType)ToControlTypeId((Core.Definitions.ControlType)val);
            }
            else if (val is AutomationElement)
            {
                val = ToNative((AutomationElement)val);
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

        public static object ToControlTypeId(Core.Definitions.ControlType controlType)
        {
            switch (controlType)
            {
                case Core.Definitions.ControlType.AppBar:
                    throw new NotSupportedByUIA2Exception();
                case Core.Definitions.ControlType.Button:
                    return UIA.ControlType.Button;
                case Core.Definitions.ControlType.Calendar:
                    return UIA.ControlType.Calendar;
                case Core.Definitions.ControlType.CheckBox:
                    return UIA.ControlType.CheckBox;
                case Core.Definitions.ControlType.ComboBox:
                    return UIA.ControlType.ComboBox;
                case Core.Definitions.ControlType.Custom:
                    return UIA.ControlType.Custom;
                case Core.Definitions.ControlType.DataGrid:
                    return UIA.ControlType.DataGrid;
                case Core.Definitions.ControlType.DataItem:
                    return UIA.ControlType.DataItem;
                case Core.Definitions.ControlType.Document:
                    return UIA.ControlType.Document;
                case Core.Definitions.ControlType.Edit:
                    return UIA.ControlType.Edit;
                case Core.Definitions.ControlType.Group:
                    return UIA.ControlType.Group;
                case Core.Definitions.ControlType.Header:
                    return UIA.ControlType.Header;
                case Core.Definitions.ControlType.HeaderItem:
                    return UIA.ControlType.HeaderItem;
                case Core.Definitions.ControlType.Hyperlink:
                    return UIA.ControlType.Hyperlink;
                case Core.Definitions.ControlType.Image:
                    return UIA.ControlType.Image;
                case Core.Definitions.ControlType.List:
                    return UIA.ControlType.List;
                case Core.Definitions.ControlType.ListItem:
                    return UIA.ControlType.ListItem;
                case Core.Definitions.ControlType.MenuBar:
                    return UIA.ControlType.MenuBar;
                case Core.Definitions.ControlType.Menu:
                    return UIA.ControlType.Menu;
                case Core.Definitions.ControlType.MenuItem:
                    return UIA.ControlType.MenuItem;
                case Core.Definitions.ControlType.Pane:
                    return UIA.ControlType.Pane;
                case Core.Definitions.ControlType.ProgressBar:
                    return UIA.ControlType.ProgressBar;
                case Core.Definitions.ControlType.RadioButton:
                    return UIA.ControlType.RadioButton;
                case Core.Definitions.ControlType.ScrollBar:
                    return UIA.ControlType.ScrollBar;
                case Core.Definitions.ControlType.SemanticZoom:
                    throw new NotSupportedByUIA2Exception();
                case Core.Definitions.ControlType.Separator:
                    return UIA.ControlType.Separator;
                case Core.Definitions.ControlType.Slider:
                    return UIA.ControlType.Slider;
                case Core.Definitions.ControlType.Spinner:
                    return UIA.ControlType.Spinner;
                case Core.Definitions.ControlType.SplitButton:
                    return UIA.ControlType.SplitButton;
                case Core.Definitions.ControlType.StatusBar:
                    return UIA.ControlType.StatusBar;
                case Core.Definitions.ControlType.Tab:
                    return UIA.ControlType.Tab;
                case Core.Definitions.ControlType.TabItem:
                    return UIA.ControlType.TabItem;
                case Core.Definitions.ControlType.Table:
                    return UIA.ControlType.Table;
                case Core.Definitions.ControlType.Text:
                    return UIA.ControlType.Text;
                case Core.Definitions.ControlType.Thumb:
                    return UIA.ControlType.Thumb;
                case Core.Definitions.ControlType.TitleBar:
                    return UIA.ControlType.TitleBar;
                case Core.Definitions.ControlType.ToolBar:
                    return UIA.ControlType.ToolBar;
                case Core.Definitions.ControlType.ToolTip:
                    return UIA.ControlType.ToolTip;
                case Core.Definitions.ControlType.Tree:
                    return UIA.ControlType.Tree;
                case Core.Definitions.ControlType.TreeItem:
                    return UIA.ControlType.TreeItem;
                case Core.Definitions.ControlType.Window:
                    return UIA.ControlType.Window;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
