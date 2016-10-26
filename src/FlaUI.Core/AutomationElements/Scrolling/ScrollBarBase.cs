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

        protected IRangeValuePattern RangeValuePattern => PatternFactory.GetRangeValuePattern();

        protected Button SmallDecrementButton => FindButton(SmallDecrementText);

        protected Button SmallIncrementButton => FindButton(SmallIncrementText);

        protected Button LargeDecrementButton => FindButton(LargeDecrementText);

        protected Button LargeIncrementButton => FindButton(LargeIncrementText);

        protected Thumb Thumb => FindThumb();

        public double Value => RangeValuePattern.Current.Value;

        public double MinimumValue => RangeValuePattern.Current.Minimum;

        public double MaximumValue => RangeValuePattern.Current.Maximum;

        public double SmallChange => RangeValuePattern.Current.SmallChange;

        public double LargeChange => RangeValuePattern.Current.LargeChange;

        public bool IsReadOnly => RangeValuePattern.Current.IsReadOnly;

        protected abstract string SmallDecrementText { get; }

        protected abstract string SmallIncrementText { get; }

        protected abstract string LargeDecrementText { get; }

        protected abstract string LargeIncrementText { get; }

        private Button FindButton(string automationId)
        {
            var button = FindFirstChild(ConditionFactory.ByControlType(ControlType.Button).And(ConditionFactory.ByAutomationId(automationId)));
            return button.AsButton();
        }

        private Thumb FindThumb()
        {
            var thumb = FindFirstChild(ConditionFactory.ByControlType(ControlType.Thumb));
            return thumb.AsThumb();
        }
    }
}
