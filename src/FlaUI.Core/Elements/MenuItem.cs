using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Elements.PatternElements;
using System.Linq;
using System.Threading;

namespace FlaUI.Core.Elements
{
    /// <summary>
    /// Represents a menuitem which can also contain sub-menuitems
    /// </summary>
    public class MenuItem : AutomationElement
    {
        private readonly InvokeAutomationElement _invokeAutomationElement;
        private readonly ExpandCollapseAutomationElement _expandCollapseAutomationElement;

        public MenuItem(AutomationObjectBase automationObject) : base(automationObject)
        {
            _invokeAutomationElement = new InvokeAutomationElement(automationObject);
            _expandCollapseAutomationElement = new ExpandCollapseAutomationElement(automationObject);
        }

        public MenuItem[] SubMenuItems
        {
            get
            {
                // WinForms dies not have the expand pattern but all children are already there to fetch
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
