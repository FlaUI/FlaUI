namespace FlaUI.Core.Elements.Infrastructure
{
    public static class ElementConversionExtensions
    {
        public static Button AsButton(this Element element)
        {
            if (element == null) { return null; }
            return new Button(element.AutomationObject);
        }

        public static CheckBox AsCheckBox(this Element element)
        {
            if (element == null) { return null; }
            return new CheckBox(element.AutomationObject);
        }

        public static Label AsLabel(this Element element)
        {
            if (element == null) { return null; }
            return new Label(element.AutomationObject);
        }

        public static Menu AsMenu(this Element element)
        {
            if (element == null) { return null; }
            return new Menu(element.AutomationObject);
        }

        public static MenuItem AsMenuItem(this Element element)
        {
            if (element == null) { return null; }
            return new MenuItem(element.AutomationObject);
        }

        public static RadioButton AsRadioButton(this Element element)
        {
            if (element == null) { return null; }
            return new RadioButton(element.AutomationObject);
        }

        public static Tab AsTab(this Element element)
        {
            if (element == null) { return null; }
            return new Tab(element.AutomationObject);
        }

        public static TabItem AsTabItem(this Element element)
        {
            if (element == null) { return null; }
            return new TabItem(element.AutomationObject);
        }

        public static TextBox AsTextBox(this Element element)
        {
            if (element == null) { return null; }
            return new TextBox(element.AutomationObject);
        }

        public static TitleBar AsTitleBar(this Element element)
        {
            if (element == null) { return null; }
            return new TitleBar(element.AutomationObject);
        }

        public static Tree AsTree(this Element element)
        {
            if (element == null) { return null; }
            return new Tree(element.AutomationObject);
        }

        public static TreeItem AsTreeItem(this Element element)
        {
            if (element == null) { return null; }
            return new TreeItem(element.AutomationObject);
        }

        public static Window AsWindow(this Element element)
        {
            if (element == null) { return null; }
            return new Window(element.AutomationObject);
        }
    }
}
