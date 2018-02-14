using System.Drawing;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Extensions
{
    public static class PointExtensions
    {
        public static UIA.tagPOINT ToTagPoint(this Point p)
        {
            return new UIA.tagPOINT { x = p.X, y = p.Y };
        }

        public static Point ToPoint(this UIA.tagPOINT p)
        {
            return new Point(p.x, p.y);
        }
    }
}
