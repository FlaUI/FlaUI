using System;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    public class ComboBox : AutomationElement
    {
        public ComboBox(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public AutomationElement EditAutomationElement { get; set; }

        public string EditableText
        {
            get { return EditableItem.Text; }
            set { EditableItem.Text = value; }
        }

        protected TextBox EditableItem
        {
            get
            {
                var edit = FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Edit)).AsTextBox();
                if (edit != null)
                {
                    return edit;
                }
                throw new Exception("ComboBox is not editable.");
            }
        }
    }
}
