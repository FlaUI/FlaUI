using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Elements.Infrastructure
{
    public abstract class ElementInformationBase
    {
        protected AutomationObjectBase AutomationObject { get; private set; }

        protected bool Cached { get; private set; }

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
