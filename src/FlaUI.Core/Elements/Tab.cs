using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using System;
using System.Linq;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class Tab : AutomationElement
    {
        public Tab(Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public TabItem SelectedTab
        {
            get { return Tabs.FirstOrDefault(t => t.IsSelected); }
        }

        public int SelectedTabIndex
        {
            get { return GetIndexOfSelectedTab(Tabs); }
        }

        public int TabCount
        {
            get { return Tabs.Length; }
        }

        public TabItem[] Tabs
        {
            get
            {
                return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TabItem))
                    .Select(e => e.AsTabItem()).ToArray();
            }
        }

        public void SelectTabPage(int index)
        {
            var tab = Tabs[index];
            tab.Select();
        }

        public void SelectTabPage(string tabTitle)
        {
            var tabs = Tabs;
            var foundTabIndex = Array.FindIndex<TabItem>(tabs, t => t.Current.Name == tabTitle);
            if (foundTabIndex < 0)
            {
                throw new Exception(String.Format("No tab found with title '{0}'", tabTitle));
            }
            var previousSelectedTabIndex = GetIndexOfSelectedTab(tabs);
            if (previousSelectedTabIndex == foundTabIndex)
            {
                return;
            }
            tabs[foundTabIndex].Select();
        }

        private int GetIndexOfSelectedTab(TabItem[] tabs)
        {
            return Array.FindIndex<TabItem>(Tabs, t => t.IsSelected);
        }
    }
}
