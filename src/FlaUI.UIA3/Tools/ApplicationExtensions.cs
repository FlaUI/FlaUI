using FlaUI.Core;
using FlaUI.UIA3.Elements;

namespace FlaUI.UIA3.Tools
{
    public static class ApplicationExtensions
    {
        public static Window GetMainWindow(this Application app, Automation automation)
        {
            var window = automation.FromHandle(app.MainWindowHandle).AsWindow();
            return window;
        }
    }
}
