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
        /// Captures the whole screen (all monitors).
        /// </summary>
        public static CaptureImage Screen(int screenIndex = -1)
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
        public static CaptureImage ElementRectangle(AutomationElement element, Rectangle rectangle)
        {
            var elementBounds = element.BoundingRectangle;
            // Calculate the rectangle that should be captured
            var capturingRectangle = new Rectangle(elementBounds.Left + rectangle.Left, elementBounds.Top + rectangle.Top, rectangle.Width, rectangle.Height);
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
        public static CaptureImage Rectangle(Rectangle bounds)
        {
            // Use P/Invoke because of: https://stackoverflow.com/a/3072580/1069200
            var sz = new System.Drawing.Size(bounds.Width, bounds.Height);
            var hDesk = User32.GetDesktopWindow();
            var hSrce = User32.GetWindowDC(hDesk);
            var hDest = Gdi32.CreateCompatibleDC(hSrce);
            var hBmp = Gdi32.CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
            var hOldBmp = Gdi32.SelectObject(hDest, hBmp);
            Gdi32.BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, (int)bounds.X, (int)bounds.Y, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
            var bmp = Image.FromHbitmap(hBmp);
            Gdi32.SelectObject(hDest, hOldBmp);
            Gdi32.DeleteObject(hBmp);
            Gdi32.DeleteDC(hDest);
            User32.ReleaseDC(hDesk, hSrce);
            return new CaptureImage(bmp, bounds);
        }
    }
}
