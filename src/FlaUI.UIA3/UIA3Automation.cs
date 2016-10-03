using FlaUI.Core;
using FlaUI.Core.Shapes;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Shapes;
using System;
using System.Runtime.InteropServices;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    /// <summary>
    /// Automation implementation for UIA3
    /// </summary>
    public class UIA3Automation : AutomationBase
    {
        public override AutomationType AutomationType { get { return AutomationType.UIA3; } }

        public override object NotSupportedValue
        {
            get { return NativeAutomation.ReservedNotSupportedValue; }
        }

        /// <summary>
        /// Native object for the ui automation
        /// </summary>
        public UIA.IUIAutomation NativeAutomation { get; private set; }

        /// <summary>
        /// Native object for Windows 8 automation
        /// </summary>
        public UIA.IUIAutomation2 NativeAutomation2
        {
            get { return GetAutomationAs<UIA.IUIAutomation2>(); }
        }

        /// <summary>
        /// Native object for Windows 8.1 automation
        /// </summary>
        public UIA.IUIAutomation3 NativeAutomation3
        {
            get { return GetAutomationAs<UIA.IUIAutomation3>(); }
        }

        /// <summary>
        /// Creates an automation object
        /// </summary>
        public UIA3Automation()
        {
            NativeAutomation = InitializeAutomation();
        }

        /// <summary>
        /// Gets the root element (desktop)
        /// </summary>
        public AutomationElement GetDesktop()
        {
            var desktop = NativeAutomation.GetRootElement();
            return new AutomationElement(this, desktop);
        }

        /// <summary>
        /// Creates an <see cref="AutomationElement"/> from a given point
        /// </summary>
        public AutomationElement FromPoint(Point point)
        {
            var nativeElement = NativeAutomation.ElementFromPoint(point.ToTagPoint());
            return nativeElement == null ? null : new AutomationElement(this, nativeElement);
        }

        /// <summary>
        /// Creates an <see cref="AutomationElement"/> from a given windows handle (HWND)
        /// </summary>
        public AutomationElement FromHandle(IntPtr hwnd)
        {
            var nativeElement = NativeAutomation.ElementFromHandle(hwnd);
            return nativeElement == null ? null : new AutomationElement(this, nativeElement);
        }

        public override void UnregisterAllEvents()
        {
            try
            {
                NativeAutomation.RemoveAllEventHandlers();
            }
            catch { }
        }

        /// <summary>
        /// Initializes the automation object with the correct instance
        /// </summary>
        private UIA.IUIAutomation InitializeAutomation()
        {
            UIA.IUIAutomation nativeAutomation;
            // Try CUIAutomation8 (Windows 8)
            try
            {
                nativeAutomation = new UIA.CUIAutomation8();
            }
            catch (COMException)
            {
                // Fall back to CUIAutomation
                nativeAutomation = new UIA.CUIAutomation();
            }
            return nativeAutomation;
        }

        /// <summary>
        /// Tries to cast the automation to a specific interface.
        /// Throws an exception if that is not possible.
        /// </summary>
        private T GetAutomationAs<T>() where T : class, UIA.IUIAutomation
        {
            var element = NativeAutomation as T;
            if (element == null)
            {
                throw new NotSupportedException(String.Format("OS does not have {0} support.", typeof(T).Name));
            }
            return element;
        }
    }
}
