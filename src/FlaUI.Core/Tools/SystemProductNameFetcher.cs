using System;
using Microsoft.Win32;

namespace FlaUI.Core.Tools
{
    public static class SystemProductNameFetcher
    {
        private static readonly string CurrentProductName;

        static SystemProductNameFetcher()
        {
            CurrentProductName = GetCurrentProductName();
        }

        public static bool CurrentProductContains(string name)
        {
            return CurrentProductName.Contains(name);
        }

        public static bool IsWindows8_1()
        {
            return CurrentProductContains("Windows 8.1");
        }

        public static bool IsWindows10()
        {
            return CurrentProductContains("Windows 10");
        }

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
