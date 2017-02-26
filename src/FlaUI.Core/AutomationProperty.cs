using System;
using FlaUI.Core.Identifiers;
#if NET35
using FlaUI.Core.Tools;
#endif

namespace FlaUI.Core
{
    public class AutomationProperty<TVal> : IEquatable<TVal>, IEquatable<AutomationProperty<TVal>>
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
                TryGetValue(out value);
                return value;
            }
        }

        public bool TryGetValue(out TVal value)
        {
            return BasicAutomationElement.TryGetPropertyValue(PropertyId, out value);
        }

        public static implicit operator TVal(AutomationProperty<TVal> automationProperty)
        {
            if (automationProperty == null)
            {
                throw new ArgumentNullException(nameof(automationProperty));
            }
            return automationProperty.Value;
        }

        public bool Equals(TVal other)
        {
            return Value.Equals(other);
        }

        public bool Equals(AutomationProperty<TVal> other)
        {
            return other != null && Value.Equals(other.Value);
        }
    }
}
