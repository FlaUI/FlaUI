using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a menu or menubar element.
    /// </summary>
    public class Menu : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="Menu"/> element.
        /// </summary>
        public Menu(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Gets all <see cref="MenuItem"/> which are inside this element.
        /// </summary>
        public MenuItems Items
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
}
