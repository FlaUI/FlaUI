namespace FlaUI.Core
{
    /// <summary>
    /// A wrapper around the event ids
    /// </summary>
    public class AutomationEvent : AutomationIdentifier
    {
        internal AutomationEvent(int id, string name)
            : base(id, name)
        {
        }

        public static AutomationEvent Register(int id, string name)
        {
            return RegisterEvent(id, name);
        }

        public static AutomationEvent Find(int id)
        {
            return FindEvent(id);
        }
    }
}
