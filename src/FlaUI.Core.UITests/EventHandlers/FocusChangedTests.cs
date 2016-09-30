using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using FlaUI.UIA3.Conditions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

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
                var button1 = mainWindow.FindFirst(TreeScope.Descendants, ConditionFactory.ByControlType(ControlType.Button).And(ConditionFactory.ByText("Resize")));
                button1.AsButton().Invoke();
                Thread.Sleep(100);
                var radio2 = mainWindow.FindFirst(TreeScope.Descendants, ConditionFactory.ByControlType(ControlType.RadioButton).And(ConditionFactory.ByText("Pixels")));
                Mouse.Instance.Click(MouseButton.Left, radio2.GetClickablePoint());
                Thread.Sleep(100);
                Keyboard.Instance.PressVirtualKeyCode(VirtualKeyShort.ESCAPE);
                Thread.Sleep(100);
                automation.UnRegisterFocusChangedEvent(x);
                mainWindow.Close();
            }
            app.Dispose();
            Assert.That(focusChangedElements.Count, Is.GreaterThan(0));
        }
    }
}
