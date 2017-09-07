using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;

namespace FlaUI.Core
{
    /// <summary>
    /// Provides methods to capture screenshots or partially screenshots.
    /// </summary>
    public static class Capture
    {
        /// <summary>
        /// Captures the whole screen (all monitors).
        /// </summary>
        public static Bitmap Screen()
        {
            // Use P/Invoke because of: https://stackoverflow.com/a/3072580/1069200
            var sz = new System.Drawing.Size((int)SystemParameters.VirtualScreenWidth, (int)SystemParameters.VirtualScreenHeight);
            var hDesk = GetDesktopWindow();
            var hSrce = GetWindowDC(hDesk);
            var hDest = CreateCompatibleDC(hSrce);
            var hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
            var hOldBmp = SelectObject(hDest, hBmp);
            BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, 0, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
            var bmp = Image.FromHbitmap(hBmp);
            SelectObject(hDest, hOldBmp);
            DeleteObject(hBmp);
            DeleteDC(hDest);
            ReleaseDC(hDesk, hSrce);
            return bmp;
        }

        /// <summary>
        /// Captures the whole screen (all monitors) in a WPF friendly format.
        /// </summary>
        public static BitmapImage ScreenWpf()
        {
            return Screen().ToWpf();
        }

        /// <summary>
        /// Captures the screen and saves it to a file.
        /// </summary>
        public static void ScreenToFile(string filePath)
        {
            using (var bmp = Screen())
            {
                Logger.Default.Info($"Capture.ScreenToFile: {filePath}");
                bmp.Save(filePath, ImageFormat.Png);
            }
        }

        /// <summary>
        /// Captures an element and returns the image.
        /// Note that a sleep may be required before if the control is newly loaded.
        /// </summary>
        public static Bitmap Element(AutomationElement element)
        {
            return Rectangle(element.Properties.BoundingRectangle.Value);
        }

        /// <summary>
        /// Captures an element in a WPF friendly format.
        /// Note that a sleep may be required before if the control is newly loaded.
        /// </summary>
        public static BitmapImage ElementeWpf(AutomationElement element)
        {
            return Element(element).ToWpf();
        }

        /// <summary>
        /// Captures an element and saves it to a file.
        /// Note that a sleep may be required before if the control is newly loaded.
        /// </summary>
        public static void ElementToFile(AutomationElement element, string filePath)
        {
            using (var bmp = Rectangle(element.Properties.BoundingRectangle.Value))
            {
                Logger.Default.Info($"Capture.ElementToFile: {element} {filePath}");
                bmp.Save(filePath, ImageFormat.Png);
            }
        }

        /// <summary>
        /// Captures a specific area from the screen.
        /// </summary>
        public static Bitmap Rectangle(Shapes.Rectangle bounds)
        {
            var width = bounds.Width.ToInt();
            var height = bounds.Height.ToInt();
            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (var graphics = Graphics.FromImage(bmp))
            {
                using (var screen = Screen())
                {
                    graphics.DrawImage(
                        screen,
                        new Rectangle(0, 0, width, height),
                        new Rectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height),
                        GraphicsUnit.Pixel);
                }
            }
            return bmp;
        }

        /// <summary>
        /// Captures a specific area in a WPF friendly format.
        /// </summary>
        public static BitmapImage RectangleWpf(Shapes.Rectangle bounds)
        {
            return Rectangle(bounds).ToWpf();
        }

        /// <summary>
        /// Captures a specific area and saves it to a file.
        /// </summary>
        public static void RectangleToFile(Shapes.Rectangle bounds, string filePath)
        {
            using (var bmp = Rectangle(bounds))
            {
                Logger.Default.Info($"Capture.RectangleToFile: {bounds} {filePath}");
                bmp.Save(filePath, ImageFormat.Png);
            }
        }

        /// <summary>
        /// Converts a WinForms <see cref="Bitmap"/> to a WPF <see cref="BitmapImage"/>.
        /// </summary>
        public static BitmapImage ToWpf(this Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                memory.Seek(0, SeekOrigin.Begin);
                bitmapImage.StreamSource = memory;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }

        #region P/Invoke
        // P/Invoke declarations
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
