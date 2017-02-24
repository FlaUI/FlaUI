using FlaUI.Core.Identifiers;

namespace FlaUI.Core
{
    public class AutomationProperty<TVal>
    {
        public AutomationProperty(PropertyId property, BasicAutomationElementBase basicAutomationElement)
        {
            PropertyId = property;
            BasicAutomationElement = basicAutomationElement;
        }

        protected PropertyId PropertyId { get; }

        protected BasicAutomationElementBase BasicAutomationElement { get; }

        public TVal Value => BasicAutomationElement.GetPropertyValue<TVal>(PropertyId);

        public TVal ValueOrDefault
        {
            get
            {
                TVal value;
                return TryGetValue(out value) ? value : default(TVal);
            }
        }

        public bool TryGetValue(out TVal value)
        {
            return BasicAutomationElement.TryGetPropertyValue(PropertyId, out value);
        }
    }
}
