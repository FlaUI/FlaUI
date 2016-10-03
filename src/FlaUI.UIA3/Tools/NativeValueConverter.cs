using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Shapes;
using FlaUI.UIA3.Definitions;
using System;
using System.Globalization;
using System.Linq;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Tools
{
    public static class NativeValueConverter
    {
        /// <summary>
        /// Converts a native element array to an array of <see cref="Element"/>
        /// </summary>
        public static Element[] NativeArrayToManaged(UIA3Automation automation, UIA.IUIAutomationElementArray nativeElements)
        {
            if (nativeElements == null) { return new Element[0]; }
            var retArray = new Element[nativeElements.Length];
            for (var i = 0; i < nativeElements.Length; i++)
            {
                var nativeElement = nativeElements.GetElement(i);
                var automationObject = automation.WrapNativeElement(nativeElement);
                retArray[i] = new Element(automationObject);
            }
            return retArray;
        }

        /// <summary>
        /// Converts a native textrange array to an array of <see cref="TextRange"/>
        /// </summary>
        public static TextRange[] NativeArrayToManaged(UIA3Automation automation, UIA.IUIAutomationTextRangeArray nativeElements)
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
        /// Converts a native element to an <see cref="Element"/>
        /// </summary>
        public static Element NativeToManaged(UIA3Automation automation, UIA.IUIAutomationElement nativeElement)
        {
            return nativeElement == null ? null : new Element(automation.WrapNativeElement(nativeElement));
        }

        /// <summary>
        /// Converts a native textrange to an <see cref="TextRange"/>
        /// </summary>
        public static TextRange NativeToManaged(UIA3Automation automation, UIA.IUIAutomationTextRange nativeElement)
        {
            return nativeElement == null ? null : new TextRange(automation, nativeElement);
        }

        /// <summary>
        /// Converts a native textrange2 to an <see cref="TextRange2"/>
        /// </summary>
        public static TextRange2 NativeToManaged(UIA3Automation automation, UIA.IUIAutomationTextRange2 nativeElement)
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
                val = (int)ToControlTypeId((ControlType)val);
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
            else if (val is Element)
            {
                throw new NotImplementedException();
                //val = ((Element)val).NativeElement;
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

        public static object ToControlTypeId(ControlType controlType)
        {
            switch (controlType)
            {
                case ControlType.AppBar:
                    return UIA.UIA_ControlTypeIds.UIA_AppBarControlTypeId;
                case ControlType.Button:
                    return UIA.UIA_ControlTypeIds.UIA_ButtonControlTypeId;
                case ControlType.Calendar:
                    return UIA.UIA_ControlTypeIds.UIA_CalendarControlTypeId;
                case ControlType.CheckBox:
                    return UIA.UIA_ControlTypeIds.UIA_CheckBoxControlTypeId;
                case ControlType.ComboBox:
                    return UIA.UIA_ControlTypeIds.UIA_ComboBoxControlTypeId;
                case ControlType.Custom:
                    return UIA.UIA_ControlTypeIds.UIA_CustomControlTypeId;
                case ControlType.DataGrid:
                    return UIA.UIA_ControlTypeIds.UIA_DataGridControlTypeId;
                case ControlType.DataItem:
                    return UIA.UIA_ControlTypeIds.UIA_DataItemControlTypeId;
                case ControlType.Document:
                    return UIA.UIA_ControlTypeIds.UIA_DocumentControlTypeId;
                case ControlType.Edit:
                    return UIA.UIA_ControlTypeIds.UIA_EditControlTypeId;
                case ControlType.Group:
                    return UIA.UIA_ControlTypeIds.UIA_GroupControlTypeId;
                case ControlType.Header:
                    return UIA.UIA_ControlTypeIds.UIA_HeaderControlTypeId;
                case ControlType.HeaderItem:
                    return UIA.UIA_ControlTypeIds.UIA_HeaderItemControlTypeId;
                case ControlType.Hyperlink:
                    return UIA.UIA_ControlTypeIds.UIA_HyperlinkControlTypeId;
                case ControlType.Image:
                    return UIA.UIA_ControlTypeIds.UIA_ImageControlTypeId;
                case ControlType.List:
                    return UIA.UIA_ControlTypeIds.UIA_ListControlTypeId;
                case ControlType.ListItem:
                    return UIA.UIA_ControlTypeIds.UIA_ListItemControlTypeId;
                case ControlType.MenuBar:
                    return UIA.UIA_ControlTypeIds.UIA_MenuBarControlTypeId;
                case ControlType.Menu:
                    return UIA.UIA_ControlTypeIds.UIA_MenuControlTypeId;
                case ControlType.MenuItem:
                    return UIA.UIA_ControlTypeIds.UIA_MenuItemControlTypeId;
                case ControlType.Pane:
                    return UIA.UIA_ControlTypeIds.UIA_PaneControlTypeId;
                case ControlType.ProgressBar:
                    return UIA.UIA_ControlTypeIds.UIA_ProgressBarControlTypeId;
                case ControlType.RadioButton:
                    return UIA.UIA_ControlTypeIds.UIA_RadioButtonControlTypeId;
                case ControlType.ScrollBar:
                    return UIA.UIA_ControlTypeIds.UIA_ScrollBarControlTypeId;
                case ControlType.SemanticZoom:
                    return UIA.UIA_ControlTypeIds.UIA_SemanticZoomControlTypeId;
                case ControlType.Separator:
                    return UIA.UIA_ControlTypeIds.UIA_SeparatorControlTypeId;
                case ControlType.Slider:
                    return UIA.UIA_ControlTypeIds.UIA_SliderControlTypeId;
                case ControlType.Spinner:
                    return UIA.UIA_ControlTypeIds.UIA_SpinnerControlTypeId;
                case ControlType.SplitButton:
                    return UIA.UIA_ControlTypeIds.UIA_SplitButtonControlTypeId;
                case ControlType.StatusBar:
                    return UIA.UIA_ControlTypeIds.UIA_StatusBarControlTypeId;
                case ControlType.Tab:
                    return UIA.UIA_ControlTypeIds.UIA_TabControlTypeId;
                case ControlType.TabItem:
                    return UIA.UIA_ControlTypeIds.UIA_TabItemControlTypeId;
                case ControlType.Table:
                    return UIA.UIA_ControlTypeIds.UIA_TableControlTypeId;
                case ControlType.Text:
                    return UIA.UIA_ControlTypeIds.UIA_TextControlTypeId;
                case ControlType.Thumb:
                    return UIA.UIA_ControlTypeIds.UIA_ThumbControlTypeId;
                case ControlType.TitleBar:
                    return UIA.UIA_ControlTypeIds.UIA_TitleBarControlTypeId;
                case ControlType.ToolBar:
                    return UIA.UIA_ControlTypeIds.UIA_ToolBarControlTypeId;
                case ControlType.ToolTip:
                    return UIA.UIA_ControlTypeIds.UIA_ToolTipControlTypeId;
                case ControlType.Tree:
                    return UIA.UIA_ControlTypeIds.UIA_TreeControlTypeId;
                case ControlType.TreeItem:
                    return UIA.UIA_ControlTypeIds.UIA_TreeItemControlTypeId;
                case ControlType.Window:
                    return UIA.UIA_ControlTypeIds.UIA_WindowControlTypeId;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
