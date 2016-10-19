using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.AutomationElements
{
    public class Window : AutomationElement
    {
        public Window(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public string Title => Current.Name;

        public bool IsModal => WindowPattern.Current.IsModal;

        public TitleBar TitleBar => FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TitleBar)).AsTitleBar();

        public IWindowPattern WindowPattern => PatternFactory.GetWindowPattern();

        public ITransformPattern TransformPattern => PatternFactory.GetTransformPattern();

        internal bool IsMainWindow { get; set; }

        /// <summary>
        /// Gets the contest menu for the window.
        /// Note: It uses the FrameworkType of the window as lookup logic. Use <see cref="GetContextMenuByFrameworkType" /> if you want to control this.
        /// </summary>
        public Menu ContextMenu => GetContextMenuByFrameworkType(FrameworkType);

        public Menu GetContextMenuByFrameworkType(FrameworkType frameworkType)
        {
            var mainWindow = this;
            if (!IsMainWindow)
            {
                // Find the main application window first
                var newMainWindow = BasicAutomationElement.Automation.GetDesktop().FindFirstChild(ConditionFactory.ByProcessId(Current.ProcessId)).AsWindow();
                if (newMainWindow != null)
                {
                    mainWindow = newMainWindow;
                }
            }
            if (frameworkType == FrameworkType.WinForms)
            {
                var ctxMenu = mainWindow.FindFirstChild(ConditionFactory.ByControlType(ControlType.Menu).And(ConditionFactory.ByName("DropDown")));
                return ctxMenu.AsMenu();
            }
            if (frameworkType == FrameworkType.Wpf)
            {
                // In WPF, there is a window without title and inside is the menu
                var windows = mainWindow.FindAllChildren(ConditionFactory.ByControlType(ControlType.Window).And(ConditionFactory.ByText("")));
                foreach (var window in windows)
                {
                    var ctxMenu = window.FindFirstChild(ConditionFactory.ByControlType(ControlType.Menu));
                    return ctxMenu.AsMenu();
                }
            }
            if (frameworkType == FrameworkType.Win32)
            {
                // The main menu is directly under the desktop with the name "Context" or in a few cases "System"
                var desktop = BasicAutomationElement.Automation.GetDesktop();
                var nameCondition = ConditionFactory.ByName("Context").Or(ConditionFactory.ByName("System"));
                var ctxMenu = desktop.FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Menu).And(nameCondition)).AsMenu();
                ctxMenu.IsWin32ContextMenu = true;
                return ctxMenu;
            }
            return null;
        }

        public void Close()
        {
            var titleBar = TitleBar;
            if (titleBar != null && titleBar.CloseButton != null)
            {
                titleBar.CloseButton.Invoke();
                return;
            }
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
