using FlaUI.UIA3.Elements;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public abstract class PatternBase
    {
        public UIA3Automation Automation { get; private set; }
        public Element AutomationElement { get; private set; }
        protected object NativePattern { get; private set; }

        protected PatternBase(Element automationElement, object nativePattern)
        {
            Automation = automationElement.Automation;
            AutomationElement = automationElement;
            NativePattern = nativePattern;
        }

        public Element ToAutomationElement(UIA.IUIAutomationElement nativeElement)
        {
            return nativeElement == null ? null : new Element(Automation, nativeElement);
        }
    }
}
