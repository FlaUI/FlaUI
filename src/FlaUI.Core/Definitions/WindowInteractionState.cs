namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the current state of the window for purposes of user or programmatic interaction.
    /// </summary>
    public enum WindowInteractionState
    {
        /// <summary>
        /// Indicates that the window is running.
        /// This does not guarantee that the window is responding or ready for user interaction.
        /// </summary>
        Running = 0,
        /// <summary>
        /// Indicates that the window is closing.
        /// </summary>
        Closing = 1,
        /// <summary>
        /// Indicates that the window is ready for user interaction.
        /// </summary>
        ReadyForUserInteraction = 2,
        /// <summary>
        /// Indicates that the window is blocked by a modal window.
        /// </summary>
        BlockedByModalWindow = 3,
        /// <summary>
        /// Indicates that the window is not responding.
        /// </summary>
        NotResponding = 4
    }
}
