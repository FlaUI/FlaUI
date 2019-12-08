using System;
using System.Drawing;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
#pragma warning disable
namespace FlaUI.Core.WindowsAPI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
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

        public static implicit operator Color(COLORREF c)
        {
            return Color.FromArgb(c.R, c.G, c.B);
        }

        public static implicit operator COLORREF(Color c)
        {
            return new COLORREF(c.R, c.G, c.B);
        }

#if NETFRAMEWORK
        public static implicit operator System.Windows.Media.Color(COLORREF c)
        {
            return System.Windows.Media.Color.FromRgb(c.R, c.G, c.B);
        }

        public static implicit operator COLORREF(System.Windows.Media.Color c)
        {
            return new COLORREF(c.R, c.G, c.B);
        }
#endif

        public override string ToString()
        {
            return $"R={R},G={G},B={B}";
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        public InputType type;
        public INPUTUNION u;

        public static int Size => Marshal.SizeOf(typeof(INPUT));

        public static INPUT MouseInput(MOUSEINPUT mouseInput)
        {
            return new INPUT { type = InputType.INPUT_MOUSE, u = new INPUTUNION { mi = mouseInput } };
        }

        public static INPUT KeyboardInput(KEYBDINPUT keyboardInput)
        {
            return new INPUT { type = InputType.INPUT_KEYBOARD, u = new INPUTUNION { ki = keyboardInput } };
        }

        public static INPUT HardwareInput(HARDWAREINPUT hardwareInput)
        {
            return new INPUT { type = InputType.INPUT_HARDWARE, u = new INPUTUNION { hi = hardwareInput } };
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct INPUTUNION
    {
        [FieldOffset(0)] public MOUSEINPUT mi;

        [FieldOffset(0)] public KEYBDINPUT ki;

        [FieldOffset(0)] public HARDWAREINPUT hi;
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
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public KeyEventFlags dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CURSORINFO
    {
        public Int32 cbSize;
        public CursorState flags;
        public IntPtr hCursor;
        public POINT ptScreenPos;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ICONINFO
    {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public override string ToString()
        {
            return $"{{X={left},Y={top},Width={right - left},Height={bottom - top}}}";
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MonitorInfo
    {
        public uint size;
        public RECT monitor;
        public RECT work;
        public uint flags;
    }

}
#pragma warning restore
