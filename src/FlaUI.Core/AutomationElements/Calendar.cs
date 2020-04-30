using System;
using System.Linq;
using System.Threading;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;
using System.Collections.Generic;
using System.Globalization;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a calendar element. Not supported for Windows Forms calendar.
    /// </summary>
    public class Calendar : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="Calendar"/> element.
        /// </summary>
        public Calendar(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Gets the selected dates in the calendar. For Win32 multiple selection calendar the returned array has two 
        /// dates, the first date and the last date of the selected range. For WPF calendar the returned array contains
        /// all selected dates.
        /// </summary>
        public DateTime[] SelectedDates
        {
            get
            {
                if (FrameworkType == FrameworkType.Wpf)
                {
                    List<DateTime> result = new List<DateTime>();
                    if (Patterns.Selection.TryGetPattern(out var selectionPattern))
                    {
                        AutomationElement[] selection = selectionPattern.Selection;
                        foreach (AutomationElement selectedElement in selection)
                        {
                            string dateString = selectedElement.Name; // name has the form like "Friday, January 24, 2020"
                            try
                            {
                                DateTime date = DateTime.Parse(dateString, CultureInfo.CurrentCulture);
                                result.Add(date);
                            }
                            catch { }
                        }
                    }
                    return result.ToArray();
                }
                else if (FrameworkType == FrameworkType.Win32)
                {
                    if (Properties.NativeWindowHandle.IsSupported)
                    {
                        var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                        if (windowHandle != IntPtr.Zero)
                        {
                            return Win32Fallback.GetSelection(windowHandle);
                        }
                    }
                }
                
                throw new NotSupportedException("Not supported");
            }
        }
        
        /// <summary>
        /// Deselects other selected dates and selects the specified date.
        /// </summary>
        public void SelectDate(DateTime date)
        {
            if (FrameworkType == FrameworkType.Wpf)
            {
                SetSelectedDate(date, false);
                return;
            }
            else if (FrameworkType == FrameworkType.Win32)
            {
                if (Properties.NativeWindowHandle.IsSupported)
                {
                    var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                    if (windowHandle != IntPtr.Zero)
                    {
                        Win32Fallback.SetSelectedDate(windowHandle, date);
                        return;
                    }
                }
            }
            
            throw new NotSupportedException("Not supported");
        }
        
        /// <summary>
        /// For WPF calendar with SelectionMode="MultipleRange" this method deselects other selected dates and selects the specified range.
        /// For any other type of SelectionMode it deselects other selected dates and selects only the last date in the range.
        /// For Win32 multiple selection calendar the "dates" parameter should contain two dates, the first and the last date of the range to be selected.
        /// For Win32 single selection calendar this method selects only the second date from the "dates" array.
        /// For WPF calendar all dates should be specified in the "dates" parameter, not only the first and the last date of the range.
        /// </summary>
        public void SelectRange(DateTime[] dates)
        {
            if (dates.Length == 0)
            {
                return;
            }
            
            if (FrameworkType == FrameworkType.Wpf)
            {
                SetSelectedDate(dates[0], false);
                for (int i = 1; i < dates.Length; i++)
                {
                    SetSelectedDate(dates[i], true);
                }
                return;
            }
            else if (FrameworkType == FrameworkType.Win32)
            {
                if (Properties.NativeWindowHandle.IsSupported)
                {
                    var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                    if (windowHandle != IntPtr.Zero)
                    {
                        Win32Fallback.SetSelectedRange(windowHandle, dates);
                        return;
                    }
                }
            }
            
            throw new NotSupportedException("Not supported");
        }
        
        /// <summary>
        /// For WPF calendar with SelectionMode="MultipleRange" this method adds the specified date to current selection.
        /// For any other type of SelectionMode it deselects other selected dates and selects the specified date.
        /// This method is supported only for WPF calendar.
        /// </summary>
        public void AddToSelection(DateTime date)
        {
            SetSelectedDate(date, true);
        }
        
        /// <summary>
        /// For WPF calendar with SelectionMode="MultipleRange" this method adds the specified range to current selection.
        /// For any other type of SelectionMode it deselects other selected dates and selects only the last date in the range.
        /// This method is supported only for WPF calendar.
        /// </summary>
        public void AddRangeToSelection(DateTime[] dates)
        {
            foreach (DateTime date in dates)
            {
                SetSelectedDate(date, true);
            }
        }
        
        private void SetSelectedDate(DateTime date, bool add)
        {
            if (FrameworkType == FrameworkType.Wpf)
            {
                // switch to Decade view
                if (Patterns.MultipleView.TryGetPattern(out var multipleViewPattern))
                {
                    int[] views = multipleViewPattern.SupportedViews;
                    if (views.Length >= 3)
                    {
                        // the third view is the Decade view
                        multipleViewPattern.SetCurrentView(views[2]);
                    }
                }
                
                // set year
                AutomationElement headerBtn = FindFirstChild(cf => cf.ByAutomationId("PART_HeaderButton"));
                string headerName = headerBtn.Name;
                string[] parts = headerName.Split('-');
                int yearLow = Convert.ToInt32(parts[0]);
                int yearHigh = Convert.ToInt32(parts[1]);
                
                if (date.Year < yearLow)
                {
                    AutomationElement prevBtn = FindFirstChild(cf => cf.ByControlType(ControlType.Button));
                    while (date.Year < yearLow)
                    {
                        if (prevBtn.Patterns.Invoke.TryGetPattern(out var invokePattern))
                        {
                            invokePattern.Invoke(); // go to previous decade
                            headerName = headerBtn.Name;
                            parts = headerName.Split('-');
                            yearLow = Convert.ToInt32(parts[0]);
                        }
                        else
                        {
                            break; // invoke pattern not supported on previous decade button
                        }
                    }
                }
                else if (date.Year > yearHigh)
                {
                    AutomationElement nextBtn = FindFirstChild(cf => cf.ByAutomationId("PART_NextButton"));
                    while (date.Year > yearHigh)
                    {
                        if (nextBtn.Patterns.Invoke.TryGetPattern(out var invokePattern))
                        {
                            invokePattern.Invoke(); // go to next decade
                            headerName = headerBtn.Name;
                            parts = headerName.Split('-');
                            yearHigh = Convert.ToInt32(parts[1]);
                        }
                        else
                        {
                            break; // invoke pattern not supported on next decade button
                        }
                    }
                }
                
                AutomationElement[] buttons = FindAllChildren(cf => cf.ByControlType(ControlType.Button));
                for (int i = 3; i < buttons.Length; i++) // iterate through all the year buttons
                {
                    AutomationElement button = buttons[i];
                    if (button.Name == date.Year.ToString())
                    {
                        if (button.Patterns.Invoke.TryGetPattern(out var invokePattern))
                        {
                            invokePattern.Invoke(); // select year
                        }
                    }
                }
                
                // set month
                AutomationElement[] monthButtons = FindAllChildren(cf => cf.ByControlType(ControlType.Button));
                for (int i = 3; i < monthButtons.Length; i++)
                {
                    AutomationElement monthBtn = monthButtons[i];
                    DateTime crtMonthDate = DateTime.Parse(monthBtn.Name, CultureInfo.CurrentCulture);
                    if (crtMonthDate.Month == date.Month)
                    {
                        if (monthBtn.Patterns.Invoke.TryGetPattern(out var invokePattern))
                        {
                            invokePattern.Invoke(); // select month
                        }
                    }
                }
                
                // set day
                AutomationElement[] dayButtons = FindAllChildren(cf => cf.ByControlType(ControlType.Button));
                DateTime dateDayMonthYear = new DateTime(date.Year, date.Month, date.Day);
                for (int i = 3; i < dayButtons.Length; i++)
                {
                    AutomationElement dayBtn = dayButtons[i];
                    string dayStr = dayBtn.Name;
                    
                    DateTime currentDate;
                    try
                    {
                        currentDate = DateTime.Parse(dayStr, CultureInfo.CurrentCulture);
                    }
                    catch 
                    {
                        continue;
                    }
                    
                    if (currentDate == dateDayMonthYear)
                    {
                        if (add == true)
                        {
                            if (dayBtn.Patterns.SelectionItem.TryGetPattern(out var selectionItemPattern))
                            {
                                selectionItemPattern.AddToSelection();
                            }
                        }
                        else
                        {
                            if (dayBtn.Patterns.Invoke.TryGetPattern(out var invokePattern))
                            {
                                invokePattern.Invoke();
                            }
                        }
                    }
                }
            }
            else
            {
                throw new NotSupportedException("Supported only for WPF");
            }
        }
    }
}
