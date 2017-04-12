using System;
using Microsoft.Win32;

namespace FlaUI.Core.Tools
{
    public static class SystemProductNameFetcher
    {
        public static bool CurrentOsContains(string name)
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
            return productName.Contains(name);
        }

        public static bool IsWindows8_1()
        {
            return CurrentOsContains("Windows 8.1");
        }

        public static bool IsWindows10()
        {
            return CurrentOsContains("Windows 10");
        }
    }
}
