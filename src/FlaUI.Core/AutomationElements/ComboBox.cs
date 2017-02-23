using System;
using System.Linq;
using System.Threading;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Patterns;

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

        public string Value
        {
            get { return ValuePattern.Value; }
            set { ValuePattern.SetValue(value);}
        }

        public SelectionItemAutomationElement SelectedItem => Items.FirstOrDefault(x => x.IsSelected);

        public SelectionItemAutomationElement[] SelectedItems => Items.Where(x => x.IsSelected).ToArray();

        public SelectionItemAutomationElement[] Items
        {
            get
            {
                Expand();
                AutomationElement[] items;
                if (FrameworkType == FrameworkType.WinForms || FrameworkType == FrameworkType.Win32)
                {
                    // WinForms and Win32
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

        public IValuePattern ValuePattern => PatternFactory.GetValuePattern();

        public ExpandCollapseState ExpandCollapseState
        {
            get
            {
                if (FrameworkType == FrameworkType.WinForms)
                {
                    // WinForms
                    var itemsList = FindFirstChild(ConditionFactory.ByControlType(ControlType.List));
                    // UIA3 does not see the list if it is collapsed
                    return itemsList == null || itemsList.Information.IsOffscreen ? ExpandCollapseState.Collapsed : ExpandCollapseState.Expanded;
                }
                // WPF
                var ecp = PatternFactory.GetExpandCollapsePattern();
                if (ecp != null)
                {
                    var state = ecp.ExpandCollapseState;
                    return state;
                }
                return ExpandCollapseState.LeafNode;
            }
        }

        public void Expand()
        {
            if (!Information.IsEnabled || ExpandCollapseState != ExpandCollapseState.Collapsed)
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
            if (!Information.IsEnabled || ExpandCollapseState != ExpandCollapseState.Expanded)
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
                    openButton.Click();
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
                ecp?.Collapse();
            }
            Helpers.WaitUntilResponsive(this);
        }

        private AutomationElement GetEditableElement()
        {
            return FindFirstChild(ConditionFactory.ByControlType(ControlType.Edit));
        }
    }
}
