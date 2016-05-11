using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using System.Linq;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    /// <summary>
    /// Represents a menu or a menubar, which contains menuitems
    /// </summary>
    public class Menu : AutomationElement
    {
        public Menu(Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public MenuItem[] MenuItems
        {
            get { return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.MenuItem)).Select(e => e.AsMenuItem()).ToArray(); }
        }
    }
}
