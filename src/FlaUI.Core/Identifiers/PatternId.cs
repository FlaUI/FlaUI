namespace FlaUI.Core.Identifiers
{
    /// <summary>
    /// A wrapper around the pattern ids
    /// </summary>
    public class PatternId : IdentifierBase
    {
        public PatternId(int id, string name)
            : base(id, name)
        {
        }

        public static PatternId Register(int id, string name)
        {
            return RegisterPattern(id, name);
        }

        public static PatternId Find(int id)
        {
            return FindPattern(id);
        }
    }
}
