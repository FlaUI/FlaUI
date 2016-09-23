using System.Linq;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class Tree : Element
    {
        public Tree(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        /// <summary>
        /// The currently selected <see cref="TreeItem"/>
        /// </summary>
        public TreeItem SelectedTreeItem
        {
            get { return SearchSelectedItem(TreeItems); }
        }

        private TreeItem SearchSelectedItem(TreeItem[] treeItems)
        {
            // Search for a selected item in the direct children
            var directSelectedItem = treeItems.FirstOrDefault(t => t.IsSelected);
            if (directSelectedItem != null) { return directSelectedItem; }
            // Loop thru the children and search in their children
            foreach (var treeItem in treeItems)
            {
                var selectedInChildItem = SearchSelectedItem(treeItem.TreeItems);
                if (selectedInChildItem != null) { return selectedInChildItem; }
            }
            return null;
        }

        /// <summary>
        /// All child <see cref="TreeItem"/> objects from this <see cref="Tree"/>
        /// </summary>
        public TreeItem[] TreeItems
        {
            get { return GetTreeItems(); }
        }

        /// <summary>
        /// Gets all the <see cref="TreeItem"/> objects for this <see cref="Tree"/>
        /// </summary>
        private TreeItem[] GetTreeItems()
        {
            return Enumerable.ToArray<TreeItem>(FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TreeItem))
                    .Select(e => e.AsTreeItem()));
        }
    }
}
