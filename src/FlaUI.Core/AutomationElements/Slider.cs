using System;
using System.Globalization;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Patterns;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a slider element.
    /// </summary>
    public class Slider : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="Slider"/> element.
        /// </summary>
        public Slider(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        private IRangeValuePattern? RangeValuePattern => Patterns.RangeValue.PatternOrDefault;

        private IValuePattern? ValuePattern => Patterns.Value.PatternOrDefault;

        /// <summary>
        /// The minimum value.
        /// </summary>
        public double Minimum => IsOnlyValue ? 0 : Patterns.RangeValue.Pattern.Minimum.Value;

        /// <summary>
        /// The maximum value.
        /// </summary>
        public double Maximum => IsOnlyValue ? 100 : Patterns.RangeValue.Pattern.Maximum.Value;

        /// <summary>
        /// The value of a small change.
        /// </summary>
        public double SmallChange => IsOnlyValue ? 1 : Patterns.RangeValue.Pattern.SmallChange.Value;

        /// <summary>
        /// The value of a large change.
        /// </summary>
        public double LargeChange => IsOnlyValue ? 10 : Patterns.RangeValue.Pattern.LargeChange.Value;

        /// <summary>
        /// The button element used to perform a large increment.
        /// </summary>
        public Button? LargeIncreaseButton => GetLargeIncreaseButton();

        /// <summary>
        /// The button element used to perform a large decrement.
        /// </summary>
        public Button? LargeDecreaseButton => GetLargeDecreaseButton();

        /// <summary>
        /// The element used to drag.
        /// </summary>
        public Thumb? Thumb => FindFirstChild(cf => cf.ByControlType(ControlType.Thumb))?.AsThumb();

        /// <summary>
        /// Flag which indicates if the <see cref="Slider"/> supports range values (min->max) or only values (0-100).
        /// Only values are for example used when combining UIA3 and WinForms applications.
        /// </summary>
        public bool IsOnlyValue => !IsPatternSupported(Automation.PatternLibrary.RangeValuePattern);

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        public double Value
        {
            get => IsOnlyValue ? Convert.ToDouble(ValuePattern.Value.Value) : RangeValuePattern.Value.Value;
            set
            {
                if (IsOnlyValue)
                {
                    ValuePattern.SetValue(value.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    RangeValuePattern.SetValue(value);
                }
            }
        }

        /// <summary>
        /// Performs a small increment.
        /// </summary>
        public void SmallIncrement()
        {
            Keyboard.Press(VirtualKeyShort.RIGHT);
            Wait.UntilInputIsProcessed();
        }

        /// <summary>
        /// Performs a small decrement.
        /// </summary>
        public void SmallDecrement()
        {
            Keyboard.Press(VirtualKeyShort.LEFT);
            Wait.UntilInputIsProcessed();
        }

        /// <summary>
        /// Performs a large increment.
        /// </summary>
        public void LargeIncrement()
        {
            LargeIncreaseButton?.Invoke();
        }

        /// <summary>
        /// Performs a large decrement.
        /// </summary>
        public void LargeDecrement()
        {
            LargeDecreaseButton?.Invoke();
        }

        private Button? GetLargeIncreaseButton()
        {
            if (FrameworkType == FrameworkType.Wpf)
            {
                // For WPF, this is simple
                return FindFirstChild(cf => cf.ByAutomationId("IncreaseLarge")).AsButton();
            }
            // For WinForms, we loop thru the buttons and find the one on the right of the thumb
            var buttons = FindAllChildren(cf => cf.ByControlType(ControlType.Button));
            foreach (var button in buttons)
            {
                if (button.Properties.BoundingRectangle.Value.Left > Thumb?.Properties.BoundingRectangle.Value.Left)
                {
                    return button.AsButton();
                }
            }
            return null;
        }

        private Button? GetLargeDecreaseButton()
        {
            if (FrameworkType == FrameworkType.Wpf)
            {
                // For WPF, this is simple
                return FindFirstChild(cf => cf.ByAutomationId("DecreaseLarge")).AsButton();
            }
            // For WinForms, we loop thru the buttons and find the one left of the thumb
            var buttons = FindAllChildren(cf => cf.ByControlType(ControlType.Button));
            foreach (var button in buttons)
            {
                if (button.Properties.BoundingRectangle.Value.Right < Thumb?.Properties.BoundingRectangle.Value.Right)
                {
                    return button.AsButton();
                }
            }
            return null;
        }
    }
}
