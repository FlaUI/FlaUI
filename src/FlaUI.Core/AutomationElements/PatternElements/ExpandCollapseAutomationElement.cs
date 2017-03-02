using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    public class ExpandCollapseAutomationElement : AutomationElement
    {
        public ExpandCollapseAutomationElement(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public IExpandCollapsePattern ExpandCollapsePattern => Patterns.ExpandCollapse.Pattern;

        public ExpandCollapseState ExpandCollapseState => ExpandCollapsePattern.ExpandCollapseState;

        public void Expand()
        {
            ExpandCollapsePattern.Expand();
        }

        public void Collapse()
        {
            ExpandCollapsePattern.Expand();
        }
    }
}
