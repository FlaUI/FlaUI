using System.Drawing;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// Base class for overlays.
    /// </summary>
    public abstract class OverlayBase : ICaptureOverlay
    {
        protected OverlayBase(CaptureImage captureImage)
        {
            CaptureImage = captureImage;
        }

        /// <summary>
        /// The captured image where this overlay should be painted.
        /// </summary>
        public CaptureImage CaptureImage { get; }

        /// <inheritdoc />
        public abstract void Draw(Graphics g);
    }
}
