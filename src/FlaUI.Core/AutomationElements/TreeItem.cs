using System;
using System.Linq;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a treeitem element.
    /// </summary>
    public class TreeItem : AutomationElement
    {
        private readonly SelectionItemAutomationElement _selectionItemAutomationElement;
        private readonly ExpandCollapseAutomationElement _expandCollapseAutomationElement;

        /// <summary>
        /// Creates a <see cref="TreeItem"/> element.
        /// </summary>
        public TreeItem(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
            _selectionItemAutomationElement = new SelectionItemAutomationElement(frameworkAutomationElement);
            _expandCollapseAutomationElement = new ExpandCollapseAutomationElement(frameworkAutomationElement);
        }

        /// <summary>
        /// All child <see cref="TreeItem" /> objects from this <see cref="TreeItem" />.
        /// </summary>
        public TreeItem[] Items => GetTreeItems();

        /// <summary>
        /// The text of the <see cref="TreeItem" />.
        /// </summary>
        public string Text
        {
            get
            {
                var value = Properties.Name.ValueOrDefault;
                if (String.IsNullOrEmpty(value) || value.Contains("System.Windows.Controls.TreeViewItem"))
                {
                    var textElement = FindFirstChild(cf => cf.ByControlType(ControlType.Text));
                    return textElement == null ? String.Empty : textElement.Properties.Name.ValueOrDefault;
                }
                return value;
            }
        }

        /// <summary>
        /// Value to get/set if this element is selected.
        /// </summary>
        public bool IsSelected
        {
            get => _selectionItemAutomationElement.IsSelected;
            set => _selectionItemAutomationElement.IsSelected = value;
        }

        /// <summary>
        /// Gets the current expand / collapse state.
        /// </summary>
        public ExpandCollapseState ExpandCollapseState => _expandCollapseAutomationElement.ExpandCollapseState;

        /// <summary>
        /// Expands the element.
        /// </summary>
        public void Expand()
        {
            _expandCollapseAutomationElement.Expand();
        }

        /// <summary>
        /// Collapses the element.
        /// </summary>
        public void Collapse()
        {
            _expandCollapseAutomationElement.Collapse();
        }

        /// <summary>
        /// Selects the element.
        /// </summary>
        public void Select()
        {
            _selectionItemAutomationElement.Select();
        }

        /// <summary>
        /// Add the element to the selection.
        /// </summary>
        public TreeItem AddToSelection()
        {
            _selectionItemAutomationElement.AddToSelection();
            return this;
        }

        /// <summary>
        /// Remove the element from the selection.
        /// </summary>
        public TreeItem RemoveFromSelection()
        {
            _selectionItemAutomationElement.RemoveFromSelection();
            return this;
        }

        /// <summary>
        /// Gets all the <see cref="TreeItem" /> objects for this <see cref="TreeItem" />
        /// </summary>
        private TreeItem[] GetTreeItems()
        {
            return FindAllChildren(cf => cf.ByControlType(ControlType.TreeItem))
                .Select(e => e.AsTreeItem()).ToArray();
        }
        
        /// <summary>
        /// Gets or sets if the tree item is checked.
        /// </summary>
        public bool? IsChecked
        {
            get => _selectionItemAutomationElement.IsToggled;
            set => _selectionItemAutomationElement.IsToggled = value;
        }
    }
}
