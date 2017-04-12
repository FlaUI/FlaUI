using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using FlaUI.Core.Exceptions;

namespace FlaUI.Core.Tools
{
    /// <summary>
    /// Wrapper for com calls
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "To keep the original Win32 names")]
    public static class ComCallWrapper
    {
        #region Error Ids
        /// <summary>
        /// Indicates that a method that requires an enabled element, such as ISelectionItemProvider::Select or IExpandCollapseProvider::Expand, was called on an element that was disabled.
        /// </summary>
        public const uint UIA_E_ELEMENTNOTENABLED = 0x80040200;
        /// <summary>
        /// Indicates that a method was called on a virtualized element, or on an element that no longer exists, usually because it has been destroyed.
        /// </summary>
        public const uint UIA_E_ELEMENTNOTAVAILABLE = 0x80040201;
        /// <summary>
        /// Indicates that the IUIAutomationElement::GetClickablePoint method was called on an element that has no clickable point.
        /// </summary>
        public const uint UIA_E_NOCLICKABLEPOINT = 0x80040202;
        /// <summary>
        /// Indicates that a problem occurred when loading an assembly that contains a client - side provider.
        /// </summary>
        public const uint UIA_E_PROXYASSEMBLYNOTLOADED = 0x80040203;
        /// <summary>
        /// Indicates that the provider explicitly does not support the specified property or control pattern. UI Automation will return this error code to the caller without attempting to provide a default value or falling back to another provider.
        /// </summary>
        public const uint UIA_E_NOTSUPPORTED = 0x80040204;
        /// <summary>
        /// Indicates that the time allotted for a process or operation has expired.
        /// </summary>
        public const uint UIA_E_TIMEOUT = 0x80131505;
        /// <summary>
        /// Indicates that the method attempted an operation that was not valid.
        /// </summary>
        public const uint UIA_E_INVALIDOPERATION = 0x80131509;
        #endregion Error Ids

        /// <summary>
        /// Wraps an action with a com call and throws the correct win32 exception in case of an error
        /// </summary>
        public static void Call(Action nativeAction)
        {
            try
            {
                nativeAction();
            }
            catch (COMException ex)
            {
                Exception newEx;
                if (ConvertException(ex, out newEx))
                {
                    throw newEx;
                }
                var errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, ex.Message);
            }
        }

        public static void CallWithHResult(Func<int> nativeAction)
        {
            try
            {
                var hr = nativeAction();
                if (hr != 0)
                {
                    throw Marshal.GetExceptionForHR(hr);
                }
            }
            catch (COMException ex)
            {
                Exception newEx;
                if (ConvertException(ex, out newEx))
                {
                    throw newEx;
                }
                var errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, ex.Message);
            }
        }

        public static T Call<T>(Func<T> nativeAction)
        {
            try
            {
                return nativeAction();
            }
            catch (COMException ex)
            {
                Exception newEx;
                if (ConvertException(ex, out newEx))
                {
                    throw newEx;
                }
                var errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, ex.Message);
            }
        }

        public static bool ConvertException(COMException ex, out Exception uiaException)
        {
            var handled = true;
            switch ((uint)ex.ErrorCode)
            {
                case UIA_E_ELEMENTNOTENABLED:
                    uiaException = new ElementNotEnabledException(ex);
                    break;
                case UIA_E_ELEMENTNOTAVAILABLE:
                    uiaException = new ElementNotAvailableException(ex);
                    break;
                case UIA_E_NOCLICKABLEPOINT:
                    uiaException = new NoClickablePointException(ex);
                    break;
                case UIA_E_PROXYASSEMBLYNOTLOADED:
                    uiaException = new ProxyAssemblyNotLoadedException(ex);
                    break;
                case UIA_E_TIMEOUT:
                    uiaException = new TimeoutException("UIA Timeout", ex);
                    break;
                case UIA_E_NOTSUPPORTED:
                    uiaException = new Exceptions.NotSupportedException(ex);
                    break;
                case UIA_E_INVALIDOPERATION:
                    uiaException = new InvalidOperationException("UIA Invalid Operation", ex);
                    break;

                default:
                    uiaException = null;
                    handled = false;
                    break;
            }
            return handled;
        }
    }
}
