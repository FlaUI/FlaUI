namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the type of change in the Microsoft UI Automation tree structure.
    /// </summary>
    public enum StructureChangeType
    {
        /// <summary>
        /// A child element was added to the UI Automation element tree.
        /// </summary>
        ChildAdded = 0,

        /// <summary>
        /// A child element was removed from the UI Automation element tree.
        /// </summary>
        ChildRemoved = 1,

        /// <summary>
        /// Child elements were invalidated in the UI Automation element tree.
        /// This might mean that one or more child elements were added or removed, or a combination of both
        /// This value can also indicate that one subtree in the UI was substituted for another.
        /// For example, the entire contents of a dialog box changed at once, or the view of a list changed because an Explorer-type application navigated to another location.
        /// The exact meaning depends on the UI Automation provider implementation.
        /// </summary>
        ChildrenInvalidated = 2,

        /// <summary>
        /// Child elements were added in bulk to the UI Automation element tree.
        /// </summary>
        ChildrenBulkAdded = 3,

        /// <summary>
        /// Child elements were removed in bulk from the UI Automation element tree.
        /// </summary>
        ChildrenBulkRemoved = 4,

        /// <summary>
        /// The order of child elements has changed in the UI Automation element tree. Child elements may or may not have been added or removed.
        /// </summary>
        ChildrenReordered = 5
    }
}
