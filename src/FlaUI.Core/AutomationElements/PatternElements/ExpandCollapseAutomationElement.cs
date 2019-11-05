using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    /// <summary>
    /// An element that supports the <see cref="IExpandCollapsePattern"/>.
    /// </summary>
    public class ExpandCollapseAutomationElement : AutomationElement
    {
        /// <summary>
        ///  Creates an expand/collapse element object from a given element.
        /// </summary>
        public ExpandCollapseAutomationElement(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        ///  Provides direct access to the expand/collapse pattern.
        /// </summary>
        public IExpandCollapsePattern ExpandCollapsePattern => Patterns.ExpandCollapse.Pattern;

        /// <summary>
        /// Gets the current expand/collapse state.
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
            ExpandCollapsePattern.Collapse();
        }
    }
}
