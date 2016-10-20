using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3TreeWalker : ITreeWalker
    {
        public UIA3Automation Automation { get; }
        public UIA.IUIAutomationTreeWalker NativeTreeWalker { get; }

        public UIA3TreeWalker(UIA3Automation automation, UIA.IUIAutomationTreeWalker nativeTreeWalker)
        {
            Automation = automation;
            NativeTreeWalker = nativeTreeWalker;
        }

        public AutomationElement GetParent(AutomationElement element)
        {
            var parent = NativeTreeWalker.GetParentElement(((UIA3BasicAutomationElement)element.BasicAutomationElement).NativeElement);
            return Automation.WrapNativeElement(parent);
        }

        public AutomationElement GetFirstChild(AutomationElement element)
        {
            var child = NativeTreeWalker.GetFirstChildElement(((UIA3BasicAutomationElement)element.BasicAutomationElement).NativeElement);
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetLastChild(AutomationElement element)
        {
            var child = NativeTreeWalker.GetLastChildElement(((UIA3BasicAutomationElement)element.BasicAutomationElement).NativeElement);
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetNextSibling(AutomationElement element)
        {
            var child = NativeTreeWalker.GetNextSiblingElement(((UIA3BasicAutomationElement)element.BasicAutomationElement).NativeElement);
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetPreviousSibling(AutomationElement element)
        {
            var child = NativeTreeWalker.GetPreviousSiblingElement(((UIA3BasicAutomationElement)element.BasicAutomationElement).NativeElement);
            return Automation.WrapNativeElement(child);
        }
    }
}
