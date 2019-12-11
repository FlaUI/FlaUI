using System;
using FlaUI.Core.AutomationElements.Scrolling;

namespace FlaUI.Core.AutomationElements
{
    public static partial class AutomationElementExtensions
    {
        /// <summary>
        /// Converts the element to a <see cref="Button"/>.
        /// </summary>
        public static Button AsButton(this AutomationElement self)
        {
            return self == null ? null : new Button(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="CheckBox"/>.
        /// </summary>
        public static CheckBox AsCheckBox(this AutomationElement self)
        {
            return self == null ? null : new CheckBox(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ComboBox"/>.
        /// </summary>
        public static ComboBox AsComboBox(this AutomationElement self)
        {
            return self == null ? null : new ComboBox(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="DataGridView"/>.
        /// </summary>
        public static DataGridView AsDataGridView(this AutomationElement self)
        {
            return self == null ? null : new DataGridView(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Label"/>.
        /// </summary>
        public static Label AsLabel(this AutomationElement self)
        {
            return self == null ? null : new Label(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Grid"/>.
        /// </summary>
        public static Grid AsGrid(this AutomationElement self)
        {
            return self == null ? null : new Grid(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridRow"/>.
        /// </summary>
        public static GridRow AsGridRow(this AutomationElement self)
        {
            return self == null ? null : new GridRow(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridCell"/>.
        /// </summary>
        public static GridCell AsGridCell(this AutomationElement self)
        {
            return self == null ? null : new GridCell(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridHeader"/>.
        /// </summary>
        public static GridHeader AsGridHeader(this AutomationElement self)
        {
            return self == null ? null : new GridHeader(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridHeaderItem"/>.
        /// </summary>
        public static GridHeaderItem AsGridHeaderItem(this AutomationElement self)
        {
            return self == null ? null : new GridHeaderItem(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="HorizontalScrollBar"/>.
        /// </summary>
        public static HorizontalScrollBar AsHorizontalScrollBar(this AutomationElement self)
        {
            return self == null ? null : new HorizontalScrollBar(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ListBox"/>.
        /// </summary>
        public static ListBox AsListBox(this AutomationElement self)
        {
            return self == null ? null : new ListBox(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ListBoxItem"/>.
        /// </summary>
        public static ListBoxItem AsListBoxItem(this AutomationElement self)
        {
            return self == null ? null : new ListBoxItem(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Menu"/>.
        /// </summary>
        public static Menu AsMenu(this AutomationElement self)
        {
            return self == null ? null : new Menu(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="MenuItem"/>.
        /// </summary>
        public static MenuItem AsMenuItem(this AutomationElement self)
        {
            return self == null ? null : new MenuItem(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ProgressBar"/>.
        /// </summary>
        public static ProgressBar AsProgressBar(this AutomationElement self)
        {
            return self == null ? null : new ProgressBar(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="RadioButton"/>.
        /// </summary>
        public static RadioButton AsRadioButton(this AutomationElement self)
        {
            return self == null ? null : new RadioButton(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Slider"/>.
        /// </summary>
        public static Slider AsSlider(this AutomationElement self)
        {
            return self == null ? null : new Slider(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Tab"/>.
        /// </summary>
        public static Tab AsTab(this AutomationElement self)
        {
            return self == null ? null : new Tab(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TabItem"/>.
        /// </summary>
        public static TabItem AsTabItem(this AutomationElement self)
        {
            return self == null ? null : new TabItem(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TextBox"/>.
        /// </summary>
        public static TextBox AsTextBox(this AutomationElement self)
        {
            return self == null ? null : new TextBox(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Thumb"/>.
        /// </summary>
        public static Thumb AsThumb(this AutomationElement self)
        {
            return self == null ? null : new Thumb(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TitleBar"/>.
        /// </summary>
        public static TitleBar AsTitleBar(this AutomationElement self)
        {
            return self == null ? null : new TitleBar(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ToggleButton"/>.
        /// </summary>
        public static ToggleButton AsToggleButton(this AutomationElement self)
        {
            return self == null ? null : new ToggleButton(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Tree"/>.
        /// </summary>
        public static Tree AsTree(this AutomationElement self)
        {
            return self == null ? null : new Tree(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TreeItem"/>.
        /// </summary>
        public static TreeItem AsTreeItem(this AutomationElement self)
        {
            return self == null ? null : new TreeItem(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="VerticalScrollBar"/>.
        /// </summary>
        public static VerticalScrollBar AsVerticalScrollBar(this AutomationElement self)
        {
            return self == null ? null : new VerticalScrollBar(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Window"/>.
        /// </summary>
        public static Window AsWindow(this AutomationElement self)
        {
            return self == null ? null : new Window(self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Method to convert the element to the given type.
        /// </summary>
        public static AutomationElement AsType(this AutomationElement self, Type type)
        {
            if (!type.IsAssignableFrom(typeof(AutomationElement)))
            {
                throw new ArgumentException("The given type is not an AutomationElement", nameof(type));
            }
            return self == null ? null : (AutomationElement)Activator.CreateInstance(type, self.FrameworkAutomationElement);
        }

        /// <summary>
        /// Generic method to convert the element to the given type.
        /// </summary>
        public static T As<T>(this AutomationElement self) where T : AutomationElement
        {
            var type = typeof(T);
            return self == null ? null : (T)Activator.CreateInstance(typeof(T), self.FrameworkAutomationElement);
        }
    }
}
