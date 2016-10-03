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
        /// The currently selected <see cref="TabItemAutomation"/>
        /// </summary>
        public TabItemAutomation SelectedTabItemAutomation
        {
            get { return TabItemsAutomation.FirstOrDefault(t => t.IsSelected); }
        }

        /// <summary>
        /// The index of the currently selected <see cref="TabItemAutomation"/>
        /// </summary>
        public int SelectedTabItemIndex => GetIndexOfSelectedTabItem();

        /// <summary>
        /// All <see cref="TabItemAutomation"/> objects from this <see cref="Tab"/>
        /// </summary>
        public TabItemAutomation[] TabItemsAutomation => GetTabItems();

        /// <summary>
        /// Selects a <see cref="TabItemAutomation"/> by index
        /// </summary>
        public void SelectTabItem(int index)
        {
            var tabItem = TabItemsAutomation[index];
            tabItem.Select();
        }

        /// <summary>
        /// Selects a <see cref="TabItemAutomation"/> by a give text (name property)
        /// </summary>
        public void SelectTabItem(string text)
        {
            var tabItems = TabItemsAutomation;
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
        /// Gets all the <see cref="TabItemAutomation"/> objects for this <see cref="Tab"/>
        /// </summary>
        private TabItemAutomation[] GetTabItems()
        {
            return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TabItem))
                .Select(e => e.AsTabItem()).ToArray();
        }

        private int GetIndexOfSelectedTabItem()
        {
            return Array.FindIndex(TabItemsAutomation, t => t.IsSelected);
        }
    }
}
