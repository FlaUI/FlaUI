using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FlaUI.Core.Tools
{
    public static class WindowsStoreAppLauncher
    {
        public static Process Launch(string appUserModelId, string arguments)
        {
            var launcher = new ApplicationActivationManager();
            uint processId;
            launcher.ActivateApplication(appUserModelId, arguments, ActivateOptions.None, out processId);
            if (processId > 0)
            {
                return Process.GetProcessById((int)processId);
            }
            throw new Exception(String.Format("Could not launch Store App '{0}'", appUserModelId));
        }

        #region Win32
        // ReSharper disable InconsistentNaming
        [Flags]
        public enum ActivateOptions
        {
            None = 0x00000000,
            DesignMode = 0x00000001,
            NoErrorUI = 0x00000002,
            NoSplashScreen = 0x00000004,
        }

        [ComImport, Guid("2E941141-7F97-4756-BA1D-9DECDE894A3D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IApplicationActivationManager
        {
            IntPtr ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, [Out] out uint processId);
            IntPtr ActivateForFile([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [In] string verb, [Out] out uint processId);
            IntPtr ActivateForProtocol([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [Out] out uint processId);
        }

        [ComImport, Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C")]
        class ApplicationActivationManager : IApplicationActivationManager
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, [Out] out uint processId);
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateForFile([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [In] string verb, [Out] out uint processId);
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateForProtocol([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [Out] out uint processId);
        }
        // ReSharper restore InconsistentNaming
        #endregion Win32
    }
}
