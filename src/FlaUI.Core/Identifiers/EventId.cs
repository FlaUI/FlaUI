namespace FlaUI.Core.Identifiers
{
    /// <summary>
    /// A wrapper around the event ids
    /// </summary>
    public class EventId : IdentifierBase
    {
        internal EventId(int id, string name)
            : base(id, name)
        {
        }

        public static EventId Register(AutomationType automationType, int id, string name)
        {
            return RegisterEvent(automationType, id, name);
        }

        public static EventId Find(AutomationType automationType, int id)
        {
            return FindEvent(automationType, id);
        }
    }
}
