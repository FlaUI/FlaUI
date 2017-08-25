using System;
using System.Globalization;
using Microsoft.Win32;

namespace FlaUI.Core.Tools
{
    /// <summary>
    /// Static class that can be used to get information about the current operating system.
    /// </summary>
    public static class OperatingSystem
    {
        private static readonly string CurrentProductName;

        static OperatingSystem()
        {
            CurrentProductName = GetCurrentProductName();
        }

        /// <summary>
        /// Gets the current <see cref="CultureInfo"/>.
        /// </summary>
        public static CultureInfo CurrentCulture => CultureInfo.InstalledUICulture;

        /// <summary>
        /// Checks if the current operating system name contains the given string.
        /// </summary>
        public static bool CurrentProductContains(string name)
        {
            return CurrentProductName.Contains(name);
        }

        /// <summary>
        /// Checks if the current operating system is Windows 8.1.
        /// </summary>
        public static bool IsWindows8_1()
        {
            return CurrentProductContains("Windows 8.1");
        }

        /// <summary>
        /// Checks if the current operating system is Windows 10.
        /// </summary>
        public static bool IsWindows10()
        {
            return CurrentProductContains("Windows 10");
        }

        /// <summary>
        /// Checks if the current operating system is Windows Server 2016.
        /// </summary>
        public static bool IsWindowsServer2016()
        {
            return CurrentProductContains("Windows Server 2016");
        }

        private static string GetCurrentProductName()
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (reg == null)
            {
                throw new Exception("Could not find the registry path needed for determining the OS version.");
            }
            var productName = (string)reg.GetValue("ProductName");
            if (productName == null)
            {
                throw new Exception("Could not find the registry key needed for determining the OS version.");
            }
            return productName;
        }
    }
}
