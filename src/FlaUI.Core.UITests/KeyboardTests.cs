using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using FlaUI.UIA3.Tools;
using NUnit.Framework;
using System.Threading;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class KeyboardTests
    {
        [Test]
        public void KeyboardTest()
        {
            var app = Application.Launch("notepad.exe");
            var automation = new Automation();
            var mainWindow = app.GetMainWindow(automation);

            Keyboard.Instance.Write("ééééééööööö aaa | ");

            Keyboard.Instance.TypeVirtualKeyCode(VirtualKeyShort.KEY_Z);
            Keyboard.Instance.TypeVirtualKeyCode(VirtualKeyShort.LEFT);
            Keyboard.Instance.TypeVirtualKeyCode(VirtualKeyShort.DELETE);
            Keyboard.Instance.TypeVirtualKeyCode(VirtualKeyShort.KEY_Y);
            Keyboard.Instance.TypeVirtualKeyCode(VirtualKeyShort.BACK);
            Keyboard.Instance.TypeVirtualKeyCode(VirtualKeyShort.KEY_X);

            Keyboard.Instance.Write(" | ");

            Keyboard.Instance.Write("ঋ ঌ এ ঐ ও ঔ ক খ গ ঘ ঙ চ ছ জ ঝ ঞ ট ঠ ড ঢ");

            Thread.Sleep(500);

            TestUtilities.CloseWindowWithDontSave(mainWindow);

            app.Dispose();
        }
    }
}
