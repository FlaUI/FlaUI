using FlaUI.UIA3.Conditions;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Exceptions;
using FlaUI.UIA3.Patterns;
using System.Linq;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    public class Window : AutomationElement
    {
        public Window(Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public string Title
        {
            get { return Current.Name; }
        }

        public bool IsModal
        {
            get { return WindowPattern.Current.IsModal; }
        }

        public TitleBar TitleBar
        {
            get
            {
                var titleBarElement = FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TitleBar));
                return titleBarElement.AsTitleBar();
            }
        }

        public WindowPattern WindowPattern
        {
            get { return PatternFactory.GetWindowPattern(); }
        }

        public TransformPattern TransformPattern
        {
            get { return PatternFactory.GetTransformPattern(); }
        }

        public void Close()
        {
            TitleBar titleBar = TitleBar;
            if (titleBar != null && titleBar.CloseButton != null)
            {
                titleBar.CloseButton.Invoke();
                return;
            }
            var windowPattern = WindowPattern;
            if (windowPattern != null)
            {
                windowPattern.Close();
                return;
            }
            throw new MethodNotSupportedException("Close is not supported");
        }

        public void Move(int x, int y)
        {
            var transformPattern = TransformPattern;
            if (transformPattern != null)
            {
                transformPattern.Move(x, y);
            }
        }

        public Window[] GetModalWindows()
        {
            return FindAll(TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window).
                And(new PropertyCondition(WindowPattern.IsModalProperty, true))).
                Select(e => AutomationElementConversionExtensions.AsWindow(e)).ToArray();
        }
    }
}
