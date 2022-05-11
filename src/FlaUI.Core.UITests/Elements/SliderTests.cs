using System.Drawing;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class SliderTests : UITestBase
    {
        public SliderTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void SlideThumbTest()
        {
            var slider = GetSlider();
            var thumb = slider.Thumb;
            var oldPos = thumb.Properties.BoundingRectangle.Value.Center();
            thumb.SlideHorizontally(50);
            UtilityMethods.AssertPointsAreSame(thumb.Properties.BoundingRectangle.Value.Center(), new Point(oldPos.X + 50, oldPos.Y), 1);
        }

        [Test]
        public void SetValueTest()
        {
            var slider = GetSlider();
            var number1 = AdjustNumberIfOnlyValue(slider, 6);
            slider.Value = number1;
            slider.Value.Should().Be(number1);
            var number2 = AdjustNumberIfOnlyValue(slider, 4);
            slider.Value = number2;
            slider.Value.Should().Be(number2);
        }

        [Test]
        public void SmallIncrementTest()
        {
            var slider = GetSlider();
            ResetToCenter(slider);
            slider.SmallIncrement();
            slider.Value.Should().Be(AdjustNumberIfOnlyValue(slider, 6));
        }

        [Test]
        public void SmallDecrementTest()
        {
            var slider = GetSlider();
            ResetToCenter(slider);
            slider.SmallDecrement();
            slider.Value.Should().Be(AdjustNumberIfOnlyValue(slider, 4));
        }

        [Test]
        public void LargeIncrementTest()
        {
            var slider = GetSlider();
            ResetToCenter(slider);
            slider.LargeIncrement();
            slider.Value.Should().Be(AdjustNumberIfOnlyValue(slider, 9));
        }

        [Test]
        public void LargeDecrementTest()
        {
            var slider = GetSlider();
            ResetToCenter(slider);
            slider.LargeDecrement();
            slider.Value.Should().Be(AdjustNumberIfOnlyValue(slider, 1));
        }

        private Slider GetSlider()
        {
            var element = Application.GetMainWindow(Automation).FindFirstDescendant(cf => cf.ByAutomationId("Slider")).AsSlider();
            return element;
        }

        /// <summary>
        /// The range of the test slider is set to 0-10, but in UIA3 WinForms,
        /// the range is always 0-100, so we fix this here
        /// </summary>
        private double AdjustNumberIfOnlyValue(Slider slider, double number)
        {
            if (slider.IsOnlyValue)
            {
                return number * 10;
            }
            return number;
        }

        private void ResetToCenter(Slider slider)
        {
            slider.Value = AdjustNumberIfOnlyValue(slider, 5);
        }
    }
}
