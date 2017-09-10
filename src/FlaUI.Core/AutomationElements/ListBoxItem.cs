using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a list box item element.
    /// </summary>
    public class ListBoxItem: SelectionItemAutomationElement
    {
        /// <summary>
        /// Creates a <see cref="ListBoxItem"/> element.
        /// </summary>
        public ListBoxItem(BasicAutomationElementBase basicAutomationElement)
            : base(basicAutomationElement)
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
                    // In WPF, the text is actually an inner content only (text) element
                    // which can be accessed only with a raw walker.
                    var rawTreeWalker = Automation.TreeWalkerFactory.GetRawViewWalker();
                    var rawElement = rawTreeWalker.GetFirstChild(this);
                    if (rawElement != null)
                    {
                        return rawElement.Properties.Name.Value;
                    }
                }

                return Properties.Name.Value;
            }
        }

        /// <summary>
        /// Pattern object for the <see cref="IScrollItemPattern"/>.
        /// </summary>
        protected IScrollItemPattern ScrollItemPattern => Patterns.ScrollItem.Pattern;

        /// <summary>
        /// Scrolls the element into view.
        /// </summary>
        public virtual ListBoxItem ScrollIntoView()
        {
            ScrollItemPattern?.ScrollIntoView();
            return this;
        }
    }
}
