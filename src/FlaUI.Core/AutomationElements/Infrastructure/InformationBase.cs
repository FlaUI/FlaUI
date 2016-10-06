using FlaUI.Core.Identifiers;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public abstract class InformationBase
    {
        protected BasicAutomationElementBase BasicAutomationElement { get; }

        protected bool Cached { get; }

        protected InformationBase(BasicAutomationElementBase basicAutomationElement, bool cached)
        {
            BasicAutomationElement = basicAutomationElement;
            Cached = cached;
        }

        protected T Get<T>(PropertyId property)
        {
            return BasicAutomationElement.SafeGetPropertyValue<T>(property, Cached);
        }
    }
}
