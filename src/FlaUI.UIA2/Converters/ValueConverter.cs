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
                var automationElement = automation.WrapNativeElement(nativeElement);
                retArray[i] = automationElement;
            }
            return retArray;
        }

        public static AutomationElement NativeToManaged(UIA2Automation automation, UIA.AutomationElement nativeElement)
        {
            return automation.WrapNativeElement(nativeElement);
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

        public static object ToControlType(object controlType)
        {
            var uia2ControlType = (UIA.ControlType)controlType;

            if (uia2ControlType == UIA.ControlType.Button)
            {
               return Core.Definitions.ControlType.Button;
            }
            if (uia2ControlType == UIA.ControlType.Calendar)
            {
               return Core.Definitions.ControlType.Calendar;
            }
            if (uia2ControlType == UIA.ControlType.CheckBox)
            {
               return Core.Definitions.ControlType.CheckBox;
            }
            if (uia2ControlType == UIA.ControlType.ComboBox)
            {
               return Core.Definitions.ControlType.ComboBox;
            }
            if (uia2ControlType == UIA.ControlType.Custom)
            {
               return Core.Definitions.ControlType.Custom;
            }
            if (uia2ControlType == UIA.ControlType.DataGrid)
            {
               return Core.Definitions.ControlType.DataGrid;
            }
            if (uia2ControlType == UIA.ControlType.DataItem)
            {
               return Core.Definitions.ControlType.DataItem;
            }
            if (uia2ControlType == UIA.ControlType.Document)
            {
               return Core.Definitions.ControlType.Document;
            }
            if (uia2ControlType == UIA.ControlType.Edit)
            {
               return Core.Definitions.ControlType.Edit;
            }
            if (uia2ControlType == UIA.ControlType.Group)
            {
               return Core.Definitions.ControlType.Group;
            }
            if (uia2ControlType == UIA.ControlType.Header)
            {
               return Core.Definitions.ControlType.Header;
            }
            if (uia2ControlType == UIA.ControlType.HeaderItem)
            {
               return Core.Definitions.ControlType.HeaderItem;
            }
            if (uia2ControlType == UIA.ControlType.Hyperlink)
            {
               return Core.Definitions.ControlType.Hyperlink;
            }
            if (uia2ControlType == UIA.ControlType.Image)
            {
               return Core.Definitions.ControlType.Image;
            }
            if (uia2ControlType == UIA.ControlType.List)
            {
               return Core.Definitions.ControlType.List;
            }
            if (uia2ControlType == UIA.ControlType.ListItem)
            {
               return Core.Definitions.ControlType.ListItem;
            }
            if (uia2ControlType == UIA.ControlType.MenuBar)
            {
               return Core.Definitions.ControlType.MenuBar;
            }
            if (uia2ControlType == UIA.ControlType.Menu)
            {
               return Core.Definitions.ControlType.Menu;
            }
            if (uia2ControlType == UIA.ControlType.MenuItem)
            {
               return Core.Definitions.ControlType.MenuItem;
            }
            if (uia2ControlType == UIA.ControlType.Pane)
            {
               return Core.Definitions.ControlType.Pane;
            }
            if (uia2ControlType == UIA.ControlType.ProgressBar)
            {
               return Core.Definitions.ControlType.ProgressBar;
            }
            if (uia2ControlType == UIA.ControlType.RadioButton)
            {
               return Core.Definitions.ControlType.RadioButton;
            }
            if (uia2ControlType == UIA.ControlType.ScrollBar)
            {
               return Core.Definitions.ControlType.ScrollBar;
            }
            if (uia2ControlType == UIA.ControlType.Separator)
            {
               return Core.Definitions.ControlType.Separator;
            }
            if (uia2ControlType == UIA.ControlType.Slider)
            {
               return Core.Definitions.ControlType.Slider;
            }
            if (uia2ControlType == UIA.ControlType.Spinner)
            {
               return Core.Definitions.ControlType.Spinner;
            }
            if (uia2ControlType == UIA.ControlType.SplitButton)
            {
               return Core.Definitions.ControlType.SplitButton;
            }
            if (uia2ControlType == UIA.ControlType.StatusBar)
            {
               return Core.Definitions.ControlType.StatusBar;
            }
            if (uia2ControlType == UIA.ControlType.Tab)
            {
               return Core.Definitions.ControlType.Tab;
            }
            if (uia2ControlType == UIA.ControlType.TabItem)
            {
               return Core.Definitions.ControlType.TabItem;
            }
            if (uia2ControlType == UIA.ControlType.Table)
            {
               return Core.Definitions.ControlType.Table;
            }
            if (uia2ControlType == UIA.ControlType.Text)
            {
               return Core.Definitions.ControlType.Text;
            }
            if (uia2ControlType == UIA.ControlType.Thumb)
            {
               return Core.Definitions.ControlType.Thumb;
            }
            if (uia2ControlType == UIA.ControlType.TitleBar)
            {
               return Core.Definitions.ControlType.TitleBar;
            }
            if (uia2ControlType == UIA.ControlType.ToolBar)
            {
               return Core.Definitions.ControlType.ToolBar;
            }
            if (uia2ControlType == UIA.ControlType.ToolTip)
            {
               return Core.Definitions.ControlType.ToolTip;
            }
            if (uia2ControlType == UIA.ControlType.Tree)
            {
               return Core.Definitions.ControlType.Tree;
            }
            if (uia2ControlType == UIA.ControlType.TreeItem)
            {
               return Core.Definitions.ControlType.TreeItem;
            }
            if (uia2ControlType == UIA.ControlType.Window)
            {
               return Core.Definitions.ControlType.Window;
            }

            throw new NotSupportedException();
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
