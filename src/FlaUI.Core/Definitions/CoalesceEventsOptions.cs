namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains possible values for the CoalesceEvents property,
    /// which indicates whether an accessible technology client receives all events,
    /// or a subset where duplicate events are detected and filtered.
    /// </summary>
    public enum CoalesceEventsOptions
    {
        /// <summary>
        /// Event coalescing is disabled.
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// Event coalescing is enabled.
        /// </summary>
        Enabled = 1
    }
}
