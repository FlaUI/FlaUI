using System.Threading;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class ComboBoxTests : UITestBase
    {
        public ComboBoxTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void Test()
        {
            var combo = App.GetMainWindow(Automation).FindFirst(TreeScope.Descendants, Automation.ConditionFactory.ByAutomationId("EditableCombo"));
            Mouse.Instance.Click(MouseButton.Left, combo.Current.BoundingRectangle.ImmediateInteriorEast);
            var items = combo.FindAll(TreeScope.Descendants, new BoolCondition(true));
            Thread.Sleep(2000);
        }
    }
}
