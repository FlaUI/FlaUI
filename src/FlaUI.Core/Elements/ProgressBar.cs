using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.Elements
{
    public class ProgressBar : Element
    {
        public ProgressBar(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public IRangeValuePattern RangeValuePattern
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
