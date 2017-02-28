namespace FlaUI.Core.Identifiers
{
    /// <summary>
    /// A wrapper around the event ids
    /// </summary>
    public class EventId : IdentifierBase
    {
        /// <summary>
        /// Fixed EventId which is used for patterns that are not supported by the framework.
        /// </summary>
        public static readonly EventId NotSupportedByFramework = new EventId(-1, "Not supported");

        public EventId(int id, string name)
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
