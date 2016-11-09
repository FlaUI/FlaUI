using System;

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
                    case FrameworkType.Win32:
                        switch (AutomationType)
                        {
                            case AutomationType.UIA2:
                                return "SmallDecrement";
                            case AutomationType.UIA3:
                                return "UpButton";
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
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
                    case FrameworkType.Win32:
                        switch (AutomationType)
                        {
                            case AutomationType.UIA2:
                                return "SmallIncrement";
                            case AutomationType.UIA3:
                                return "DownButton";
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
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
                    case FrameworkType.Win32:
                        switch (AutomationType)
                        {
                            case AutomationType.UIA2:
                                return "LargeDecrement";
                            case AutomationType.UIA3:
                                return "DownPageButton";
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
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
                    case FrameworkType.Win32:
                        switch (AutomationType)
                        {
                            case AutomationType.UIA2:
                                return "LargeIncrement";
                            case AutomationType.UIA3:
                                return "UpPageButton";
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
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
