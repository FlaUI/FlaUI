using System;
using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    public class TreeItem : AutomationElement
    {
        private readonly SelectionItemAutomationElement _selectionItemAutomationElement;
        private readonly ExpandCollapseAutomationElement _expandCollapseAutomationElement;

        public TreeItem(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
            _selectionItemAutomationElement = new SelectionItemAutomationElement(basicAutomationElement);
            _expandCollapseAutomationElement = new ExpandCollapseAutomationElement(basicAutomationElement);
        }

        /// <summary>
        /// All child <see cref="TreeItem" /> objects from this <see cref="TreeItem" />
        /// </summary>
        public TreeItem[] TreeItems => GetTreeItems();

        /// <summary>
        /// The text of the <see cref="TreeItem" />
        /// </summary>
        public string Text
        {
            get
            {
                var value = Properties.Name.Value;
                if (String.IsNullOrEmpty(value) || value.Contains("System.Windows.Controls.TreeViewItem"))
                {
                    var textElement = FindFirstChild(cf => cf.ByControlType(ControlType.Text));
                    return textElement == null ? String.Empty : textElement.Properties.Name;
                }
                return value;
            }
        }

        public bool IsSelected
        {
            get { return _selectionItemAutomationElement.IsSelected; }
            set { _selectionItemAutomationElement.IsSelected = value; }
        }

        public void Expand()
        {
            _expandCollapseAutomationElement.Expand();
        }

        public void Collapse()
        {
            _expandCollapseAutomationElement.Collapse();
        }

        public void Select()
        {
            _selectionItemAutomationElement.Select();
        }

        /// <summary>
        /// Gets all the <see cref="TreeItem" /> objects for this <see cref="TreeItem" />
        /// </summary>
        private TreeItem[] GetTreeItems()
        {
            return FindAllChildren(cf => cf.ByControlType(ControlType.TreeItem))
                .Select(e => e.AsTreeItem()).ToArray();
        }
    }
}
