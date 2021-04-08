using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace FlaUI.Core.WindowsAPI
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class Kernel32
    {
        public const string KERNEL32 = "kernel32.dll";

        [DllImport(KERNEL32)]
        public static extern uint GetCurrentThreadId();

        [DllImport(KERNEL32, CharSet = CharSet.Auto, BestFitMapping = false, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [ResourceExposure(ResourceScope.Process)]  // Is your module side-by-side?
        public static extern IntPtr GetModuleHandle(String moduleName);

        [DllImport(KERNEL32, CharSet = CharSet.Ansi, BestFitMapping = false, SetLastError = true, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, String methodName);

        [DllImport(KERNEL32, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool IsWow64Process([In] IntPtr hSourceProcessHandle, [Out, MarshalAs(UnmanagedType.Bool)] out bool isWow64);
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
