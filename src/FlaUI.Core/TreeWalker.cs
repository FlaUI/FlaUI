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

        public AutomationElement GetParent(AutomationElement element)
        {
            var parent = NativeTreeWalker.GetParentElement(element.NativeElement);
            return parent == null ? null : new AutomationElement(Automation, parent);
        }

        public AutomationElement GetFirstChild(AutomationElement element)
        {
            var child = NativeTreeWalker.GetFirstChildElement(element.NativeElement);
            return child == null ? null : new AutomationElement(Automation, child);
        }

        public AutomationElement GetLastChild(AutomationElement element)
        {
            var child = NativeTreeWalker.GetLastChildElement(element.NativeElement);
            return child == null ? null : new AutomationElement(Automation, child);
        }

        public AutomationElement GetNextSibling(AutomationElement element)
        {
            var child = NativeTreeWalker.GetNextSiblingElement(element.NativeElement);
            return child == null ? null : new AutomationElement(Automation, child);
        }

        public AutomationElement GetPreviousSibling(AutomationElement element)
        {
            var child = NativeTreeWalker.GetPreviousSiblingElement(element.NativeElement);
            return child == null ? null : new AutomationElement(Automation, child);
        }
    }
}
