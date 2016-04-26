using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
namespace FlaUI.Core.WindowsAPI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public POINT(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator System.Drawing.Point(POINT p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }

        public static implicit operator POINT(System.Drawing.Point p)
        {
            return new POINT(p.X, p.Y);
        }

        public static implicit operator System.Windows.Point(POINT p)
        {
            return new System.Windows.Point(p.X, p.Y);
        }

        public static implicit operator POINT(System.Windows.Point p)
        {
            return new POINT((int)p.X, (int)p.Y);
        }

        public override string ToString()
        {
            return String.Format("X={0},Y={1}", X, Y);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COLORREF
    {
        public byte R;
        public byte G;
        public byte B;

        public COLORREF(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static implicit operator System.Drawing.Color(COLORREF c)
        {
            return System.Drawing.Color.FromArgb(c.R, c.G, c.B);
        }

        public static implicit operator COLORREF(System.Drawing.Color c)
        {
            return new COLORREF(c.R, c.G, c.B);
        }

        public static implicit operator System.Windows.Media.Color(COLORREF c)
        {
            return System.Windows.Media.Color.FromRgb(c.R, c.G, c.B);
        }

        public static implicit operator COLORREF(System.Windows.Media.Color c)
        {
            return new COLORREF(c.R, c.G, c.B);
        }

        public override string ToString()
        {
            return String.Format("R={0},G={1},B={2}", R, G, B);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        public InputType type;
        public INPUTUNION u;

        public static INPUT MouseInput(MOUSEINPUT mouseInput)
        {
            return new INPUT { type = InputType.INPUT_MOUSE, u = new INPUTUNION { mi = mouseInput } };
        }

        public static INPUT KeyboardInput(int type, KEYBDINPUT keyboardInput)
        {
            return new INPUT { type = InputType.INPUT_KEYBOARD, u = new INPUTUNION { ki = keyboardInput } };
        }

        public static INPUT HardwareInput(int type, HARDWAREINPUT hardwareInput)
        {
            return new INPUT { type = InputType.INPUT_HARDWARE, u = new INPUTUNION { hi = hardwareInput } };
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct INPUTUNION
    {
        [FieldOffset(0)]
        public MOUSEINPUT mi;

        [FieldOffset(0)]
        public KEYBDINPUT ki;

        [FieldOffset(0)]
        public HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public MouseEventFlags dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;

        public MOUSEINPUT(MouseEventFlags dwFlags, IntPtr dwExtraInfo, uint mouseData = 0)
        {
            this.dwFlags = dwFlags;
            this.dwExtraInfo = dwExtraInfo;
            dx = 0;
            dy = 0;
            time = 0;
            this.mouseData = mouseData;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public KeyEventFlags dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;

        public KEYBDINPUT(ushort wVk, KeyEventFlags dwFlags, IntPtr dwExtraInfo)
        {
            this.wVk = wVk;
            wScan = 0;
            this.dwFlags = dwFlags;
            time = 0;
            this.dwExtraInfo = dwExtraInfo;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }
}
