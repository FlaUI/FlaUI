using FlaUI.Core;
using FlaUI.UIA2.Elements;

namespace FlaUI.UIA2.Tools
{
    public static class ApplicationExtensions
    {
        public static Window GetMainWindow(this Application app, UIA2Automation automation)
        {
            var window = automation.FromHandle(app.MainWindowHandle).AsWindow();
            return window;
        }
    }
}
