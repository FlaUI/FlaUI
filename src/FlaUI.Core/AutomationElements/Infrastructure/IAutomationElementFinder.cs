using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    /// <summary>
    /// Interface for the base methods to find <see cref="AutomationElement"/>s on an <see cref="AutomationElement"/>.
    /// </summary>
    public interface IAutomationElementFinder
    {
        /// <summary>
        /// Finds all elements in the given scope with the given condition.
        /// </summary>
        /// <param name="treeScope">The scope to search.</param>
        /// <param name="condition">The condition to use.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition);

        /// <summary>
        /// Finds the first element in the given scope with the given condition.
        /// </summary>
        /// <param name="treeScope">The scope to search.</param>
        /// <param name="condition">The condition to use.</param>
        /// <returns>The found element or null if no element was found.</returns>
        AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition);

        /// <summary>
        /// Find all matching elements in the specified order.
        /// </summary>
        /// <param name="treeScope">A combination of values specifying the scope of the search.</param>
        /// <param name="condition">A condition that represents the criteria to match.</param>
        /// <param name="traversalOptions">Value specifying the tree navigation order.</param>
        /// <param name="root">An element with which to begin the search.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        AutomationElement[] FindAllWithOptions(TreeScope treeScope, ConditionBase condition, TreeTraversalOptions traversalOptions, AutomationElement root);

        /// <summary>
        /// Finds the first matching element in the specified order.
        /// </summary>
        /// <param name="treeScope">A combination of values specifying the scope of the search.</param>
        /// <param name="condition">A condition that represents the criteria to match.</param>
        /// <param name="traversalOptions">Value specifying the tree navigation order.</param>
        /// <param name="root">An element with which to begin the search.</param>
        /// <returns>The found element or null if no element was found.</returns>
        AutomationElement FindFirstWithOptions(TreeScope treeScope, ConditionBase condition, TreeTraversalOptions traversalOptions, AutomationElement root);

        /// <summary>
        /// Finds the element with the given index with the given condition.
        /// </summary>
        /// <param name="treeScope">The scope to search.</param>
        /// <param name="index">The index of the element to return (0-based).</param>
        /// <param name="condition">The condition to use.</param>
        /// <returns>The found element or null if no element was found.</returns>
        AutomationElement FindAt(TreeScope treeScope, int index, ConditionBase condition);
    }
}
