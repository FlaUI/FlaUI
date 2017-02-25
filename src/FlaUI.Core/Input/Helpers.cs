using System;
using System.Threading;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Input
{
    public static class Helpers
    {
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(1);

        public static void WaitUntilInputIsProcessed()
        {
            // Let the thread some time to process the system's hardware input queue.
            // For details see this post: http://blogs.msdn.com/b/oldnewthing/archive/2014/02/13/10499047.aspx
            // TODO: Should this be configurable?
            Thread.Sleep(100);
        }

        public static bool WaitUntilResponsive(AutomationElement automationElement)
        {
            return WaitUntilResponsive(automationElement, DefaultTimeout);
        }

        public static bool WaitUntilResponsive(AutomationElement automationElement, TimeSpan timeout)
        {
            var currentElement = automationElement;
            var treeWalker = automationElement.Automation.TreeWalkerFactory.GetControlViewWalker();
            while (currentElement.Info.NativeWindowHandle.ValueOrDefault == new IntPtr(0))
            {
                currentElement = treeWalker.GetParent(currentElement);
            }
            return WaitUntilResponsive(currentElement.Info.NativeWindowHandle, timeout);
        }

        public static bool WaitUntilResponsive(IntPtr hWnd)
        {
            return WaitUntilResponsive(hWnd, DefaultTimeout);
        }

        /// <summary>
        /// Waits until a window is responsive by sending a WM_NULL message.
        /// See: https://blogs.msdn.microsoft.com/oldnewthing/20161118-00/?p=94745
        /// </summary>
        public static bool WaitUntilResponsive(IntPtr hWnd, TimeSpan timeout)
        {
            UIntPtr result;
            var ret = User32.SendMessageTimeout(hWnd, WindowsMessages.WM_NULL,
                UIntPtr.Zero, IntPtr.Zero, SendMessageTimeoutFlags.SMTO_NORMAL, (uint)timeout.TotalMilliseconds, out result);
            // There might be other things going on so do a small sleep anyway...
            // Other sources: http://blogs.msdn.com/b/oldnewthing/archive/2014/02/13/10499047.aspx
            Thread.Sleep(20);
            return ret != new IntPtr(0);
        }
    }
}
