using System.Linq;
using System.Threading;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Represents a menuitem which can also contain sub-menuitems
    /// </summary>
    public class MenuItem : AutomationElement
    {
        private readonly InvokeAutomationElement _invokeAutomationElement;
        private readonly ExpandCollapseAutomationElement _expandCollapseAutomationElement;

        public MenuItem(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
            _invokeAutomationElement = new InvokeAutomationElement(basicAutomationElement);
            _expandCollapseAutomationElement = new ExpandCollapseAutomationElement(basicAutomationElement);
        }

        public MenuItem[] SubMenuItems
        {
            get
            {
                // WinForms does not have the expand pattern but all children are already there to fetch so we can just continue
                if (_expandCollapseAutomationElement.ExpandCollapsePattern != null)
                {
                    ExpandCollapseState state;
                    do
                    {
                        state = _expandCollapseAutomationElement.ExpandCollapseState;
                        if (state == ExpandCollapseState.Collapsed)
                        {
                            Expand();
                        }
                        Thread.Sleep(50);
                    } while (state != ExpandCollapseState.Expanded);
                }
                return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.MenuItem)).Select(e => e.AsMenuItem()).ToArray();
            }
        }

        public void Invoke()
        {
            _invokeAutomationElement.Invoke();
        }

        public void Expand()
        {
            _expandCollapseAutomationElement.Expand();
        }

        public void Collapse()
        {
            _expandCollapseAutomationElement.Collapse();
        }
    }
}
