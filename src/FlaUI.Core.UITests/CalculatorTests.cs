using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
using FlaUI.Core.WindowsAPI;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class CalculatorTests : UITestBase
    {
        public CalculatorTests()
            : base(AutomationType.UIA3, TestApplicationType.Custom)
        {
        }

        [Test]
        public void CalculatorTest()
        {
            var window = App.GetMainWindow(Automation);
            Console.WriteLine(window.Title);
            var calc = SystemProductNameFetcher.IsWindows10() ? (ICalculator)new Win10Calc(window) : new LegacyCalc(window);

            // Switch to default mode
            Keyboard.Instance.PressVirtualKeyCode(VirtualKeyShort.ALT);
            Keyboard.Instance.TypeVirtualKeyCode(VirtualKeyShort.KEY_1);
            Keyboard.Instance.ReleaseVirtualKeyCode(VirtualKeyShort.ALT);
            Helpers.WaitUntilInputIsProcessed();
            App.WaitWhileBusy();

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
            App.WaitWhileBusy();
            var result = calc.Result;
            Assert.That(result, Is.EqualTo("6912"));

            // Date comparison
            Keyboard.Instance.PressVirtualKeyCode(VirtualKeyShort.CONTROL);
            Keyboard.Instance.TypeVirtualKeyCode(VirtualKeyShort.KEY_E);
            Keyboard.Instance.ReleaseVirtualKeyCode(VirtualKeyShort.CONTROL);

            /*
                // Verify can click on menu twice
                var menuBar = mainWindow.Get<MenuBar>(SearchCriteria.ByText("Application"));
                menuBar.MenuItem("Edit", "Copy").Click();
                menuBar.MenuItem("Edit", "Copy").Click();

                //On Date window find the difference between dates.
                //Set value into combobox
                mainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("4003")).Select("Calculate the difference between two dates");
                //Click on Calculate button
                mainWindow.Get<Button>(SearchCriteria.ByAutomationId("4009")).Click();

                mainWindow.Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
                mainWindow.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.F4);
                mainWindow.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);

                var menuView = mainWindow.Get<Menu>(SearchCriteria.ByText("View"));
                menuView.Click();
                var menuViewBasic = mainWindow.Get<Menu>(SearchCriteria.ByText("Basic"));
                menuViewBasic.Click();

            }*/
        }

        protected override Application StartApplication()
        {
            var app = SystemProductNameFetcher.IsWindows10()
                ? Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App")
                : Application.Launch("calc.exe");
            return app;
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
                var resultElement = _mainWindow.FindFirst(TreeScope.Descendants, _mainWindow.BasicAutomationElement.Automation.ConditionFactory.ByAutomationId("158"));
                var value = resultElement.Current.Name;
                return Regex.Replace(value, "[^0-9]", "");
            }
        }

        public LegacyCalc(AutomationElement mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private AutomationElement FindElement(string text)
        {
            var element = _mainWindow.FindFirst(TreeScope.Descendants, _mainWindow.BasicAutomationElement.Automation.ConditionFactory.ByText(text));
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
                var value = resultElement.Current.Name;
                return Regex.Replace(value, "[^0-9]", "");
            }
        }

        public Win10Calc(AutomationElement mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private AutomationElement FindElement(string text)
        {
            var element = _mainWindow.FindFirst(TreeScope.Descendants, _mainWindow.BasicAutomationElement.Automation.ConditionFactory.ByAutomationId(text));
            return element;
        }
    }
}
