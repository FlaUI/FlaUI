﻿using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using FlaUI.UIA3.Conditions;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Tools;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(TestApplicationType.WinForms)]
    [TestFixture(TestApplicationType.Wpf)]
    public class ComboBoxTests : UITestBase
    {
        public ComboBoxTests(TestApplicationType appType)
            : base(appType)
        {
        }

        [Test]
        public void Test()
        {
            var combo = App.GetMainWindow(Uia3Automation).FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId("EditableCombo"));
            Mouse.Instance.Click(MouseButton.Left, combo.Current.BoundingRectangle.ImmediateInteriorEast);
            var items = combo.FindAll(TreeScope.Descendants, new BoolCondition(true));
            System.Threading.Thread.Sleep(2000);
        }
    }
}