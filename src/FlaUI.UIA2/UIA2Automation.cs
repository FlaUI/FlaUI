using FlaUI.Core;
using FlaUI.UIA2.Elements;
using System;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    /// <summary>
    /// Automation implementation for UIA2
    /// </summary>
    public class UIA2Automation : AutomationBase
    {
        public override AutomationType AutomationType { get { return AutomationType.UIA2; } }

        public override object NotSupportedValue
        {
            get { return UIA.AutomationElement.NotSupported; }
        }

        /// <summary>
        /// Creates an <see cref="UIA.AutomationElement"/> from a given windows handle (HWND)
        /// </summary>
        public Element FromHandle(IntPtr hwnd)
        {
            var nativeElement = UIA.AutomationElement.FromHandle(hwnd);
            return nativeElement == null ? null : new Element(this, nativeElement);
        }

        public override void UnregisterAllEvents()
        {
            UIA.Automation.RemoveAllEventHandlers();
        }
    }
}
