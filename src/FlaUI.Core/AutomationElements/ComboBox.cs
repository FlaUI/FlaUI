using System;
using System.Linq;
using System.Threading;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;

namespace FlaUI.Core.AutomationElements
{
    public class ComboBox : AutomationElement
    {
        public ComboBox(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public string EditableText
        {
            get { return EditableItem.Text; }
            set { EditableItem.Text = value; }
        }

        public virtual bool IsEditable => GetEditableElement() != null;

        protected TextBox EditableItem
        {
            get
            {
                var edit = GetEditableElement();
                if (edit != null)
                {
                    return edit.AsTextBox();
                }
                throw new Exception("ComboBox is not editable.");
            }
        }

        public SelectionItemAutomationElement SelectedItem => Items.FirstOrDefault(x => x.IsSelected);

        public SelectionItemAutomationElement[] SelectedItems => Items.Where(x => x.IsSelected).ToArray();

        public SelectionItemAutomationElement[] Items
        {
            get
            {
                Expand();
                AutomationElement[] items;
                if (FrameworkType == FrameworkType.WinForms)
                {
                    // WinForms
                    var listElement = FindFirstChild(ConditionFactory.ByControlType(ControlType.List));
                    items = listElement.FindAllChildren(new TrueCondition());
                }
                else
                {
                    // WPF
                    items = FindAllChildren(ConditionFactory.ByControlType(ControlType.ListItem));
                }
                return items.Select(x => new SelectionItemAutomationElement(x.BasicAutomationElement)).ToArray();
            }
        }

        public ExpandCollapseState ExpandCollapseState
        {
            get
            {
                if (FrameworkType == FrameworkType.WinForms)
                {
                    // WinForms
                    var itemsList = FindFirstChild(ConditionFactory.ByControlType(ControlType.List));
                    // UIA3 does not see the list if it is collapsed
                    return itemsList == null || itemsList.Current.IsOffscreen ? ExpandCollapseState.Collapsed : ExpandCollapseState.Expanded;
                }
                // WPF
                var ecp = PatternFactory.GetExpandCollapsePattern();
                if (ecp != null)
                {
                    var state = ecp.Current.ExpandCollapseState;
                    return state;
                }
                return ExpandCollapseState.LeafNode;
            }
        }

        public void Expand()
        {
            if (!Current.IsEnabled || ExpandCollapseState != ExpandCollapseState.Collapsed)
            {
                return;
            }
            if (FrameworkType == FrameworkType.WinForms)
            {
                // WinForms
                var openButton = FindFirstChild(ConditionFactory.ByControlType(ControlType.Button)).AsButton();
                openButton.Invoke();
            }
            else
            {
                // WPF
                var ecp = PatternFactory.GetExpandCollapsePattern();
                if (ecp != null)
                {
                    ecp.Expand();
                    Thread.Sleep(50);
                }
            }
        }

        public void Collapse()
        {
            if (!Current.IsEnabled || ExpandCollapseState != ExpandCollapseState.Expanded)
            {
                return;
            }
            if (FrameworkType == FrameworkType.WinForms)
            {
                // WinForms
                var openButton = FindFirstChild(ConditionFactory.ByControlType(ControlType.Button)).AsButton();
                if (IsEditable)
                {
                    // WinForms editable combo box only closes on click and not on invoke
                    openButton.Click(false);
                }
                else
                {
                    openButton.Invoke();
                }
            }
            else
            {
                // WPF
                var ecp = PatternFactory.GetExpandCollapsePattern();
                if (ecp != null)
                {
                    ecp.Collapse();
                }
            }
            Helpers.WaitUntilInputIsProcessed();
        }

        private AutomationElement GetEditableElement()
        {
            return FindFirstChild(ConditionFactory.ByControlType(ControlType.Edit));
        }
    }
}
