using System.Threading;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class KeyboardTests
    {
        [Test]
        public void KeyboardTest()
        {
            var app = Application.Launch("notepad.exe");
            using (var automation = new UIA3Automation())
            {
                var mainWindow = app.GetMainWindow(automation);

                Keyboard.Write("ééééééööööö aaa | ");

                Keyboard.TypeVirtualKeyCode(VirtualKeyShort.KEY_Z);
                Keyboard.TypeVirtualKeyCode(VirtualKeyShort.LEFT);
                Keyboard.TypeVirtualKeyCode(VirtualKeyShort.DELETE);
                Keyboard.TypeVirtualKeyCode(VirtualKeyShort.KEY_Y);
                Keyboard.TypeVirtualKeyCode(VirtualKeyShort.BACK);
                Keyboard.TypeVirtualKeyCode(VirtualKeyShort.KEY_X);

                Keyboard.Write(" | ");

                Keyboard.Write("ঋ ঌ এ ঐ ও ঔ ক খ গ ঘ ঙ চ ছ জ ঝ ঞ ট ঠ ড ঢ");

                Thread.Sleep(500);

                TestUtilities.CloseWindowWithDontSave(mainWindow);
            }
            app.Dispose();
        }
    }
}
