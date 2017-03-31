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

                Keyboard.Type("ééééééööööö aaa | ");

                Keyboard.Type(VirtualKeyShort.KEY_Z);
                Keyboard.Type(VirtualKeyShort.LEFT);
                Keyboard.Type(VirtualKeyShort.DELETE);
                Keyboard.Type(VirtualKeyShort.KEY_Y);
                Keyboard.Type(VirtualKeyShort.BACK);
                Keyboard.Type(VirtualKeyShort.KEY_X);

                Keyboard.Type(" | ");

                Keyboard.Type("ঋ ঌ এ ঐ ও ঔ ক খ গ ঘ ঙ চ ছ জ ঝ ঞ ট ঠ ড ঢ");

                Thread.Sleep(500);

                TestUtilities.CloseWindowWithDontSave(mainWindow);
            }
            app.Dispose();
        }
    }
}
