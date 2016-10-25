namespace FlaUI.Core.AutomationElements.Scrolling
{
    public class VScrollBar : ScrollBarBase
    {
        public VScrollBar(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        protected override string SmallDecrementText => FrameworkType == FrameworkType.Wpf ? "PART_LineUpButton" : "SmallDecrement";

        protected override string SmallIncrementText => FrameworkType == FrameworkType.Wpf ? "PART_LineDownButton" : "SmallIncrement";

        protected override string LargeDecrementText => FrameworkType == FrameworkType.Wpf ? "PageUp" : "LargeDecrement";

        protected override string LargeIncrementText => FrameworkType == FrameworkType.Wpf ? "PageDown" : "LargeIncrement";

        public void ScrollUp()
        {
            SmallDecrementButton.Invoke();
        }

        public void ScrollDown()
        {
            SmallIncrementButton.Invoke();
        }

        public void ScrollUpLarge()
        {
            LargeDecrementButton.Invoke();
        }

        public void ScrollDownLarge()
        {
            LargeIncrementButton.Invoke();
        }
    }
}
