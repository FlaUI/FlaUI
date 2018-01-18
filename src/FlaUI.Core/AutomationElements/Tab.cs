using System;
using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a tab element.
    /// </summary>
    public class Tab : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="Tab"/> element.
        /// </summary>
        public Tab(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// The currently selected <see cref="TabItem" />
        /// </summary>
        public TabItem SelectedTabItem
        {
            get { return TabItems.FirstOrDefault(t => t.IsSelected); }
        }

        /// <summary>
        /// The index of the currently selected <see cref="TabItem" />
        /// </summary>
        public int SelectedTabItemIndex => GetIndexOfSelectedTabItem();

        /// <summary>
        /// All <see cref="TabItem" /> objects from this <see cref="Tab" />
        /// </summary>
        public TabItem[] TabItems => GetTabItems();

        /// <summary>
        /// Selects a <see cref="TabItem" /> by index
        /// </summary>
        public TabItem SelectTabItem(int index)
        {
            var tabItem = TabItems[index];
            tabItem.Select();
            return tabItem;
        }

        /// <summary>
        /// Selects a <see cref="TabItem" /> by a give text (name property)
        /// </summary>
        public TabItem SelectTabItem(string text)
        {
            var tabItems = TabItems;
            var foundTabItemIndex = Array.FindIndex(tabItems, t => t.Properties.Name == text);
            if (foundTabItemIndex < 0)
            {
                throw new Exception($"No TabItem found with text '{text}'");
            }
            var tabItem = tabItems[foundTabItemIndex];
            if (SelectedTabItemIndex != foundTabItemIndex)
            {
                // It is not the selected one, so select it
                tabItem.Select();
            }
            return tabItem;
        }

        /// <summary>
        /// Gets all the <see cref="TabItem" /> objects for this <see cref="Tab" />
        /// </summary>
        private TabItem[] GetTabItems()
        {
            return FindAllChildren(cf => cf.ByControlType(ControlType.TabItem))
                .Select(e => e.AsTabItem()).ToArray();
        }

        private int GetIndexOfSelectedTabItem()
        {
            return Array.FindIndex(TabItems, t => t.IsSelected);
        }
    }
}
