namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the current state of the window for purposes of user interaction.
    /// </summary>
    public enum WindowInteractionState
    {
        /// <summary>
        /// The window is running.
        /// This does not guarantee that the window is ready for user interaction or is responding.
        /// </summary>
        Running = 0,

        /// <summary>
        /// The window is closing.
        /// </summary>
        Closing = 1,

        /// <summary>
        /// The window is ready for user interaction.
        /// </summary>
        ReadyForUserInteraction = 2,

        /// <summary>
        /// The window is blocked by a modal window.
        /// </summary>
        BlockedByModalWindow = 3,

        /// <summary>
        /// The window is not responding.
        /// </summary>
        NotResponding = 4
    }
}
