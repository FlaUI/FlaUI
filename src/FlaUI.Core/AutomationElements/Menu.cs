using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
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

        public MenuItem[] MenuItems
        {
            get
            {
                return FindAllChildren(cf => cf.ByControlType(ControlType.MenuItem)).Select(e =>
                  {
                      var mi = e.AsMenuItem();
                      mi.IsWin32ContextMenu = IsWin32ContextMenu;
                      return mi;
                  }).ToArray();
            }
        }

        /// <summary>
        /// Flag to indicate, if the menu is a Win32 context menu because that one needs special handling
        /// </summary>
        internal bool IsWin32ContextMenu { get; set; }
    }
}
