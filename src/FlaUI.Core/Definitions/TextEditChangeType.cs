namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Describes the text editing change being performed by controls when text-edit events are raised or handled.
    /// </summary>
    public enum TextEditChangeType
    {
        /// <summary>
        /// Not related to a specific change type.
        /// </summary>
        None = 0,

        /// <summary>
        /// Change is from an auto-correct action performed by a control.
        /// </summary>
        AutoCorrect = 1,

        /// <summary>
        /// Change is from an IME active composition within a control.
        /// </summary>
        Composition = 2,

        /// <summary>
        /// Change is from an IME composition going from active to finalized state within a control.
        /// Note: The finalized string may be empty if composition was canceled or deleted.
        /// </summary>
        CompositionFinalized = 3
    }
}
