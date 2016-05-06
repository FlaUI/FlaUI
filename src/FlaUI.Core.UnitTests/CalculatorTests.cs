using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace FlaUI.Core.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void CalculatorTest()
        {
            var app = SystemProductNameFetcher.IsWindows10()
                ? Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App")
                : Application.Launch("calc.exe");
            var window = app.GetMainWindow();
            Console.WriteLine(window.Title);
            var calc = SystemProductNameFetcher.IsWindows10() ? (ICalculator)new Win10Calc(window) : new LegacyCalc(window);

            // Switch to default mode
            window.Automation.Keyboard.PressVirtualKeyCode(VirtualKeyShort.ALT);
            window.Automation.Keyboard.TypeVirtualKeyCode(VirtualKeyShort.KEY_1);
            window.Automation.Keyboard.ReleaseVirtualKeyCode(VirtualKeyShort.ALT);
            Input.Helpers.WaitUntilInputIsProcessed();
            app.WaitWhileBusy();

            // Simple addition
            calc.Button1.PatternFactory.GetInvokePattern().Invoke();
            calc.Button2.PatternFactory.GetInvokePattern().Invoke();
            calc.Button3.PatternFactory.GetInvokePattern().Invoke();
            calc.Button4.PatternFactory.GetInvokePattern().Invoke();
            calc.ButtonAdd.PatternFactory.GetInvokePattern().Invoke();
            calc.Button5.PatternFactory.GetInvokePattern().Invoke();
            calc.Button6.PatternFactory.GetInvokePattern().Invoke();
            calc.Button7.PatternFactory.GetInvokePattern().Invoke();
            calc.Button8.PatternFactory.GetInvokePattern().Invoke();
            calc.ButtonEquals.PatternFactory.GetInvokePattern().Invoke();
            var result = calc.Result;
            Assert.That(result, Is.EqualTo("6912"));

            // Date comparison
            window.Automation.Keyboard.PressVirtualKeyCode(VirtualKeyShort.CONTROL);
            window.Automation.Keyboard.TypeVirtualKeyCode(VirtualKeyShort.KEY_E);
            window.Automation.Keyboard.ReleaseVirtualKeyCode(VirtualKeyShort.CONTROL);

            app.Close();


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
    }

    public interface ICalculator
    {
        AutomationElement Button1 { get; }
        AutomationElement Button2 { get; }
        AutomationElement Button3 { get; }
        AutomationElement Button4 { get; }
        AutomationElement Button5 { get; }
        AutomationElement Button6 { get; }
        AutomationElement Button7 { get; }
        AutomationElement Button8 { get; }
        AutomationElement ButtonAdd { get; }
        AutomationElement ButtonEquals { get; }
        string Result { get; }
    }

    // TODO: Implement
    public class LegacyCalc : ICalculator
    {
        private readonly AutomationElement _mainWindow;

        public AutomationElement Button1 { get { return FindElement("1"); } }

        public AutomationElement Button2 { get { return FindElement("2"); } }

        public AutomationElement Button3 { get { return FindElement("3"); } }

        public AutomationElement Button4 { get { return FindElement("4"); } }

        public AutomationElement Button5 { get { return FindElement("5"); } }

        public AutomationElement Button6 { get { return FindElement("6"); } }

        public AutomationElement Button7 { get { return FindElement("7"); } }

        public AutomationElement Button8 { get { return FindElement("8"); } }

        public AutomationElement ButtonAdd { get { return FindElement("Add"); } }

        public AutomationElement ButtonEquals { get { return FindElement("Equals"); } }

        public string Result
        {
            get
            {
                var resultElement = _mainWindow.FindFirst(TreeScope.Descendants,
                        new PropertyCondition(
                            AutomationElement.AutomationIdProperty, "158"));
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
            var element = _mainWindow.FindFirst(TreeScope.Descendants,
                        new PropertyCondition(
                            AutomationElement.NameProperty, text));
            return element;
        }
    }

    public class Win10Calc : ICalculator
    {
        private readonly AutomationElement _mainWindow;

        public AutomationElement Button1 { get { return FindElement("num1Button"); } }

        public AutomationElement Button2 { get { return FindElement("num2Button"); } }

        public AutomationElement Button3 { get { return FindElement("num3Button"); } }

        public AutomationElement Button4 { get { return FindElement("num4Button"); } }

        public AutomationElement Button5 { get { return FindElement("num5Button"); } }

        public AutomationElement Button6 { get { return FindElement("num6Button"); } }

        public AutomationElement Button7 { get { return FindElement("num7Button"); } }

        public AutomationElement Button8 { get { return FindElement("num8Button"); } }

        public AutomationElement ButtonAdd { get { return FindElement("plusButton"); } }

        public AutomationElement ButtonEquals { get { return FindElement("equalButton"); } }

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
            var element = _mainWindow.FindFirst(TreeScope.Descendants, new PropertyCondition(
                AutomationElement.AutomationIdProperty, text));
            return element;
        }
    }
}
