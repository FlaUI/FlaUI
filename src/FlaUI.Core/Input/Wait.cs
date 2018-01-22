using System;
using System.Threading;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Class with various helper tools used in various places
    /// </summary>
    public static class Wait
    {
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Waits a little to allow inputs (mouse, keyboard, ...) to be processed.
        /// </summary>
        /// <param name="waitTimeout">An optional timeout. If no value or null is passed, the timeout is 100ms.</param>
        public static void UntilInputIsProcessed(TimeSpan? waitTimeout = null)
        {
            // Let the thread some time to process the system's hardware input queue.
            // For details see this post: http://blogs.msdn.com/b/oldnewthing/archive/2014/02/13/10499047.aspx
            var waitTime = (waitTimeout ?? TimeSpan.FromMilliseconds(100)).TotalMilliseconds;
            Thread.Sleep((int)waitTime);
        }

        public static bool UntilResponsive(AutomationElement automationElement)
        {
            return UntilResponsive(automationElement, DefaultTimeout);
        }

        public static bool UntilResponsive(AutomationElement automationElement, TimeSpan timeout)
        {
            var currentElement = automationElement;
            var treeWalker = automationElement.Automation.TreeWalkerFactory.GetControlViewWalker();
            while (currentElement.Properties.NativeWindowHandle.ValueOrDefault == new IntPtr(0))
            {
                currentElement = treeWalker.GetParent(currentElement);
            }
            return UntilResponsive(currentElement.Properties.NativeWindowHandle, timeout);
        }

        public static bool UntilResponsive(IntPtr hWnd)
        {
            return UntilResponsive(hWnd, DefaultTimeout);
        }

        /// <summary>
        /// Waits until a window is responsive by sending a WM_NULL message.
        /// See: https://blogs.msdn.microsoft.com/oldnewthing/20161118-00/?p=94745
        /// </summary>
        public static bool UntilResponsive(IntPtr hWnd, TimeSpan timeout)
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
