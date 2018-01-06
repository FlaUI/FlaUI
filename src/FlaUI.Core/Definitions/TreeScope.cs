namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the scope of various operations in the Microsoft UI Automation tree.
    /// </summary>
    public enum TreeScope
    {
        /// <summary>
        /// The scope excludes the subtree from the search.
        /// </summary>
        None = 0,

        /// <summary>
        /// The scope includes the element itself.
        /// </summary>
        Element = 1,

        /// <summary>
        /// The scope includes children of the element.
        /// </summary>
        Children = 2,

        /// <summary>
        /// The scope includes children and more distant descendants of the element.
        /// </summary>
        Descendants = 4,

        /// <summary>
        /// The scope includes the element and all its descendants. This flag is a combination of the <see cref="Element"/> and <see cref="Descendants"/> values.
        /// </summary>
        Subtree = 7,

        /// <summary>
        /// The scope includes the parent of the element.
        /// </summary>
        Parent = 8,

        /// <summary>
        /// The scope includes the parent and more distant ancestors of the element.
        /// </summary>
        Ancestors = 16
    }
}
