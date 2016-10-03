using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;
using System;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.Elements.PatternElements
{
    public class ExpandCollapseElement : Element
    {
        public ExpandCollapseElement(AutomationObjectBase automationObject) : base(automationObject)
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
