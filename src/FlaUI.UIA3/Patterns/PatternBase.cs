using FlaUI.UIA3.Elements;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public abstract class PatternBase
    {
        public UIA3Automation Automation { get; private set; }
        public AutomationElement AutomationAutomationElement { get; private set; }
        protected object NativePattern { get; private set; }

        protected PatternBase(AutomationElement automationAutomationElement, object nativePattern)
        {
            Automation = automationAutomationElement.Automation;
            AutomationAutomationElement = automationAutomationElement;
            NativePattern = nativePattern;
        }

        public AutomationElement ToAutomationElement(UIA.IUIAutomationElement nativeElement)
        {
            return nativeElement == null ? null : new AutomationElement(Automation, nativeElement);
        }
    }
}
