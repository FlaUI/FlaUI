using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core
{
    public class Application : IDisposable
    {
        /// <summary>
        /// The process of this application
        /// </summary>
        private readonly Process _process;

        private static readonly ILogger Log = new ConsoleLogger();

        /// <summary>
        /// Flag to indicate, if the application is a windows store app
        /// </summary>
        public bool IsStoreApp { get; }

        /// <summary>
        /// Application process id
        /// </summary>
        public int ProcessId => _process.Id;

        /// <summary>
        /// The name of the application
        /// </summary>
        public string Name => _process.ProcessName;

        public IntPtr MainWindowHandle => _process.MainWindowHandle;

        public Application(int processId, bool isStoreApp = false)
            : this(FindProcess(processId), isStoreApp)
        {
        }

        public Application(Process process, bool isStoreApp = false)
        {
            if (process == null)
            {
                throw new Exception("Process cannot be null");
            }
            _process = process;
            IsStoreApp = isStoreApp;
            WaitWhileBusy();
            WaitWhileMainHandleIsMissing();
        }

        public void Close()
        {
            Log.Info("Closing application");
            if (_process.HasExited)
            {
                _process.Dispose();
                return;
            }
            _process.CloseMainWindow();
            if (IsStoreApp)
            {
                return;
            }
            _process.WaitForExit(5000);
            if (!_process.HasExited)
            {
                Log.Info("Application failed to exit, killing process");
                _process.Kill();
                _process.WaitForExit(5000);
            }
            _process.Close();
            _process.Dispose();
        }

        /// <summary>
        /// Kills the applications and waits till it is closed
        /// </summary>
        public void Kill()
        {
            try
            {
                if (_process.HasExited) return;
                _process.Kill();
                _process.WaitForExit();
                _process.Dispose();
            }
            catch { }
        }

        private static Process FindProcess(int processId)
        {
            try
            {
                var process = Process.GetProcessById(processId);
                return process;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not find process with id: " + processId, ex);
            }
        }

        private static Process[] FindProcess(string executable)
        {
            var processes = Process.GetProcessesByName(executable.Replace(".exe", string.Empty));
            return processes;
        }

        public static Application Attach(int processId)
        {
            return Attach(FindProcess(processId));
        }

        public static Application Attach(Process process)
        {
            Log.DebugFormat("[Attaching process:{0}] [Process name {1}] [Process full path:{1}]", process.Id, process.ProcessName, process.MainModule.FileName);
            return new Application(process);
        }

        public static Application Attach(string executable)
        {
            return new Application(FindProcess(executable)[0]);        
        }

        public static Application AttachOrLaunch(ProcessStartInfo processStartInfo)
        {
            var processes = FindProcess(processStartInfo.FileName);
            return processes.Length == 0 ? Launch(processStartInfo) : Attach(processes[0]);
        }

        public static Application Launch(string executable)
        {
            var processStartInfo = new ProcessStartInfo(executable);
            return Launch(processStartInfo);
        }

        public static Application Launch(ProcessStartInfo processStartInfo)
        {
            if (String.IsNullOrEmpty(processStartInfo.WorkingDirectory))
            {
                processStartInfo.WorkingDirectory = ".";
            }

            Log.DebugFormat("[Launching process:{0}] [Working directory:{1}] [Process full path:{2}] [Current Directory:{3}]",
                processStartInfo.FileName,
                new DirectoryInfo(processStartInfo.WorkingDirectory).FullName,
                new FileInfo(processStartInfo.FileName).FullName,
                Environment.CurrentDirectory);

            Process process;
            try
            {
                process = Process.Start(processStartInfo);
            }
            catch (Win32Exception ex)
            {
                var error = String.Format(
                    "[Failed Launching process:{0}] [Working directory:{1}] [Process full path:{2}] [Current Directory:{3}]",
                    processStartInfo.FileName,
                    new DirectoryInfo(processStartInfo.WorkingDirectory).FullName,
                    new FileInfo(processStartInfo.FileName).FullName,
                    Environment.CurrentDirectory);
                Log.Error(error, ex);
                throw;
            }

            return new Application(process);
        }

        public static Application LaunchStoreApp(string appUserModelId, string arguments = null)
        {
            var process = WindowsStoreAppLauncher.Launch(appUserModelId, arguments);
            return new Application(process, true);
        }

        /// <summary>
        /// Waits as long as the application is busy
        /// </summary>
        public void WaitWhileBusy(TimeSpan? waitTimeout = null)
        {
            var waitTime = (waitTimeout ?? TimeSpan.FromMilliseconds(500)).TotalMilliseconds;
            _process.WaitForInputIdle((int)waitTime);
        }

        /// <summary>
        /// Waits until the main handle is set
        /// </summary>
        private void WaitWhileMainHandleIsMissing()
        {
            while (_process.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(50);
                _process.Refresh();
            }
        }

        public Window GetMainWindow(AutomationBase automation)
        {
            return automation.FromHandle(MainWindowHandle).AsWindow();
        }

        public void Dispose()
        {
            Close();
        }
    }
}
