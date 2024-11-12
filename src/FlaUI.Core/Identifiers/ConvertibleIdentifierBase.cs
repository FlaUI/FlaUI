using System;

namespace FlaUI.Core.Identifiers
{
    /// <summary>
    /// Base class for identifiers which are convertible
    /// </summary>
    public abstract class ConvertibleIdentifierBase : IdentifierBase
    {
        private Func<AutomationBase, object, object>? _converterMethod;

        protected ConvertibleIdentifierBase(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// Sets a custom convert method to convert the values for this id
        /// </summary>
        protected T SetConverter<T>(Func<AutomationBase, object, object> convertMethod) where T : ConvertibleIdentifierBase
        {
            _converterMethod = convertMethod;
            return (T)this;
        }

        /// <summary>
        /// Converts the given value with the converter or casts it, if no converter is given
        /// </summary>
        public T Convert<T>(AutomationBase automation, object value)
        {
            return _converterMethod == null ? (T)value : (T)_converterMethod(automation, value);
        }
    }
}
