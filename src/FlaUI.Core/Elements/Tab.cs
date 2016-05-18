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

        /// <summary>
        /// The currently selected <see cref="TabItem"/>
        /// </summary>
        public TabItem SelectedTabItem
        {
            get { return TabItems.FirstOrDefault(t => t.IsSelected); }
        }

        /// <summary>
        /// The index of the currently selected <see cref="TabItem"/>
        /// </summary>
        public int SelectedTabItemIndex
        {
            get { return GetIndexOfSelecteTabItem(); }
        }

        /// <summary>
        /// All <see cref="TabItem"/> objects from this <see cref="Tab"/>
        /// </summary>
        public TabItem[] TabItems
        {
            get { return GetTabItems(); }
        }

        /// <summary>
        /// Selects a <see cref="TabItem"/> by index
        /// </summary>
        public void SelectTabItem(int index)
        {
            var tabItem = TabItems[index];
            tabItem.Select();
        }

        /// <summary>
        /// Selects a <see cref="TabItem"/> by a give text (name property)
        /// </summary>
        public void SelectTabItem(string text)
        {
            var vabItems = TabItems;
            var foundTabItemIndex = Array.FindIndex(vabItems, t => t.Current.Name == text);
            if (foundTabItemIndex < 0)
            {
                throw new Exception(String.Format("No TabItem found with text '{0}'", text));
            }
            var previousSelectedTabItemIndex = SelectedTabItemIndex;
            if (previousSelectedTabItemIndex == foundTabItemIndex)
            {
                // It is already selected so don't do anything
                return;
            }
            // Select the item
            vabItems[foundTabItemIndex].Select();
        }

        /// <summary>
        /// Gets all the <see cref="TabItem"/> objects for this <see cref="Tab"/>
        /// </summary>
        private TabItem[] GetTabItems()
        {
            return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TabItem))
                .Select(e => e.AsTabItem()).ToArray();
        }

        private int GetIndexOfSelecteTabItem()
        {
            return Array.FindIndex(TabItems, t => t.IsSelected);
        }
    }
}
