using System;
using System.Runtime.InteropServices;

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
    }

    public struct COLORREF
    {
        public byte R;
        public byte G;
        public byte B;

        public override string ToString()
        {
            return String.Format("R={0},G={1},B={2}", R, G, B);
        }
    }
}
