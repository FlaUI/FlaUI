using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core
{
    /// <summary>
    /// Wrapper for an application which should be automated.
    /// </summary>
    public class Application : IDisposable
    {
        /// <summary>
        /// The process of this application.
        /// </summary>
        private Process _process;

        /// <summary>
        /// Flag to indicate if Dispose has already been called.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Flag to indicate whether this instance owns the <see cref="_process"/> and should dispose it.
        /// When <see langword="false"/> (e.g. created via <see cref="Attach(Process)"/> or
        /// <see cref="Application(Process, bool)"/> with an externally-owned process), the caller
        /// retains ownership and FlaUI will not dispose or replace the <see cref="Process"/> object.
        /// </summary>
        private readonly bool _ownsProcess;

        /// <summary>
        /// The timeout to wait to close an application gracefully.
        /// </summary>
        public TimeSpan CloseTimeout { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Flag to indicate, if the application is a windows store app.
        /// </summary>
        public bool IsStoreApp { get; }

        /// <summary>
        /// The process id of the application.
        /// </summary>
        public int ProcessId => _process.Id;

        /// <summary>
        /// The name of the application's process.
        /// </summary>
        public string Name => _process.ProcessName;

        /// <summary>
        /// The current handle (Win32) of the application's main window.
        /// Can be IntPtr.Zero if no main window is currently available.
        /// </summary>
        public IntPtr MainWindowHandle => _process.MainWindowHandle;

        /// <summary>
        /// Gets a value indicating whether the associated process has been terminated.
        /// </summary>
        public bool HasExited => _process.HasExited;

        /// <summary>
        /// Gets the value that the associated process specified when it terminated.
        /// </summary>
        public int ExitCode => _process.ExitCode;

        /// <summary>
        /// Creates an application object with the given process id.
        /// FlaUI looks up the process internally and therefore owns the resulting <see cref="Process"/> object.
        /// </summary>
        /// <param name="processId">The process id.</param>
        /// <param name="isStoreApp">Flag to define if it's a store app or not.</param>
        public Application(int processId, bool isStoreApp = false)
            : this(FindProcess(processId), isStoreApp, ownsProcess: true)
        {
        }

        /// <summary>
        /// Creates an application object with the given process.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <param name="isStoreApp">Flag to define if it's a store app or not.</param>
        /// <remarks>
        /// The caller retains ownership of <paramref name="process"/>. FlaUI will not dispose it.
        /// If you want FlaUI to manage the process lifetime, use <see cref="Application(int, bool)"/> or
        /// one of the <see cref="Launch(string, string)"/> factory methods instead.
        /// </remarks>
        public Application(Process process, bool isStoreApp = false)
            : this(process, isStoreApp, ownsProcess: false)
        {
        }

        /// <summary>
        /// Internal constructor that allows specifying process ownership explicitly.
        /// </summary>
        /// <param name="process">The process to wrap.</param>
        /// <param name="isStoreApp">Flag to define if it's a store app or not.</param>
        /// <param name="ownsProcess">
        /// <see langword="true"/> if this instance should dispose <paramref name="process"/> when it is disposed;
        /// <see langword="false"/> to leave ownership with the caller.
        /// </param>
        private Application(Process process, bool isStoreApp, bool ownsProcess)
        {
            _process = process ?? throw new ArgumentNullException(nameof(process));
            IsStoreApp = isStoreApp;
            _ownsProcess = ownsProcess;
        }

        /// <summary>
        /// Closes the application. Force-closes it after a small timeout.
        /// </summary>
        /// <param name="killIfCloseFails">A flag to indicate if the process should be killed if closing fails within the <see cref="CloseTimeout"/>.</param>
        /// <returns>Returns true if the application was closed normally and false if it could not be closed gracefully.</returns>
        public bool Close(bool killIfCloseFails = true)
        {
            Logger.Default.Debug("Closing application");
            if (_disposed || _process.HasExited)
            {
                return true;
            }
            _process.CloseMainWindow();
            if (IsStoreApp)
            {
                return true;
            }
            // Gracefully wait until it exits
            _process.WaitForExit((int)CloseTimeout.TotalMilliseconds);
            if (!_process.HasExited)
            {
                // It hasn't exited yet so kill it
                Logger.Default.Info("Application failed to exit");
                if (killIfCloseFails)
                {
                    _process.Kill();
                    _process.WaitForExit(5000);
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kills the applications and waits until it is closed.
        /// </summary>
        public void Kill()
        {
            try
            {
                if (_process.HasExited)
                {
                    return;
                }
                _process.Kill();
                _process.WaitForExit();
            }
            catch
            {
                // NOOP
            }
        }

        /// <summary>
        /// Disposes the application.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the application.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing && _ownsProcess)
            {
                _process?.Dispose();
            }
            _disposed = true;
        }

        /// <summary>
        /// Attaches to a given process id.
        /// </summary>
        /// <param name="processId">The id of the process to attach to.</param>
        /// <returns>An application instance which is attached to the process.</returns>
        public static Application Attach(int processId)
        {
            var process = FindProcess(processId);
            Logger.Default.Debug($"[Attaching to process:{process.Id}] [Process name:{process.ProcessName}] [Process full path:{WindowsApiTools.GetMainModuleFilepath(process)}]");
            return new Application(process, isStoreApp: false, ownsProcess: true);
        }

        /// <summary>
        /// Attaches to a given process.
        /// The caller retains ownership of <paramref name="process"/>; FlaUI will not dispose it.
        /// </summary>
        /// <param name="process">The process to attach to.</param>
        /// <returns>An application instance which is attached to the process.</returns>
        public static Application Attach(Process process)
        {
            Logger.Default.Debug($"[Attaching to process:{process.Id}] [Process name:{process.ProcessName}] [Process full path:{WindowsApiTools.GetMainModuleFilepath(process)}]");
            return new Application(process, isStoreApp: false, ownsProcess: false);
        }

        /// <summary>
        /// Attaches to a running process which has the given executable.
        /// </summary>
        /// <param name="executable">The executable of the process to attach to.</param>
        /// <param name="index">Defines the index of the process to use in case multiple are found.</param>
        /// <returns>An application instance which is attached to the process.</returns>
        public static Application Attach(string executable, int index = 0)
        {
            var processes = FindProcess(executable);
            if (processes.Length > index)
            {
                return Attach(processes[index]);
            }
            throw new Exception("Unable to find process with name: " + executable);
        }

        /// <summary>
        /// Attaches or launches the given process.
        /// </summary>
        public static Application AttachOrLaunch(ProcessStartInfo processStartInfo)
        {
            var processes = FindProcess(processStartInfo.FileName);
            return processes.Length == 0 ? Launch(processStartInfo) : Attach(processes[0]);
        }

        /// <summary>
        /// Launches the given executable.
        /// </summary>
        /// <param name="executable">The executable to launch.</param>
        /// <param name="arguments">Arguments to executable</param>
        public static Application Launch(string executable, string arguments = "")
        {
            var processStartInfo = new ProcessStartInfo(executable, arguments);
            return Launch(processStartInfo);
        }

        /// <summary>
        /// Launches an application with the given process information.
        /// </summary>
        /// <param name="processStartInfo">The process information used to launch the application.</param>
        public static Application Launch(ProcessStartInfo processStartInfo)
        {
            if (String.IsNullOrEmpty(processStartInfo.WorkingDirectory))
            {
                processStartInfo.WorkingDirectory = ".";
            }

            Logger.Default.Debug("[Launching process:{0}] [Working directory:{1}] [Process full path:{2}] [Current Directory:{3}]",
                processStartInfo.FileName,
                new DirectoryInfo(processStartInfo.WorkingDirectory).FullName,
                new FileInfo(processStartInfo.FileName).FullName,
                Environment.CurrentDirectory);

            Process process;
            try
            {
                process = Process.Start(processStartInfo)!;
            }
            catch (Win32Exception ex)
            {
                var error = String.Format(
                    "[Failed Launching process:{0}] [Working directory:{1}] [Process full path:{2}] [Current Directory:{3}]",
                    processStartInfo.FileName,
                    new DirectoryInfo(processStartInfo.WorkingDirectory).FullName,
                    new FileInfo(processStartInfo.FileName).FullName,
                    Environment.CurrentDirectory);
                Logger.Default.Error(error, ex);
                throw;
            }

            return new Application(process, isStoreApp: false, ownsProcess: true);
        }

        /// <summary>
        /// Launches a store application.
        /// </summary>
        /// <param name="appUserModelId">The app id of the application to launch.</param>
        /// <param name="arguments">The arguments to pass to the application.</param>
        public static Application LaunchStoreApp(string appUserModelId, string arguments = "")
        {
            var process = WindowsStoreAppLauncher.Launch(appUserModelId, arguments);
            return new Application(process, isStoreApp: true, ownsProcess: true);
        }

        /// <summary>
        /// Waits as long as the application is busy.
        /// </summary>
        /// <param name="waitTimeout">An optional timeout. If null is passed, the timeout is infinite.</param>
        /// <returns>True if the application is idle, false otherwise.</returns>
        public bool WaitWhileBusy(TimeSpan? waitTimeout = null)
        {
            var waitTime = (waitTimeout ?? TimeSpan.FromMilliseconds(-1)).TotalMilliseconds;
            return _process.WaitForInputIdle((int)waitTime);
        }

        /// <summary>
        /// Waits until the main handle is set.
        /// </summary>
        /// <param name="waitTimeout">An optional timeout. If null is passed, the timeout is infinite.</param>
        /// <returns>True a main window handle was found, false otherwise.</returns>
        public bool WaitWhileMainHandleIsMissing(TimeSpan? waitTimeout = null)
        {
            var waitTime = waitTimeout ?? TimeSpan.FromMilliseconds(-1);
            return Retry.WhileTrue(() =>
            {
                // Refresh the Process object so the MainWindowHandle cache is cleared.
                // When FlaUI owns the process it can safely dispose and re-fetch; otherwise
                // a fresh Process snapshot is used temporarily without touching the caller's instance.
                if (_ownsProcess)
                {
                    int processId = _process.Id;
                    _process.Dispose();
                    _process = FindProcess(processId);
                }
                else
                {
                    // We don't own the process — use a temporary snapshot to read the current handle
                    // without disposing or replacing the caller's Process instance.
                    using var snapshot = FindProcess(_process.Id);
                    return snapshot.MainWindowHandle == IntPtr.Zero;
                }
                return _process.MainWindowHandle == IntPtr.Zero;
            }, waitTime, TimeSpan.FromMilliseconds(50)).Result;
        }

        /// <summary>
        /// Gets the main window of the applications process.
        /// </summary>
        /// <param name="automation">The automation object to use.</param>
        /// <param name="waitTimeout">An optional timeout. If null is passed, the timeout is infinite.</param>
        /// <returns>The main window object as <see cref="Window" /> or null if no main window was found within the timeout.</returns>
        public Window? GetMainWindow(AutomationBase automation, TimeSpan? waitTimeout = null)
        {
            WaitWhileMainHandleIsMissing(waitTimeout);
            var mainWindowHandle = MainWindowHandle;
            if (mainWindowHandle == IntPtr.Zero)
            {
                return null;
            }
            var mainWindow = automation.FromHandle(mainWindowHandle).AsWindow();
            if (mainWindow != null)
            {
                mainWindow.IsMainWindow = true;
            }
            return mainWindow;
        }

        /// <summary>
        /// Gets all top level windows from the application.
        /// </summary>
        public Window[] GetAllTopLevelWindows(AutomationBase automation)
        {
            var desktop = automation.GetDesktop();
            var foundElements = desktop.FindAllChildren(cf => cf.ByControlType(ControlType.Window).And(cf.ByProcessId(ProcessId)));
            return foundElements.Select(x => x.AsWindow()).ToArray();
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
            return Process.GetProcessesByName(Path.GetFileNameWithoutExtension(executable));
        }
    }
}
