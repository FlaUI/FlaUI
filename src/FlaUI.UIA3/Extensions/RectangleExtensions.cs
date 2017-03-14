using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Extensions
{
    public static class RectangleExtensions
    {
        public static UIA.tagRECT ToTagRect(this Rectangle r)
        {
            return new UIA.tagRECT
            {
                left = r.Left.ToInt(),
                top = r.Top.ToInt(),
                right = r.Right.ToInt(),
                bottom = r.Bottom.ToInt()
            };
        }

        public static Rectangle ToRectangle(this UIA.tagRECT r)
        {
            return new Rectangle(r.left, r.top, r.right - r.left, r.bottom - r.top);
        }
    }
}
