using System;
using System.Drawing;
using System.Windows;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// Provides methods to capture the screen, <see cref="AutomationElement"/>s or rectangles on them.
    /// </summary>
    public static class Capture
    {
        /// <summary>
        /// Captures the main (primary) screen.
        /// </summary>
        public static CaptureImage MainScreen(CaptureSettings settings = null)
        {
            return Rectangle(System.Windows.Forms.Screen.PrimaryScreen.Bounds, settings);
        }

        /// <summary>
        /// Captures the whole screen (all monitors).
        /// </summary>
        public static CaptureImage Screen(int screenIndex = -1, CaptureSettings settings = null)
        {
            Rectangle capturingRectangle;
            // Take the appropriate screen if requested
            if (screenIndex >= 0 && screenIndex < System.Windows.Forms.Screen.AllScreens.Length)
            {
                var rectangle = System.Windows.Forms.Screen.AllScreens[screenIndex].Bounds;
                capturingRectangle = rectangle;
            }
            else
            {
                // Use the entire desktop
                capturingRectangle = new Rectangle(
                    SystemParameters.VirtualScreenLeft.ToInt(), SystemParameters.VirtualScreenTop.ToInt(),
                    SystemParameters.VirtualScreenWidth.ToInt(), SystemParameters.VirtualScreenHeight.ToInt());
            }
            return Rectangle(capturingRectangle, settings);
        }

        /// <summary>
        /// Captures an element and returns the image.
        /// </summary>
        public static CaptureImage Element(AutomationElement element, CaptureSettings settings = null)
        {
            return Rectangle(element.Properties.BoundingRectangle.Value, settings);
        }

        /// <summary>
        /// Captures a rectangle inside an element and returns the image.
        /// </summary>
        public static CaptureImage ElementRectangle(AutomationElement element, Rectangle rectangle, CaptureSettings settings = null)
        {
            var elementBounds = element.BoundingRectangle;
            // Calculate the rectangle that should be captured
            var capturingRectangle = new Rectangle(elementBounds.Left + rectangle.Left, elementBounds.Top + rectangle.Top, rectangle.Width, rectangle.Height);
            // Check if the element contains the rectangle that should be captured
            if (!elementBounds.Contains(capturingRectangle))
            {
                throw new FlaUIException($"The given rectangle ({capturingRectangle}) is out of bounds of the element ({elementBounds}).");
            }
            return Rectangle(capturingRectangle, settings);
        }

        /// <summary>
        /// Captures a specific area from the screen.
        /// </summary>
        public static CaptureImage Rectangle(Rectangle bounds, CaptureSettings settings = null)
        {
            // Default is the original size
            var outputWidth = bounds.Width;
            var outputHeight = bounds.Height;

            if (settings != null)
            {
                if (settings.OutputScale != 1)
                {
                    // Calculate with the scale
                    outputWidth = (bounds.Width * settings.OutputScale).ToInt();
                    outputHeight = (bounds.Height * settings.OutputScale).ToInt();
                }
                else if (settings.OutputHeight == -1 && settings.OutputWidth != -1)
                {
                    // Adjust the height
                    outputWidth = settings.OutputWidth;
                    var percent = outputWidth / (double)bounds.Width;
                    outputHeight = (bounds.Height * percent).ToInt();
                }
                else if (settings.OutputHeight != -1 && settings.OutputWidth == -1)
                {
                    // Adjust the width
                    outputHeight = settings.OutputHeight;
                    var percent = outputHeight / (double)bounds.Height;
                    outputWidth = (bounds.Width * percent).ToInt();
                }
            }

            Bitmap bmp;
            if (outputWidth == bounds.Width || outputHeight == bounds.Height)
            {
                // Capture directly without any resizing
                bmp = CaptureDesktopToBitmap(bounds.Width, bounds.Height, (dest, src) =>
                {
                    Gdi32.BitBlt(dest, 0, 0, outputWidth, outputHeight, src, bounds.X, bounds.Y, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
                });
            }
            else
            {
                //  Capture with scaling
                bmp = CaptureDesktopToBitmap(outputWidth, outputHeight, (dest, src) =>
                {
                    Gdi32.SetStretchBltMode(dest, StretchMode.STRETCH_HALFTONE);
                    Gdi32.StretchBlt(dest, 0, 0, outputWidth, outputHeight, src, bounds.X, bounds.Y, bounds.Width, bounds.Height, TernaryRasterOperations.SRCCOPY | TernaryRasterOperations.CAPTUREBLT);
                });
            }
            return new CaptureImage(bmp, bounds);
        }

        private static Bitmap CaptureDesktopToBitmap(int width, int height, Action<IntPtr, IntPtr> action)
        {
            // Use P/Invoke because of: https://stackoverflow.com/a/3072580/1069200
            var hDesk = User32.GetDesktopWindow();
            var hSrc = User32.GetWindowDC(hDesk);
            var hDest = Gdi32.CreateCompatibleDC(hSrc);
            var hBmp = Gdi32.CreateCompatibleBitmap(hSrc, width, height);
            var hPrevBmp = Gdi32.SelectObject(hDest, hBmp);
            action(hDest, hSrc);
            var bmp = Image.FromHbitmap(hBmp);
            Gdi32.SelectObject(hDest, hPrevBmp);
            Gdi32.DeleteObject(hBmp);
            Gdi32.DeleteDC(hDest);
            User32.ReleaseDC(hDesk, hSrc);
            return bmp;
        }
    }
}
