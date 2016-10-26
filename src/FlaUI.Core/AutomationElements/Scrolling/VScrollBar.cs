namespace FlaUI.Core.AutomationElements.Scrolling
{
    public class VScrollBar : ScrollBarBase
    {
        public VScrollBar(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        protected override string SmallDecrementText
        {
            get
            {
                switch (FrameworkType)
                {
                    case FrameworkType.Wpf:
                        return "PART_LineUpButton";
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
                        return "PART_LineDownButton";
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
                        return "PageUp";
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
                        return "PageDown";
                    case FrameworkType.WinForms:
                        return "UpPageButton";
                    default:
                        return "LargeIncrement";
                }
            }
        }

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
