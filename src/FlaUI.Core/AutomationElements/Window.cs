using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a window element.
    /// </summary>
    public class Window : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="Window"/> element.
        /// </summary>
        public Window(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Gets the title of the window.
        /// </summary>
        public string Title => Properties.Name.Value;

        /// <summary>
        /// Gets if the window is modal.
        /// </summary>
        public bool IsModal => Patterns.Window.Pattern.IsModal.Value;

        /// <summary>
        /// Gets the <see cref="TitleBar"/> of the window.
        /// </summary>
        public TitleBar TitleBar => FindFirstChild(cf => cf.ByControlType(ControlType.TitleBar))?.AsTitleBar();

        /// <summary>
        /// Flag to indicate, if the window is the application's main window.
        /// Is used so that it does not need to be looked up again in some cases (e.g. Context Menu).
        /// </summary>
        internal bool IsMainWindow { get; set; }

        /// <summary>
        /// Gets a list of all modal child windows.
        /// </summary>
        public Window[] ModalWindows
        {
            get
            {
                return FindAllDescendants(cf =>
                    cf.ByControlType(ControlType.Window).
                    And(new PropertyCondition(Automation.PropertyLibrary.Window.IsModal, true))
                ).Select(e => e.AsWindow()).ToArray();
            }
        }

        /// <summary>
        /// Gets the current WPF popup window.
        /// </summary>
        public Window Popup
        {
            get
            {
                var mainWindow = GetMainWindow();
                var popup = mainWindow.FindFirstChild(cf => cf.ByControlType(ControlType.Window).And(cf.ByText(String.Empty).And(cf.ByClassName("Popup"))));
                return popup?.AsWindow();
            }
        }

        /// <summary>
        /// Gets the context menu for the window.
        /// Note: It uses the FrameworkType of the window as lookup logic. Use <see cref="GetContextMenuByFrameworkType" /> if you want to control this.
        /// </summary>
        public Menu ContextMenu => GetContextMenuByFrameworkType(FrameworkType);

        /// <summary>
        /// Gets the context menu by a given <see cref="FrameworkType"/>.
        /// </summary>
        public Menu GetContextMenuByFrameworkType(FrameworkType frameworkType)
        {
            if (frameworkType == FrameworkType.Win32)
            {
                // The main menu is directly under the desktop with the name "Context" or in a few cases "System"
                var desktop = FrameworkAutomationElement.Automation.GetDesktop();
                var nameCondition = ConditionFactory.ByName("Context").Or(ConditionFactory.ByName("System")).Or(ConditionFactory.ByClassName("#32768"));
                var ctxMenu = desktop.FindFirstChild(cf => cf.ByControlType(ControlType.Menu).And(nameCondition)).AsMenu();
                if (ctxMenu != null)
                {
                    ctxMenu.IsWin32Menu = true;
                    return ctxMenu;
                }
            }
            var mainWindow = GetMainWindow();
            if (frameworkType == FrameworkType.WinForms)
            {
                var ctxMenu = Retry.WhileNull(() => mainWindow.FindFirstChild(cf =>
                    new AndCondition(
                        new OrCondition(cf.ByControlType(ControlType.Menu), cf.ByControlType(ControlType.ToolBar))
                        , cf.ByName("DropDown"))), TimeSpan.FromSeconds(1)).Result;
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

        /// <summary>
        /// Closes the window.
        /// </summary>
        public void Close()
        {
            var titleBar = TitleBar;
            if (titleBar?.CloseButton != null)
            {
                titleBar.CloseButton.Invoke();
                return;
            }
            if (Patterns.Window.TryGetPattern(out var windowPattern))
            {
                windowPattern.Close();
                return;
            }
            throw new MethodNotSupportedException("Close is not supported");
        }

        /// <summary>
        /// Moves the window to the given coordinates.
        /// </summary>
        public void Move(int x, int y)
        {
            Patterns.Transform.PatternOrDefault?.Move(x, y);
        }

        /// <summary>
        /// Brings the element to the foreground.
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
        /// Gets the main window (first window on desktop with the same process as this window).
        /// </summary>
        private Window GetMainWindow()
        {
            if (IsMainWindow)
            {
                return this;
            }
            var mainWindow = Automation.GetDesktop().FindFirstChild(cf => cf.ByProcessId(Properties.ProcessId.Value)).AsWindow();
            return mainWindow ?? this;
        }
    }
}
