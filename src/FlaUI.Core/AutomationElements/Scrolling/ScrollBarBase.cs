using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.Scrolling
{
    /// <summary>
    /// Base class for a scroll bar element.
    /// </summary>
    public abstract class ScrollBarBase : AutomationElement
    {
        protected ScrollBarBase(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// The <see cref="IRangeValuePattern"/> of this element.
        /// </summary>
        protected IRangeValuePattern RangeValuePattern => Patterns.RangeValue.Pattern;

        /// <summary>
        /// The <see cref="Button"/> used to scroll by a small decrement.
        /// </summary>
        protected Button SmallDecrementButton => FindButton(SmallDecrementText);

        /// <summary>
        /// The <see cref="Button"/> used to scroll by a small increment.
        /// </summary>
        protected Button SmallIncrementButton => FindButton(SmallIncrementText);

        /// <summary>
        /// The <see cref="Button"/> used to scroll by a large decrement.
        /// </summary>
        protected Button LargeDecrementButton => FindButton(LargeDecrementText);

        /// <summary>
        /// The <see cref="Button"/> used to scroll by a large increment.
        /// </summary>
        protected Button LargeIncrementButton => FindButton(LargeIncrementText);

        /// <summary>
        /// The <see cref="Thumb"/> used to scroll with dragging.
        /// </summary>
        protected Thumb Thumb => FindThumb();

        /// <summary>
        /// The current value of the scroll.
        /// </summary>
        public double Value => RangeValuePattern.Value.Value;

        /// <summary>
        /// The minimum value of the scroll.
        /// </summary>
        public double MinimumValue => RangeValuePattern.Minimum.Value;

        /// <summary>
        /// The maximum value of the scroll.
        /// </summary>
        public double MaximumValue => RangeValuePattern.Maximum.Value;

        /// <summary>
        /// The small change value of the scroll.
        /// </summary>
        public double SmallChange => RangeValuePattern.SmallChange.Value;

        /// <summary>
        /// The large change value of the scroll.
        /// </summary>
        public double LargeChange => RangeValuePattern.LargeChange.Value;

        /// <summary>
        /// Value which indicates if the scroll is read only.
        /// </summary>
        public bool IsReadOnly => RangeValuePattern.IsReadOnly.Value;

        /// <summary>
        /// The text used to find the small decrement button.
        /// </summary>
        protected abstract string SmallDecrementText { get; }

        /// <summary>
        /// The text used to find the small increment button.
        /// </summary>
        protected abstract string SmallIncrementText { get; }

        /// <summary>
        /// The text used to find the large decrement button.
        /// </summary>
        protected abstract string LargeDecrementText { get; }

        /// <summary>
        /// The text used to find the large increment button.
        /// </summary>
        protected abstract string LargeIncrementText { get; }

        private Button FindButton(string automationId)
        {
            var button = FindFirstChild(cf => cf.ByControlType(ControlType.Button).And(cf.ByAutomationId(automationId)));
            return button?.AsButton();
        }

        private Thumb FindThumb()
        {
            var thumb = FindFirstChild(cf => cf.ByControlType(ControlType.Thumb));
            return thumb?.AsThumb();
        }
    }
}
