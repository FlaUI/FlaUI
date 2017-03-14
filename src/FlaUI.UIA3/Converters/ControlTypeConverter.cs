using System;
using FlaUI.Core.Definitions;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Converters
{
    public static class ControlTypeConverter
    {
        public static object ToControlType(object nativeControlType)
        {
            switch ((int)nativeControlType)
            {
                case UIA.UIA_ControlTypeIds.UIA_AppBarControlTypeId:
                    return ControlType.AppBar;
                case UIA.UIA_ControlTypeIds.UIA_ButtonControlTypeId:
                    return ControlType.Button;
                case UIA.UIA_ControlTypeIds.UIA_CalendarControlTypeId:
                    return ControlType.Calendar;
                case UIA.UIA_ControlTypeIds.UIA_CheckBoxControlTypeId:
                    return ControlType.CheckBox;
                case UIA.UIA_ControlTypeIds.UIA_ComboBoxControlTypeId:
                    return ControlType.ComboBox;
                case UIA.UIA_ControlTypeIds.UIA_CustomControlTypeId:
                    return ControlType.Custom;
                case UIA.UIA_ControlTypeIds.UIA_DataGridControlTypeId:
                    return ControlType.DataGrid;
                case UIA.UIA_ControlTypeIds.UIA_DataItemControlTypeId:
                    return ControlType.DataItem;
                case UIA.UIA_ControlTypeIds.UIA_DocumentControlTypeId:
                    return ControlType.Document;
                case UIA.UIA_ControlTypeIds.UIA_EditControlTypeId:
                    return ControlType.Edit;
                case UIA.UIA_ControlTypeIds.UIA_GroupControlTypeId:
                    return ControlType.Group;
                case UIA.UIA_ControlTypeIds.UIA_HeaderControlTypeId:
                    return ControlType.Header;
                case UIA.UIA_ControlTypeIds.UIA_HeaderItemControlTypeId:
                    return ControlType.HeaderItem;
                case UIA.UIA_ControlTypeIds.UIA_HyperlinkControlTypeId:
                    return ControlType.Hyperlink;
                case UIA.UIA_ControlTypeIds.UIA_ImageControlTypeId:
                    return ControlType.Image;
                case UIA.UIA_ControlTypeIds.UIA_ListControlTypeId:
                    return ControlType.List;
                case UIA.UIA_ControlTypeIds.UIA_ListItemControlTypeId:
                    return ControlType.ListItem;
                case UIA.UIA_ControlTypeIds.UIA_MenuBarControlTypeId:
                    return ControlType.MenuBar;
                case UIA.UIA_ControlTypeIds.UIA_MenuControlTypeId:
                    return ControlType.Menu;
                case UIA.UIA_ControlTypeIds.UIA_MenuItemControlTypeId:
                    return ControlType.MenuItem;
                case UIA.UIA_ControlTypeIds.UIA_PaneControlTypeId:
                    return ControlType.Pane;
                case UIA.UIA_ControlTypeIds.UIA_ProgressBarControlTypeId:
                    return ControlType.ProgressBar;
                case UIA.UIA_ControlTypeIds.UIA_RadioButtonControlTypeId:
                    return ControlType.RadioButton;
                case UIA.UIA_ControlTypeIds.UIA_ScrollBarControlTypeId:
                    return ControlType.ScrollBar;
                case UIA.UIA_ControlTypeIds.UIA_SemanticZoomControlTypeId:
                    return ControlType.SemanticZoom;
                case UIA.UIA_ControlTypeIds.UIA_SeparatorControlTypeId:
                    return ControlType.Separator;
                case UIA.UIA_ControlTypeIds.UIA_SliderControlTypeId:
                    return ControlType.Slider;
                case UIA.UIA_ControlTypeIds.UIA_SpinnerControlTypeId:
                    return ControlType.Spinner;
                case UIA.UIA_ControlTypeIds.UIA_SplitButtonControlTypeId:
                    return ControlType.SplitButton;
                case UIA.UIA_ControlTypeIds.UIA_StatusBarControlTypeId:
                    return ControlType.StatusBar;
                case UIA.UIA_ControlTypeIds.UIA_TabControlTypeId:
                    return ControlType.Tab;
                case UIA.UIA_ControlTypeIds.UIA_TabItemControlTypeId:
                    return ControlType.TabItem;
                case UIA.UIA_ControlTypeIds.UIA_TableControlTypeId:
                    return ControlType.Table;
                case UIA.UIA_ControlTypeIds.UIA_TextControlTypeId:
                    return ControlType.Text;
                case UIA.UIA_ControlTypeIds.UIA_ThumbControlTypeId:
                    return ControlType.Thumb;
                case UIA.UIA_ControlTypeIds.UIA_TitleBarControlTypeId:
                    return ControlType.TitleBar;
                case UIA.UIA_ControlTypeIds.UIA_ToolBarControlTypeId:
                    return ControlType.ToolBar;
                case UIA.UIA_ControlTypeIds.UIA_ToolTipControlTypeId:
                    return ControlType.ToolTip;
                case UIA.UIA_ControlTypeIds.UIA_TreeControlTypeId:
                    return ControlType.Tree;
                case UIA.UIA_ControlTypeIds.UIA_TreeItemControlTypeId:
                    return ControlType.TreeItem;
                case UIA.UIA_ControlTypeIds.UIA_WindowControlTypeId:
                    return ControlType.Window;
                default:
                    throw new NotSupportedException();
            }
        }

        public static object ToControlTypeNative(ControlType controlType)
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
