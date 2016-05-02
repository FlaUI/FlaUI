using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core
{
    public class TreeWalker
    {
        public Automation Automation { get; private set; }
        public IUIAutomationTreeWalker NativeTreeWalker { get; private set; }

        public TreeWalker(Automation automation)
        {
            Automation = automation;
            NativeTreeWalker = automation.NativeAutomation.ControlViewWalker;
        }

        public AutomationElement GetParent(AutomationElement child)
        {
            var parent = NativeTreeWalker.GetParentElement(child.NativeElement);
            return parent == null ? null : new AutomationElement(Automation, parent);
        }
    }
}
