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

        public static RadioButton AsRadioButton(this Element element)
        {
            if (element == null) { return null; }
            return new RadioButton(element.AutomationObject);
        }

        public static TextBox AsTextBox(this Element element)
        {
            if (element == null) { return null; }
            return new TextBox(element.AutomationObject);
        }

        public static Window AsWindow(this Element element)
        {
            if (element == null) { return null; }
            return new Window(element.AutomationObject);
        }
    }
}
