using FlaUI.Core;
using System;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    /// <summary>
    /// Automation implementation for UIA2
    /// </summary>
    public class UIA2Automation : AutomationBase
    {
        public override object NotSupportedValue
        {
            get { return UIA.AutomationElement.NotSupported; }
        }

        /// <summary>
        /// Creates an <see cref="UIA.AutomationElement"/> from a given windows handle (HWND)
        /// </summary>
        public UIA.AutomationElement FromHandle(IntPtr hwnd)
        {
            var nativeElement = UIA.AutomationElement.FromHandle(hwnd);
            return nativeElement;
        }

        public override void UnregisterAllEvents()
        {
            UIA.Automation.RemoveAllEventHandlers();
        }
    }
}
