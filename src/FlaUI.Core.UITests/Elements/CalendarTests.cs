using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
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
            RestartApplication();
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(2);
            //Wait.UntilInputIsProcessed();
            calendar = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("calendar")).AsCalendar();
            DateTime date = new DateTime(2020, 5, 21); // 21-May-2020
            calendar.SelectDate(date);
            DateTime[] selectedDates = calendar.SelectedDates;
            selectedDates.Should().HaveCount(1);
            selectedDates[0].Should().Be(date);
        }

        [Test]
        public void AddToSelectionTest()
        {
            DateTime date1 = new DateTime(2020, 5, 20); // 20-May-2020
            calendar.SelectDate(date1);
            DateTime date2 = new DateTime(2020, 5, 23); // 23-May-2020
            calendar.AddToSelection(date2);
            DateTime[] selectedDates = calendar.SelectedDates;
            selectedDates.Should().HaveCount(2);
            selectedDates[0].Should().Be(date1);
            selectedDates[1].Should().Be(date2);
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
            selectedDates.Should().HaveCount(3);
            selectedDates[0].Should().Be(date1);
            selectedDates[1].Should().Be(date2);
            selectedDates[2].Should().Be(date3);
        }

        [Test]
        public void AddRangeToSelectionTest()
        {
            DateTime date1 = new DateTime(2021, 3, 10);
            calendar.SelectDate(date1);
            DateTime date2 = new DateTime(2021, 3, 15);
            DateTime date3 = new DateTime(2021, 3, 17);
            DateTime[] dates = new DateTime[] { date2, date3 };
            calendar.AddRangeToSelection(dates);
            DateTime[] selectedDates = calendar.SelectedDates;
            selectedDates.Should().HaveCount(3);
            selectedDates[0].Should().Be(date1);
            selectedDates[1].Should().Be(date2);
            selectedDates[2].Should().Be(date3);
        }
    }
}
