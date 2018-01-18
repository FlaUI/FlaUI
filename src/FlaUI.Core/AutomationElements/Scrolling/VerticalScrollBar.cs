using System;

namespace FlaUI.Core.AutomationElements.Scrolling
{
    /// <summary>
    /// A vertical scrollbar element.
    /// </summary>
    public class VerticalScrollBar : ScrollBarBase
    {
        public VerticalScrollBar(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
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
                        return "PART_LineUpButton";
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
                        return "PART_LineDownButton";
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
                        return "PageUp";
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
                        return "PageDown";
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
        /// Scrolls up by a small amount.
        /// </summary>
        public void ScrollUp()
        {
            SmallDecrementButton.Invoke();
        }

        /// <summary>
        /// Scrolls down by a small amount.
        /// </summary>
        public void ScrollDown()
        {
            SmallIncrementButton.Invoke();
        }

        /// <summary>
        /// Scrolls up by a large amount.
        /// </summary>
        public void ScrollUpLarge()
        {
            LargeDecrementButton.Invoke();
        }

        /// <summary>
        /// Scrolls down by a large amount.
        /// </summary>
        public void ScrollDownLarge()
        {
            LargeIncrementButton.Invoke();
        }
    }
}
