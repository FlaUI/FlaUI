namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the scope of elements within the UI Automation tree.
    /// </summary>
    public enum TreeScope
    {
        /// <summary>
        /// Specifies that the search include the element itself.
        /// </summary>
        Element = 1,
        /// <summary>
        /// Specifies that the search include the element's immediate children.
        /// </summary>
        Children = 2,
        /// <summary>
        /// Specifies that the search include the element's descendants, including children.
        /// </summary>
        Descendants = 4,
        /// <summary>
        /// Specifies that the search include the root of the search and all descendants.
        /// </summary>
        Subtree = 7,
        /// <summary>
        /// Specifies that the search include the element's parent.
        /// </summary>
        Parent = 8,
        /// <summary>
        /// Specifies that the search include the element's ancestors, including the parent.
        /// </summary>
        Ancestors = 16
    }
}
