using interop.UIAutomationCore;
using System.Windows;

namespace FlaUI.Core.Tools
{
    public static class Converter
    {
        public static Rect ToRect(tagRECT rect)
        {
            return new Rect(new Point(rect.left, rect.top), new Point(rect.right, rect.bottom));
        }
    }
}
