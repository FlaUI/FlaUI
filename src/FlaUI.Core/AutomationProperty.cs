namespace FlaUI.Core
{
    /// <summary>
    /// A wrapper around the property ids
    /// </summary>
    public class AutomationProperty : AutomationIdentifier
    {
        internal AutomationProperty(int id, string name)
            : base(id, name)
        {
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
