using FlaUI.Core;
using FlaUI.UIA3.Elements;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public abstract class PatternBase
    {
        public Automation Automation { get; private set; }
        public AutomationElement AutomationElement { get; private set; }
        protected object NativePattern { get; private set; }

        protected PatternBase(AutomationElement automationElement, object nativePattern)
        {
            Automation = automationElement.Automation;
            AutomationElement = automationElement;
            NativePattern = nativePattern;
        }

        public AutomationElement ToAutomationElement(UIA.IUIAutomationElement nativeElement)
        {
            return nativeElement == null ? null : new AutomationElement(Automation, nativeElement);
        }
    }
}
