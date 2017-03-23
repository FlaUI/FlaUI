using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.Scrolling
{
    public abstract class ScrollBarBase : AutomationElement
    {
        protected ScrollBarBase(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        protected IRangeValuePattern RangeValuePattern => Patterns.RangeValue.Pattern;

        protected Button SmallDecrementButton => FindButton(SmallDecrementText);

        protected Button SmallIncrementButton => FindButton(SmallIncrementText);

        protected Button LargeDecrementButton => FindButton(LargeDecrementText);

        protected Button LargeIncrementButton => FindButton(LargeIncrementText);

        protected Thumb Thumb => FindThumb();

        public double Value => RangeValuePattern.Value.Value;

        public double MinimumValue => RangeValuePattern.Minimum.Value;

        public double MaximumValue => RangeValuePattern.Maximum.Value;

        public double SmallChange => RangeValuePattern.SmallChange.Value;

        public double LargeChange => RangeValuePattern.LargeChange.Value;

        public bool IsReadOnly => RangeValuePattern.IsReadOnly.Value;

        protected abstract string SmallDecrementText { get; }

        protected abstract string SmallIncrementText { get; }

        protected abstract string LargeDecrementText { get; }

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
