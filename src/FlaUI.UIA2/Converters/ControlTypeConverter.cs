using System;
using FlaUI.Core.Definitions;
using FlaUI.Core.Exceptions;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Converters
{
    /// <summary>
    /// Converter with converts between <see cref="UIA.ControlType"/> and FlaUIs <see cref="ControlType"/>.
    /// </summary>
    public static class ControlTypeConverter
    {
        /// <summary>
        /// Converts a <see cref="UIA.ControlType"/> to a FlaUI <see cref="ControlType"/>.
        /// </summary>
        public static object ToControlType(object nativeControlType)
        {
            var uia2ControlType = (UIA.ControlType)nativeControlType;

            if (Equals(uia2ControlType, UIA.ControlType.Button))
            {
                return ControlType.Button;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Calendar))
            {
                return ControlType.Calendar;
            }
            if (Equals(uia2ControlType, UIA.ControlType.CheckBox))
            {
                return ControlType.CheckBox;
            }
            if (Equals(uia2ControlType, UIA.ControlType.ComboBox))
            {
                return ControlType.ComboBox;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Custom))
            {
                return ControlType.Custom;
            }
            if (Equals(uia2ControlType, UIA.ControlType.DataGrid))
            {
                return ControlType.DataGrid;
            }
            if (Equals(uia2ControlType, UIA.ControlType.DataItem))
            {
                return ControlType.DataItem;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Document))
            {
                return ControlType.Document;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Edit))
            {
                return ControlType.Edit;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Group))
            {
                return ControlType.Group;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Header))
            {
                return ControlType.Header;
            }
            if (Equals(uia2ControlType, UIA.ControlType.HeaderItem))
            {
                return ControlType.HeaderItem;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Hyperlink))
            {
                return ControlType.Hyperlink;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Image))
            {
                return ControlType.Image;
            }
            if (Equals(uia2ControlType, UIA.ControlType.List))
            {
                return ControlType.List;
            }
            if (Equals(uia2ControlType, UIA.ControlType.ListItem))
            {
                return ControlType.ListItem;
            }
            if (Equals(uia2ControlType, UIA.ControlType.MenuBar))
            {
                return ControlType.MenuBar;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Menu))
            {
                return ControlType.Menu;
            }
            if (Equals(uia2ControlType, UIA.ControlType.MenuItem))
            {
                return ControlType.MenuItem;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Pane))
            {
                return ControlType.Pane;
            }
            if (Equals(uia2ControlType, UIA.ControlType.ProgressBar))
            {
                return ControlType.ProgressBar;
            }
            if (Equals(uia2ControlType, UIA.ControlType.RadioButton))
            {
                return ControlType.RadioButton;
            }
            if (Equals(uia2ControlType, UIA.ControlType.ScrollBar))
            {
                return ControlType.ScrollBar;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Separator))
            {
                return ControlType.Separator;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Slider))
            {
                return ControlType.Slider;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Spinner))
            {
                return ControlType.Spinner;
            }
            if (Equals(uia2ControlType, UIA.ControlType.SplitButton))
            {
                return ControlType.SplitButton;
            }
            if (Equals(uia2ControlType, UIA.ControlType.StatusBar))
            {
                return ControlType.StatusBar;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Tab))
            {
                return ControlType.Tab;
            }
            if (Equals(uia2ControlType, UIA.ControlType.TabItem))
            {
                return ControlType.TabItem;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Table))
            {
                return ControlType.Table;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Text))
            {
                return ControlType.Text;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Thumb))
            {
                return ControlType.Thumb;
            }
            if (Equals(uia2ControlType, UIA.ControlType.TitleBar))
            {
                return ControlType.TitleBar;
            }
            if (Equals(uia2ControlType, UIA.ControlType.ToolBar))
            {
                return ControlType.ToolBar;
            }
            if (Equals(uia2ControlType, UIA.ControlType.ToolTip))
            {
                return ControlType.ToolTip;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Tree))
            {
                return ControlType.Tree;
            }
            if (Equals(uia2ControlType, UIA.ControlType.TreeItem))
            {
                return ControlType.TreeItem;
            }
            if (Equals(uia2ControlType, UIA.ControlType.Window))
            {
                return ControlType.Window;
            }

            throw new ArgumentOutOfRangeException(nameof(nativeControlType));
        }

        /// <summary>
        /// Converts a FlaUI <see cref="ControlType"/> to a <see cref="UIA.ControlType"/>.
        /// </summary>
        public static object ToControlTypeNative(ControlType controlType)
        {
            switch (controlType)
            {
                case ControlType.AppBar:
                    throw new NotSupportedByFrameworkException();
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
                    throw new NotSupportedByFrameworkException();
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
                    throw new ArgumentOutOfRangeException(nameof(controlType));
            }
        }
    }
}
