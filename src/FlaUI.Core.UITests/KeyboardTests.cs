using System.Threading;
using System.Windows.Forms;
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

                UtilityMethods.CloseWindowWithDontSave(mainWindow);
            }
            app.Dispose();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void PressingShiftAndArrowSelectsText()
        {
            var app = Application.Launch("notepad.exe");
            using (var automation = new UIA3Automation())
            {
                var mainWindow = app.GetMainWindow(automation);
                mainWindow.Focus();
                Wait.UntilInputIsProcessed();

                Keyboard.Type("Hello");
                Wait.UntilInputIsProcessed();

                // Move cursor to the beginning of the text
                Keyboard.Type(VirtualKeyShort.HOME);
                Wait.UntilInputIsProcessed();

                // Select all 5 characters using Shift+Right
                using (Keyboard.Pressing(VirtualKeyShort.LSHIFT))
                {
                    for (var i = 0; i < 5; i++)
                    {
                        Keyboard.Type(VirtualKeyShort.RIGHT);
                        Wait.UntilInputIsProcessed();
                    }
                }

                // Copy selection to clipboard with Ctrl+C
                Keyboard.TypeSimultaneously(VirtualKeyShort.CONTROL, VirtualKeyShort.KEY_C);
                Wait.UntilInputIsProcessed();

                var clipboardText = Clipboard.GetText();
                Assert.That(clipboardText, Is.EqualTo("Hello"));

                UtilityMethods.CloseWindowWithDontSave(mainWindow);
            }
            app.Dispose();
        }
    }
}
