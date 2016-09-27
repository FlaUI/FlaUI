using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Shapes
{
    public static class PointExtensions
    {
        public static UIA.tagPOINT ToTagPoint(this Point p)
        {
            return new UIA.tagPOINT { x = p.X.ToInt(), y = p.Y.ToInt() };
        }

        public static Point ToPoint(this UIA.tagPOINT p)
        {
            return new Point(p.x, p.y);
        }
    }
}
