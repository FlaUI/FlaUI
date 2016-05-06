using System;

namespace FlaUI.Core.Identifiers
{
    /// <summary>
    /// A wrapper around text attribute ids
    /// </summary>
    public class TextAttributeId : ConvertibleIdentifierBase
    {
        public TextAttributeId(int id, string name)
            : base(id, name)
        {
        }

        public TextAttributeId SetConverter(Func<object, object> convertMethod)
        {
            return SetConverter<TextAttributeId>(convertMethod);
        }

        public static TextAttributeId Register(int id, string name)
        {
            return RegisterTextAttribute(id, name);
        }

        public static TextAttributeId Find(int id)
        {
            return FindTextAttribute(id);
        }
    }
}
