using System;
using System.Diagnostics;
using System.Management;

namespace FlaUI.Core.Tools
{
    public static class SystemInfo
    {
        private static readonly PerformanceCounter CpuCounter;
        private static DateTime _lastCpuRead;
        private static DateTime _lastMemoryRead;

        static SystemInfo()
        {
            CpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            CpuUsage = CpuCounter.NextValue();
            _lastCpuRead = DateTime.MinValue;
            _lastMemoryRead = DateTime.MinValue;
            RefreshAll();
        }

        /// <summary>
        /// As the operations to get the memory/cpu values are quite slow, this interval is used to not refresh too often.
        /// </summary>
        public static TimeSpan MinimumRefreshInterval { get; set; } = TimeSpan.FromSeconds(1);

        public static void RefreshAll()
        {
            RefreshMemory();
            RefreshCpu();
        }

        public static void RefreshMemory()
        {
            if (DateTime.UtcNow - _lastMemoryRead > MinimumRefreshInterval)
            {
                var osQuery = new WqlObjectQuery("SELECT * FROM Win32_OperatingSystem");
                var osSearcher = new ManagementObjectSearcher(osQuery);
                foreach (var os in osSearcher.Get())
                {
                    PhysicalMemoryTotal = Convert.ToUInt64(os["TotalVisibleMemorySize"]) * 1024;
                    PhysicalMemoryFree = Convert.ToUInt64(os["FreePhysicalMemory"]) * 1024;
                    VirtualMemoryTotal = Convert.ToUInt64(os["TotalVirtualMemorySize"]) * 1024;
                    VirtualMemoryFree = Convert.ToUInt64(os["FreeVirtualMemory"]) * 1024;
                }
                _lastMemoryRead = DateTime.UtcNow;
            }
        }

        public static void RefreshCpu()
        {
            if (DateTime.UtcNow - _lastCpuRead > MinimumRefreshInterval)
            {
                CpuUsage = Math.Round(CpuCounter.NextValue(), 2);
                _lastCpuRead = DateTime.UtcNow;
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
