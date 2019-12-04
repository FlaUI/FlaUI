using System;
using System.Text.RegularExpressions;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.UITests.WordPad.Screens
{
    public class MainScreen : Window
    {
        public MainScreen(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        protected Button ZoomInButton => FindFirstNested(cf => new ConditionBase[] {
            cf.ByControlType(ControlType.StatusBar),
            cf.ByControlType(ControlType.Pane),
            cf.ByText("+")
        }).AsButton();

        protected Button ZoomOutButton => FindFirstNested(cf => new ConditionBase[] {
            cf.ByControlType(ControlType.StatusBar),
            cf.ByControlType(ControlType.Pane),
            cf.ByText("-")
        }).AsButton();

        protected TextBox ZoomText => FindFirstNested(cf => new ConditionBase[] {
            cf.ByControlType(ControlType.StatusBar),
            cf.ByControlType(ControlType.Pane),
            cf.ByControlType(ControlType.Text)
        }).AsTextBox();

        public void ZoomIn()
        {
            var currentZoom = ZoomText.Text;
            ZoomInButton.Invoke();
            WaitUntilZoomTextChanged(currentZoom);
        }

        public void ZoomOut()
        {
            var currentZoom = ZoomText.Text;
            ZoomOutButton.Invoke();
            WaitUntilZoomTextChanged(currentZoom);
        }

        public int GetCurrentZoomPercent()
        {
            var zoomText = ZoomText.Text;
            var zoomNumberString = Regex.Match(zoomText, @"[0-9]+").ToString();
            return Convert.ToInt32(zoomNumberString);
        }

        public InfoScreen OpenAndGetInfoScreen()
        {
            // Open the screen with shortcuts
            if (Tools.OperatingSystem.CurrentCulture.TwoLetterISOLanguageName == "de")
            {
                Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.KEY_D);
                Keyboard.Type(VirtualKeyShort.KEY_I);
            }
            else
            {
                Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.KEY_F);
                Keyboard.Type(VirtualKeyShort.KEY_T);
            }

            // Do a retry to wait for the window
            return Retry.Find(() => FindFirstChild(cf => cf.ByControlType(ControlType.Window).And(cf.ByName("Info"))),
                new RetrySettings
                {
                    Timeout = TimeSpan.FromSeconds(1),
                    ThrowOnTimeout = true,
                    TimeoutMessage = "Failed to find info screen"
                })
            .As<InfoScreen>();
        }

        private void WaitUntilZoomTextChanged(string oldZoomText)
        {
            Retry.WhileTrue(() => oldZoomText == ZoomText.Text, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: true, timeoutMessage: "Failed to change zoom");
        }
    }
}
