using Microsoft.Win32;

namespace FlaUI.Core.Tools
{
    public static class SystemProductNameFetcher
    {
        public static bool IsCurrentOsContains(string name)
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            var productName = (string)reg.GetValue("ProductName");
            return productName.Contains(name);
        }

        public static bool IsWindows8_1()
        {
            return IsCurrentOsContains("Windows 8.1");
        }

        public static bool IsWindows10()
        {
            return IsCurrentOsContains("Windows 10");
        }
    }
}
