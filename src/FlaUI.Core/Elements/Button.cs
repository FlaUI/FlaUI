using interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class Button : ElementBase
    {
        public Button(Automation automation, IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

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
