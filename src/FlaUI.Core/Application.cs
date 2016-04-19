using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Logging;
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
        private readonly Process process;
        private static readonly ILogger Log = new ConsoleLogger();

        public string Name
        {
            get { return process.ProcessName; }
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
            this.process = process;
            WaitWhileBusy();
            WaitWhileMainHandleIsMissing();
        }

        public void Close()
        {
            Log.Info("Closing application");
            if (process.HasExited)
            {
                process.Dispose();
                return;
            }
            process.CloseMainWindow();
            process.WaitForExit(5000);
            if (!process.HasExited)
            {
                Log.Info("Application failed to exit, killing process");
                process.Kill();
                process.WaitForExit(5000);
            }
            process.Close();
            process.Dispose();
        }

        /// <summary>
        /// Kills the applications and waits till it is closed
        /// </summary>
        public void Kill()
        {
            try
            {
                if (process.HasExited) return;
                process.Kill();
                process.WaitForExit();
                process.Dispose();
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

        /// <summary>
        /// Waits as long as the application is busy
        /// </summary>
        public void WaitWhileBusy(TimeSpan? waitTimeout = null)
        {
            var waitTime = (waitTimeout ?? TimeSpan.FromMilliseconds(500)).TotalMilliseconds;
            process.WaitForInputIdle((int)waitTime);
        }

        /// <summary>
        /// Waits until the main handle is set
        /// </summary>
        private void WaitWhileMainHandleIsMissing()
        {
            while (process.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(50);
                process.Refresh();
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


        public Window GetWindow(string title)
        {
            var desktop = Automation.Instance.GetRootElement();
            var windows = desktop.FindAll(interop.UIAutomationCore.TreeScope.TreeScope_Children,
                Automation.Instance.CreateAndCondition(
                    Automation.Instance.CreatePropertyCondition((int)PropertyType.ControlType, ControlType.Window),
                    Automation.Instance.CreatePropertyCondition((int)PropertyType.ProcessId, process.Id)));
            return new Window(windows.GetElement(0));
        }

        //public virtual Window GetWindow(string title)
        //{
        //    return GetWindow(title, InitializeOption.NoCache);
        //}

        //public virtual Window GetWindow(SearchCriteria searchCriteria, InitializeOption initializeOption)
        //{
        //    WindowSession windowSession = applicationSession.WindowSession(initializeOption);
        //    return windowFactory.CreateWindow(searchCriteria, process, initializeOption, windowSession);
        //}

        //public virtual List<Window> GetWindows()
        //{
        //    return windowFactory.DesktopWindows(process, new NoApplicationSession());
        //}

        //public virtual Window FindSplash()
        //{
        //    return windowFactory.SplashWindow(process);
        //}

        //public virtual Window Find(Predicate<string> match, InitializeOption initializeOption)
        //{
        //    WindowSession windowSession = applicationSession.WindowSession(initializeOption);
        //    return windowFactory.FindWindow(process, match, initializeOption, windowSession);
        //}
        #endregion Window
    }
}
