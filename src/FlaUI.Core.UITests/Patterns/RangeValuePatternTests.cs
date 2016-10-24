using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Patterns
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class RangeValuePatternTests : UITestBase
    {
        public RangeValuePatternTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
        {
        }

        [Test]
        public void RangeValuePatternTest()
        {
            var slider = GetSlider();
            Assert.That(slider, Is.Not.Null);
            var rvPattern = slider.PatternFactory.GetRangeValuePattern();
            Assert.That(rvPattern, Is.Not.Null);
            Assert.That(rvPattern.Current.IsReadOnly, Is.False);
            Assert.That(rvPattern.Current.Value, Is.EqualTo(5));
            Assert.That(rvPattern.Current.LargeChange, Is.EqualTo(4));
            Assert.That(rvPattern.Current.SmallChange, Is.EqualTo(1));
            Assert.That(rvPattern.Current.Minimum, Is.EqualTo(0));
            Assert.That(rvPattern.Current.Maximum, Is.EqualTo(10));
            var number1 = 6;
            rvPattern.SetValue(number1);
            Assert.That(rvPattern.Current.Value, Is.EqualTo(number1));
            var number2 = 3;
            rvPattern.SetValue(number2);
            Assert.That(rvPattern.Current.Value, Is.EqualTo(number2));
        }

        private AutomationElement GetSlider()
        {
            var element = App.GetMainWindow(Automation).FindFirstDescendant(Automation.ConditionFactory.ByAutomationId("Slider"));
            return element;
        }
    }
}
