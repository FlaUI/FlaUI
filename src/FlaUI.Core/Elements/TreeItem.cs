using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Elements.PatternElements;
using System;
using System.Linq;

namespace FlaUI.Core.Elements
{
    public class TreeItem : Element
    {
        private readonly SelectionItemElement _selectionItemElement;
        private readonly ExpandCollapseElement _expandCollapseElement;

        public TreeItem(AutomationObjectBase automationObject) : base(automationObject)
        {
            _selectionItemElement= new SelectionItemElement(automationObject);
            _expandCollapseElement = new ExpandCollapseElement(automationObject);
        }

        /// <summary>
        /// All child <see cref="TreeItem"/> objects from this <see cref="TreeItem"/>
        /// </summary>
        public TreeItem[] TreeItems => GetTreeItems();

        /// <summary>
        /// The text of the <see cref="TreeItem"/>
        /// </summary>
        public string Text
        {
            get
            {
                var value = Current.Name;
                if (String.IsNullOrEmpty(value) || value.Contains("System.Windows.Controls.TreeViewItem"))
                {
                    var textElement = FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Text));
                    return textElement == null ? String.Empty : textElement.Current.Name;
                }
                return value;
            }
        }

        public bool IsSelected
        {
            get { return _selectionItemElement.IsSelected; }
            set { _selectionItemElement.IsSelected = value; }
        }

        public void Expand()
        {
            _expandCollapseElement.Expand();
        }

        public void Collapse()
        {
            _expandCollapseElement.Collapse();
        }

        public void Select()
        {
            _selectionItemElement.Select();
        }

        /// <summary>
        /// Gets all the <see cref="TreeItem"/> objects for this <see cref="TreeItem"/>
        /// </summary>
        private TreeItem[] GetTreeItems()
        {
            return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TreeItem))
                .Select(e => ElementConversionExtensions.AsTreeItem(e)).ToArray();
        }
    }
}
