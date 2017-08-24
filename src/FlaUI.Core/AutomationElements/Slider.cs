using System;
using System.Globalization;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Patterns;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.AutomationElements
{
    public class Slider : AutomationElement
    {
        public Slider(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        private IRangeValuePattern RangeValuePattern => Patterns.RangeValue.PatternOrDefault;

        private IValuePattern ValuePattern => Patterns.Value.PatternOrDefault;

        private Button LargeIncreaseButton => GetLargeIncreaseButton();

        private Button LargeDecreaseButton => GetLargeDecreaseButton();

        public Thumb Thumb => FindFirstChild(cf => cf.ByControlType(ControlType.Thumb))?.AsThumb();

        public bool IsOnlyValue => !IsPatternSupported(Automation.PatternLibrary.RangeValuePattern);

        public double Value
        {
            get
            {
                var rangeValuePattern = RangeValuePattern;
                if (rangeValuePattern != null)
                {
                    return RangeValuePattern.Value.Value;
                }
                // UIA3 for WinForms does not have the RangeValue pattern, only the value pattern
                // The value in this case is always between 0 and 100
                return Convert.ToDouble(ValuePattern.Value.Value);
            }
            set
            {
                var rangeValuePattern = RangeValuePattern;
                if (rangeValuePattern != null)
                {
                    RangeValuePattern.SetValue(value);
                }
                else
                {
                    // UIA3 for WinForms does not have the RangeValue pattern, only the value pattern
                    // The value in this case is always between 0 and 100
                    ValuePattern.SetValue(value.ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        public void SmallIncrement()
        {
            Keyboard.Press(VirtualKeyShort.RIGHT);
            Wait.UntilInputIsProcessed();
        }

        public void SmallDecrement()
        {
            Keyboard.Press(VirtualKeyShort.LEFT);
            Wait.UntilInputIsProcessed();
        }

        public void LargeIncrement()
        {
            LargeIncreaseButton.Invoke();
        }

        public void LargeDecrement()
        {
            LargeDecreaseButton.Invoke();
        }

        private Button GetLargeIncreaseButton()
        {
            if (FrameworkType == FrameworkType.Wpf)
            {
                // For WPF, this is simple
                return FindFirstChild(cf => cf.ByAutomationId("IncreaseLarge")).AsButton();
            }
            // For WinForms, we loop thru the buttons and find the one right of the thumb
            var buttons = FindAllChildren(cf => cf.ByControlType(ControlType.Button));
            foreach (var button in buttons)
            {
                if (button.Properties.BoundingRectangle.Value.Left > Thumb.Properties.BoundingRectangle.Value.Left)
                {
                    return button.AsButton();
                }
            }
            return null;
        }

        private Button GetLargeDecreaseButton()
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
                if (button.Properties.BoundingRectangle.Value.Right < Thumb.Properties.BoundingRectangle.Value.Right)
                {
                    return button.AsButton();
                }
            }
            return null;
        }
    }
}
