using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class ProgressBar : Element
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
