using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;
using System;

namespace FlaUI.Core.Elements.PatternElements
{
    /// <summary>
    /// An UI-item which supports the <see cref="SelectionItemPattern"/>
    /// </summary>
    public class SelectionItemAutomationElement : AutomationElement
    {
        public SelectionItemAutomationElement(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public ISelectionItemPattern SelectionItemPattern => PatternFactory.GetSelectionItemPattern();

        public bool IsSelected
        {
            get { return SelectionItemPattern.Current.IsSelected; }
            set
            {
                if (IsSelected == value) return;
                if (value && !IsSelected)
                {
                    Select();
                }
            }
        }

        public void Select()
        {
            var selectionItemPattern = SelectionItemPattern;
            if (selectionItemPattern != null)
            {
                selectionItemPattern.Select();
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
