using System;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core
{
    /// <summary>
    /// Inferface for property objects.
    /// </summary>
    /// <typeparam name="T">The type of the value of the property.</typeparam>
    public interface IAutomationProperty<T>
    {
        /// <summary>
        /// Get the value of the property. Throws if the property is not supported or
        /// if it is accessed in a caching context and it is not cached.
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Gets the value of the property or the default for this property type if it is not supported.
        /// Throws if the property is accessed in a caching context and it is not cached.
        /// </summary>
        T ValueOrDefault { get; }

        /// <summary>
        /// Tries to get the value of the property.
        /// Throws if the property is accessed in a caching context and it is not cached.
        /// </summary>
        /// <param name="value">The value of the property. Contains the default if it is not supported.</param>
        /// <returns>True if the property is supported, false otherwise.</returns>
        bool TryGetValue(out T value);

        /// <summary>
        /// Gets a flag if the property is supported or not.
        /// </summary>
        bool IsSupported { get; }
    }

    /// <summary>
    /// Implementation of the property object.
    /// </summary>
    /// <typeparam name="TVal">The type of the value of the property.</typeparam>
    public class AutomationProperty<TVal> : IAutomationProperty<TVal>, IEquatable<TVal>, IEquatable<AutomationProperty<TVal>>
    {
        /// <summary>
        /// Create the property object.
        /// </summary>
        /// <param name="propertyId">The <see cref="PropertyId"/> for this property object.</param>
        /// <param name="frameworkAutomationElement">The <see cref="FrameworkAutomationElement"/> for this property object.</param>
        public AutomationProperty(PropertyId propertyId, FrameworkAutomationElementBase frameworkAutomationElement)
        {
            PropertyId = propertyId;
            FrameworkAutomationElement = frameworkAutomationElement;
        }

        /// <summary>
        /// The <see cref="PropertyId"/> of this property object.
        /// </summary>
        protected PropertyId PropertyId { get; }

        /// <summary>
        /// The <see cref="FrameworkAutomationElement"/> where this property object belongs to.
        /// </summary>
        protected FrameworkAutomationElementBase FrameworkAutomationElement { get; }

        /// <inheritdoc />
        public TVal Value => FrameworkAutomationElement.GetPropertyValue<TVal>(PropertyId);

        /// <inheritdoc />
        public TVal ValueOrDefault
        {
            get
            {
                TryGetValue(out TVal value);
                return value;
            }
        }

        /// <inheritdoc />
        public bool TryGetValue(out TVal value)
        {
            return FrameworkAutomationElement.TryGetPropertyValue(PropertyId, out value);
        }

        /// <inheritdoc />
        public bool IsSupported => TryGetValue(out TVal _);

        /// <summary>
        /// Implicit operator to convert the property object directly to its value.
        /// </summary>
        /// <param name="automationProperty">The property object which should be converted.</param>
        public static implicit operator TVal(AutomationProperty<TVal> automationProperty)
        {
            return automationProperty == null ? default(TVal) : automationProperty.Value;
        }

        public bool Equals(TVal other)
        {
            return Value.Equals(other);
        }

        public bool Equals(AutomationProperty<TVal> other)
        {
            return other != null && Value.Equals(other.Value);
        }

        public override string ToString()
        {
            return this.ValueOrDefault?.ToString() ?? "null";
        }
    }
}
