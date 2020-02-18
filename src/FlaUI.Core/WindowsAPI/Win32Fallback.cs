using System;
using System.Runtime.InteropServices;
using System.Text;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.WindowsAPI
{
    /// <summary>
    /// This class wraps the various win32 fallback methods which are used in case UIA fails.
    /// </summary>
    internal static class Win32Fallback
    {
        // ReSharper disable InconsistentNaming
        internal static class ButtonMessages
        {
            public const uint BM_SETCHECK = 0x00F1;
            public const uint BM_GETCHECK = 0x00F0;
        }

        internal static class ButtonStates
        {
            public const uint BST_UNCHECKED = 0x0000;
            public const uint BST_CHECKED = 0x0001;
            public const uint BST_INDETERMINATE = 0x0002;
        }
        
        internal static class Win32CalendarMessages
        {
            public const uint MCM_GETCURSEL = 0x1001;
            public const uint MCM_SETCURSEL = 0x1002;
            public const uint MCM_GETSELRANGE = 0x1005;
            public const uint MCM_SETSELRANGE = 0x1006;
        }
        
        internal static class Win32CalendarStyles
        {
            public const uint MCS_MULTISELECT = 2;
        }
        
        internal static class DateTimePicker32Messages
        {
            public const uint DTM_GETSYSTEMTIME = 0x1001;
            public const uint DTM_SETSYSTEMTIME = 0x1002;
        }
        
        internal static class DateTimePicker32Constants
        {
            public const uint GDT_VALID = 0;
            public const uint GDT_NONE = 1;
        }
        // ReSharper restore InconsistentNaming

        internal static bool GetTextWin32(AutomationElement automationElement, out string textOut)
        {
            // try with native Win32 function SetWindowText
            if (automationElement.Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = automationElement.Properties.NativeWindowHandle.ValueOrDefault;
                return GetTextWin32(windowHandle, out textOut);
            }
            textOut = string.Empty;
            return false;
        }

        internal static bool GetTextWin32(IntPtr elementHwnd, out string textOut)
        {
            if (elementHwnd != IntPtr.Zero)
            {
                var textLengthPtr = User32.SendMessage(elementHwnd, WindowsMessages.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
                if (textLengthPtr.ToInt32() > 0)
                {
                    var textLength = textLengthPtr.ToInt32() + 1;
                    var text = new StringBuilder(textLength);
                    User32.SendMessage(elementHwnd, WindowsMessages.WM_GETTEXT, textLength, text);
                    textOut = text.ToString();
                    return true;
                }
            }
            textOut = string.Empty;
            return false;
        }

        internal static bool SetTextWin32(AutomationElement automationElement, string text)
        {
            // try with native Win32 function SetWindowText
            if (automationElement.Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = automationElement.Properties.NativeWindowHandle.ValueOrDefault;
                SetTextWin32(windowHandle, text);
            }
            return false;
        }

        internal static bool SetTextWin32(IntPtr elementHwnd, string text)
        {
            if (elementHwnd != IntPtr.Zero)
            {
                var textPtr = Marshal.StringToBSTR(text);
                try
                {
                    if (textPtr != IntPtr.Zero)
                    {
                        if (User32.SendMessage(elementHwnd, WindowsMessages.WM_SETTEXT, IntPtr.Zero, textPtr) == Win32Constants.TRUE)
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    // ignored
                }
                finally
                {
                    Marshal.FreeBSTR(textPtr);
                }
            }
            return false;
        }

        internal static ToggleState? GetToggleStateWin32(AutomationElement automationElement)
        {
            if (automationElement.Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = automationElement.Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != IntPtr.Zero)
                {
                    var className = new StringBuilder(256);
                    User32.GetClassName(windowHandle, className, 256);

                    if (className.ToString() == "Button")  // common Win32 checkbox window
                    {
                        var result = User32.SendMessage(windowHandle, ButtonMessages.BM_GETCHECK, IntPtr.Zero, IntPtr.Zero);

                        if (result.ToInt32() == ButtonStates.BST_UNCHECKED)
                        {
                            return ToggleState.Off;
                        }
                        if (result.ToInt32() == ButtonStates.BST_CHECKED)
                        {
                            return ToggleState.On;
                        }
                        if (result.ToInt32() == ButtonStates.BST_INDETERMINATE)
                        {
                            return ToggleState.Indeterminate;
                        }
                    }
                }
            }
            return null;
        }

        internal static void SetToggleStateWin32(AutomationElement automationElement, ToggleState state)
        {
            if (automationElement.Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = automationElement.Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != IntPtr.Zero)
                {
                    var className = new StringBuilder(256);
                    User32.GetClassName(windowHandle, className, 256);

                    if (className.ToString() == "Button") // Common Win32 Checkbox window
                    {
                        var result = User32.SendMessage(windowHandle, ButtonMessages.BM_GETCHECK, IntPtr.Zero, IntPtr.Zero);

                        if (state == ToggleState.On)
                        {
                            if (result.ToInt32() != (int)ButtonStates.BST_CHECKED)
                            {
                                User32.SendMessage(windowHandle, ButtonMessages.BM_SETCHECK, new IntPtr(ButtonStates.BST_CHECKED), IntPtr.Zero);
                            }
                        }
                        else if (state == ToggleState.Off)
                        {
                            if (result.ToInt32() != (int)ButtonStates.BST_UNCHECKED)
                            {
                                User32.SendMessage(windowHandle, ButtonMessages.BM_SETCHECK, new IntPtr(ButtonStates.BST_UNCHECKED), IntPtr.Zero);
                            }
                        }
                        else // indeterminate state
                        {
                            if (result.ToInt32() != (int)ButtonStates.BST_INDETERMINATE)
                            {
                                User32.SendMessage(windowHandle, ButtonMessages.BM_SETCHECK, new IntPtr(ButtonStates.BST_INDETERMINATE), IntPtr.Zero);
                            }
                        }
                    }
                }
            }
        }

        // get the edit window inside the spinner for Windows Forms
        internal static IntPtr GetSpinnerEditWindow(AutomationElement automationElement)
        {
            if (!automationElement.Properties.NativeWindowHandle.IsSupported)
            {
                return IntPtr.Zero;
            }
            var windowHandle = automationElement.Properties.NativeWindowHandle.ValueOrDefault;
            if (windowHandle == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }

            IntPtr hwndEdit = IntPtr.Zero;
            IntPtr hwndChild = User32.FindWindowEx(windowHandle, IntPtr.Zero, null, null);

            while (hwndChild != IntPtr.Zero)
            {
                StringBuilder childClassName = new StringBuilder(256);
                User32.GetClassName(hwndChild, childClassName, 256);
                if (childClassName.ToString().ToLower().Contains("edit"))
                {
                    hwndEdit = hwndChild;
                    break;
                }

                hwndChild = User32.FindWindowEx(windowHandle, hwndChild, null, null);
            }
            return hwndEdit;
        }
        
        internal static string GetWindowClassName(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                return null;
            }
            StringBuilder className = new StringBuilder(256);
            User32.GetClassName(handle, className, 256);
            return className.ToString();
        }
        
        // gets the selected date/dates from a Win32 calendar
        internal static DateTime[] GetSelection(IntPtr handle)
        {
            if (handle == IntPtr.Zero || GetWindowClassName(handle) != "SysMonthCal32")
            {
                throw new Exception("Not supported for this type of calendar");
            }
            
            uint styles = User32.GetWindowLong(handle, WindowLongParam.GWL_STYLE);
            if ((styles & Win32CalendarStyles.MCS_MULTISELECT) != 0)
            {
                // multiple selection calendar
                DateTime[] dates = GetSelectedRange(handle);
                if (dates.Length == 2 && dates[0] == dates[1])
                {
                    return new DateTime[] { dates[0] };
                }
                return dates;
            }
            else
            {
                // single selection calendar
                DateTime date = GetSelectedDate(handle);
                return new DateTime[] { date };
            }
        }
        
        // gets the first and last date of the selected range in a Win32 calendar that supports multiple selection
        internal static DateTime[] GetSelectedRange(IntPtr handle)
        {
            uint procid = 0;
            User32.GetWindowThreadProcessId(handle, out procid);
            IntPtr hProcess = User32.OpenProcess(ProcessAccessFlags.All, false, (int)procid);
            if (hProcess == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            SYSTEMTIME systemtime1 = new SYSTEMTIME();
            SYSTEMTIME systemtime2 = new SYSTEMTIME();
            // allocate memory in the process of the calendar
            IntPtr hMem = User32.VirtualAllocEx(hProcess, IntPtr.Zero, (uint)(2 * Marshal.SizeOf(systemtime1)),
                AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ReadWrite);
            if (hMem == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            User32.SendMessage(handle, Win32CalendarMessages.MCM_GETSELRANGE, IntPtr.Zero, hMem);
            
            IntPtr address = Marshal.AllocHGlobal(2 * Marshal.SizeOf(systemtime1));
            IntPtr lpNumberOfBytesRead = IntPtr.Zero;
            if (User32.ReadProcessMemory(hProcess, hMem, address, 2 * Marshal.SizeOf(systemtime1), out lpNumberOfBytesRead) == false)
            {
                throw new Exception("Insufficient rights");
            }
            
            systemtime1 = (SYSTEMTIME)Marshal.PtrToStructure(address, typeof(SYSTEMTIME));
            IntPtr address2 = new IntPtr(address.ToInt64() + Marshal.SizeOf(systemtime1));
            systemtime2 = (SYSTEMTIME)Marshal.PtrToStructure(address2, typeof(SYSTEMTIME));
            
            // release memory
            Marshal.FreeHGlobal(address);
            User32.VirtualFreeEx(hProcess, hMem, 2 * Marshal.SizeOf(systemtime1), AllocationType.Decommit | AllocationType.Release);
            User32.CloseHandle(hProcess);
            
            DateTime date1;
            try
            {
                date1 = new DateTime(systemtime1.Year, systemtime1.Month, systemtime1.Day, 
                    systemtime1.Hour, systemtime1.Minute, systemtime1.Second);
            }
            catch
            {
                date1 = new DateTime(systemtime1.Year, systemtime1.Month, systemtime1.Day, 
                    0, 0, 0);
            }
            
            DateTime date2;
            try
            {
                date2 = new DateTime(systemtime2.Year, systemtime2.Month, systemtime2.Day, 
                    systemtime2.Hour, systemtime2.Minute, systemtime2.Second);
            }
            catch
            {
                date2 = new DateTime(systemtime2.Year, systemtime2.Month, systemtime2.Day, 
                    0, 0, 0);
            }
            
            return new DateTime[] { date1, date2 };
        }
        
        // gets the selected date from a Win32 calendar that supports single selection
        internal static DateTime GetSelectedDate(IntPtr handle)
        {
            uint procid = 0;
            User32.GetWindowThreadProcessId(handle, out procid);
            IntPtr hProcess = User32.OpenProcess(ProcessAccessFlags.All, false, (int)procid);
            if (hProcess == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            SYSTEMTIME systemtime = new SYSTEMTIME();
            // allocate memory in the process of the calendar
            IntPtr hMem = User32.VirtualAllocEx(hProcess, IntPtr.Zero, (uint)Marshal.SizeOf(systemtime), 
                AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ReadWrite);
            if (hMem == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            User32.SendMessage(handle, Win32CalendarMessages.MCM_GETCURSEL, IntPtr.Zero, hMem);
            
            IntPtr address = Marshal.AllocHGlobal(Marshal.SizeOf(systemtime));
            IntPtr lpNumberOfBytesRead = IntPtr.Zero;
            if (User32.ReadProcessMemory(hProcess, hMem, address, Marshal.SizeOf(systemtime), out lpNumberOfBytesRead) == false)
            {
                throw new Exception("Insufficient rights");
            }

            systemtime = (SYSTEMTIME)Marshal.PtrToStructure(address, typeof(SYSTEMTIME));
            
            // release memory
            Marshal.FreeHGlobal(address);
            User32.VirtualFreeEx(hProcess, hMem, Marshal.SizeOf(systemtime), 
                AllocationType.Decommit | AllocationType.Release);
            User32.CloseHandle(hProcess);
            
            DateTime datetime;
            try
            {
                datetime = new DateTime(systemtime.Year, systemtime.Month, systemtime.Day, 
                    systemtime.Hour, systemtime.Minute, systemtime.Second);
            }
            catch
            {
                datetime = new DateTime(systemtime.Year, systemtime.Month, systemtime.Day, 
                    0, 0, 0);
            }
            
            return datetime;
        }
        
        internal static void SetSelectedDate(IntPtr handle, DateTime date)
        {
            if (handle == IntPtr.Zero || GetWindowClassName(handle) != "SysMonthCal32")
            {
                throw new Exception("Not supported for this type of calendar");
            }
            
            uint styles = User32.GetWindowLong(handle, WindowLongParam.GWL_STYLE);
            if ((styles & Win32CalendarStyles.MCS_MULTISELECT) != 0)
            {
                // multiselect calendar
                SetSelectedRange(handle, new DateTime[] { date, date });
                return;
            }
            
            uint procid = 0;
            User32.GetWindowThreadProcessId(handle, out procid);
            IntPtr hProcess = User32.OpenProcess(ProcessAccessFlags.All, false, (int)procid);
            if (hProcess == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            SYSTEMTIME systemtime = new SYSTEMTIME();
            systemtime.Year = (short)date.Year;
            systemtime.Month = (short)date.Month;
            systemtime.Day = (short)date.Day;
            systemtime.DayOfWeek = (short)date.DayOfWeek;
            systemtime.Hour = (short)date.Hour;
            systemtime.Minute = (short)date.Minute;
            systemtime.Second = (short)date.Second;
            systemtime.Milliseconds = (short)date.Millisecond;
            
            // allocate memory in the process of the calendar
            IntPtr hMem = User32.VirtualAllocEx(hProcess, IntPtr.Zero, (uint)Marshal.SizeOf(systemtime), 
                AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ReadWrite);
            if (hMem == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            IntPtr lpNumberOfBytesWritten = IntPtr.Zero;
            if (User32.WriteProcessMemory(hProcess, hMem, systemtime, Marshal.SizeOf(systemtime), out lpNumberOfBytesWritten) == false)
            {
                throw new Exception("Insufficient rights");
            }
            
            User32.SendMessage(handle, Win32CalendarMessages.MCM_SETCURSEL, IntPtr.Zero, hMem);
            
            // release memory
            User32.VirtualFreeEx(hProcess, hMem, Marshal.SizeOf(systemtime), 
                AllocationType.Decommit | AllocationType.Release);
            User32.CloseHandle(hProcess);
        }
        
        // Selects a range in a multiple selection Win32 calendar. The range is specified by the first and the last date.
        // If the calendar is single selection then the second date will be selected.
        // The "dates" parameter should always contain two dates.
        internal static void SetSelectedRange(IntPtr handle, DateTime[] dates)
        {
            if (handle == IntPtr.Zero || GetWindowClassName(handle) != "SysMonthCal32")
            {
                throw new Exception("Not supported for this type of calendar");
            }
            
            if (dates.Length != 2)
            {
                throw new Exception("Dates array length must be 2");
            }
            
            uint styles = User32.GetWindowLong(handle, WindowLongParam.GWL_STYLE);
            if ((styles & Win32CalendarStyles.MCS_MULTISELECT) == 0)
            {
                // singleselect calendar
                SetSelectedDate(handle, dates[1]);
                return;
            }
            
            uint procid = 0;
            User32.GetWindowThreadProcessId(handle, out procid);
            IntPtr hProcess = User32.OpenProcess(ProcessAccessFlags.All, false, (int)procid);
            if (hProcess == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            SYSTEMTIME systemtime1 = new SYSTEMTIME();
            systemtime1.Year = (short)dates[0].Year;
            systemtime1.Month = (short)dates[0].Month;
            systemtime1.Day = (short)dates[0].Day;
            systemtime1.DayOfWeek = (short)dates[0].DayOfWeek;
            systemtime1.Hour = (short)dates[0].Hour;
            systemtime1.Minute = (short)dates[0].Minute;
            systemtime1.Second = (short)dates[0].Second;
            systemtime1.Milliseconds = (short)dates[0].Millisecond;
            
            SYSTEMTIME systemtime2 = new SYSTEMTIME();
            systemtime2.Year = (short)dates[1].Year;
            systemtime2.Month = (short)dates[1].Month;
            systemtime2.Day = (short)dates[1].Day;
            systemtime2.DayOfWeek = (short)dates[1].DayOfWeek;
            systemtime2.Hour = (short)dates[1].Hour;
            systemtime2.Minute = (short)dates[1].Minute;
            systemtime2.Second = (short)dates[1].Second;
            systemtime2.Milliseconds = (short)dates[1].Millisecond;
            
            // allocate memory in the process of the calendar
            IntPtr hMem = User32.VirtualAllocEx(hProcess, IntPtr.Zero, (uint)(2 * Marshal.SizeOf(systemtime1)),
                AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ReadWrite);
            if (hMem == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            IntPtr lpNumberOfBytesWritten = IntPtr.Zero;
            if (User32.WriteProcessMemory(hProcess, hMem, systemtime1, Marshal.SizeOf(systemtime1), out lpNumberOfBytesWritten) == false)
            {
                throw new Exception("Insufficient rights");
            }
            IntPtr hMem2 = new IntPtr(hMem.ToInt64() + Marshal.SizeOf(systemtime1));
            if (User32.WriteProcessMemory(hProcess, hMem2, systemtime2, Marshal.SizeOf(systemtime2), out lpNumberOfBytesWritten) == false)
            {
                throw new Exception("Insufficient rights");
            }
            
            User32.SendMessage(handle, Win32CalendarMessages.MCM_SETSELRANGE, IntPtr.Zero, hMem);
            
            // release memory
            User32.VirtualFreeEx(hProcess, hMem, 2 * Marshal.SizeOf(systemtime1),
                AllocationType.Decommit | AllocationType.Release);
            User32.CloseHandle(hProcess);
        }
        
        // gets the selected date from a Win32 DateTimePicker
        internal static DateTime? GetDTPSelectedDate(IntPtr handle)
        {
            uint procid = 0;
            User32.GetWindowThreadProcessId(handle, out procid);
            
            IntPtr hProcess = User32.OpenProcess(ProcessAccessFlags.All, false, (int)procid);
            if (hProcess == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            SYSTEMTIME systemtime = new SYSTEMTIME();
            IntPtr hMem = User32.VirtualAllocEx(hProcess, IntPtr.Zero, (uint)Marshal.SizeOf(systemtime), 
                AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ReadWrite);
            if (hMem == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            IntPtr lResult = User32.SendMessage(handle, DateTimePicker32Messages.DTM_GETSYSTEMTIME, IntPtr.Zero, hMem);
            if (lResult.ToInt32() == (int)(DateTimePicker32Constants.GDT_NONE))
            {
                // DateTimePicker is unchecked and grayed out
                User32.VirtualFreeEx(hProcess, hMem, Marshal.SizeOf(systemtime), AllocationType.Decommit | AllocationType.Release);
                User32.CloseHandle(hProcess);
                return null;
            }
            
            IntPtr address = Marshal.AllocHGlobal(Marshal.SizeOf(systemtime));
            
            IntPtr lpNumberOfBytesRead = IntPtr.Zero;
            if (User32.ReadProcessMemory(hProcess, hMem, address, Marshal.SizeOf(systemtime), out lpNumberOfBytesRead) == false)
            {
                throw new Exception("Insufficient rights");
            }
            
            systemtime = (SYSTEMTIME)Marshal.PtrToStructure(address, typeof(SYSTEMTIME));
            
            Marshal.FreeHGlobal(address);
            User32.VirtualFreeEx(hProcess, hMem, Marshal.SizeOf(systemtime), AllocationType.Decommit | AllocationType.Release);
            User32.CloseHandle(hProcess);
            
            DateTime datetime;
            try
            {
                datetime = new DateTime(systemtime.Year, systemtime.Month, systemtime.Day, 
                    systemtime.Hour, systemtime.Minute, systemtime.Second);
            }
            catch
            {
                datetime = new DateTime(systemtime.Year, systemtime.Month, systemtime.Day, 
                    0, 0, 0);
            }
            
            return datetime;
        }
        
        // sets the selected date in a Win32 DateTimePicker.
        // if "date" parameter is null then the DateTimePicker will be unchecked and grayed out.
        internal static void SetDTPSelectedDate(IntPtr handle, DateTime? date)
        {
            if (handle == IntPtr.Zero || GetWindowClassName(handle) != "SysDateTimePick32")
            {
                throw new Exception("Not supported for this type of DateTimePicker");
            }
            
            if (date == null)
            {
                User32.SendMessage(handle, DateTimePicker32Messages.DTM_SETSYSTEMTIME, new IntPtr(DateTimePicker32Constants.GDT_NONE), IntPtr.Zero);
                return;
            }
            
            uint procid = 0;
            User32.GetWindowThreadProcessId(handle, out procid);
            
            IntPtr hProcess = User32.OpenProcess(ProcessAccessFlags.All, false, (int)procid);
            if (hProcess == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            SYSTEMTIME systemtime = new SYSTEMTIME();
            systemtime.Year = (short)date.Value.Year;
            systemtime.Month = (short)date.Value.Month;
            systemtime.Day = (short)date.Value.Day;
            systemtime.DayOfWeek = (short)date.Value.DayOfWeek;
            systemtime.Hour = (short)date.Value.Hour;
            systemtime.Minute = (short)date.Value.Minute;
            systemtime.Second = (short)date.Value.Second;
            systemtime.Milliseconds = (short)date.Value.Millisecond;
            
            IntPtr hMem = User32.VirtualAllocEx(hProcess, IntPtr.Zero, (uint)Marshal.SizeOf(systemtime), 
                AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ReadWrite);
            if (hMem == IntPtr.Zero)
            {
                throw new Exception("Insufficient rights");
            }
            
            IntPtr lpNumberOfBytesWritten = IntPtr.Zero;
            if (User32.WriteProcessMemory(hProcess, hMem, systemtime, Marshal.SizeOf(systemtime), 
                out lpNumberOfBytesWritten) == false)
            {
                throw new Exception("Insufficient rights");
            }
            
            User32.SendMessage(handle, DateTimePicker32Messages.DTM_SETSYSTEMTIME, new IntPtr(DateTimePicker32Constants.GDT_VALID), hMem);
            
            User32.VirtualFreeEx(hProcess, hMem, Marshal.SizeOf(systemtime), AllocationType.Decommit | AllocationType.Release);
            User32.CloseHandle(hProcess);
        }
    }
}
