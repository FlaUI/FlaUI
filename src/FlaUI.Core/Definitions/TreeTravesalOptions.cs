namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Defines values that can be used to customize tree navigation order.
    /// </summary>
    public enum TreeTravesalOptions
    {
        /// <summary>
        /// Pre-order, visit children from first to last.
        /// </summary>
        Default = 0x0,

        /// <summary>
        /// Post-order, see Remarks for more info.
        /// </summary>
        PostOrder = 0x1,

        /// <summary>
        /// Visit children from last to first.
        /// </summary>
        LastToFirstOrder = 0x2
    }
}
