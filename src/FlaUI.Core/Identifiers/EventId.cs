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

        public static EventId Register(int id, string name)
        {
            return RegisterEvent(id, name);
        }

        public static EventId Find(int id)
        {
            return FindEvent(id);
        }
    }
}
