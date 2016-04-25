using interop.UIAutomationCore;
using System;
using System.Runtime.InteropServices;

namespace FlaUI.Core
{
    public class Automation
    {
        private static IUIAutomation _instance = null;

        // Tell the compiler not to mark the type as beforefieldinit
        static Automation()
        {
        }

        /// <summary>
        /// Basic instance for the ui automation
        /// </summary>
        public static IUIAutomation Instance
        {
            get
            {
                // Try CUIAutomation8 (Windows 8)
                if (_instance == null)
                {
                    try
                    {
                        _instance = new CUIAutomation8();
                    }
                    catch (COMException)
                    {
                    }
                }

                // Fall back to CUIAutomation
                if (_instance == null)
                {
                    _instance = new CUIAutomation();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Windows 8 automation
        /// </summary>
        public static IUIAutomation2 Instance2
        {
            get
            {
                var instance2 = Instance as IUIAutomation2;
                if (instance2 == null)
                {
                    throw new NotImplementedException("OS does not have IUIAutomation2 support.");
                }
                return instance2;
            }
        }

        /// <summary>
        /// Windows 8.1 automation
        /// </summary>
        public static IUIAutomation3 Instance3
        {
            get
            {
                var instance3 = Instance as IUIAutomation3;
                if (instance3 == null)
                {
                    throw new NotImplementedException("OS does not have IUIAutomation3 support.");
                }
                return instance3;
            }
        }
    }
}
