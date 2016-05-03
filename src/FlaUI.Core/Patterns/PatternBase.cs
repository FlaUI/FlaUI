using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;
using System;

namespace FlaUI.Core.Patterns
{
    public abstract class PatternBase<T>
    {
        public Automation Automation { get; private set; }
        public AutomationElement AutomationElement { get; private set; }
        public T NativePattern { get; private set; }

        protected PatternBase(AutomationElement automationElement, T nativePattern)
        {
            Automation = automationElement.Automation;
            AutomationElement = automationElement;
            NativePattern = nativePattern;
        }

        public AutomationElement ToAutomationElement(IUIAutomationElement nativeElement)
        {
            return nativeElement == null ? null : new AutomationElement(Automation, nativeElement);
        }
    }
}
