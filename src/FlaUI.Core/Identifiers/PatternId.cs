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

        public static PatternId Register(AutomationType automationType, int id, string name)
        {
            return RegisterPattern(automationType, id, name);
        }

        public static PatternId Find(AutomationType automationType, int id)
        {
            return FindPattern(automationType, id);
        }
    }
}
