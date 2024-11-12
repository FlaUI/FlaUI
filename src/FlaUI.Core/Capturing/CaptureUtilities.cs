using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// Various utility methods used for capturing.
    /// </summary>
    public static class CaptureUtilities
    {
        [DllImport("Gdi32")]
        public static extern bool DeleteObject(IntPtr ho);

        /// <summary>
        /// Calculates a scale factor according to the bounds and capture settings.
        /// </summary>
        /// <param name="originalBounds">The original bounds of the captured image.</param>
        /// <param name="captureSettings">The settings to use for the capture.</param>
        /// <returns>A scale factor, defaults to 1 which means original size.</returns>
        public static double GetScale(Rectangle originalBounds, CaptureSettings captureSettings)
        {
            double scale = 1;
            if (captureSettings != null)
            {
                scale = captureSettings.OutputScale;
                if (scale == 1)
                {
                    if (captureSettings.OutputHeight == -1 && captureSettings.OutputWidth != -1)
                    {
                        // Calculate the scale by a defined width
                        scale = captureSettings.OutputWidth / (double)originalBounds.Width;
                    }
                    else if (captureSettings.OutputHeight != -1 && captureSettings.OutputWidth == -1)
                    {
                        // Calculate the scale by a defined height
                        scale = captureSettings.OutputHeight / (double)originalBounds.Height;
                    }
                }
            }
            return scale;
        }

        /// <summary>
        /// Scales a point according to the given settings.
        /// </summary>
        /// <param name="x">The x-position of the point to scale.</param>
        /// <param name="y">The y-position of the pint to scale.</param>
        /// <param name="originalBounds">The original bounds of the captured image.</param>
        /// <param name="captureSettings">The settings to use for the capture.</param>
        /// <returns>The transformed point.</returns>
        public static Point ScaleAccordingToSettings(int x, int y, Rectangle originalBounds, CaptureSettings captureSettings)
        {
            return ScaleAccordingToSettings(new Point(x, y), originalBounds, captureSettings);
        }

        /// <summary>
        /// Scales a point according to the given settings.
        /// </summary>
        /// <param name="point">The point to scale.</param>
        /// <param name="originalBounds">The original bounds of the captured image.</param>
        /// <param name="captureSettings">The settings to use for the capture.</param>
        /// <returns>The transformed point.</returns>
        public static Point ScaleAccordingToSettings(Point point, Rectangle originalBounds, CaptureSettings captureSettings)
        {
            var scale = GetScale(originalBounds, captureSettings);
            return scale != 1 ? new Point((point.X * scale).ToInt(), (point.Y * scale).ToInt()) : point;
        }

        /// <summary>
        /// Scales a rectangle according to the given settings.
        /// </summary>
        /// <param name="originalBounds">The original bounds of the captured image.</param>
        /// <param name="captureSettings">The settings to use for the capture.</param>
        /// <returns>The transformed rectangle.</returns>
        public static Rectangle ScaleAccordingToSettings(Rectangle originalBounds, CaptureSettings? captureSettings)
        {
            // Default is the original size
            var outputWidth = originalBounds.Width;
            var outputHeight = originalBounds.Height;

            if (captureSettings != null)
            {
                if (captureSettings.OutputScale != 1)
                {
                    // Calculate with the scale
                    outputWidth = (originalBounds.Width * captureSettings.OutputScale).ToInt();
                    outputHeight = (originalBounds.Height * captureSettings.OutputScale).ToInt();
                }
                else if (captureSettings.OutputHeight == -1 && captureSettings.OutputWidth != -1)
                {
                    // Adjust the height
                    outputWidth = captureSettings.OutputWidth;
                    var percent = outputWidth / (double)originalBounds.Width;
                    outputHeight = (originalBounds.Height * percent).ToInt();
                }
                else if (captureSettings.OutputHeight != -1 && captureSettings.OutputWidth == -1)
                {
                    // Adjust the width
                    outputHeight = captureSettings.OutputHeight;
                    var percent = outputHeight / (double)originalBounds.Height;
                    outputWidth = (originalBounds.Width * percent).ToInt();
                }
            }
            return new Rectangle(0, 0, outputWidth, outputHeight);
        }

        /// <summary>
        /// Captures the cursor as bitmap and returns the bitmap and the position on screen of the cursor.
        /// </summary>
        public static Bitmap? CaptureCursor(ref Point position)
        {
            var cursorInfo = new CURSORINFO();
            cursorInfo.cbSize = Marshal.SizeOf(cursorInfo);
            if (!User32.GetCursorInfo(out cursorInfo))
            {
                return null;
            }

            if (cursorInfo.flags != CursorState.CURSOR_SHOWING)
            {
                return null;
            }

            var hicon = User32.CopyIcon(cursorInfo.hCursor);
            if (hicon == IntPtr.Zero)
            {
                return null;
            }

            if (!User32.GetIconInfo(hicon, out var iconInfo))
            {
                return null;
            }

            // Calculate the position respecting the hotspot offset
            position.X = cursorInfo.ptScreenPos.X - iconInfo.xHotspot;
            position.Y = cursorInfo.ptScreenPos.Y - iconInfo.yHotspot;

            using (var maskBitmap = Image.FromHbitmap(iconInfo.hbmMask))
            {
                // Special handling for monchome icons
                if (maskBitmap.Height == maskBitmap.Width * 2)
                {
                    var cursor = new Bitmap(maskBitmap.Width, maskBitmap.Width, PixelFormat.Format32bppArgb);
                    var black = Color.FromArgb(255, 0, 0, 0); //cannot compare Color.Black because of different names
                    var white = Color.FromArgb(255, 255, 255, 255); //cannot compare Color.White because of different names
                    for (var y = 0; y < maskBitmap.Width; y++)
                    {
                        for (var x = 0; x < maskBitmap.Width; x++)
                        {
                            var maskPixel = maskBitmap.GetPixel(x, y);
                            var cursorPixel = maskBitmap.GetPixel(x, y + maskBitmap.Width);
                            if (maskPixel == white && cursorPixel == black)
                            {
                                cursor.SetPixel(x, y, Color.Transparent);
                            }
                            else if (maskPixel == black)
                            {
                                cursor.SetPixel(x, y, cursorPixel);
                            }
                            else
                            {
                                cursor.SetPixel(x, y, cursorPixel == black ? white : black);
                            }
                        }
                    }
                    return cursor;
                }
            }

            // Just return the icon converted to a bitmap
            Bitmap result;
            using (Icon icon = Icon.FromHandle(hicon))
            {
                result = icon.ToBitmap();
            }

            User32.DestroyIcon(hicon);
            DeleteObject(iconInfo.hbmMask);
            DeleteObject(iconInfo.hbmColor);
            return result;
        }
    }
}
