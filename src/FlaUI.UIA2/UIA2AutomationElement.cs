using FlaUI.Core;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public class UIA2AutomationElement : AutomationElementBase
    {
        public UIA2AutomationElement(UIA2Automation automation, UIA.AutomationElement wrappedElement)
            : base(automation)
        {
            WrappedElement = wrappedElement;
        }

        public UIA.AutomationElement WrappedElement { get; private set; }

        protected override object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var ignoreDefaultValue = !useDefaultIfNotSupported;
            var property = UIA.AutomationProperty.LookupById(propertyId);
            var returnValue = cached ?
                WrappedElement.GetCachedPropertyValue(property, ignoreDefaultValue) :
                WrappedElement.GetCurrentPropertyValue(property, ignoreDefaultValue);
            return returnValue;
        }

        protected override IAutomationElementInformation CreateInformation(bool cached)
        {
            return new AutomationElementInformation(this, cached);
        }
    }
}
