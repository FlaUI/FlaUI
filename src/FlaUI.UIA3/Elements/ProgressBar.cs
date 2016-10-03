using FlaUI.UIA3.Patterns;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    public class ProgressBar : AutomationElement
    {
        public ProgressBar(UIA3Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation, nativeElement)
        {
        }

        public RangeValuePattern RangeValuePattern
        {
            get { return PatternFactory.GetRangeValuePattern(); }
        }

        public double Minimum
        {
            get { return RangeValuePattern.Current.Minimum; }
        }

        public double Maximum
        {
            get { return RangeValuePattern.Current.Maximum; }
        }

        public double Value
        {
            get { return RangeValuePattern.Current.Value; }
        }
    }
}
