using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace FlaUI.Core.WindowsAPI
{
    // TODO: Clean this up
    public class NativeWindow
    {
        private readonly IntPtr _handle;

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(POINT point);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern COLORREF GetBkColor(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern COLORREF GetTextColor(IntPtr hdc);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        public static bool WaitForInputIdle(IntPtr hWnd, TimeSpan timeout)
        {
            int pid;
            uint tid = GetWindowThreadProcessId(hWnd, out pid);
            if (tid == 0) return true; // probably closed already
            //return Retry.For(() => IsThreadIdle(pid, tid), timeout, TimeSpan.FromMilliseconds(10));
            return true;
        }

        private static bool IsThreadIdle(int pid, uint tid)
        {
            Process prc;
            try
            {
                prc = Process.GetProcessById(pid);
            }
            catch (ArgumentException)
            {
                // process with specified pid is not running - most probably it was closed already, in which case we can assume it is definitely idle
                return true;
            }
            var thr = prc.Threads.Cast<ProcessThread>().First(t => tid == t.Id);
            return thr.ThreadState == ThreadState.Wait &&
                   thr.WaitReason == ThreadWaitReason.UserRequest;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowEnabled(IntPtr hWnd);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);



        public static IEnumerable<NativeWindow> GetProcessWindows(int processId)
        {
            var result = new List<NativeWindow>();
            Func<IntPtr, bool> processWindow = hwnd =>
            {
                if (IsWindowEnabled(hwnd))
                {
                    int pid;
                    GetWindowThreadProcessId(hwnd, out pid);
                    if (pid == processId)
                        result.Add(new NativeWindow(hwnd));
                }
                return true;
            };
            EnumWindows((wnd, param) => processWindow(wnd), IntPtr.Zero);
            return result;
        }

        public NativeWindow(Point point)
        {
            _handle = WindowFromPoint(new POINT((int)point.X, (int)point.Y));
        }

        public NativeWindow(IntPtr handle)
        {
            this._handle = handle;
        }

        public virtual COLORREF BackgroundColor
        {
            get
            {
                return GetBkColor(GetDC(_handle));
            }
        }

        public virtual COLORREF TextColor
        {
            get
            {
                return GetTextColor(GetDC(_handle));
            }
        }

        public virtual void PostCloseMessage()
        {
            PostMessage(_handle, Constants.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        //Native methods needed for highlighting UIItems
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hwndAfter, int x, int y, int width, int height, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool SetForegroundWindow(IntPtr windowHandle);
    }
}
