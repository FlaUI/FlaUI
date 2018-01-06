namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the state of a UI element that can be expanded and collapsed.
    /// </summary>
    public enum ExpandCollapseState
    {
        /// <summary>
        /// No children are visible.
        /// </summary>
        Collapsed = 0,

        /// <summary>
        /// All children are visible.
        /// </summary>
        Expanded = 1,

        /// <summary>
        /// Some, but not all, children are visible.
        /// </summary>
        PartiallyExpanded = 2,

        /// <summary>
        /// The element does not expand or collapse.
        /// </summary>
        LeafNode = 3
    }
}
