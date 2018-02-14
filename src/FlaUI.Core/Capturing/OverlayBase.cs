using System.Drawing;

namespace FlaUI.Core.Capturing
{
    public abstract class OverlayBase : ICaptureOverlay
    {
        protected OverlayBase(Rectangle desktopBounds)
        {
            DesktopBounds = desktopBounds;
        }

        public Rectangle DesktopBounds { get; }

        /// <inheritdoc />
        public abstract void Draw(Graphics g);
    }
}
