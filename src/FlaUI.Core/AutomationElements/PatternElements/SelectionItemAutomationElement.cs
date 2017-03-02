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

        public ISelectionItemPattern SelectionItemPattern => Patterns.SelectionItem.Pattern;

        public bool IsSelected
        {
            get { return SelectionItemPattern.IsSelected; }
            set
            {
                if (IsSelected == value) return;
                if (value && !IsSelected)
                {
                    Select();
                }
            }
        }

        public SelectionItemAutomationElement Select()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.Select());
            return this;
        }

        public SelectionItemAutomationElement AddToSelection()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.AddToSelection());
            return this;
        }

        public SelectionItemAutomationElement RemoveFromSelection()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.RemoveFromSelection());
            return this;
        }
    }
}
