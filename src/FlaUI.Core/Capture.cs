using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Exceptions;
,
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
        public static CaptureImage Screen()
        {
            var screen = new Shapes.Rectangle(
                SystemParameters.VirtualScreenLeft, SystemParameters.VirtualScreenTop,
                SystemParameters.VirtualScreenWidth, SystemParameters.VirtualScreenHeight);
            return Rectangle(screen);
        }

        /// <summary>
        /// Captures an element and returns the image.
        /// </summary>
        public static CaptureImage Element(AutomationElement element, bool focus = true)
        {
            if (focus) {
                element.Focus();
            }
            return Rectangle(element.Properties.BoundingRectangle.Value);
        }

        /// <summary>
        /// Captures a rectangle inside an element and returns the image.
        /// </summary>
        public static CaptureImage ElementRectangle(AutomationElement element, Shapes.Rectangle rectangle)
        {
            element.Focus();
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
            return new CaptureImage(bmp);
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
