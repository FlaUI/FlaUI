using System.Collections.Generic;
using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.TestUtilities;
using FlaUI.UIA3;
using NUnit.Framework;
using OperatingSystem = FlaUI.Core.Tools.OperatingSystem;

namespace FlaUI.Core.UITests.EventHandlers
{
    [TestFixture]
    public class FocusChangedTests : FlaUITestBase
    {
        protected override AutomationBase GetAutomation()
        {
            return new UIA3Automation();
        }

        protected override Application StartApplication()
        {
            var app = Application.Launch("mspaint");
            app.WaitWhileMainHandleIsMissing();
            return app;
        }

        [Test]
        public void FocusChangedWithPaintTest()
        {
            var focusChangedElements = new List<string>();
            var mainWindow = Application.GetMainWindow(Automation);
            var x = Automation.RegisterFocusChangedEvent(element => { focusChangedElements.Add(element.ToString()); });
            Thread.Sleep(100);
            var button1 = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Button).And(cf.ByText(GetResizeText())));
            button1.AsButton().Invoke();
            Thread.Sleep(100);
            var radio2 = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.RadioButton).And(cf.ByText(GetPixelsText())));
            Mouse.Click(radio2.GetClickablePoint());
            Thread.Sleep(100);
            Keyboard.Press(VirtualKeyShort.ESCAPE);
            Thread.Sleep(100);
            x.Dispose();
            mainWindow.Close();
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
