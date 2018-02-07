using System.Collections.Generic;
using System.Threading;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using NUnit.Framework;

namespace FlaUI.Core.UITests.EventHandlers
{
    [TestFixture]
    public class FocusChangedTests
    {
        [Test]
        public void FocusChangedWithPaintTest()
        {
            var app = Application.Launch("mspaint");
            var focusChangedElements = new List<string>();
            using (var automation = new UIA3Automation())
            {
                var mainWindow = app.GetMainWindow(automation);
                var x = automation.RegisterFocusChangedEvent(element => { focusChangedElements.Add(element.ToString()); });
                Thread.Sleep(100);
                var button1 = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Button).And(cf.ByText(GetResizeText())));
                button1.AsButton().Invoke();
                Thread.Sleep(100);
                var radio2 = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.RadioButton).And(cf.ByText(GetPixelsText())));
                Mouse.Click(MouseButton.Left, radio2.GetClickablePoint());
                Thread.Sleep(100);
                Keyboard.Press(VirtualKeyShort.ESCAPE);
                Thread.Sleep(100);
                x.Dispose();
                mainWindow.Close();
            }
            app.Dispose();
            Assert.That(focusChangedElements.Count, Is.GreaterThan(0));
        }

        private string GetResizeText()
        {
            switch (OperatingSystem.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "de":
                    return "Größe ändern";
                default:
                    return "Resize";
            }
        }

        private string GetPixelsText()
        {
            switch (OperatingSystem.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "de":
                    return "Pixel";
                default:
                    return "Pixels";
            }
        }
    }
}
