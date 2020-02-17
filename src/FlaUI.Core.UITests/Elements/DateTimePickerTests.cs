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
            var mainWindow = App.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(2);
            //Wait.UntilInputIsProcessed();
            var dateTimePicker = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("datePicker")).AsDateTimePicker();
            DateTime date = new DateTime(2020, 5, 21); // 21-May-2020
            dateTimePicker.SelectedDate = date;
            DateTime selectedDate = dateTimePicker.SelectedDate;
            Assert.That(selectedDate, Is.EqualTo(date));
        }
    }
}
