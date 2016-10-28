using System;
using System.Windows.Media;
using FlaUI.Core.Shapes;

namespace FlaUI.Core.Overlay
{
    public interface IOverlayManager: IDisposable
    {
        void Show(Rectangle rectangle, Color color, int durationInMs);
        void ShowBlocking(Rectangle rectangle, Color color, int durationInMs);
    }
}
