using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    /// <summary>
    /// An element which supports the <see cref="ISelectionItemPattern" />.
    /// </summary>
    public class SelectionItemAutomationElement : AutomationElement
    {
        public SelectionItemAutomationElement(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        protected ISelectionItemPattern SelectionItemPattern => Patterns.SelectionItem.Pattern;

        /// <summary>
        /// Value to get/set if this element is selected.
        /// </summary>
        public bool IsSelected
        {
            get => SelectionItemPattern.IsSelected;
            set
            {
                if (IsSelected == value) return;
                if (value && !IsSelected)
                {
                    Select();
                }
            }
        }

        /// <summary>
        /// Selects the element.
        /// </summary>
        public SelectionItemAutomationElement Select()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.Select());
            return this;
        }

        /// <summary>
        /// Adds the element to the selection.
        /// </summary>
        public SelectionItemAutomationElement AddToSelection()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.AddToSelection());
            return this;
        }

        /// <summary>
        /// Removes the element from the selection.
        /// </summary>
        public SelectionItemAutomationElement RemoveFromSelection()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.RemoveFromSelection());
            return this;
        }
    }
}
