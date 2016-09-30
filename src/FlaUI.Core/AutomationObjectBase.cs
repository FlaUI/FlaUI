using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using System;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Shapes;

namespace FlaUI.Core
{
    public abstract class AutomationObjectBase
    {
        /// <summary>
        /// Underlying <see cref="AutomationBase"/> object where this element belongs to
        /// </summary>
        public AutomationBase Automation { get; private set; }

        protected AutomationObjectBase(AutomationBase automation)
        {
            Automation = automation;
        }

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

        public Point GetClickablePoint()
        {
            Point point;
            if (!TryGetClickablePoint(out point))
            {
                throw new NoClickablePointException();
            }
            return point;
        }

        public abstract void SetFocus();

        public abstract IElementInformation CreateInformation(bool cached);

        public abstract IPatternFactory CreatePatternFactory();

        /// <summary>
        /// Gets the desired property value
        /// </summary>
        /// <param name="propertyId">The id of the property to get</param>
        /// <param name="cached">Flag to indicate if the cached or current value should be fetched</param>
        /// <param name="useDefaultIfNotSupported">Flag to indicate, if the default value should be used if the property is not supported</param>
        /// <returns>The value / default value of the property or <see cref="AutomationBase.NotSupportedValue" /></returns>
        protected abstract object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported);

        public abstract Element[] FindAll(TreeScope treeScope, ConditionBase condition);
        public abstract Element FindFirst(TreeScope treeScope, ConditionBase condition);
        public abstract bool TryGetClickablePoint(out Point point);
        public abstract IElementProperties CreateProperties();
        public abstract IAutomationEventHandler RegisterEvent(EventId @event, TreeScope treeScope, Action<Element, EventId> action);
        public abstract IAutomationPropertyChangedEventHandler RegisterPropertyChangedEvent(TreeScope treeScope, Action<Element, PropertyId, object> action, PropertyId[] properties);
        public abstract IAutomationStructureChangedEventHandler RegisterStructureChangedEvent(TreeScope treeScope, Action<Element, StructureChangeType, int[]> action);
        public abstract void RemoveAutomationEventHandler(EventId @event, IAutomationEventHandler eventHandler);
        public abstract void RemovePropertyChangedEventHandler(IAutomationPropertyChangedEventHandler eventHandler);
        public abstract void RemoveStructureChangedEventHandler(IAutomationStructureChangedEventHandler eventHandler);
    }
}
