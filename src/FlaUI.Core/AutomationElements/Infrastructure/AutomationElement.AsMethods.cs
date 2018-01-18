using System;
using FlaUI.Core.AutomationElements.Scrolling;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public partial class AutomationElement
    {
        /// <summary>
        /// Converts the element to a <see cref="Button"/>.
        /// </summary>
        public Button AsButton()
        {
            return new Button(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="CheckBox"/>.
        /// </summary>
        public CheckBox AsCheckBox()
        {
            return new CheckBox(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ComboBox"/>.
        /// </summary>
        public ComboBox AsComboBox()
        {
            return new ComboBox(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="DataGridView"/>.
        /// </summary>
        public DataGridView AsDataGridView()
        {
            return new DataGridView(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Label"/>.
        /// </summary>
        public Label AsLabel()
        {
            return new Label(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Grid"/>.
        /// </summary>
        public Grid AsGrid()
        {
            return new Grid(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridRow"/>.
        /// </summary>
        public GridRow AsGridRow()
        {
            return new GridRow(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridCell"/>.
        /// </summary>
        public GridCell AsGridCell()
        {
            return new GridCell(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridHeader"/>.
        /// </summary>
        public GridHeader AsGridHeader()
        {
            return new GridHeader(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridHeaderItem"/>.
        /// </summary>
        public GridHeaderItem AsGridHeaderItem()
        {
            return new GridHeaderItem(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="HorizontalScrollBar"/>.
        /// </summary>
        public HorizontalScrollBar AsHorizontalScrollBar()
        {
            return new HorizontalScrollBar(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ListBox"/>.
        /// </summary>
        public ListBox AsListBox()
        {
            return new ListBox(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ListBoxItem"/>.
        /// </summary>
        public ListBoxItem AsListBoxItem()
        {
            return new ListBoxItem(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Menu"/>.
        /// </summary>
        public Menu AsMenu()
        {
            return new Menu(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="MenuItem"/>.
        /// </summary>
        public MenuItem AsMenuItem()
        {
            return new MenuItem(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ProgressBar"/>.
        /// </summary>
        public ProgressBar AsProgressBar()
        {
            return new ProgressBar(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="RadioButton"/>.
        /// </summary>
        public RadioButton AsRadioButton()
        {
            return new RadioButton(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Slider"/>.
        /// </summary>
        public Slider AsSlider()
        {
            return new Slider(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Tab"/>.
        /// </summary>
        public Tab AsTab()
        {
            return new Tab(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TabItem"/>.
        /// </summary>
        public TabItem AsTabItem()
        {
            return new TabItem(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TextBox"/>.
        /// </summary>
        public TextBox AsTextBox()
        {
            return new TextBox(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Thumb"/>.
        /// </summary>
        public Thumb AsThumb()
        {
            return new Thumb(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TitleBar"/>.
        /// </summary>
        public TitleBar AsTitleBar()
        {
            return new TitleBar(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ToggleButton"/>.
        /// </summary>
        public ToggleButton AsToggleButton()
        {
            return new ToggleButton(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Tree"/>.
        /// </summary>
        public Tree AsTree()
        {
            return new Tree(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TreeItem"/>.
        /// </summary>
        public TreeItem AsTreeItem()
        {
            return new TreeItem(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="VerticalScrollBar"/>.
        /// </summary>
        public VerticalScrollBar AsVerticalScrollBar()
        {
            return new VerticalScrollBar(FrameworkAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Window"/>.
        /// </summary>
        public Window AsWindow()
        {
            return new Window(FrameworkAutomationElement);
        }
    }
}
