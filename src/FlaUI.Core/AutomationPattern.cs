namespace FlaUI.Core
{
    /// <summary>
    /// A wrapper around the pattern ids
    /// </summary>
    public class AutomationPattern : AutomationIdentifier
    {
        public AutomationPattern(int id, string name)
            : base(id, name)
        {
        }

        public static AutomationPattern Register(int id, string name)
        {
            return RegisterPattern(id, name);
        }

        public static AutomationPattern Find(int id)
        {
            return FindPattern(id);
        }
    }
}
