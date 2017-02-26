using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    public class InvokeAutomationElement : AutomationElement
    {
        public InvokeAutomationElement(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public IInvokePattern InvokePattern => Patterns.Invoke.Pattern;

        public void Invoke()
        {
            InvokePattern.Invoke();
        }
    }
}
