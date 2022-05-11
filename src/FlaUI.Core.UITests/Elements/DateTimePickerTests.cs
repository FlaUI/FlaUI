using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class DateTimePickerTests : UITestBase
    {
        public DateTimePickerTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void SelectDateTest()
        {
            //RestartApp();
            var mainWindow = Application.GetMainWindow(Automation);
            DateTimePicker dateTimePicker = null;

            if (ApplicationType == TestApplicationType.Wpf)
            {
                var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
                tab.SelectTabItem(2);
                dateTimePicker = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("datePicker")).AsDateTimePicker();
            }
            else // TestApplicationType.WinForms
            {
                dateTimePicker = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("dateTimePicker1")).AsDateTimePicker();
            }

            DateTime date = new DateTime(2021, 5, 17); // 17-May-2021
            dateTimePicker.SelectedDate = date;
            DateTime selectedDate = dateTimePicker.SelectedDate.Value;
            selectedDate.Should().Be(date);
        }
    }
}
