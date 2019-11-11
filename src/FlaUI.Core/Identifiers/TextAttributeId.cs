using System;

namespace FlaUI.Core.Identifiers
{
    /// <summary>
    /// A wrapper around text attribute ids
    /// </summary>
    public class TextAttributeId : ConvertibleIdentifierBase
    {
        /// <summary>
        /// Fixed TextAttributeId which is used for text attributes that are not supported by the framework.
        /// </summary>
        public static readonly TextAttributeId NotSupportedByFramework = new TextAttributeId(-1, "Not supported");

        public TextAttributeId(int id, string name)
            : base(id, name)
        {
        }

        public TextAttributeId SetConverter(Func<AutomationBase, object, object> convertMethod)
        {
            return SetConverter<TextAttributeId>(convertMethod);
        }

        public static TextAttributeId Register(AutomationType automationType, int id, string name)
        {
            return RegisterTextAttribute(automationType, id, name);
        }

        public static TextAttributeId Find(AutomationType automationType, int id)
        {
            return FindTextAttribute(automationType, id);
        }
    }
}
