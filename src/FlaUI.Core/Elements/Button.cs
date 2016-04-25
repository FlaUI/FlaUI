using interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class Button : ElementBase
    {
        public Button(IUIAutomationElement nativeElement) : base(nativeElement) { }

        public void Invoke()
        {
            var invokePattern = PatternFactory.GetInvokePattern();
            if (invokePattern != null)
            {
               invokePattern.Invoke();
            }
        }
    }
}
