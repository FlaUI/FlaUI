using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Conditions
{
    /// <summary>
    /// A condition that is used to check for a property of an element.
    /// </summary>
    public class PropertyCondition : ConditionBase
    {
        /// <summary>
        /// Creates a new instance off a <see cref="PropertyCondition"/>.
        /// </summary>
        /// <param name="property">The property to check.</param>
        /// <param name="value">The value to check the property for.</param>
        public PropertyCondition(PropertyId property, object value)
            : this(property, value, PropertyConditionFlags.None)
        {
        }

        /// <summary>
        /// Creates a new instance off a <see cref="PropertyCondition"/>.
        /// </summary>
        /// <param name="property">The property to check.</param>
        /// <param name="value">The value to check the property for.</param>
        /// <param name="propertyConditionFlags">The flags to use when checking the property.</param>
        public PropertyCondition(PropertyId property, object value, PropertyConditionFlags propertyConditionFlags)
        {
            Property = property;
            Value = value;
            PropertyConditionFlags = propertyConditionFlags;
        }

        /// <summary>
        /// The property that should be checked.
        /// </summary>
        public PropertyId Property { get; }

        /// <summary>
        /// Optional flags that are used when checking the property.
        /// </summary>
        public PropertyConditionFlags PropertyConditionFlags { get; }

        /// <summary>
        /// The value that is used for checking.
        /// </summary>
        public object Value { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Property}: {Value}";
        }
    }
}
