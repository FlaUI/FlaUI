using System;

namespace FlaUI.Core.AutomationElements.Scrolling
{
    /// <summary>
    /// A horizontal scrollbar element.
    /// </summary>
    public class HorizontalScrollBar : ScrollBarBase
    {
        /// <summary>
        /// Creates a horizontal scroll bar element from the given element.
        /// </summary>
        public HorizontalScrollBar(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <inheritdoc />
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
                                throw new NotImplementedException();
                        }
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <inheritdoc />
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
                                throw new NotImplementedException();
                        }
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <inheritdoc />
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
                                throw new NotImplementedException();
                        }
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <inheritdoc />
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
                                throw new NotImplementedException();
                        }
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Scrolls left by a small amount.
        /// </summary>
        public virtual void ScrollLeft()
        {
            SmallDecrementButton?.Click();
        }

        /// <summary>
        /// Scrolls right by a small amount.
        /// </summary>
        public virtual void ScrollRight()
        {
            SmallIncrementButton?.Click();
        }

        /// <summary>
        /// Scrolls left by a large amount.
        /// </summary>
        public virtual void ScrollLeftLarge()
        {
            LargeDecrementButton?.Click();
        }

        /// <summary>
        /// Scrolls right by a large amount.
        /// </summary>
        public virtual void ScrollRightLarge()
        {
            LargeIncrementButton?.Click();
        }
    }
}
