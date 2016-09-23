using System.Linq;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    /// <summary>
    /// Represents a menu or a menubar, which contains menuitems
    /// </summary>
    public class Menu : Element
    {
        public Menu(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public MenuItem[] MenuItems
        {
            get { return Enumerable.ToArray<MenuItem>(FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.MenuItem)).Select(e => ElementConversionExtensions.AsMenuItem(e))); }
        }
    }
}
