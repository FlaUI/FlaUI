using System;
using System.Linq;
using System.Threading;
using System.Drawing;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;
using System.Collections.Generic;
using System.Globalization;
using FlaUI.Core.WindowsAPI;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a DateTimePicker element.
    /// </summary>
    public class DateTimePicker : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="DateTimePicker"/> element.
        /// </summary>
        public DateTimePicker(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Gets or sets the selected date in the DateTimePicker.
        /// For Win32, setting SelectedDate to null will uncheck the DateTimePicker control and disable it. Also for Win32, if the control is unchecked then SelectedDate will return null.
        /// For Windows Forms you can only read the selected date from a DateTimePicker control.
        /// </summary>
        public DateTime? SelectedDate
        {
            get
            {
                if (FrameworkType == FrameworkType.Wpf)
                {
                    if (Patterns.Value.TryGetPattern(out var valuePattern))
                    {
                        string val = valuePattern.Value.Value;
                        DateTime date = DateTime.Parse(val, CultureInfo.CurrentCulture);
                        return date;
                    }
                }
                else if (FrameworkType == FrameworkType.Win32)
                {
                    if (Properties.NativeWindowHandle.IsSupported)
                    {
                        var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                        if (windowHandle != IntPtr.Zero)
                        {
                            return Win32Fallback.GetDTPSelectedDate(windowHandle);
                        }
                    }
                }
                else if (FrameworkType == FrameworkType.WinForms)
                {
                    string name = Properties.Name.Value;
                    string dateString = name.Remove(0, name.IndexOf(",") + 1).Trim();
                    DateTime date = DateTime.Parse(dateString, CultureInfo.CurrentCulture);
                    return date;
                }
                
                throw new Exception("Unable to get the selected date from this DateTimePicker");
            }
            set
            {
                if (FrameworkType == FrameworkType.Wpf)
                {
                    if (Patterns.Value.TryGetPattern(out var valuePattern))
                    {
                        valuePattern.SetValue(value.Value.ToString(CultureInfo.CurrentCulture));
                        return;
                    }
                }
                else if (FrameworkType == FrameworkType.Win32)
                {
                    if (Properties.NativeWindowHandle.IsSupported)
                    {
                        var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                        if (windowHandle != IntPtr.Zero)
                        {
                            Win32Fallback.SetDTPSelectedDate(windowHandle, value);
                            return;
                        }
                    }
                }
                else if (FrameworkType == FrameworkType.WinForms)
                {
                    SetForeground();
                    Wait.UntilInputIsProcessed();
                    
                    Rectangle boundingRect = Properties.BoundingRectangle.Value;
                    int x = (int)boundingRect.Right - 5;
                    int y = (int)((boundingRect.Top + boundingRect.Bottom) / 2);
                    Mouse.Click(new Point(x, y)); // click the down arrow
                    
                    //Focus();
                    //Wait.UntilInputIsProcessed();
                    //Keyboard.PressVirtualKeyCode((ushort)(VirtualKeyShort.ALT)); // Alt + Down key
                    //Keyboard.TypeVirtualKeyCode((ushort)(VirtualKeyShort.DOWN));
                    //Keyboard.ReleaseVirtualKeyCode((ushort)(VirtualKeyShort.ALT));
                    
                    AutomationElement parent = Parent;
                    AutomationElement parentOfParent = parent.Parent;
                    AutomationElement root = Automation.GetDesktop();
                    
                    // Get the top level window
                    while (parentOfParent != root)
                    {
                        parent = parentOfParent;
                        parentOfParent = parent.Parent;
                    }
                    
                    Wait.UntilInputIsProcessed();
                    var retryResult = Retry.While(() => parent.FindFirstDescendant(cf => cf.ByName("Calendar Control").And(cf.ByClassName("SysMonthCal32"))).AsCalendar(), w => w == null, TimeSpan.FromMilliseconds(1000));
                    Calendar calendar = retryResult.Result;
                    
                    if (calendar != null)
                    {
                        calendar.SelectDate(value.Value);
                        Keyboard.Type(' ');
                        Wait.UntilInputIsProcessed();
                    }
                    else
                    {
                        throw new Exception("calendar is null");
                    }
                }
                
                throw new Exception("Unable to set the selected date for this DateTimePicker");
            }
        }
    }
}
