using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace FlaUI.Core
{
    public class Application
    {
        private readonly Process _process;
        private static readonly ILogger Log = new ConsoleLogger();

        public string Name
        {
            get { return _process.ProcessName; }
        }

        public Application(int processId)
            : this(FindProcess(processId))
        {
        }

        public Application(Process process)
        {
            if (process == null)
            {
                throw new Exception("Process cannot be null");
            }
            this._process = process;
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
            return new Application(process);
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

        #region Window

        /// <summary>
        /// Gets the root element (desktop)
        /// </summary>
        public IUIAutomationElement GetDektop()
        {
            var desktop = Automation.Instance.GetRootElement();
            return desktop;
        }

        /// <summary>
        /// Gets the window from the MainWindowHandle of the process
        /// </summary>
        public Window GetMainWindow()
        {
            var win = Automation.Instance.ElementFromHandle(_process.MainWindowHandle);
            return new Window(win);
        }

        public Window GetWindow(string title)
        {
            var desktop = Automation.Instance.GetRootElement();
            var windows = desktop.FindAll(TreeScope.TreeScope_Children,
                Automation.Instance.CreateAndCondition(
                    Automation.Instance.CreatePropertyCondition((int)PropertyType.ControlType, ControlType.Window),
                    Automation.Instance.CreatePropertyCondition((int)PropertyType.ProcessId, _process.Id)));
            return new Window(windows.GetElement(0));
        }
        #endregion Window
    }
}
