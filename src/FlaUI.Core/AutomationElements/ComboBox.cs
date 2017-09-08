using System;
using System.Linq;
using System.Threading;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Element which can be used for combobox elements.
    /// </summary>
    public class ComboBox : AutomationElement
    {
        public ComboBox(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        protected IValuePattern ValuePattern => Patterns.Value.Pattern;

        protected ISelectionPattern SelectionPattern => Patterns.Selection.PatternOrDefault;

        /// <summary>
        /// The text of the editable element inside the combobox.
        /// Only works if the combobox is editable.
        /// </summary>
        public string EditableText
        {
            get => EditableItem.Text;
            set
            {
                EditableItem.Text = value;
                // UIA2/WinForms does not set the selected item until it is expanded
                if (AutomationType == AutomationType.UIA2 && FrameworkType == FrameworkType.WinForms)
                {
                    Expand();
                    Collapse();
                }
            }
        }

        /// <summary>
        /// Flag which indicates, if the combobox is editable or not.
        /// </summary>
        public virtual bool IsEditable => GetEditableElement() != null;

        /// <summary>
        /// Flag which indicates, if the combobox is read-only or not.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                // Try with the value pattern
                if (Patterns.Value.TryGetPattern(out var valuePattern) &&
                    valuePattern.IsReadOnly.TryGetValue(out var value))
                {
                    return value;
                }
                // try with the selection pattern
                if (Patterns.Selection.TryGetPattern(out var selectPattern) &&
                    selectPattern.Selection.IsSupported)
                {
                    return false;
                }
                // Assume that it is editable
                return true;
            }
        }

        /// <summary>
        /// Gets the editable element.
        /// </summary>
        protected virtual TextBox EditableItem
        {
            get
            {
                var edit = GetEditableElement();
                if (edit != null)
                {
                    return edit.AsTextBox();
                }
                throw new Exception("ComboBox is not editable.");
            }
        }

        /// <summary>
        /// Getter / setter for the selected value.
        /// </summary>
        public string Value
        {
            get => ValuePattern.Value.Value;
            set => ValuePattern.SetValue(value);
        }

        /// <summary>
        /// Gets all selected items.
        /// </summary>
        public ComboBoxItem[] SelectedItems
        {
            get
            {
                // In WinForms, there is no selection pattern, so search the items which are selected.
                if (SelectionPattern == null)
                {
                    return Items.Where(x => x.IsSelected).ToArray();
                }
                return SelectionPattern.Selection.Value.Select(x => new ComboBoxItem(x.BasicAutomationElement)).ToArray();
            }
        }

        /// <summary>
        /// Gets the first selected item or null otherwise.
        /// </summary>
        public ComboBoxItem SelectedItem => SelectedItems?.FirstOrDefault();

        /// <summary>
        /// Gets all items.
        /// </summary>
        public ComboBoxItem[] Items
        {
            get
            {
                Expand();
                AutomationElement[] items;
                if (FrameworkType == FrameworkType.WinForms || FrameworkType == FrameworkType.Win32)
                {
                    // WinForms and Win32
                    var listElement = FindFirstChild(cf => cf.ByControlType(ControlType.List));
                    items = listElement.FindAllChildren();
                }
                else
                {
                    // WPF
                    items = FindAllChildren(cf => cf.ByControlType(ControlType.ListItem));
                }
                return items.Select(x => new ComboBoxItem(x.BasicAutomationElement)).ToArray();
            }
        }

        public ExpandCollapseState ExpandCollapseState
        {
            get
            {
                if (FrameworkType == FrameworkType.WinForms)
                {
                    // WinForms
                    var itemsList = FindFirstChild(cf => cf.ByControlType(ControlType.List));
                    // UIA3 does not see the list if it is collapsed
                    return itemsList == null || itemsList.Properties.IsOffscreen ? ExpandCollapseState.Collapsed : ExpandCollapseState.Expanded;
                }
                // WPF
                var ecp = Patterns.ExpandCollapse.PatternOrDefault;
                if (ecp != null)
                {
                    var state = ecp.ExpandCollapseState.Value;
                    return state;
                }
                return ExpandCollapseState.LeafNode;
            }
        }

        public void Expand()
        {
            if (!Properties.IsEnabled.Value || ExpandCollapseState != ExpandCollapseState.Collapsed)
            {
                return;
            }
            if (FrameworkType == FrameworkType.WinForms)
            {
                // WinForms
                var openButton = FindFirstChild(cf => cf.ByControlType(ControlType.Button)).AsButton();
                openButton.Invoke();
            }
            else
            {
                // WPF
                var ecp = Patterns.ExpandCollapse.PatternOrDefault;
                if (ecp != null)
                {
                    ecp.Expand();
                    // Wait a bit in case there is an open animation
                    Thread.Sleep(50);
                }
            }
        }

        public void Collapse()
        {
            if (!Properties.IsEnabled || ExpandCollapseState != ExpandCollapseState.Expanded)
            {
                return;
            }
            if (FrameworkType == FrameworkType.WinForms)
            {
                // WinForms
                var openButton = FindFirstChild(cf => cf.ByControlType(ControlType.Button)).AsButton();
                if (IsEditable)
                {
                    // WinForms editable combo box only closes on click and not on invoke
                    openButton.Click();
                }
                else
                {
                    openButton.Invoke();
                }
            }
            else
            {
                // WPF
                var ecp = Patterns.ExpandCollapse.PatternOrDefault;
                ecp?.Collapse();
            }
            Wait.UntilResponsive(this);
        }

        /// <summary>
        /// Select an item by index.
        /// </summary>
        public ComboBoxItem Select(int index)
        {
            var foundItem = Items[index];
            foundItem.Select();
            return foundItem;
        }

        /// <summary>
        /// Select the first item which matches the given text.
        /// </summary>
        /// <param name="textToFind">The text to search for.</param>
        /// <returns>The first found item or null if no item matches.</returns>
        public ComboBoxItem Select(string textToFind)
        {
            var foundItem = Items.FirstOrDefault(item => item.Text.Equals(textToFind));
            foundItem?.Select();
            return foundItem;
        }

        private AutomationElement GetEditableElement()
        {
            return FindFirstChild(cf => cf.ByControlType(ControlType.Edit));
        }
    }
}
