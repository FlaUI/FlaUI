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
    public class MenuItem : Element
    {
        private readonly InvokeElement _invokeElement;
        private readonly ExpandCollapseElement _expandCollapseElement;

        public MenuItem(AutomationObjectBase automationObject) : base(automationObject)
        {
            _invokeElement = new InvokeElement(automationObject);
            _expandCollapseElement = new ExpandCollapseElement(automationObject);
        }

        public MenuItem[] SubMenuItems
        {
            get
            {
                // WinForms does not have the expand pattern but all children are already there to fetch so we can just continue
                if (_expandCollapseElement.ExpandCollapsePattern != null)
                {
                    ExpandCollapseState state;
                    do
                    {
                        state = _expandCollapseElement.ExpandCollapseState;
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
            _invokeElement.Invoke();
        }

        public void Expand()
        {
            _expandCollapseElement.Expand();
        }

        public void Collapse()
        {
            _expandCollapseElement.Collapse();
        }
    }
}
