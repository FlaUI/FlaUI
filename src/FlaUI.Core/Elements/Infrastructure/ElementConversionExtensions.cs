namespace FlaUI.Core.Elements.Infrastructure
{
    public static class ElementConversionExtensions
    {
        public static Button AsButton(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Button(automationElement.AutomationObject);
        }

        public static CheckBox AsCheckBox(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new CheckBox(automationElement.AutomationObject);
        }

        public static Label AsLabel(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Label(automationElement.AutomationObject);
        }

        public static Menu AsMenu(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Menu(automationElement.AutomationObject);
        }

        public static MenuItem AsMenuItem(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new MenuItem(automationElement.AutomationObject);
        }

        public static ProgressBar AsProgressBar(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new ProgressBar(automationElement.AutomationObject);
        }

        public static RadioButton AsRadioButton(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new RadioButton(automationElement.AutomationObject);
        }

        public static Tab AsTab(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Tab(automationElement.AutomationObject);
        }

        public static TabItem AsTabItem(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new TabItem(automationElement.AutomationObject);
        }

        public static TextBox AsTextBox(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new TextBox(automationElement.AutomationObject);
        }

        public static TitleBar AsTitleBar(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new TitleBar(automationElement.AutomationObject);
        }

        public static Tree AsTree(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Tree(automationElement.AutomationObject);
        }

        public static TreeItem AsTreeItem(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new TreeItem(automationElement.AutomationObject);
        }

        public static Window AsWindow(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Window(automationElement.AutomationObject);
        }
    }
}
