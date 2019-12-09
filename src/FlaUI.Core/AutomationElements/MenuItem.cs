using System.Linq;
using System.Threading;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a menu item element.
    /// </summary>
    public class MenuItem : AutomationElement
    {
        private readonly InvokeAutomationElement _invokeAutomationElement;
        private readonly ExpandCollapseAutomationElement _expandCollapseAutomationElement;
        private readonly ToggleAutomationElement _toggleAutomationElement;

        /// <summary>
        /// Creates a <see cref="MenuItem"/> element.
        /// </summary>
        public MenuItem(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
            _invokeAutomationElement = new InvokeAutomationElement(frameworkAutomationElement);
            _expandCollapseAutomationElement = new ExpandCollapseAutomationElement(frameworkAutomationElement);
            _toggleAutomationElement = new ToggleAutomationElement(frameworkAutomationElement);
        }

        /// <summary>
        /// Flag to indicate if the containing menu is a Win32 menu because that one needs special handling
        /// </summary>
        internal bool IsWin32Menu { get; set; }

        /// <summary>
        /// Gets the text of the element.
        /// </summary>
        public string Text => Properties.Name.Value;

        /// <summary>
        /// Gets all <see cref="MenuItem"/> which are inside this element.
        /// </summary>
        public MenuItems Items
        {
            get
            {
                // Special handling for Win32 context menus
                if (IsWin32Menu)
                {
                    // Click the item to load the child items
                    Click();
                    // In Win32, the nested menu items are below a menu control which is below the application window
                    // So search the app window first
                    var appWindow = FrameworkAutomationElement.Automation.GetDesktop().FindFirstChild(cf => cf.ByControlType(ControlType.Window).And(cf.ByProcessId(Properties.ProcessId)));
                    // Then search the menu below the window
                    var menu = appWindow.FindFirstChild(cf => cf.ByControlType(ControlType.Menu).And(cf.ByName(Text))).AsMenu();
                    menu.IsWin32Menu = true;
                    // Now return the menu items
                    return menu.Items;
                }
                // Expand if needed, WinForms does not have the expand pattern but all children are already visible so it works as well
                if (Patterns.ExpandCollapse.IsSupported)
                {
                    ExpandCollapseState state;
                    do
                    {
                        state = _expandCollapseAutomationElement.ExpandCollapseState;
                        if (state == ExpandCollapseState.Collapsed)
                        {
                            Expand();
                        }
                        Thread.Sleep(50);
                    } while (state != ExpandCollapseState.Expanded);
                }
                var childItems = FindAllChildren(cf => cf.ByControlType(ControlType.MenuItem)).Select(e => e.AsMenuItem());
                return new MenuItems(childItems);
            }
        }

        /// <summary>
        /// Invokes the element.
        /// </summary>
        public MenuItem Invoke()
        {
            _invokeAutomationElement.Invoke();
            return this;
        }

        /// <summary>
        /// Expands the element.
        /// </summary>
        public MenuItem Expand()
        {
            _expandCollapseAutomationElement.Expand();
            return this;
        }

        /// <summary>
        /// Collapses the element.
        /// </summary>
        public MenuItem Collapse()
        {
            _expandCollapseAutomationElement.Collapse();
            return this;
        }
        
        /// <summary>
        /// Gets or sets if a menu item is checked or unchecked, if checking is supported.
        /// For some applications, like WPF, setting this property doesn't execute the action that happens when a user clicks the menu item, only the checked state is changed.
        /// For WPF and Windows Forms applications, if you want to execute the action too, you need to use Invoke() method.
        /// </summary>
        public bool? IsChecked
        {
            get
            {
                if (FrameworkType == FrameworkType.Win32)
                {
                    if (Patterns.Toggle.IsSupported)
                    {
                        return _toggleAutomationElement.IsToggled;
                    }
                    else
                    {
                        // Toggle pattern is supported only for checked menu items. This strange behaviour happens only for Win32 applications.
                        // Toggle pattern is not present on menu items that support checking but are unchecked.
                        // Menu items that doesn't support Toggle pattern are considered unchecked.
                        return false;
                    }
                }
                else
                {
                    // WinForms doesn't support Toggle pattern at all. WPF fully supports Toggle pattern.
                    return _toggleAutomationElement.IsToggled;
                }
            }
            set
            {
                if (FrameworkType == FrameworkType.Win32)
                {
                    if (Patterns.Toggle.IsSupported)
                    {
                        _toggleAutomationElement.IsToggled = value;
                    }
                    else
                    {
                        // here the menu item is unchecked because Toggle pattern is not supported
                        if (value == true)
                        {
                            _invokeAutomationElement.Invoke();
                        }
                    }
                }
                else
                {
                    _toggleAutomationElement.IsToggled = value;
                }
            }
        }
    }
}
