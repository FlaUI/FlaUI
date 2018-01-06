namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the supported text selection attribute.
    /// </summary>
    public enum SupportedTextSelection
    {
        /// <summary>
        /// Does not support text selections.
        /// </summary>
        None = 0,

        /// <summary>
        /// Supports a single, continuous text selection.
        /// </summary>
        Single = 1,

        /// <summary>
        /// Supports multiple, disjoint text selections.
        /// </summary>
        Multiple = 2
    }
}
