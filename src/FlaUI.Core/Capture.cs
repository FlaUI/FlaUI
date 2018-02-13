using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core
{
    /// <summary>
    /// Provides methods to capture the screen, <see cref="AutomationElement"/>s or rectangles on them.
    /// </summary>
    public static class Capture
    {
        /// <summary>
        /// Captures the whole screen (all monitors).
        /// </summary>
        public static CaptureImage Screen(int screenIndex = -1)
        {
            Shapes.Rectangle capturingRectangle;
            // Take the appropriate screen if requested
            if (screenIndex >= 0 && screenIndex < System.Windows.Forms.Screen.AllScreens.Length)
            {
                var rectangle = System.Windows.Forms.Screen.AllScreens[screenIndex].Bounds;
                capturingRectangle = rectangle;
            }
            else
            {
                // Use the entire desktop
                capturingRectangle = new Shapes.Rectangle(
                    SystemParameters.VirtualScreenLeft, SystemParameters.VirtualScreenTop,
                    SystemParameters.VirtualScreenWidth, SystemParameters.VirtualScreenHeight);
            }
            return Rectangle(capturingRectangle);
        }

        /// <summary>
        /// Captures an element and returns the image.
        /// </summary>
        public static CaptureImage Element(AutomationElement element)
        {
            return Rectangle(element.Properties.BoundingRectangle.Value);
        }

        /// <summary>
        /// Captures a rectangle inside an element and returns the image.
        /// </summary>
        public static CaptureImage ElementRectangle(AutomationElement element, Shapes.Rectangle rectangle)
        {
            var elementBounds = element.BoundingRectangle;
            // Calculate the rectangle that should be captured
            var capturingRectangle = new Shapes.Rectangle(elementBounds.Left + rectangle.Left, elementBounds.Top + rectangle.Top, rectangle.Width, rectangle.Height);
            // Check if the element contains the rectangle that should be captured
            if (!elementBounds.Contains(capturingRectangle))
            {
                throw new FlaUIException($"The given rectangle ({capturingRectangle}) is out of bounds of the element ({elementBounds}).");
            }
            return Rectangle(capturingRectangle);
        }

        /// <summary>
        /// Captures a specific area from the screen.
        /// </summary>
        public static CaptureImage Rectangle(Shapes.Rectangle bounds)
        {
            // Use P/Invoke because of: https://stackoverflow.com/a/3072580/1069200
            var sz = new System.Drawing.Size((int)bounds.Width, (int)bounds.Height);
            var hDesk = GetDesktopWindow();
            var hSrce = GetWindowDC(hDesk);
            var hDest = CreateCompatibleDC(hSrce);
            var hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
            var hOldBmp = SelectObject(hDest, hBmp);
            BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, (int)bounds.X, (int)bounds.Y, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
            var bmp = Image.FromHbitmap(hBmp);
            SelectObject(hDest, hOldBmp);
            DeleteObject(hBmp);
            DeleteDC(hDest);
            ReleaseDC(hDesk, hSrce);

            var captureOptions = new CaptureOptions();
            if (captureOptions.AddCursor || captureOptions.AddOverlayString)
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    // Draw the overlay if wanted
                    if (captureOptions.AddOverlayString)
                    {
                        var overlayString = FormatOverlayString(captureOptions.OverlayStringFormat);
                        var font = new Font("Arial", 12f);
                        var size = g.MeasureString(overlayString, font);
                        g.FillRectangle(Brushes.Black, 0, 0, bmp.Width, size.Height + 4);
                        g.DrawString(overlayString, font, Brushes.White, 2, 2);
                    }

                    // Draw the cursor if wanted
                    if (captureOptions.AddCursor)
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
                                        var x = cursorInfo.ptScreenPos.X - bounds.Left.ToInt();
                                        var y = cursorInfo.ptScreenPos.Y - bounds.Top.ToInt();
                                        User32.DrawIconEx(g.GetHdc(), x - iconInfo.xHotspot, y - iconInfo.yHotspot, cursorInfo.hCursor, 0, 0, 0, IntPtr.Zero, 0x0003);
                                        g.ReleaseHdc();
                                        Console.WriteLine(bounds);
                                        Console.WriteLine(Mouse.Position);
                                        Console.WriteLine($"{cursorInfo.ptScreenPos.X}:{cursorInfo.ptScreenPos.Y}");
                                        Console.WriteLine($"{x}:{y}");
                                        Console.WriteLine("---");
                                    }
                                    DeleteObject(iconInfo.hbmColor);
                                    DeleteObject(iconInfo.hbmMask);
                                }
                                User32.DestroyIcon(hicon);
                            }
                            DeleteObject(cursorInfo.hCursor);
                        }
                    }
                }
            }

            return new CaptureImage(bmp);
        }

        private static string FormatOverlayString(string overlayString)
        {
            SystemInfo.Refresh();
            // Replace the simple values
            overlayString = overlayString
                .Replace("{name}", $"{Environment.MachineName}")
                .Replace("{cpu}", $"{SystemInfo.CpuUsage}%")
                .Replace("{mem.p.tot}", $"{StringFormatter.SizeSuffix(SystemInfo.PhysicalMemoryTotal, 2)}")
                .Replace("{mem.p.free}", $"{StringFormatter.SizeSuffix(SystemInfo.PhysicalMemoryFree, 2)}")
                .Replace("{mem.p.used}", $"{StringFormatter.SizeSuffix(SystemInfo.PhysicalMemoryUsed, 2)}")
                .Replace("{mem.p.free.perc}", $"{SystemInfo.PhysicalMemoryFreePercent}%")
                .Replace("{mem.p.used.perc}", $"{SystemInfo.PhysicalMemoryUsedPercent}%")
                .Replace("{mem.v.tot}", $"{StringFormatter.SizeSuffix(SystemInfo.VirtualMemoryTotal, 2)}")
                .Replace("{mem.v.free}", $"{StringFormatter.SizeSuffix(SystemInfo.VirtualMemoryFree, 2)}")
                .Replace("{mem.v.used}", $"{StringFormatter.SizeSuffix(SystemInfo.VirtualMemoryUsed, 2)}")
                .Replace("{mem.v.free.perc}", $"{SystemInfo.VirtualMemoryFreePercent}%")
                .Replace("{mem.v.used.perc}", $"{SystemInfo.VirtualMemoryUsedPercent}%");

            // Replace the date and times
            var now = DateTime.Now;
            overlayString = Regex.Replace(overlayString, @"\{dt:?(.*?)\}", m => now.ToString(m.Groups[1].Value));
            return overlayString;
        }

        #region P/Invoke
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);

        [DllImport("user32.dll")]
        private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr DeleteDC(IntPtr hDc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr DeleteObject(IntPtr hDc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr ptr);
        #endregion P/Invoke
    }
}
