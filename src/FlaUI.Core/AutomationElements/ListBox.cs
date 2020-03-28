using System;
using System.Linq;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a list box element.
    /// </summary>
    public class ListBox : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="ListBox"/> element.
        /// </summary>
        public ListBox(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Pattern object for the <see cref="ISelectionPattern"/>.
        /// </summary>
        protected ISelectionPattern SelectionPattern => Patterns.Selection.Pattern;

        /// <summary>
        /// Returns all the list box items
        /// </summary>
        public ListBoxItem[] Items
        {
            get
            {
                if (FrameworkType == FrameworkType.Wpf && Patterns.ItemContainer.TryGetPattern(out var itemContainerPattern))
                {
                    List<ListBoxItem> allItems = new List<ListBoxItem>();
                    AutomationElement item = null;
                    do
                    {
                        item = itemContainerPattern.FindItemByProperty(item, null, null);
                        if (item != null)
                        {
                            allItems.Add(item.AsListBoxItem());
                        }
                    }
                    while (item != null);
                    return allItems.ToArray();
                }
                else
                {
                    return FindAllChildren(cf => cf.ByControlType(ControlType.ListItem)).Select(x => x.AsListBoxItem()).ToArray();
                }
            }
        }

        /// <summary>
        /// Gets all selected items.
        /// </summary>
        public ListBoxItem[] SelectedItems => SelectionPattern.Selection.Value.Select(x => x.AsListBoxItem()).ToArray();

        /// <summary>
        /// Gets the first selected item or null otherwise.
        /// </summary>
        public ListBoxItem SelectedItem => SelectionPattern.Selection.Value.FirstOrDefault()?.AsListBoxItem();

        private ListBoxItem GetWPFListItemByIndex(int index)
        {
            if (index < 0)
            {
                throw new Exception("index cannot be negative");
            }
            
            if (Patterns.ItemContainer.TryGetPattern(out var itemContainerPattern))
            {
                AutomationElement item = null;
                do
                {
                    item = itemContainerPattern.FindItemByProperty(item, null, null);
                    if (item == null)
                    {
                        throw new Exception("index is too big");
                    }
                    index--;
                }
                while (index >= 0);
                return item.AsListBoxItem();
            }
            
            return null;
        }

        /// <summary>
        /// Selects an item by index.
        /// </summary>
        public ListBoxItem Select(int index)
        {
            ListBoxItem[] allItems = Items;
            if (FrameworkType == FrameworkType.Wpf && index >= allItems.Length)
            {
                ListBoxItem wpfItem = GetWPFListItemByIndex(index);
                if (wpfItem != null)
                {
                    wpfItem.Select();
                    return wpfItem;
                }
            }
            var item = allItems.ElementAt(index);
            item.Select();
            return item;
        }

        /// <summary>
        /// Selects an item by text.
        /// </summary>
        public ListBoxItem Select(string text)
        {
            var item = Items.FirstOrDefault(x => x.Text.Equals(text));
            if (item == null)
            {
                if (FrameworkType == FrameworkType.Wpf && Patterns.ItemContainer.TryGetPattern(out var itemContainerPattern))
                {
                    AutomationElement foundItem = itemContainerPattern.FindItemByProperty(null, FrameworkAutomationElement.PropertyIdLibrary.Name, text);
                    if (foundItem != null)
                    {
                        item = foundItem.AsListBoxItem();
                    }
                }
                if (item == null)
                {
                    throw new InvalidOperationException($"Did not find an item with text \"{text}\"");
                }
            }
            item.Select();
            return item;
        }

        /// <summary>
        /// Add a row to the selection by index.
        /// </summary>
        public ListBoxItem AddToSelection(int index)
        {
            ListBoxItem[] allItems = Items;
            if (FrameworkType == FrameworkType.Wpf && index >= allItems.Length)
            {
                ListBoxItem wpfItem = GetWPFListItemByIndex(index);
                if (wpfItem != null)
                {
                    wpfItem.AddToSelection();
                    return wpfItem;
                }
            }
            var item = allItems.ElementAt(index);
            item.AddToSelection();
            return item;
        }
        
        /// <summary>
        /// Add a row to the selection by text.
        /// </summary>
        public ListBoxItem AddToSelection(string text)
        {
            var item = Items.FirstOrDefault(x => x.Text.Equals(text));
            if (item == null)
            {
                if (FrameworkType == FrameworkType.Wpf && Patterns.ItemContainer.TryGetPattern(out var itemContainerPattern))
                {
                    AutomationElement foundItem = itemContainerPattern.FindItemByProperty(null, FrameworkAutomationElement.PropertyIdLibrary.Name, text);
                    if (foundItem != null)
                    {
                        item = foundItem.AsListBoxItem();
                    }
                }
                if (item == null)
                {
                    throw new InvalidOperationException($"Did not find an item with text \"{text}\"");
                }
            }
            item.AddToSelection();
            return item;
        }

        /// <summary>
        /// Remove a row from the selection by index.
        /// </summary>
        public ListBoxItem RemoveFromSelection(int index)
        {
            ListBoxItem[] allItems = Items;
            if (FrameworkType == FrameworkType.Wpf && index >= allItems.Length)
            {
                ListBoxItem wpfItem = GetWPFListItemByIndex(index);
                if (wpfItem != null)
                {
                    wpfItem.RemoveFromSelection();
                    return wpfItem;
                }
            }
            var item = allItems.ElementAt(index);
            item.RemoveFromSelection();
            return item;
        }
        
        /// <summary>
        /// Remove a row from the selection by text.
        /// </summary>
        public ListBoxItem RemoveFromSelection(string text)
        {
            var item = Items.FirstOrDefault(x => x.Text.Equals(text));
            if (item == null)
            {
                if (FrameworkType == FrameworkType.Wpf && Patterns.ItemContainer.TryGetPattern(out var itemContainerPattern))
                {
                    AutomationElement foundItem = itemContainerPattern.FindItemByProperty(null, FrameworkAutomationElement.PropertyIdLibrary.Name, text);
                    if (foundItem != null)
                    {
                        item = foundItem.AsListBoxItem();
                    }
                }
                if (item == null)
                {
                    throw new InvalidOperationException($"Did not find an item with text \"{text}\"");
                }
            }
            item.RemoveFromSelection();
            return item;
        }
    }
}
