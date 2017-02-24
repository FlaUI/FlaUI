using System;
using FlaUI.Core.Identifiers;
#if NET35
using FlaUI.Core.Tools;
#endif

namespace FlaUI.Core
{
    public class AutomationProperty<TVal>
    {
        private readonly Lazy<PropertyId> _propertyIdLazy;

        public AutomationProperty(Func<PropertyId> propertyFunc, BasicAutomationElementBase basicAutomationElement)
        {
            _propertyIdLazy = new Lazy<PropertyId>(propertyFunc);
            BasicAutomationElement = basicAutomationElement;
        }

        protected PropertyId PropertyId => _propertyIdLazy.Value;

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
