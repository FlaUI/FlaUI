using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Patterns;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a WinForms spinner element.
    /// </summary>
    public class Spinner : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="Spinner"/> element.
        /// </summary>
        public Spinner(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
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
        /// The button element used to perform a large increment.
        /// </summary>
        public Button? IncreaseButton => GetIncreaseButton();

        /// <summary>
        /// The button element used to perform a large decrement.
        /// </summary>
        public Button? DecreaseButton => GetDecreaseButton();

        /// <summary>
        /// Flag which indicates if the <see cref="Spinner"/> supports range values (min->max) or only values (0-100).
        /// Only values are for example used when combining UIA3 and WinForms applications.
        /// </summary>
        public bool IsOnlyValue => !IsPatternSupported(Automation.PatternLibrary.RangeValuePattern);

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        public double Value
        {
            get
            {
                if (FrameworkType == FrameworkType.WinForms)
                {
                    if (AutomationType == AutomationType.UIA2)
                    {
                        IntPtr hwndEdit = Win32Fallback.GetSpinnerEditWindow(this);
                        if (hwndEdit != IntPtr.Zero)
                        {
                            //get window text
                            IntPtr textLengthPtr = User32.SendMessage(hwndEdit,
                                WindowsMessages.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);

                            string windowText = string.Empty;
                            if (textLengthPtr.ToInt32() > 0)
                            {
                                int textLength = textLengthPtr.ToInt32() + 1;
                                StringBuilder text = new StringBuilder(textLength);

                                User32.SendMessage(hwndEdit, WindowsMessages.WM_GETTEXT, textLength, text);
                                windowText = text.ToString();
                            }

                            double valueDouble = 0.0;
                            if (double.TryParse(windowText, out valueDouble) == true)
                            {
                                return valueDouble;
                            }
                        }
                    }
                    else // UIA3
                    {
                        var edit = FindFirstChild(cf => cf.ByControlType(ControlType.Edit)).AsTextBox();
                        if (edit != null)
                        {
                            double valueDouble = 0.0;
                            if (double.TryParse(edit.Text, out valueDouble) == true)
                            {
                                return valueDouble;
                            }
                        }
                    }
                }
                else if (FrameworkType == FrameworkType.Win32 && AutomationType == AutomationType.UIA3)
                {
                    if (ControlType == ControlType.Spinner)
                    {
                        SetForeground();
                        // take the edit control at the left of spinner
                        Point pt = new Point(BoundingRectangle.Left - 5, (BoundingRectangle.Top + BoundingRectangle.Bottom) / 2);
                        var edit = FrameworkAutomationElement.Automation.FromPoint(pt).AsTextBox();
                        return Convert.ToDouble(edit.Text);
                    }
                }

                return IsOnlyValue ? Convert.ToDouble(ValuePattern.Value.Value) : RangeValuePattern.Value.Value;
            }
            set
            {
                if (FrameworkType == FrameworkType.WinForms)
                {
                    if (AutomationType == AutomationType.UIA2)
                    {
                        IntPtr hwndEdit = Win32Fallback.GetSpinnerEditWindow(this);
                        if (hwndEdit != IntPtr.Zero)
                        {
                            // set spinner value
                            IntPtr textPtr = Marshal.StringToBSTR(value.ToString(CultureInfo.InvariantCulture));
                            if (textPtr != IntPtr.Zero)
                            {
                                User32.SendMessage(hwndEdit, WindowsMessages.WM_SETTEXT, IntPtr.Zero, textPtr);
                                return;
                            }
                        }
                    }
                    else // UIA3
                    {
                        var edit = FindFirstChild(cf => cf.ByControlType(ControlType.Edit)).AsTextBox();
                        if (edit != null)
                        {
                            edit.Text = value.ToString(CultureInfo.InvariantCulture);
                            return;
                        }
                    }
                }
                else if (FrameworkType == FrameworkType.Win32 && AutomationType == AutomationType.UIA3)
                {
                    if (ControlType == ControlType.Spinner)
                    {
                        SetForeground();
                        // take the edit control at the left of spinner
                        Point pt = new Point(BoundingRectangle.Left - 5, (BoundingRectangle.Top + BoundingRectangle.Bottom) / 2);
                        var edit = FrameworkAutomationElement.Automation.FromPoint(pt).AsTextBox();
                        edit.Text = value.ToString(CultureInfo.InvariantCulture);
                        return;
                    }
                }

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
        /// Performs increment.
        /// </summary>
        public void Increment()
        {
            if (AutomationType == AutomationType.UIA2)
            {
                IncreaseButton?.Invoke();
                Wait.UntilInputIsProcessed();
            }
            else // UIA3
            {
                SetForeground();
                Wait.UntilInputIsProcessed();
                IncreaseButton?.Click();
                Wait.UntilInputIsProcessed();
            }
        }

        /// <summary>
        /// Performs decrement.
        /// </summary>
        public void Decrement()
        {
            if (AutomationType == AutomationType.UIA2)
            {
                DecreaseButton?.Invoke();
                Wait.UntilInputIsProcessed();
            }
            else // UIA3
            {
                SetForeground();
                Wait.UntilInputIsProcessed();
                DecreaseButton?.Click();
                Wait.UntilInputIsProcessed();
            }
        }

        /// <summary>
        /// Method to get the increase button.
        /// </summary>
        protected virtual Button? GetIncreaseButton()
        {
            var buttons = FindAllDescendants(cf => cf.ByControlType(ControlType.Button));
            return buttons.Length >= 1 ? buttons[0].AsButton() : null;
        }

        /// <summary>
        /// Method to get the decrease button.
        /// </summary>
        protected virtual Button? GetDecreaseButton()
        {
            var buttons = FindAllDescendants(cf => cf.ByControlType(ControlType.Button));
            return buttons.Length >= 2 ? buttons[1].AsButton() : null;
        }
    }
}
