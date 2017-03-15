using FlaUI.Core.Elements;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using System;

namespace FlaUI.Core
{
    public abstract class AutomationElementBase
    {
        protected AutomationElementBase(AutomationBase automation)
        {
            Automation = automation;
            InitializeInformation();
        }

        /// <summary>
        /// Underlying <see cref="AutomationBase"/> object where this element belongs to
        /// </summary>
        public AutomationBase Automation { get; private set; }

        /// <summary>
        /// Basic information about this element (cached)
        /// </summary>
        public IAutomationElementInformation Cached { get; private set; }

        /// <summary>
        /// Basic information about this element (realtime)
        /// </summary>
        public IAutomationElementInformation Current { get; private set; }

        /// <summary>
        /// Gets the desired property value. Ends in an exception if the property is not supported.
        /// </summary>
        public object GetPropertyValue(PropertyId property, bool cached)
        {
            return GetPropertyValue<object>(property, cached);
        }

        public T GetPropertyValue<T>(PropertyId property, bool cached)
        {
            var value = InternalGetPropertyValue(property.Id, cached, false);
            if (value == Automation.NotSupportedValue)
            {
                throw new PropertyNotSupportedException(String.Format("Property '{0}' not supported", property.Name), property);
            }
            return property.Convert<T>(value);
        }

        /// <summary>
        /// Gets the desired property value or the default value, if the property is not supported
        /// </summary>
        public object SafeGetPropertyValue(PropertyId property, bool cached)
        {
            return SafeGetPropertyValue<object>(property, cached);
        }

        public T SafeGetPropertyValue<T>(PropertyId property, bool cached)
        {
            var value = InternalGetPropertyValue(property.Id, cached, true);
            return property.Convert<T>(value);
        }

        /// <summary>
        /// Tries to get the property value. Fails if the property is not supported.
        /// </summary>
        public bool TryGetPropertyValue(PropertyId property, bool cached, out object value)
        {
            return TryGetPropertyValue<object>(property, cached, out value);
        }

        public bool TryGetPropertyValue<T>(PropertyId property, bool cached, out T value)
        {
            var tmp = InternalGetPropertyValue(property.Id, cached, false);
            if (tmp == Automation.NotSupportedValue)
            {
                value = default(T);
                return false;
            }
            value = property.Convert<T>(tmp);
            return true;
        }

        protected abstract object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported);

        protected abstract IAutomationElementInformation CreateInformation(bool cached);

        private void InitializeInformation()
        {
            Cached = CreateInformation(true);
            Current = CreateInformation(false);
        }

        public static Clickable AsClickable(AutomationElementBase automationElement)
        {
            return automationElement == null ? null : new Clickable(automationElement);
        }
    }
}
