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

        public string Title => Properties.Name;

        public bool IsModal => WindowPattern.IsModal.Value;

        public TitleBar TitleBar => FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TitleBar)).AsTitleBar();

        public IWindowPattern WindowPattern => Patterns.Window.Pattern;

        public ITransformPattern TransformPattern => Patterns.Transform.Pattern;

        /// <summary>
        /// Flag to indicate, if the window is the application's main window.
        /// Is used so that it does not need to be looked up again in some cases (e.g. Context Menu).
        /// </summary>
        internal bool IsMainWindow { get; set; }

        public Window[] ModalWindows
        {
            get
            {
                return FindAllChildren(cf => cf.ByControlType(ControlType.Window).And(new PropertyCondition(Automation.PropertyLibrary.Window.IsModal, true))).
                    Select(e => e.AsWindow()).ToArray();
            }
        }

        /// <summary>
        /// Gets the current WPF popup window
        /// </summary>
        public Window Popup
        {
            get
            {
                var mainWindow = GetMainWindow();
                var popup = mainWindow.FindFirstChild(cf => cf.ByControlType(ControlType.Window).And(cf.ByText("").And(cf.ByClassName("Popup"))));
                return popup.AsWindow();
            }
        }

        /// <summary>
        /// Gets the contest menu for the window.
        /// Note: It uses the FrameworkType of the window as lookup logic. Use <see cref="GetContextMenuByFrameworkType" /> if you want to control this.
        /// </summary>
        public Menu ContextMenu => GetContextMenuByFrameworkType(FrameworkType);

        public Menu GetContextMenuByFrameworkType(FrameworkType frameworkType)
        {
            if (frameworkType == FrameworkType.Win32)
            {
                // The main menu is directly under the desktop with the name "Context" or in a few cases "System"
                var desktop = BasicAutomationElement.Automation.GetDesktop();
                var nameCondition = ConditionFactory.ByName("Context").Or(ConditionFactory.ByName("System"));
                var ctxMenu = desktop.FindFirstChild(cf => cf.ByControlType(ControlType.Menu).And(nameCondition)).AsMenu();
                if (ctxMenu != null)
                {
                    ctxMenu.IsWin32ContextMenu = true;
                    return ctxMenu;
                }
            }
            var mainWindow = GetMainWindow();
            if (frameworkType == FrameworkType.WinForms)
            {
                var ctxMenu = mainWindow.FindFirstChild(cf => cf.ByControlType(ControlType.Menu).And(cf.ByName("DropDown")));
                return ctxMenu.AsMenu();
            }
            if (frameworkType == FrameworkType.Wpf)
            {
                // In WPF, there is a window (Popup) where the menu is inside
                var popup = Popup;
                var ctxMenu = popup.FindFirstChild(cf => cf.ByControlType(ControlType.Menu));
                return ctxMenu.AsMenu();
            }
            // No menu found
            return null;
        }

        public void Close()
        {
            var titleBar = TitleBar;
            if (titleBar?.CloseButton != null)
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
            TransformPattern?.Move(x, y);
        }

        /// <summary>
        /// Brings the element to the foreground
        /// </summary>
        public void SetTransparency(byte alpha)
        {
            if (User32.SetWindowLong(Properties.NativeWindowHandle, WindowLongParam.GWL_EXSTYLE, WindowStyles.WS_EX_LAYERED) == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            if (!User32.SetLayeredWindowAttributes(Properties.NativeWindowHandle, 0, alpha, LayeredWindowAttributes.LWA_ALPHA))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        /// <summary>
        /// Gets the main window (first window on desktop with the same process as this window)
        /// </summary>
        private Window GetMainWindow()
        {
            if (IsMainWindow)
            {
                return this;
            }
            var mainWindow = BasicAutomationElement.Automation.GetDesktop().FindFirstChild(cf => cf.ByProcessId(Properties.ProcessId)).AsWindow();
            return mainWindow ?? this;
        }
    }
}
