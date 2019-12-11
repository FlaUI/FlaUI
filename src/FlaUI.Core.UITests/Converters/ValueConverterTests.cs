﻿using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Converters
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class ValueConverterTests : FlaUITestBase
    {
        public ValueConverterTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
        {
        }

        [Test]
        public void GetControlType()
        {
            var window = Application.GetMainWindow(Automation);
            var checkBox = window.FindFirstDescendant(cf => cf.ByName("Test Checkbox"));
            Assert.That(ControlType.CheckBox, Is.EqualTo(checkBox.Properties.ControlType));
        }
    }
}
