using FlaUI.Core.Overlay;
using interop.UIAutomationCore;
using System;
using System.Runtime.InteropServices;
using FlaUI.Core.Input;

namespace FlaUI.Core
{
    /// <summary>
    /// Wrapper for the native automation object
    /// </summary>
    public class Automation : IDisposable
    {
        /// <summary>
        /// Basic object for the ui automation
        /// </summary>
        public IUIAutomation NativeAutomation
        {
            get;
            private set;
        }

        /// <summary>
        /// Object for Windows 8 automation
        /// </summary>
        public IUIAutomation2 NativeAutomation2
        {
            get
            {
                var upgradedAutomation = NativeAutomation as IUIAutomation2;
                if (upgradedAutomation == null)
                {
                    throw new NotImplementedException("OS does not have IUIAutomation2 support.");
                }
                return upgradedAutomation;
            }
        }

        /// <summary>
        /// Object for Windows 8.1 automation
        /// </summary>
        public IUIAutomation3 NativeAutomation3
        {
            get
            {
                var upgradedAutomation = NativeAutomation as IUIAutomation3;
                if (upgradedAutomation == null)
                {
                    throw new NotImplementedException("OS does not have IUIAutomation3 support.");
                }
                return upgradedAutomation;
            }
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
        /// Creates an automation object
        /// </summary>
        public Automation()
        {
            NativeAutomation = InitializeAutomation();
            ConditionFactory = new ConditionFactory(NativeAutomation);
            OverlayManager = new OverlayManager();
            Mouse = new Mouse();
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
    }
}
