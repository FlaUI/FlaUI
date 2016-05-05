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
