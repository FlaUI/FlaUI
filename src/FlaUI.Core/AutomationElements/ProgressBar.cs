using FlaUI.Core.AutomationElements;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a progressbar element.
    /// </summary>
    public class ProgressBar : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="ProgressBar"/> element.
        /// </summary>
        public ProgressBar(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Pattern object for the <see cref="IRangeValuePattern"/>.
        /// </summary>
        public IRangeValuePattern RangeValuePattern => Patterns.RangeValue.Pattern;

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        public double Minimum => RangeValuePattern.Minimum.Value;

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        public double Maximum => RangeValuePattern.Maximum.Value;

        /// <summary>
        /// Gets the current value.
        /// </summary>
        public double Value => RangeValuePattern.Value.Value;
    }
}
