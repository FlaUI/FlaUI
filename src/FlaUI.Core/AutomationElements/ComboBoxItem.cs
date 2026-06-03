using FlaUI.Core.AutomationElements.PatternElements;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a combobox item element.
    /// </summary>
    public class ComboBoxItem : SelectionItemAutomationElement
    {
        /// <summary>
        /// Creates a <see cref="ComboBoxItem"/> element.
        /// </summary>
        public ComboBoxItem(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Gets the text of the element.
        /// </summary>
        public virtual string Text
        {
            get
            {
                if (FrameworkType == FrameworkType.Wpf)
                {
                    var text = ItemTextResolver.FindFirstTextDescendantName(this);
                    if (text != null)
                    {
                        return text;
                    }
                }
                return FrameworkAutomationElement.Properties.Name.Value;
            }
        }
    }
}
