namespace FlaUI.Core.AutomationElements.Scrolling
{
    public class HScrollBar : ScrollBarBase
    {
        public HScrollBar(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        protected override string SmallDecrementText => FrameworkType == FrameworkType.Wpf ? "PART_LineLeftButton" : "SmallDecrement";

        protected override string SmallIncrementText => FrameworkType == FrameworkType.Wpf ? "PART_LineRightButton" : "SmallIncrement";

        protected override string LargeDecrementText => FrameworkType == FrameworkType.Wpf ? "PageLeft" : "LargeDecrement";

        protected override string LargeIncrementText => FrameworkType == FrameworkType.Wpf ? "PageRight" : "LargeIncrement";

        public virtual void ScrollLeft()
        {
            SmallDecrementButton.Click();
        }

        public virtual void ScrollRight()
        {
            SmallIncrementButton.Click();
        }

        public virtual void ScrollLeftLarge()
        {
            LargeDecrementButton.Click();
        }

        public virtual void ScrollRightLarge()
        {
            LargeIncrementButton.Click();
        }
    }
}
