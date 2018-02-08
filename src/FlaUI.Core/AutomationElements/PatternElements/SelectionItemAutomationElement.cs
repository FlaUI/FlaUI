using FlaUI.Core.AutomationElements;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    /// <summary>
    /// An element which supports the <see cref="ISelectionItemPattern" />.
    /// </summary>
    public class SelectionItemAutomationElement : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="SelectionItemAutomationElement"/> element.
        /// </summary>
        public SelectionItemAutomationElement(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Pattern object for the <see cref="ISelectionItemPattern"/>.
        /// </summary>
        protected ISelectionItemPattern SelectionItemPattern => Patterns.SelectionItem.Pattern;

        /// <summary>
        /// Value to get/set if this element is selected.
        /// </summary>
        public virtual bool IsSelected
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
        public virtual SelectionItemAutomationElement Select()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.Select());
            return this;
        }

        /// <summary>
        /// Adds the element to the selection.
        /// </summary>
        public virtual SelectionItemAutomationElement AddToSelection()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.AddToSelection());
            return this;
        }

        /// <summary>
        /// Removes the element from the selection.
        /// </summary>
        public virtual SelectionItemAutomationElement RemoveFromSelection()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.RemoveFromSelection());
            return this;
        }
    }
}
