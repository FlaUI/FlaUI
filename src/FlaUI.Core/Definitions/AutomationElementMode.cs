namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the type of reference to use when returning UI Automation elements. 
    /// </summary>
    public enum AutomationElementMode
    {
        /// <summary>
        /// Specifies that returned elements have no reference to the underlying UI and contain only cached information.
        /// This mode might be used, for example, to retrieve the names of items in a list box without obtaining references to the items themselves.
        /// </summary>
        None = 0,
        /// <summary>
        /// Specifies that returned elements have a full reference to the underlying UI. 
        /// </summary>
        Full = 1
    }
}
