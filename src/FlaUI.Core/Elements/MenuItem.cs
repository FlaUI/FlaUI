using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;
using System.Linq;
using System.Threading;

namespace FlaUI.Core.Elements
{
    /// <summary>
    /// Represents a menuitem which can also contain sub-menuitems
    /// </summary>
    public class MenuItem : Element
    {
        public MenuItem(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public MenuItem[] SubMenuItems
        {
            get
            {
                if (ExpandCollapsePattern != null &&
                    ExpandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.Collapsed)
                {
                    ExpandCollapsePattern.Expand();
                    Thread.Sleep(250);
                }
                return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.MenuItem)).Select(e => e.AsMenuItem()).ToArray();
            }
        }

        public IInvokePattern InvokePattern => PatternFactory.GetInvokePattern();

        public IExpandCollapsePattern ExpandCollapsePattern => PatternFactory.GetExpandCollapsePattern();

        public void Invoke()
        {
            var invokePattern = InvokePattern;
            if (invokePattern != null)
            {
                invokePattern.Invoke();
            }
        }

        public void Expand()
        {
            var expandCollapsePattern = ExpandCollapsePattern;
            if (expandCollapsePattern != null)
            {
                expandCollapsePattern.Expand();
            }
        }

        public void Collapse()
        {
            var expandCollapsePattern = ExpandCollapsePattern;
            if (expandCollapsePattern != null)
            {
                expandCollapsePattern.Expand();
            }
        }
    }
}
