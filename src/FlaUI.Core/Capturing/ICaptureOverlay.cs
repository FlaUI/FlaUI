using System.Drawing;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// Interface for overlays that can be applied to captured images.
    /// </summary>
    public interface ICaptureOverlay
    {
        /// <summary>
        /// Draws the overlay onto the given graphics object.
        /// </summary>
        void Draw(Graphics g);
    }
}
