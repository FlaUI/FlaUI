using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;
using FlaUI.Core.WindowsAPI;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace FlaUI.Core.Elements
{
    public class Window : Element
    {
        public Window(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public string Title => Current.Name;

        public bool IsModal => WindowPattern.Current.IsModal;

        //public TitleBar TitleBar
        //{
        //    get
        //    {
        //        var titleBarElement = FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TitleBar));
        //        return titleBarElement.AsTitleBar();
        //    }
        //}

        public IWindowPattern WindowPattern => PatternFactory.GetWindowPattern();

        public ITransformPattern TransformPattern => PatternFactory.GetTransformPattern();

        public void Close()
        {
            //TitleBar titleBar = TitleBar;
            //if (titleBar != null && titleBar.CloseButton != null)
            //{
            //    titleBar.CloseButton.Invoke();
            //    return;
            //}
            var windowPattern = WindowPattern;
            if (windowPattern != null)
            {
                windowPattern.Close();
                return;
            }
            throw new MethodNotSupportedException("Close is not supported");
        }

        public void Move(int x, int y)
        {
            var transformPattern = TransformPattern;
            if (transformPattern != null)
            {
                transformPattern.Move(x, y);
            }
        }

        public Window[] GetModalWindows()
        {
            return FindAll(TreeScope.Children,
                new PropertyCondition(Properties.ControlTypeProperty, ControlType.Window).
                And(new PropertyCondition(WindowPattern.Properties.IsModalProperty, true))).
                Select(e => e.AsWindow()).ToArray();
        }

        /// <summary>
        /// Brings the element to the foreground
        /// </summary>
        public void SetTransparency(byte alpha)
        {
            if (User32.SetWindowLong(Current.NativeWindowHandle, WindowLongParam.GWL_EXSTYLE, WindowStyles.WS_EX_LAYERED) == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            if (!User32.SetLayeredWindowAttributes(Current.NativeWindowHandle, 0, alpha, LayeredWindowAttributes.LWA_ALPHA))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }
}
