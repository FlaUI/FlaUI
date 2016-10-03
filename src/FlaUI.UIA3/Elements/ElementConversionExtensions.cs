using FlaUI.Core;

namespace FlaUI.UIA3.Elements
{
    /// <summary>
    /// Class with extension methods to convert the automationElement to a specific class
    /// </summary>
    public static class ElementConversionExtensions
    {
        public static Button AsButton(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new Button(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static CheckBox AsCheckBox(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new CheckBox(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static TextBox AsTextBox(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new TextBox(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static RadioButton AsRadioButton(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new RadioButton(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static Window AsWindow(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new Window(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static Label AsLabel(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new Label(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static TitleBar AsTitleBar(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new TitleBar(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static Menu AsMenu(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new Menu(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static MenuItem AsMenuItem(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new MenuItem(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static Tab AsTab(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new Tab(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static TabItem AsTabItem(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new TabItem(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static Tree AsTree(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new Tree(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static TreeItem AsTreeItem(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new TreeItem(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static ProgressBar AsProgressBar(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new ProgressBar(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static Slider AsSlider(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            if (automationAutomationElement.FrameworkType == FrameworkType.Wpf)
            {
                return new WpfSlider(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
            }
            if (automationAutomationElement.FrameworkType == FrameworkType.WinForms)
            {
                return new WinFormsSlider(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
            }
            return new Slider(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }

        public static Thumb AsThumb(this AutomationElement automationAutomationElement)
        {
            if (automationAutomationElement == null) { return null; }
            return new Thumb(automationAutomationElement.Automation, automationAutomationElement.NativeElement);
        }
    }
}
