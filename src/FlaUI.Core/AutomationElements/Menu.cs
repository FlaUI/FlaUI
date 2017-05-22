using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Represents a menu or a menubar, which contains menuitems
    /// </summary>
    public class Menu : AutomationElement
    {
        public Menu(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public MenuItems MenuItems
        {
            get
            {
                var childItems = FindAllChildren(cf => cf.ByControlType(ControlType.MenuItem))
                    .Select(e =>
                    {
                        var mi = e.AsMenuItem();
                        mi.IsWin32Menu = IsWin32Menu;
                        return mi;
                    });
                return new MenuItems(childItems);
            }
        }

        /// <summary>
        /// Flag to indicate if the menu is a Win32 menu because that one needs special handling
        /// </summary>
        public bool IsWin32Menu { get; set; }
    }

    /// <summary>
    /// Represents a menuitem which can also contain sub-menuitems
    /// </summary>
    public class MenuItem : AutomationElement
    {
        private readonly InvokeAutomationElement _invokeAutomationElement;
        private readonly ExpandCollapseAutomationElement _expandCollapseAutomationElement;

        public MenuItem(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
            _invokeAutomationElement = new InvokeAutomationElement(basicAutomationElement);
            _expandCollapseAutomationElement = new ExpandCollapseAutomationElement(basicAutomationElement);
        }

        /// <summary>
        /// Flag to indicate if the containing menu is a Win32 menu because that one needs special handling
        /// </summary>
        internal bool IsWin32Menu { get; set; }

        public string Text => Properties.Name.Value;

        public MenuItems SubMenuItems
        {
            get
            {
                Console.WriteLine(FrameworkType);
                // Special handling for Win32 context menus
                if (IsWin32Menu)
                {
                    // Click the item to load the child items
                    Click();
                    // In Win32, the nested menu items are below a menu control which is below the application window
                    // So search the app window first
                    var appWindow = BasicAutomationElement.Automation.GetDesktop().FindFirstChild(cf => cf.ByControlType(ControlType.Window).And(cf.ByProcessId(Properties.ProcessId)));
                    // Then search the menu below the window
                    var menu = appWindow.FindFirstChild(cf => cf.ByControlType(ControlType.Menu).And(cf.ByName(Text))).AsMenu();
                    menu.IsWin32Menu = true;
                    // Now return the menu items
                    return menu.MenuItems;
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

        public MenuItem Invoke()
        {
            _invokeAutomationElement.Invoke();
            return this;
        }

        public MenuItem Expand()
        {
            _expandCollapseAutomationElement.Expand();
            return this;
        }

        public MenuItem Collapse()
        {
            _expandCollapseAutomationElement.Collapse();
            return this;
        }
    }

    /// <summary>
    /// Represents a list of <see cref="MenuItem"/>s.
    /// </summary>
    public class MenuItems : List<MenuItem>
    {
        public MenuItems(IEnumerable<MenuItem> collection) : base(collection)
        {
        }

        public int Length => Count;

        public MenuItem this[string text]
        {
            get { return this.FirstOrDefault(x => x.Text.Equals(text)); }
        }
    }
}
