using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a radiobutton element.
    /// </summary>
    public class RadioButton : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="RadioButton"/> element.
        /// </summary>
        public RadioButton(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Pattern object for the <see cref="ISelectionItemPattern"/>.
        /// </summary>
        protected ISelectionItemPattern SelectionItemPattern => Patterns.SelectionItem.Pattern;

        /// <summary>
        /// Flag to get/set the selection of this element.
        /// </summary>
        public bool IsChecked
        {
            get => SelectionItemPattern.IsSelected.Value;
            set
            {
                if (IsChecked == value)
                {
                    return;
                }

                if (value && !IsChecked)
                {
                    ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.Select());
                }

                if (IsChecked != value)
                {
                    throw new FlaUIException($"Failed setting {this}.IsChecked to {value}");
                }
            }
        }
    }
}
