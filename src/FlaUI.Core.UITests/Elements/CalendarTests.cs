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
        private Calendar calendar = null;
    
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
        
        [Test]
        public void SelectRangeTest()
        {
            DateTime date1 = new DateTime(2021, 3, 8); // 8-Mar-2021
            DateTime date2 = new DateTime(2021, 3, 9); // 9-Mar-2021
            DateTime date3 = new DateTime(2021, 3, 11); // 11-Mar-2021
            DateTime[] dates = new DateTime[] { date1, date2, date3 };
            calendar.SelectRange(dates);
            DateTime[] selectedDates = calendar.SelectedDates;
            Assert.That(selectedDates, Has.Length.EqualTo(3));
            Assert.That(selectedDates[0], Is.EqualTo(date1));
            Assert.That(selectedDates[1], Is.EqualTo(date2));
            Assert.That(selectedDates[2], Is.EqualTo(date3));
        }
        
        [Test]
        public void AddRangeToSelectionTest()
        {
            DateTime date1 = new DateTime(2021, 3, 15);
            DateTime date2 = new DateTime(2021, 3, 17);
            DateTime[] dates = new DateTime[] { date1, date2 };
            calendar.AddRangeToSelection(dates);
            DateTime[] selectedDates = calendar.SelectedDates;
            Assert.That(selectedDates, Has.Length.EqualTo(5));
            Assert.That(selectedDates[0], Is.EqualTo(new DateTime(2021, 3, 8)));
            Assert.That(selectedDates[1], Is.EqualTo(new DateTime(2021, 3, 9)));
            Assert.That(selectedDates[2], Is.EqualTo(new DateTime(2021, 3, 11)));
            Assert.That(selectedDates[3], Is.EqualTo(date1));
            Assert.That(selectedDates[4], Is.EqualTo(date2));
        }
    }
}
