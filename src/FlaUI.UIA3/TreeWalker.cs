using FlaUI.UIA3.Elements;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class TreeWalker
    {
        public UIA3Automation Automation { get; private set; }
        public UIA.IUIAutomationTreeWalker NativeTreeWalker { get; private set; }

        public TreeWalker(UIA3Automation automation)
        {
            Automation = automation;
            NativeTreeWalker = automation.NativeAutomation.ControlViewWalker;
        }

        public AutomationElement GetParent(AutomationElement automationElement)
        {
            var parent = NativeTreeWalker.GetParentElement(automationElement.NativeElement);
            return parent == null ? null : new AutomationElement(Automation, parent);
        }

        public AutomationElement GetFirstChild(AutomationElement automationElement)
        {
            var child = NativeTreeWalker.GetFirstChildElement(automationElement.NativeElement);
            return child == null ? null : new AutomationElement(Automation, child);
        }

        public AutomationElement GetLastChild(AutomationElement automationElement)
        {
            var child = NativeTreeWalker.GetLastChildElement(automationElement.NativeElement);
            return child == null ? null : new AutomationElement(Automation, child);
        }

        public AutomationElement GetNextSibling(AutomationElement automationElement)
        {
            var child = NativeTreeWalker.GetNextSiblingElement(automationElement.NativeElement);
            return child == null ? null : new AutomationElement(Automation, child);
        }

        public AutomationElement GetPreviousSibling(AutomationElement automationElement)
        {
            var child = NativeTreeWalker.GetPreviousSiblingElement(automationElement.NativeElement);
            return child == null ? null : new AutomationElement(Automation, child);
        }
    }
}
