using System.Drawing;
using System.Drawing.Drawing2D;
using FlaUI.Core.Tools;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// An overlay to draw the current mouse cursor.
    /// </summary>
    public class MouseOverlay : OverlayBase
    {
        /// <summary>
        /// Creates a <see cref="MouseOverlay"/> object for the current captured image.
        /// </summary>
        /// <param name="captureImage">The captured image.</param>
        /// <returns>The created object.</returns>
        public MouseOverlay(CaptureImage captureImage) : base(captureImage)
        {
        }

        /// <inheritdoc />
        public override void Draw(Graphics g)
        {
            var outputPoint = new Point();
            var cursorBitmap = CaptureUtilities.CaptureCursor(ref outputPoint);
            // Early exit
            if (cursorBitmap == null) {
                return;
            }
            // Fix the coordinates for multi-screen scenarios
            outputPoint.X -= CaptureImage.OriginalBounds.Left;
            outputPoint.Y -= CaptureImage.OriginalBounds.Top;
            // Check for scaling and handle that
            var scale = CaptureUtilities.GetScale(CaptureImage.OriginalBounds, CaptureImage.Settings);
            if (scale != 1)
            {
                outputPoint.X = (outputPoint.X * scale).ToInt();
                outputPoint.Y = (outputPoint.Y * scale).ToInt();
                var outputWidth = (cursorBitmap.Width * scale).ToInt();
                var outputHeight = (cursorBitmap.Height * scale).ToInt();
                var origInterpolationMode = g.InterpolationMode;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(cursorBitmap, outputPoint.X, outputPoint.Y, outputWidth, outputHeight);
                g.InterpolationMode = origInterpolationMode;
            }
            else
            {
                g.DrawImage(cursorBitmap, outputPoint.X, outputPoint.Y);
            }
            // Cleanup
            cursorBitmap.Dispose();
        }
    }
}
