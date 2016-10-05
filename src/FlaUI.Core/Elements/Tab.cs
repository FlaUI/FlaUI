using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using System;
using System.Linq;

namespace FlaUI.Core.Elements
{
    public class Tab : AutomationElement
    {
        public Tab(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

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
        public int SelectedTabItemIndex => GetIndexOfSelectedTabItem();

        /// <summary>
        /// All <see cref="TabItem"/> objects from this <see cref="Tab"/>
        /// </summary>
        public TabItem[] TabItems => GetTabItems();

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
            var tabItems = TabItems;
            var foundTabItemIndex = Array.FindIndex(tabItems, t => t.Current.Name == text);
            if (foundTabItemIndex < 0)
            {
                throw new Exception(String.Format("No TabItemAutomation found with text '{0}'", text));
            }
            var previousSelectedTabItemIndex = SelectedTabItemIndex;
            if (previousSelectedTabItemIndex == foundTabItemIndex)
            {
                // It is already selected so don't do anything
                return;
            }
            // Select the item
            tabItems[foundTabItemIndex].Select();
        }

        /// <summary>
        /// Gets all the <see cref="TabItem"/> objects for this <see cref="Tab"/>
        /// </summary>
        private TabItem[] GetTabItems()
        {
            return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TabItem))
                .Select(e => e.AsTabItem()).ToArray();
        }

        private int GetIndexOfSelectedTabItem()
        {
            return Array.FindIndex(TabItems, t => t.IsSelected);
        }
    }
}
