using System;

namespace FlaUI.Core
{
    /// <summary>
    /// A wrapper around the property ids
    /// </summary>
    public class AutomationProperty : AutomationIdentifier
    {
        private Func<object, object> _specificConverter;

        internal AutomationProperty(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// Sets a custom convert method to convert the values for this property
        /// </summary>
        public AutomationProperty SetConverter(Func<object, object> convertMethod)
        {
            _specificConverter = convertMethod;
            return this;
        }

        /// <summary>
        /// Converts the given value with the converter or casts it, if no converter is given
        /// </summary>
        public T Convert<T>(object value)
        {
            return _specificConverter == null ? (T)value : (T)_specificConverter(value);
        }

        public static AutomationProperty Register(int id, string name)
        {
            return RegisterProperty(id, name);
        }

        public static AutomationProperty Find(int id)
        {
            return FindProperty(id);
        }
    }
}
