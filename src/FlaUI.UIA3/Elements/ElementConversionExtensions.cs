using FlaUI.UIA3.Definitions;

namespace FlaUI.UIA3.Elements
{
    /// <summary>
    /// Class with extension methods to convert the element to a specific class
    /// </summary>
    public static class ElementConversionExtensions
    {
        public static Button AsButton(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new Button(automationElement.Automation, automationElement.NativeElement);
        }

        public static CheckBox AsCheckBox(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new CheckBox(automationElement.Automation, automationElement.NativeElement);
        }

        public static TextBox AsTextBox(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new TextBox(automationElement.Automation, automationElement.NativeElement);
        }

        public static RadioButton AsRadioButton(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new RadioButton(automationElement.Automation, automationElement.NativeElement);
        }

        public static Window AsWindow(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new Window(automationElement.Automation, automationElement.NativeElement);
        }

        public static Label AsLabel(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new Label(automationElement.Automation, automationElement.NativeElement);
        }

        public static TitleBar AsTitleBar(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new TitleBar(automationElement.Automation, automationElement.NativeElement);
        }

        public static Menu AsMenu(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new Menu(automationElement.Automation, automationElement.NativeElement);
        }

        public static MenuItem AsMenuItem(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new MenuItem(automationElement.Automation, automationElement.NativeElement);
        }

        public static Tab AsTab(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new Tab(automationElement.Automation, automationElement.NativeElement);
        }

        public static TabItem AsTabItem(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new TabItem(automationElement.Automation, automationElement.NativeElement);
        }

        public static Tree AsTree(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new Tree(automationElement.Automation, automationElement.NativeElement);
        }

        public static TreeItem AsTreeItem(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new TreeItem(automationElement.Automation, automationElement.NativeElement);
        }

        public static ProgressBar AsProgressBar(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new ProgressBar(automationElement.Automation, automationElement.NativeElement);
        }

        public static Slider AsSlider(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            if (automationElement.Current.FrameworkId == FrameworkIds.Wpf)
            {
                return new WpfSlider(automationElement.Automation, automationElement.NativeElement);
            }
            if (automationElement.Current.FrameworkId == FrameworkIds.WinForms)
            {
                return new WinFormsSlider(automationElement.Automation, automationElement.NativeElement);
            }
            return new Slider(automationElement.Automation, automationElement.NativeElement);
        }

        public static Thumb AsThumb(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new Thumb(automationElement.Automation, automationElement.NativeElement);
        }
    }
}
