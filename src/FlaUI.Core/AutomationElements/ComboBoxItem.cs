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
                    // In WPF, the Text is actually an inner content only (text) element
                    // which can be accessed only with a raw walker.
                    var rawTreeWalker = Automation.TreeWalkerFactory.GetRawViewWalker();
                    var rawElement = rawTreeWalker.GetFirstChild(this);
                    if (rawElement != null)
                    {
                        return rawElement.Properties.Name.Value;
                    }
                }
                return FrameworkAutomationElement.Properties.Name.Value;
            }
        }
    }
}
