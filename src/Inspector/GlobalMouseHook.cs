using System.Runtime.InteropServices;

namespace Inspector
{
    public class GlobalMouseHook
    {
        private IntPtr hookId = IntPtr.Zero;
        private NativeMethods.LowLevelMouseProc mouseProc;
        public GlobalMouseHook()
        {
            mouseProc = HookCallback;
        }


        public event EventHandler<Point>? RightClick;

        public void Start()
        {
            if (hookId == IntPtr.Zero)
            {
                mouseProc = HookCallback;
                hookId = NativeMethods.SetWindowsHookEx(NativeMethods.WH_MOUSE_LL, mouseProc, NativeMethods.GetModuleHandle(null), 0);
            }
        }

        public void Stop()
        {
            if (hookId != IntPtr.Zero)
            {
                NativeMethods.UnhookWindowsHookEx(hookId);
                hookId = IntPtr.Zero;
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int msg = wParam.ToInt32();
                if (msg == NativeMethods.WM_RBUTTONDOWN)
                {
                    NativeMethods.MSLLHOOKSTRUCT hookStruct = Marshal.PtrToStructure<NativeMethods.MSLLHOOKSTRUCT>(lParam);
                    RightClick?.Invoke(this, new Point(hookStruct.pt.x, hookStruct.pt.y));
                }
            }

            return NativeMethods.CallNextHookEx(hookId, nCode, wParam, lParam);
        }
    }
}
