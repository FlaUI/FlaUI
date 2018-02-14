using System;
using System.Diagnostics;
using System.Management;

namespace FlaUI.Core.Tools
{
    public static class SystemInfo
    {
        private static readonly PerformanceCounter CpuCounter;
        private static readonly TimeSpan CpuReadInterval = TimeSpan.FromMilliseconds(500);
        private static DateTime _lastCpuRead;

        static SystemInfo()
        {
            CpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _lastCpuRead = DateTime.MinValue;
            CpuUsage = CpuCounter.NextValue();
            Refresh();
        }

        public static void Refresh()
        {
            // Get the RAM usage
            var osQuery = new WqlObjectQuery("SELECT * FROM Win32_OperatingSystem");
            var osSearcher = new ManagementObjectSearcher(osQuery);
            foreach (var os in osSearcher.Get())
            {
                PhysicalMemoryTotal = Convert.ToUInt64(os["TotalVisibleMemorySize"]) * 1024;
                PhysicalMemoryFree = Convert.ToUInt64(os["FreePhysicalMemory"]) * 1024;
                VirtualMemoryTotal = Convert.ToUInt64(os["TotalVirtualMemorySize"]) * 1024;
                VirtualMemoryFree = Convert.ToUInt64(os["FreeVirtualMemory"]) * 1024;
            }

            if (DateTime.UtcNow - _lastCpuRead > CpuReadInterval)
            {
                _lastCpuRead = DateTime.UtcNow;
                CpuUsage = Math.Round(CpuCounter.NextValue(), 2);
            }
        }

        public static double CpuUsage { get; private set; }

        public static ulong PhysicalMemoryTotal { get; private set; }
        public static ulong PhysicalMemoryFree { get; private set; }
        public static ulong PhysicalMemoryUsed => PhysicalMemoryTotal - PhysicalMemoryFree;
        public static double PhysicalMemoryFreePercent => Math.Round((double)PhysicalMemoryFree / PhysicalMemoryTotal * 100, 2);
        public static double PhysicalMemoryUsedPercent => Math.Round((double)PhysicalMemoryUsed / PhysicalMemoryTotal * 100, 2);

        public static ulong VirtualMemoryTotal { get; private set; }
        public static ulong VirtualMemoryFree { get; private set; }
        public static ulong VirtualMemoryUsed => VirtualMemoryTotal - VirtualMemoryFree;
        public static double VirtualMemoryFreePercent => Math.Round((double)VirtualMemoryFree / VirtualMemoryTotal * 100, 2);
        public static double VirtualMemoryUsedPercent => Math.Round((double)VirtualMemoryUsed / VirtualMemoryTotal * 100, 2);
    }
}
