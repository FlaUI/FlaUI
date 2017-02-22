using FlaUI.Core.Identifiers;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public abstract class InformationBase
    {
        protected BasicAutomationElementBase BasicAutomationElement { get; }

        protected InformationBase(BasicAutomationElementBase basicAutomationElement)
        {
            BasicAutomationElement = basicAutomationElement;
        }

        protected T Get<T>(PropertyId property)
        {
            return BasicAutomationElement.GetPropertyValue<T>(property);
        }
    }
}
