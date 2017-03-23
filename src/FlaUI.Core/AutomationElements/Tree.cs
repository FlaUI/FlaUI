using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    public class Tree : AutomationElement
    {
        public Tree(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// The currently selected <see cref="TreeItem" />
        /// </summary>
        public TreeItem SelectedTreeItem => SearchSelectedItem(TreeItems);

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
                var selectedInChildItem = SearchSelectedItem(treeItem.TreeItems);
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
        public TreeItem[] TreeItems => GetTreeItems();

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
