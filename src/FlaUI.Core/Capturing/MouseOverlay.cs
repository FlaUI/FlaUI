using System;
using System.Drawing;
using System.Runtime.InteropServices;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// An overlay to draw the current mouse cursor.
    /// </summary>
    public class MouseOverlay : OverlayBase
    {
        public MouseOverlay(Rectangle desktopBounds) : base(desktopBounds)
        {
        }

        /// <inheritdoc />
        public override void Draw(Graphics g)
        {
            CURSORINFO cursorInfo;
            cursorInfo.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            if (User32.GetCursorInfo(out cursorInfo))
            {
                if (cursorInfo.flags == CursorState.CURSOR_SHOWING)
                {
                    // We need to get the icon to get the "Hotspot" (aka offset)
                    var hicon = User32.CopyIcon(cursorInfo.hCursor);
                    if (hicon != IntPtr.Zero)
                    {
                        if (User32.GetIconInfo(hicon, out var iconInfo))
                        {
                            // Calculate the positions, relative to the bounds of the image relative to the desktop.
                            var x = cursorInfo.ptScreenPos.X - DesktopBounds.Left;
                            var y = cursorInfo.ptScreenPos.Y - DesktopBounds.Top;
                            User32.DrawIconEx(g.GetHdc(), x - iconInfo.xHotspot, y - iconInfo.yHotspot, cursorInfo.hCursor, 0, 0, 0, IntPtr.Zero, 0x0003);
                            g.ReleaseHdc();
                        }
                        Gdi32.DeleteObject(iconInfo.hbmColor);
                        Gdi32.DeleteObject(iconInfo.hbmMask);
                    }
                    User32.DestroyIcon(hicon);
                }
                Gdi32.DeleteObject(cursorInfo.hCursor);
            }
        }
    }
}
