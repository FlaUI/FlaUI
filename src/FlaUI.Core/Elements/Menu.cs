using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using System.Linq;

namespace FlaUI.Core.Elements
{
    /// <summary>
    /// Represents a menu or a menubar, which contains menuitems
    /// </summary>
    public class Menu : Element
    {
        public Menu(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public MenuItem[] MenuItems
        {
            get { return Enumerable.ToArray<MenuItem>(FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.MenuItem)).Select(e => ElementConversionExtensions.AsMenuItem(e))); }
        }
    }
}
