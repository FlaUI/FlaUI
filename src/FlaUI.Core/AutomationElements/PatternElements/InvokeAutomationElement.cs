using FlaUI.Core.AutomationElements;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    public class InvokeAutomationElement : AutomationElement
    {
        public InvokeAutomationElement(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        public IInvokePattern InvokePattern => Patterns.Invoke.Pattern;

        public void Invoke()
        {
            InvokePattern.Invoke();
        }
    }
}
