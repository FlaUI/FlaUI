using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class CalendarTests : UITestBase
    {
        Calendar calendar = null;
    
        public CalendarTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectDateTest()
        {
            //Console.WriteLine("AutomationType: " + AutomationType.ToString());
            RestartApplication();
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(2);
            //Wait.UntilInputIsProcessed();
            calendar = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("calendar")).AsCalendar();
            DateTime date = new DateTime(2020, 5, 21); // 21-May-2020
            calendar.SelectDate(date); 
            DateTime[] selectedDates = calendar.SelectedDates;
            Assert.That(selectedDates, Has.Length.EqualTo(1));
            Assert.That(selectedDates[0], Is.EqualTo(date));
        }
        
        [Test]
        public void AddToSelectionTest()
        {
            DateTime date = new DateTime(2020, 5, 23); // 23-May-2020
            calendar.AddToSelection(date);
            DateTime[] selectedDates = calendar.SelectedDates;
            Assert.That(selectedDates, Has.Length.EqualTo(2));
            Assert.That(selectedDates[0], Is.EqualTo(new DateTime(2020, 5, 21)));
            Assert.That(selectedDates[1], Is.EqualTo(date));
        }
    }
}
