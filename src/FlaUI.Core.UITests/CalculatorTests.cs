using System;
using System.Text.RegularExpressions;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.TestUtilities;
using FlaUI.UIA3;
using NUnit.Framework;
using OperatingSystem = FlaUI.Core.Tools.OperatingSystem;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class CalculatorTests : FlaUITestBase
    {
        protected override AutomationBase GetAutomation()
        {
            return new UIA3Automation();
        }

        [Test]
        public void CalculatorTest()
        {
            var window = Application.GetMainWindow(Automation);
            var calc = (OperatingSystem.IsWindows10() || OperatingSystem.IsWindows11() || OperatingSystem.IsWindowsServer2019()) ? (ICalculator)new Win10Calc(window) : new LegacyCalc(window);

            // Switch to default mode
            System.Threading.Thread.Sleep(1000);
            Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.KEY_1);
            Wait.UntilInputIsProcessed();
            Application.WaitWhileBusy();
            System.Threading.Thread.Sleep(1000);

            // Simple addition
            calc.Button1.Click();
            calc.Button2.Click();
            calc.Button3.Click();
            calc.Button4.Click();
            calc.ButtonAdd.Click();
            calc.Button5.Click();
            calc.Button6.Click();
            calc.Button7.Click();
            calc.Button8.Click();
            calc.ButtonEquals.Click();
            Application.WaitWhileBusy();
            var result = calc.Result;
            Assert.That(result, Is.EqualTo("6912"));

            // Date comparison
            using (Keyboard.Pressing(VirtualKeyShort.CONTROL))
            {
                Keyboard.Type(VirtualKeyShort.KEY_E);
            }
        }

        protected override Application StartApplication()
        {
            if (OperatingSystem.IsWindows10())
            {
                // Use the store application on those systems
                return Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            }
            if (OperatingSystem.IsWindowsServer2016() || OperatingSystem.IsWindowsServer2019())
            {
                // The calc.exe on this system is just a stub which launches win32calc.exe
                return Application.Launch("win32calc.exe");
            }
            return Application.Launch("calc.exe");
        }
    }

    public interface ICalculator
    {
        Button Button1 { get; }
        Button Button2 { get; }
        Button Button3 { get; }
        Button Button4 { get; }
        Button Button5 { get; }
        Button Button6 { get; }
        Button Button7 { get; }
        Button Button8 { get; }
        Button ButtonAdd { get; }
        Button ButtonEquals { get; }
        string Result { get; }
    }

    public class LegacyCalc : ICalculator
    {
        private readonly AutomationElement _mainWindow;

        public Button Button1 => FindElement("1").AsButton();
        public Button Button2 => FindElement("2").AsButton();
        public Button Button3 => FindElement("3").AsButton();
        public Button Button4 => FindElement("4").AsButton();
        public Button Button5 => FindElement("5").AsButton();
        public Button Button6 => FindElement("6").AsButton();
        public Button Button7 => FindElement("7").AsButton();
        public Button Button8 => FindElement("8").AsButton();
        public Button ButtonAdd => FindElement("Add").AsButton();
        public Button ButtonEquals => FindElement("Equals").AsButton();

        public string Result
        {
            get
            {
                var resultElement = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("158"));
                var value = resultElement.Properties.Name;
                return Regex.Replace(value, "[^0-9]", String.Empty);
            }
        }

        public LegacyCalc(AutomationElement mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private AutomationElement FindElement(string text)
        {
            var element = _mainWindow.FindFirstDescendant(cf => cf.ByText(text));
            return element;
        }
    }

    public class Win10Calc : ICalculator
    {
        private readonly AutomationElement _mainWindow;

        public Button Button1 => FindElement("num1Button").AsButton();
        public Button Button2 => FindElement("num2Button").AsButton();
        public Button Button3 => FindElement("num3Button").AsButton();
        public Button Button4 => FindElement("num4Button").AsButton();
        public Button Button5 => FindElement("num5Button").AsButton();
        public Button Button6 => FindElement("num6Button").AsButton();
        public Button Button7 => FindElement("num7Button").AsButton();
        public Button Button8 => FindElement("num8Button").AsButton();
        public Button ButtonAdd => FindElement("plusButton").AsButton();
        public Button ButtonEquals => FindElement("equalButton").AsButton();

        public string Result
        {
            get
            {
                var resultElement = FindElement("CalculatorResults");
                var value = resultElement.Properties.Name;
                return Regex.Replace(value, "[^0-9]", String.Empty);
            }
        }

        public Win10Calc(AutomationElement mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private AutomationElement FindElement(string text)
        {
            var element = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(text));
            return element;
        }
    }
}
