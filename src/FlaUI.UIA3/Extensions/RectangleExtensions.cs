using System.Drawing;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Extensions
{
    public static class RectangleExtensions
    {
        public static UIA.tagRECT ToTagRect(this Rectangle r)
        {
            return new UIA.tagRECT
            {
                left = r.Left,
                top = r.Top,
                right = r.Right,
                bottom = r.Bottom
            };
        }

        public static Rectangle ToRectangle(this UIA.tagRECT r)
        {
            return new Rectangle(r.left, r.top, r.right - r.left, r.bottom - r.top);
        }
    }
}
