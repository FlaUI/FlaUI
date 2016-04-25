using FlaUI.Core.Tools;
using NUnit.Framework;
using System;

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
            app.Close();


            /*//strat process for the above exe file location
            var psi = new ProcessStartInfo(ExeSourceFile);
            // launch the process through white application
            using (var application = Application.AttachOrLaunch(psi))
            using (var mainWindow = application.GetWindow(SearchCriteria.ByText("Calculator"), InitializeOption.NoCache))
            {
                // Verify can click on menu twice
                var menuBar = mainWindow.Get<MenuBar>(SearchCriteria.ByText("Application"));
                menuBar.MenuItem("Edit", "Copy").Click();
                menuBar.MenuItem("Edit", "Copy").Click();

                mainWindow.Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
                mainWindow.Keyboard.Enter("E");
                mainWindow.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);

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

                PerformSummationOnCalculator(mainWindow);
            }*/
        }

        /// <summary>
        /// method to Perform Addition of two numbers and validate the result
        /// </summary>
        /*private static void PerformSummationOnCalculator(UIItemContainer mainWindow)
        {
            mainWindow.Get<Button>(SearchCriteria.ByText("1")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("2")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("3")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("4")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("Add")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("5")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("6")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("7")).Click();
            mainWindow.Get<Button>(SearchCriteria.ByText("8")).Click();
            //Button with text as +(for sum)
            //Read button to get the result
            mainWindow.Get<Button>(SearchCriteria.ByText("Equals")).Click();

            //Get the result
            var resultLable = mainWindow.Get<Label>(SearchCriteria.ByAutomationId("150"));
            var result = resultLable.Text;
            Assert.That(result, Is.EqualTo("6912"));
        }*/
    }
}
