using interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class Window : ElementBase
    {
        public string Title
        {
            get { return NativeElement.CurrentName; }
        }

        public Window(IUIAutomationElement nativeElement) : base(nativeElement) { }

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
