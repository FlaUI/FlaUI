using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Elements.Infrastructure
{
    public abstract class ElementInformationBase
    {
        protected AutomationObjectBase AutomationObject { get; }

        protected bool Cached { get; }

        protected ElementInformationBase(AutomationObjectBase automationObject, bool cached)
        {
            AutomationObject = automationObject;
            Cached = cached;
        }

        protected T Get<T>(PropertyId property)
        {
            return AutomationObject.SafeGetPropertyValue<T>(property, Cached);
        }
    }
}
