namespace FlaUI.Core.Elements.Infrastructure
{
    public static class ElementConversionExtensions
    {
        public static Button AsButton(this Element element)
        {
            if (element == null) { return null; }
            return new Button(element.AutomationObject);
        }

        public static Window AsWindow(this Element element)
        {
            if (element == null) { return null; }
            return new Window(element.AutomationObject);
        }
    }
}
