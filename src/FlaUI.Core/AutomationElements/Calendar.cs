using System;
using System.Linq;
using System.Threading;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a calendar element.
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
        /// Gets the selected dates in the calendar.
        /// </summary>
        public DateTime[] SelectedDates
        {
            get
            {
                if (FrameworkType == FrameworkType.Wpf)
                {
                    if (Patterns.MultipleView.TryGetPattern(out var multipleViewPattern))
                    {
                        int[] views = multipleViewPattern.SupportedViews;
                        if (views.Length > 0)
                        {
                            // Set current view so days are shown
                            multipleViewPattern.SetCurrentView(views[0]);
                        }
                    }
                    
                    List<DateTime> result = new List<DateTime>();
                    AutomationElement[] buttons = FindAllChildren(cf => cf.ByControlType(ControlType.Button));
                    
                    // skip the first 3 buttons (previous, header and next buttons) and
                    // iterate through all the day buttons
                    for (int i = 3; i < buttons.Length; i++)
                    {
                        Button dayButton = buttons[i].AsButton();
                        if (dayButton.Patterns.SelectionItem.TryGetPattern(out var selectionItemPattern))
                        {
                            if (selectionItemPattern.IsSelected)
                            {
                                string name = dayButton.Name; // name has the form like "Friday, January 24, 2020"
                                // remove the day name from the beggining of the string
                                string dateString = name.Remove(0, name.IndexOf(',') + 1).Trim();
                                DateTime date = DateTime.ParseExact(dateString, "MMMM dd, yyyy", CultureInfo.CurrentCulture);
                                result.Add(date);
                            }
                        }
                    }
                    
                    return result.ToArray();
                }
                else
                {
                    throw new NotSupportedException("Supported only for WPF");
                }
            }
        }
        
        /// <summary>
        /// Deselects other selected dates and selects the specified date.
        /// </summary>
        public void SelectDate(DateTime date)
        {
            SetSelectedDate(date, false);
        }
        
        /// <summary>
        /// Deselects other selected dates and selects the specified range.
        /// </summary>
        public void SelectRange(DateTime[] dates)
        {
            if (dates.Length == 0)
            {
                return;
            }
            
            SetSelectedDate(dates[0], false);
            for (int i = 1; i < dates.Length; i++)
            {
                SetSelectedDate(dates[i], true);
            }
        }
        
        /// <summary>
        /// Adds the specified date to selection.
        /// </summary>
        public void AddToSelection(DateTime date)
        {
            SetSelectedDate(date, true);
        }
        
        /// <summary>
        /// Adds the specified range to selection.
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
                    string[] parts = monthBtn.Name.Split(' ');
                    if (parts[0] == date.ToString("MMMM"))
                    {
                        if (monthBtn.Patterns.Invoke.TryGetPattern(out var invokePattern))
                        {
                            invokePattern.Invoke(); // select month
                        }
                    }
                }
                
                AutomationElement[] dayButtons = FindAllChildren(cf => cf.ByControlType(ControlType.Button));
                for (int i = 3; i < dayButtons.Length; i++)
                {
                    AutomationElement dayBtn = dayButtons[i];
                    string[] parts = dayBtn.Name.Split(',');
                    string dayStr = parts[1].Trim();
                    
                    if (dayStr == date.ToString("MMMM d"))
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
