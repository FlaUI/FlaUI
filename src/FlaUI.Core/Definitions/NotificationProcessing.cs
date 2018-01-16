namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Defines values that indicate how a notification should be processed.
    /// </summary>
    public enum NotificationProcessing
    {
        /// <summary>
        /// These notifications should be presented to the user as soon as possible
        /// and all of the notifications from this source should be delivered to the user.
        /// </summary>
        ImportantAll = 0,

        /// <summary>
        /// These notifications should be presented to the user as soon as possible.
        /// The most recent notification from this source should be delivered to the user because it supersedes all of the other notifications.
        /// </summary>
        ImportantMostRecent = 1,

        /// <summary>
        /// These notifications should be presented to the user when possible.
        /// All of the notifications from this source should be delivered to the user.
        /// </summary>
        All = 2,

        /// <summary>
        /// These notifications should be presented to the user when possible.
        /// The most recent notification from this source should be delivered to the user because it supersedes all of the other notifications.
        /// </summary>
        MostRecent = 3,

        /// <summary>
        /// These notifications should be presented to the user when possible.
        /// Don’t interrupt the current notification for this one.
        /// If new notifications come in from the same source while the current notification is being presented,
        /// keep the most recent and ignore the rest until the current processing is completed.
        /// Then, use the most recent message as the current message.
        /// </summary>
        CurrentThenMostRecent = 4
    }
}
