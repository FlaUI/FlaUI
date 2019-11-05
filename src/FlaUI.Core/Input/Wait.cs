using System;
using System.Threading;
using FlaUI.Core.AutomationElements;
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

        /// <summary>
        /// Waits until the given element is responsive.
        /// </summary>
        /// <param name="automationElement">The element that should be waited for.</param>
        /// <returns>True if the element was responsive, false otherwise.</returns>
        public static bool UntilResponsive(AutomationElement automationElement)
        {
            return UntilResponsive(automationElement, DefaultTimeout);
        }

        /// <summary>
        /// Waits until the given element is responsive.
        /// </summary>
        /// <param name="automationElement">The element that should be waited for.</param>
        /// <param name="timeout">The timeout of the waiting.</param>
        /// <returns>True if the element was responsive, false otherwise.</returns>
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

        /// <summary>
        /// Waits until the given hwnd is responsive.
        /// See: https://blogs.msdn.microsoft.com/oldnewthing/20161118-00/?p=94745
        /// </summary>
        /// <param name="hWnd">The hwnd that should be waited for.</param>
        /// <returns>True if the hwnd was responsive, false otherwise.</returns>
        public static bool UntilResponsive(IntPtr hWnd)
        {
            return UntilResponsive(hWnd, DefaultTimeout);
        }

        /// <summary>
        /// Waits until the given hwnd is responsive.
        /// See: https://blogs.msdn.microsoft.com/oldnewthing/20161118-00/?p=94745
        /// </summary>
        /// <param name="hWnd">The hwnd that should be waited for.</param>
        /// <param name="timeout">The timeout of the waiting.</param>
        /// <returns>True if the hwnd was responsive, false otherwise.</returns>
        public static bool UntilResponsive(IntPtr hWnd, TimeSpan timeout)
        {
            var ret = User32.SendMessageTimeout(hWnd, WindowsMessages.WM_NULL,
                UIntPtr.Zero, IntPtr.Zero, SendMessageTimeoutFlags.SMTO_NORMAL, (uint)timeout.TotalMilliseconds, out _);
            // There might be other things going on so do a small sleep anyway...
            // Other sources: http://blogs.msdn.com/b/oldnewthing/archive/2014/02/13/10499047.aspx
            Thread.Sleep(20);
            return ret != IntPtr.Zero;
        }
    }
}
