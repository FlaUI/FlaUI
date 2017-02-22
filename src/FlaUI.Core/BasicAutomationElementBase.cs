using System;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;

namespace FlaUI.Core
{
    public abstract class BasicAutomationElementBase
    {
        protected BasicAutomationElementBase(AutomationBase automation)
        {
            Automation = automation;
        }

        public abstract IPatternFactory PatternFactory { get; }

        public abstract IAutomationElementInformation Cached { get; }

        public abstract IAutomationElementInformation Current { get; }

        /// <summary>
        /// Underlying <see cref="AutomationBase" /> object where this element belongs to
        /// </summary>
        public AutomationBase Automation { get; }

        /// <summary>
        /// Gets the desired property value. Ends in an exception if the property is not supported.
        /// </summary>
        public object GetPropertyValue(PropertyId property, bool cached)
        {
            return GetPropertyValue<object>(property, cached);
        }

        public T GetPropertyValue<T>(PropertyId property, bool cached)
        {
            var value = InternalGetPropertyValue(property, cached, false);
            if (value == Automation.NotSupportedValue)
            {
                throw new PropertyNotSupportedException($"Property '{property}' not supported", property);
            }
            return property.Convert<T>(value);
        }

        /// <summary>
        /// Tries to get the property value.
        /// Returns false and sets a default value if the property is not supported.
        /// </summary>
        public bool TryGetPropertyValue(PropertyId property, bool cached, out object value)
        {
            return TryGetPropertyValue<object>(property, cached, out value);
        }

        public bool TryGetPropertyValue<T>(PropertyId property, bool cached, out T value)
        {
            var tmp = InternalGetPropertyValue(property, cached, false);
            if (tmp == Automation.NotSupportedValue)
            {
                value = default(T);
                return false;
            }
            value = property.Convert<T>(tmp);
            return true;
        }

        private object InternalGetPropertyValue(PropertyId property, bool cached, bool useDefaultIfNotSupported)
        {
            try
            {
                return InternalGetPropertyValue(property.Id, cached, useDefaultIfNotSupported);
            }
            catch (Exception ex)
            {
                var msg = $"Property '{property}' not supported";
                if (cached)
                {
                    msg += " or not cached";
                }
                throw new InvalidOperationException(msg, ex);
            }
        }

        public T GetNativePattern<T>(PatternId pattern, bool cached)
        {
            try
            {
                var nativePattern = InternalGetPattern(pattern.Id, cached);
                return (T)nativePattern;
            }
            catch (Exception ex)
            {
                var msg = $"Pattern '{pattern}' not supported";
                if (cached)
                {
                    msg += " or not cached";
                }
                throw new InvalidOperationException(msg, ex);
            }
        }

        public bool TryGetNativePattern<T>(PatternId pattern, bool cached, out T nativePattern)
        {
            try
            {
                nativePattern = (T)InternalGetPattern(pattern.Id, cached);
                return true;
            }
            catch (Exception ex)
            {
                nativePattern = default(T);
                return false;
            }
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

        /// <summary>
        /// Gets the desired property value
        /// </summary>
        /// <param name="propertyId">The id of the property to get</param>
        /// <param name="cached">Flag to indicate if the cached or current value should be fetched</param>
        /// <param name="useDefaultIfNotSupported">
        /// Flag to indicate, if the default value should be used if the property is not
        /// supported
        /// </param>
        /// <returns>The value / default value of the property or <see cref="AutomationBase.NotSupportedValue" /></returns>
        protected abstract object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported);

        /// <summary>
        /// Gets the desired pattern
        /// </summary>
        /// <param name="patternId">The id of the pattern to get</param>
        /// <param name="cached">Flag to indicate if the cached or current pattern should be fetched</param>
        /// <returns>The pattern or null if it was not found / cached</returns>
        protected abstract object InternalGetPattern(int patternId, bool cached);

        public abstract AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition);
        public abstract AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition);
        public abstract bool TryGetClickablePoint(out Point point);
        public abstract IAutomationEventHandler RegisterEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action);
        public abstract IAutomationPropertyChangedEventHandler RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, PropertyId[] properties);
        public abstract IAutomationStructureChangedEventHandler RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action);
        public abstract void RemoveAutomationEventHandler(EventId @event, IAutomationEventHandler eventHandler);
        public abstract void RemovePropertyChangedEventHandler(IAutomationPropertyChangedEventHandler eventHandler);
        public abstract void RemoveStructureChangedEventHandler(IAutomationStructureChangedEventHandler eventHandler);
        public abstract PatternId[] GetSupportedPatterns();
        public abstract PropertyId[] GetSupportedProperties();
        public abstract AutomationElement GetUpdatedCache();
        public abstract AutomationElement[] GetCachedChildren();
        public abstract AutomationElement GetCachedParent();
    }
}
