using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    /// <summary>
    /// An element that supports the <see cref="IExpandCollapsePattern"/>.
    /// </summary>
    public class ExpandCollapseAutomationElement : AutomationElement
    {
        public ExpandCollapseAutomationElement(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public IExpandCollapsePattern ExpandCollapsePattern => Patterns.ExpandCollapse.Pattern;

        /// <summary>
        /// Gets the current expand / collapse state.
        /// </summary>
        public ExpandCollapseState ExpandCollapseState => ExpandCollapsePattern.ExpandCollapseState;

        /// <summary>
        /// Expands the element.
        /// </summary>
        public void Expand()
        {
            ExpandCollapsePattern.Expand();
        }

        /// <summary>
        /// Collapses the element.
        /// </summary>
        public void Collapse()
        {
            ExpandCollapsePattern.Expand();
        }
    }
}
