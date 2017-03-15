﻿using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;
using FlaUI.Core.WindowsAPI;
using System;
using System.Globalization;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class Slider : AutomationElement
    {
        public Slider(Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public Thumb Thumb
        {
            get { return FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Thumb)).AsThumb(); }
        }

        public virtual double Value { get; set; }

        public void SmallIncrement()
        {
            Automation.Keyboard.PressVirtualKeyCode(VirtualKeyShort.RIGHT);
        }

        public void SmallDecrement()
        {
            Automation.Keyboard.PressVirtualKeyCode(VirtualKeyShort.LEFT);
        }

        public virtual void LargeIncrement() { }

        public virtual void LargeDecrement() { }
    }

    public class WinFormsSlider : Slider
    {
        public WinFormsSlider(Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        private ValuePattern ValuePattern { get { return PatternFactory.GetValuePattern(); } }

        private Button LargeIncreaseButton
        {
            get
            {
                var buttons = FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Button));
                foreach (var button in buttons)
                {
                    if (button.Current.BoundingRectangle.Left > Thumb.Current.BoundingRectangle.Left)
                    {
                        return button.AsButton();
                    }
                }
                return null;
            }
        }

        private Button LargeDecreaseButton
        {
            get
            {
                var buttons = FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Button));
                foreach (var button in buttons)
                {
                    if (button.Current.BoundingRectangle.Right < Thumb.Current.BoundingRectangle.Right)
                    {
                        return button.AsButton();
                    }
                }
                return null;
            }
        }

        public override double Value
        {
            get { return Convert.ToDouble(ValuePattern.Current.Value); }
            set { ValuePattern.SetValue(value.ToString(CultureInfo.InvariantCulture)); }
        }

        public override void LargeIncrement()
        {
            LargeIncreaseButton.Click(false);
        }

        public override void LargeDecrement()
        {
            LargeDecreaseButton.Click(false);
        }
    }

    public class WpfSlider : Slider
    {
        public WpfSlider(Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        private RangeValuePattern RangeValuePattern { get { return PatternFactory.GetRangeValuePattern(); } }

        private Button LargeIncreaseButton
        {
            get { return FindFirst(TreeScope.Children, ConditionFactory.ByAutomationId("IncreaseLarge")).AsButton(); }
        }

        private Button LargeDecreaseButton
        {
            get { return FindFirst(TreeScope.Children, ConditionFactory.ByAutomationId("DecreaseLarge")).AsButton(); }
        }

        public override double Value
        {
            get { return RangeValuePattern.Current.Value; }
            set { RangeValuePattern.SetValue(value); }
        }

        public override void LargeIncrement()
        {
            LargeIncreaseButton.Click(false);
        }

        public override void LargeDecrement()
        {
            LargeDecreaseButton.Click(false);
        }
    }
}
