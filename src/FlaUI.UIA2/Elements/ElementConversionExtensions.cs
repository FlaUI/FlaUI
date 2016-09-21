namespace FlaUI.UIA2.Elements
{
    public static class ElementConversionExtensions
    {
        public static Window AsWindow(this Element automationElement)
        {
            if (automationElement == null) { return null; }
            return new Window(automationElement.Automation, automationElement.NativeElement);
        }
    }
}
