using System;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    /// <summary>
    /// An UI-item which supports the <see cref="SelectionItemPattern" />
    /// </summary>
    public class SelectionItemAutomationElement : AutomationElement
    {
        public SelectionItemAutomationElement(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
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
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.Select());
        }

        public void AddToSelection()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.AddToSelection());
        }

        public void RemoveFromSelection()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.RemoveFromSelection());
        }
    }
}
