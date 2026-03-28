using System.Threading;
using FlaUI.Core.AutomationElements;
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
    }

    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class KeyboardSelectionTests : UITestBase
    {
        public KeyboardSelectionTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void PressingShiftAndArrowSelectsText()
        {
            RestartApplication();
            var window = Application.GetMainWindow(Automation);
            var textBox = window.FindFirstDescendant(cf => cf.ByAutomationId("TextBox")).AsTextBox();

            // Clear and type known text
            textBox.Text = "Hello";
            Wait.UntilInputIsProcessed();

            // Focus the textbox and move cursor to the beginning
            textBox.Click();
            Wait.UntilInputIsProcessed();
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
            Wait.UntilInputIsProcessed();

            // Type over the selection to verify it worked.
            // If "Hello" was selected, typing "X" replaces it entirely.
            // If selection failed (the bug), "X" is inserted and we get "XHello".
            Keyboard.Type("X");
            Wait.UntilInputIsProcessed();
            Assert.That(textBox.Text, Is.EqualTo("X"));
        }
    }
}
