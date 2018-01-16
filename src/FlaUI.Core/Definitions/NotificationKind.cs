namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Defines values that indicate the type of a notification event, and a hint to the listener about the processing of the event.
    /// </summary>
    public enum NotificationKind
    {
        /// <summary>
        /// The current element and/or the container has had something added to it that should be presented to the user.
        /// </summary>
        ItemAdded = 0,

        /// <summary>
        /// The current element has had something removed from inside of it that should be presented to the user.
        /// </summary>
        ItemRemoved = 1,

        /// <summary>
        /// The current element has a notification that an action was completed.
        /// </summary>
        ActionCompleted = 2,

        /// <summary>
        /// The current element has a notification that an action was aborted.
        /// </summary>
        ActionAborted = 3,

        /// <summary>
        /// The current element has a notification not an add, remove, completed, or aborted action.
        /// </summary>
        Other = 4
    }
}
