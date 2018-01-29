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
        // Numbers taken from: https://www.gaijin.at/en/lstwinver.php
        public static readonly Version Windows2000 = new Version(5, 0, 2195);
        public static readonly Version WindowsXP = new Version(5, 1, 2600);
        public static readonly Version WindowsVista = new Version(6, 0, 6000);
        public static readonly Version WindowsVistaSP1 = new Version(6, 0, 6001);
        public static readonly Version WindowsVistaSP2 = new Version(6, 0, 6002);
        public static readonly Version Windows7 = new Version(6, 1, 7600);
        public static readonly Version Windows7SP1 = new Version(6, 1, 7601);
        public static readonly Version Windows8 = new Version(6, 2, 9200);
        public static readonly Version Windows81 = new Version(6, 3, 9200);
        public static readonly Version Windows81U1 = new Version(6, 3, 9600);
        public static readonly Version Windows10 = new Version(10, 0, 10240); // 1507
        public static readonly Version Windows10NovemberUpdate = new Version(10, 0, 10586); // 1511
        public static readonly Version Windows10AnniversaryUpdate = new Version(10, 0, 14393); // 1607
        public static readonly Version Windows10CreatorsUpdate = new Version(10, 0, 15063); // 1703
        public static readonly Version Windows10FallCreatorsUpdate = new Version(10, 0, 16299); // 1709
        public static readonly Version WindowsServer2003 = new Version(5, 2, 3790);
        public static readonly Version WindowsServer2008 = WindowsVistaSP1;
        public static readonly Version WindowsServer2008R2 = Windows7;
        public static readonly Version WindowsServer2008R2SP1 = Windows7SP1;
        public static readonly Version WindowsServer2012 = Windows8;
        public static readonly Version WindowsServer2012R2 = Windows81;
        public static readonly Version WindowsServer2016 = Windows10AnniversaryUpdate;

        static OperatingSystem()
        {
            var version = GetVersion();
            var build = GetBuildNumber();
            var revision = GetUpdateBuildRevision();
            var versionParts = version.Split('.');
            var major = versionParts.Length > 0 ? versionParts[0] : "0";
            var minor = versionParts.Length > 1 ? versionParts[1] : "0";
            Version = new Version(Convert.ToInt32(major), Convert.ToInt32(minor), Convert.ToInt32(build), Convert.ToInt32(revision));
        }

        /// <summary>
        /// The full version number of the current system.
        /// </summary>
        public static Version Version { get; }

        /// <summary>
        /// Gets the current <see cref="CultureInfo"/>.
        /// </summary>
        public static CultureInfo CurrentCulture => CultureInfo.InstalledUICulture;

        /// <summary>
        /// Checks if the current operating system name contains the given string.
        /// </summary>
        public static bool CurrentProductContains(string name)
        {
            return GetProductName().Contains(name);
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

        /// <summary>
        /// Gets the product name in plain text.
        /// </summary>
        private static string GetProductName()
        {
            return GetRegistryValue<string>("ProductName");
        }

        /// <summary>
        /// Gets the internal build number.
        /// </summary>
        private static string GetBuildNumber()
        {
            return GetRegistryValue<string>("CurrentBuild");
        }

        /// <summary>
        /// Gets the release (Windows 10).
        /// </summary>
        private static string GetRelease()
        {
            return GetRegistryValue<string>("ReleaseId");
        }

        /// <summary>
        /// Gets the version numnber.
        /// </summary>
        private static string GetVersion()
        {
            // Old version, works until Windows 8
            var version = GetRegistryValue<string>("CurrentVersion");
            // New version, starting to work with Windows 10
            var major = GetRegistryValue<int>("CurrentMajorVersionNumber");
            if (major > 0)
            {
                var minor = GetRegistryValue<int>("CurrentMinorVersionNumber");
                version = $"{major}.{minor}";
            }
            return version;
        }

        /// <summary>
        /// Gets the current update build revision.
        /// </summary>
        private static string GetUpdateBuildRevision()
        {
            return GetRegistryValue<int>("UBR").ToString();
        }

        private static T GetRegistryValue<T>(string keyName)
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (reg != null)
            {
                var value = (T)reg.GetValue(keyName);
                if (value != null)
                {
                    return value;
                }
            }
            return default(T);
        }
    }
}
