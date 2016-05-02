using interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class Window : AutomationElement
    {
        public string Title
        {
            get { return Current.Name; }
        }

        public Window(Automation automation, IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public void Move(int x, int y)
        {
            var transformPattern = PatternFactory.GetTransformPattern();
            if (transformPattern != null)
            {
                transformPattern.Move(x, y);
            }
        }
    }
}
