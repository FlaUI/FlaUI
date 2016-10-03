using FlaUI.UIA3.Conditions;
using FlaUI.UIA3.Definitions;
using System.Linq;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    /// <summary>
    /// Represents a menu or a menubar, which contains menuitems
    /// </summary>
    public class Menu : AutomationElement
    {
        public Menu(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public MenuItem[] MenuItems
        {
            get { return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.MenuItem)).Select(e => ElementConversionExtensions.AsMenuItem(e)).ToArray(); }
        }
    }
}
