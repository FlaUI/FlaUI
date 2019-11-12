using System.Drawing;
using System.Threading;

namespace FlaUI.Core.Overlay
{
    /// <summary>
    /// An overlay manager that does nothing.
    /// </summary>
    public class NullOverlayManager : IOverlayManager
    {
        public int Size { get; set; }
        public int Margin { get; set; }

        public void Dispose()
        {
            // Noop
        }

        public void Show(Rectangle rectangle, Color color, int durationInMs)
        {
            // Noop
        }

        public void ShowBlocking(Rectangle rectangle, Color color, int durationInMs)
        {
            Thread.Sleep(durationInMs);
        }
    }
}
