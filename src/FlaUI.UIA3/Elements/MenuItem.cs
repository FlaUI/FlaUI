﻿using FlaUI.UIA3.Conditions;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Patterns;
using System.Linq;
using System.Threading;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    /// <summary>
    /// Represents a menuitem which can also contain sub-menuitems
    /// </summary>
    public class MenuItem : Element
    {
        public MenuItem(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

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
                return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.MenuItem)).Select(e => ElementConversionExtensions.AsMenuItem(e)).ToArray();
            }
        }

        public InvokePattern InvokePattern
        {
            get { return PatternFactory.GetInvokePattern(); }
        }

        public ExpandCollapsePattern ExpandCollapsePattern
        {
            get { return PatternFactory.GetExpandCollapsePattern(); }
        }

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
