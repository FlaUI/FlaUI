using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    public class ProgressBar : AutomationElement
    {
        public ProgressBar(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
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
