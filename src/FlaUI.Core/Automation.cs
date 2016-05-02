using FlaUI.Core.Input;
using FlaUI.Core.Overlay;
using interop.UIAutomationCore;
using System;
using System.Runtime.InteropServices;

namespace FlaUI.Core
{
    /// <summary>
    /// Wrapper for the native automation object
    /// </summary>
    public class Automation : IDisposable
    {
        /// <summary>
        /// Native object for the ui automation
        /// </summary>
        public IUIAutomation NativeAutomation { get; private set; }

        /// <summary>
        /// Native object for Windows 8 automation
        /// </summary>
        public IUIAutomation2 NativeAutomation2
        {
            get { return GetAutomationAs<IUIAutomation2>(); }
        }

        /// <summary>
        /// Native object for Windows 8.1 automation
        /// </summary>
        public IUIAutomation3 NativeAutomation3
        {
            get { return GetAutomationAs<IUIAutomation3>(); }
        }

        /// <summary>
        /// Factory object for conditions
        /// </summary>
        public ConditionFactory ConditionFactory
        {
            get;
            private set;
        }

        /// <summary>
        /// Manager object for overlay objects
        /// </summary>
        public OverlayManager OverlayManager
        {
            get;
            private set;
        }

        /// <summary>
        /// Object to control the mouse
        /// </summary>
        public IMouse Mouse
        {
            get;
            private set;
        }

        /// <summary>
        /// Object to control the keyboard
        /// </summary>
        public IKeyboard Keyboard
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates an automation object
        /// </summary>
        public Automation()
        {
            NativeAutomation = InitializeAutomation();
            ConditionFactory = new ConditionFactory(NativeAutomation);
            OverlayManager = new OverlayManager();
            Mouse = new Mouse();
            Keyboard = new Keyboard();
        }

        /// <summary>
        /// Initializes the automation object with the correct instance
        /// </summary>
        private IUIAutomation InitializeAutomation()
        {
            IUIAutomation nativeAutomation;
            // Try CUIAutomation8 (Windows 8)
            try
            {
                nativeAutomation = new CUIAutomation8();
            }
            catch (COMException)
            {
                // Fall back to CUIAutomation
                nativeAutomation = new CUIAutomation();
            }
            return nativeAutomation;
        }

        /// <summary>
        /// Cleans up the resources
        /// </summary>
        public void Dispose()
        {
            OverlayManager.Dispose();
        }

        /// <summary>
        /// Tries to cast the automation to a specific interface.
        /// Throws an exception if that is not possible.
        /// </summary>
        private T GetAutomationAs<T>() where T : class, IUIAutomation
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
