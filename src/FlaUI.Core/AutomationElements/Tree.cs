using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a tree element.
    /// </summary>
    public class Tree : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="Tree"/> element.
        /// </summary>
        public Tree(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// The currently selected <see cref="TreeItem" />
        /// </summary>
        public TreeItem SelectedTreeItem => SearchSelectedItem(Items);

        private TreeItem SearchSelectedItem(TreeItem[] treeItems)
        {
            // Search for a selected item in the direct children
            var directSelectedItem = treeItems.FirstOrDefault(t => t.IsSelected);
            if (directSelectedItem != null)
            {
                return directSelectedItem;
            }
            // Loop thru the children and search in their children
            foreach (var treeItem in treeItems)
            {
                var selectedInChildItem = SearchSelectedItem(treeItem.Items);
                if (selectedInChildItem != null)
                {
                    return selectedInChildItem;
                }
            }
            return null;
        }

        /// <summary>
        /// All child <see cref="TreeItem" /> objects from this <see cref="Tree" />
        /// </summary>
        public TreeItem[] Items => GetTreeItems();

        /// <summary>
        /// Gets all the <see cref="TreeItem" /> objects for this <see cref="Tree" />
        /// </summary>
        private TreeItem[] GetTreeItems()
        {
            return FindAllChildren(cf => cf.ByControlType(ControlType.TreeItem))
                .Select(e => e.AsTreeItem()).ToArray();
        }
    }
}
