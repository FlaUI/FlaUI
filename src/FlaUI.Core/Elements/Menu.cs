using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using System.Linq;

namespace FlaUI.Core.Elements
{
    /// <summary>
    /// Represents a menu or a menubar, which contains menuitems
    /// </summary>
    public class Menu : AutomationElement
    {
        public Menu(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public MenuItem[] MenuItems
        {
            get { return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.MenuItem)).Select(e => e.AsMenuItem()).ToArray(); }
        }
    }
}
