using System;
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

        public IExpandCollapsePattern ExpandCollapsePattern => PatternFactory.GetExpandCollapsePattern();

        public ExpandCollapseState ExpandCollapseState => ExpandCollapsePattern.Current.ExpandCollapseState;

        public void Expand()
        {
            var expandCollapsePattern = ExpandCollapsePattern;
            if (expandCollapsePattern != null)
            {
                expandCollapsePattern.Expand();
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public void Collapse()
        {
            var expandCollapsePattern = ExpandCollapsePattern;
            if (expandCollapsePattern != null)
            {
                expandCollapsePattern.Expand();
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
