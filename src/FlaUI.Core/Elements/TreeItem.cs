using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using System;
using System.Linq;
using FlaUI.Core.Patterns;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class TreeItem : SelectionItem
    {
        public TreeItem(Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public ExpandCollapsePattern ExpandCollapsePattern
        {
            get { return PatternFactory.GetExpandCollapsePattern(); }
        }
        /// <summary>
        /// All child <see cref="TreeItem"/> objects from this <see cref="TreeItem"/>
        /// </summary>
        public TreeItem[] TreeItems
        {
            get { return GetTreeItems(); }
        }

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

        public void Expand()
        {
            var expandCollapsePattern = ExpandCollapsePattern;
            if (expandCollapsePattern != null)
            {
                expandCollapsePattern.Expand();
            }
        }

        public void Collapse()
        {
            var expandCollapsePattern = ExpandCollapsePattern;
            if (expandCollapsePattern != null)
            {
                expandCollapsePattern.Expand();
            }
        }

        /// <summary>
        /// Gets all the <see cref="TreeItem"/> objects for this <see cref="TreeItem"/>
        /// </summary>
        private TreeItem[] GetTreeItems()
        {
            return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TreeItem))
                .Select(e => e.AsTreeItem()).ToArray();
        }
    }
}
