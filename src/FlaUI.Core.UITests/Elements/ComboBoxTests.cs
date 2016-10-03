using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
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
            var combo = App.GetMainWindow(Uia3Automation).FindFirst(TreeScope.Descendants, Uia3Automation.ConditionFactory.ByAutomationId("EditableCombo"));
            Mouse.Instance.Click(MouseButton.Left, combo.Current.BoundingRectangle.ImmediateInteriorEast);
            var items = combo.FindAll(TreeScope.Descendants, new BoolCondition(true));
            System.Threading.Thread.Sleep(2000);
        }
    }
}