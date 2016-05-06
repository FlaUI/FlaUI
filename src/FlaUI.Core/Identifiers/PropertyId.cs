using FlaUI.Core.Conditions;
using System;

namespace FlaUI.Core.Identifiers
{
    /// <summary>
    /// A wrapper around the property ids
    /// </summary>
    public class PropertyId : ConvertibleIdentifierBase
    {
        internal PropertyId(int id, string name)
            : base(id, name)
        {
        }

        public PropertyId SetConverter(Func<object, object> convertMethod)
        {
            return SetConverter<PropertyId>(convertMethod);
        }

        /// <summary>
        /// Returs a condition for this property with the given value
        /// </summary>
        public PropertyCondition GetCondition(object value)
        {
            return new PropertyCondition(this, value);
        }

        public static PropertyId Register(int id, string name)
        {
            return RegisterProperty(id, name);
        }

        public static PropertyId Find(int id)
        {
            return FindProperty(id);
        }
    }
}
