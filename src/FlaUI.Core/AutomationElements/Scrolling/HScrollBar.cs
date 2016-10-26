namespace FlaUI.Core.AutomationElements.Scrolling
{
    public class HScrollBar : ScrollBarBase
    {
        public HScrollBar(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        protected override string SmallDecrementText
        {
            get
            {
                switch (FrameworkType)
                {
                    case FrameworkType.Wpf:
                        return "PART_LineLeftButton";
                    case FrameworkType.WinForms:
                        return "UpButton";
                    default:
                        return "SmallDecrement";
                }
            }
        }

        protected override string SmallIncrementText
        {
            get
            {
                switch (FrameworkType)
                {
                    case FrameworkType.Wpf:
                        return "PART_LineRightButton";
                    case FrameworkType.WinForms:
                        return "DownButton";
                    default:
                        return "SmallIncrement";
                }
            }
        }

        protected override string LargeDecrementText
        {
            get
            {
                switch (FrameworkType)
                {
                    case FrameworkType.Wpf:
                        return "PageLeft";
                    case FrameworkType.WinForms:
                        return "DownPageButton";
                    default:
                        return "LargeDecrement";
                }
            }
        }

        protected override string LargeIncrementText
        {
            get
            {
                switch (FrameworkType)
                {
                    case FrameworkType.Wpf:
                        return "PageRight";
                    case FrameworkType.WinForms:
                        return "UpPageButton";
                    default:
                        return "LargeIncrement";
                }
            }
        }

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
