using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace FlaUI.Core.Tools
{
    /// <summary>
    /// Wrapper for com calls
    /// </summary>
    public static class ComCallWrapper
    {
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
                var errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, ex.Message);
            }
        }
    }
}