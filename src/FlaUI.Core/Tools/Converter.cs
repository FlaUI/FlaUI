using interop.UIAutomationCore;
using System.Windows;

namespace FlaUI.Core.Tools
{
    public static class Converter
    {
        public static Rect ToRect(this tagRECT rect)
        {
            return new Rect(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
        }
    }
}
