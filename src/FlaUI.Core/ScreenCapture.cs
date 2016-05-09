using FlaUI.Core.Tools;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Rectangle = FlaUI.Core.Shapes.Rectangle;

namespace FlaUI.Core
{
    /// <summary>
    /// Provides methods to capture screenshots or partially screenshots
    /// </summary>
    public static class ScreenCapture
    {
        /// <summary>
        /// Captures the whole screen (all monitors)
        /// </summary>
        public static Bitmap CaptureScreen()
        {
            var screenTop = Convert.ToInt32(SystemParameters.VirtualScreenTop);
            var screenLeft = Convert.ToInt32(SystemParameters.VirtualScreenLeft);
            var screenWidth = Convert.ToInt32(SystemParameters.VirtualScreenWidth);
            var screenHeight = Convert.ToInt32(SystemParameters.VirtualScreenHeight);
            return CaptureArea(new Rectangle(screenLeft, screenTop, screenWidth, screenHeight));
        }

        public static BitmapImage CaptureScreenWpf()
        {
            return CaptureScreen().ToWpf();
        }

        /// <summary>
        /// Captures a specific area from the screen
        /// </summary>
        public static Bitmap CaptureArea(Rectangle rectangle)
        {
            var width = rectangle.Width.ToInt();
            var height = rectangle.Height.ToInt();
            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(rectangle.Left.ToInt(), rectangle.Top.ToInt(), 0, 0, new System.Drawing.Size(width, height), CopyPixelOperation.SourceCopy);
            return bmp;
        }

        public static BitmapImage CaptureAreaWpf(Rectangle rectangle)
        {
            return CaptureArea(rectangle).ToWpf();
        }

        /// <summary>
        /// Captures the screen and saves it to a file
        /// </summary>
        public static void CaptureScreenToFile(string filePath)
        {
            var bmp = CaptureScreen();
            bmp.Save(filePath, ImageFormat.Png);
        }

        /// <summary>
        /// Captures a specific area and saves it to a file
        /// </summary>
        public static void CaptureAreaToFile(Rectangle rectangle, string filePath)
        {
            var bmp = CaptureArea(rectangle);
            bmp.Save(filePath, ImageFormat.Png);
        }

        /// <summary>
        /// Converts a WinForms bitmap to a WPF bitmap
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
    }
}
