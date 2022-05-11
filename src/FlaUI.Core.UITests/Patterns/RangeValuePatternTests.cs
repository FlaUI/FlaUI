using FlaUI.Core.AutomationElements;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
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
            slider.Should().NotBeNull();
            var rvPattern = slider.Patterns.RangeValue.Pattern;
            rvPattern.Should().NotBeNull();
            rvPattern.IsReadOnly.Value.Should().BeFalse();
            rvPattern.Value.Value.Should().Be(5);
            rvPattern.LargeChange.Value.Should().Be(4);
            rvPattern.SmallChange.Value.Should().Be(1);
            rvPattern.Minimum.Value.Should().Be(0);
            rvPattern.Maximum.Value.Should().Be(10);
            var number1 = 6;
            rvPattern.SetValue(number1);
            rvPattern.Value.Value.Should().Be(number1);
            var number2 = 3;
            rvPattern.SetValue(number2);
            rvPattern.Value.Value.Should().Be(number2);
        }

        private AutomationElement GetSlider()
        {
            var element = Application.GetMainWindow(Automation).FindFirstDescendant(cf => cf.ByAutomationId("Slider"));
            return element;
        }
    }
}
