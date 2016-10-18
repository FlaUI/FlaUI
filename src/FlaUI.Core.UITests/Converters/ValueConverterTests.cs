using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Converters
{
   [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
   [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
   [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
   [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
   public class ValueConverterTests : UITestBase
   {
      public ValueConverterTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
      {
      }

      [Test]
      public void GetControlType()
      {
         var window = App.GetMainWindow(Automation);
         var checkBox = window.FindFirst(TreeScope.Descendants, Automation.ConditionFactory.ByName("Test Checkbox"));
         Assert.That(ControlType.CheckBox, Is.EqualTo(checkBox.Current.ControlType));
      }
   }
}
