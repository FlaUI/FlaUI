using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Security;

namespace FlaUI.Core.WindowsAPI
{
    public static class WindowsApiTools
    {
        [SecurityCritical]
        public static bool DoesWin32MethodExist(string moduleName, string methodName)
        {
            IntPtr hModule = Kernel32.GetModuleHandle(moduleName);
            if (hModule == IntPtr.Zero)
            {
                return false;
            }
            IntPtr functionPointer = Kernel32.GetProcAddress(hModule, methodName);
            return functionPointer != IntPtr.Zero;
        }

        public static bool IsCurrentProcess64Bit()
        {
            return IntPtr.Size == 8;
        }

        public static bool IsProcess64Bit(Process process)
        {
            return IsProcess64Bit(process.Handle);
        }

        public static bool IsProcess64Bit(IntPtr processHandle)
        {
            if (!Tools.OperatingSystem.Is64Bit)
            {
                // The system is only 32 bit
                return false;
            }
            // The process is NOT running in the WOW64 emulator
            return DoesWin32MethodExist(Kernel32.KERNEL32, "IsWow64Process")
                        && Kernel32.IsWow64Process(processHandle, out bool isWow64)
                        && !isWow64;
        }

        /// <summary>
        /// Tries to get the executable path for a given process.
        /// </summary>
        public static string? GetMainModuleFilepath(Process process)
        {
            // Workaround for when the current process is 32 bit and the otherto get the info is 64 bit.
            if (Tools.OperatingSystem.Is64Bit && !IsCurrentProcess64Bit())
            {
                var wmiQueryString = $"SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = {process.Id}";
                using (var searcher = new ManagementObjectSearcher(wmiQueryString))
                {
                    using (var results = searcher.Get())
                    {
                        var mo = results.Cast<ManagementObject>().FirstOrDefault();
                        if (mo != null)
                        {
                            return (string)mo["ExecutablePath"];
                        }
                    }
                }
                return null;
            }
            return process.MainModule?.FileName;
        }
    }
}
