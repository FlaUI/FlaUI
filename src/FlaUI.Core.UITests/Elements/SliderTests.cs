using FlaUI.Core.Elements;
using FlaUI.Core.Input;
using FlaUI.Core.Shapes;
using FlaUI.Core.UITests.TestFramework;
using FlaUI.UIA3.Conditions;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Tools;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(TestApplicationType.WinForms)]
    [TestFixture(TestApplicationType.Wpf)]
    public class SliderTests : UITestBase
    {
        public SliderTests(TestApplicationType appType)
            : base(appType)
        {
        }

        [Test]
        public void SlideThumbTest()
        {
            var slider = GetSlider();
            var thumb = slider.Thumb;
            var oldPos = thumb.Current.BoundingRectangle.Center;
            thumb.SlideHorizontally(50);
            Helpers.WaitUntilInputIsProcessed();
            TestUtilities.AssertPointsAreSame(thumb.Current.BoundingRectangle.Center, new Point(oldPos.X + 50, oldPos.Y), 1);
        }

        [Test]
        public void SetValueTest()
        {
            var slider = GetSlider();
            slider.Value = FixNumberForWinforms(5);
            Assert.That(slider.Value, Is.EqualTo(FixNumberForWinforms(5)));
        }
        [Test]
        public void SmallIncrementTest()
        {
            var slider = GetSlider();
            slider.Value = FixNumberForWinforms(5);
            slider.SmallIncrement();
            Assert.That(slider.Value, Is.EqualTo(FixNumberForWinforms(6)));
        }

        [Test]
        public void SmallDecrementTest()
        {
            var slider = GetSlider();
            slider.Value = FixNumberForWinforms(5);
            slider.SmallDecrement();
            Assert.That(slider.Value, Is.EqualTo(FixNumberForWinforms(4)));
        }

        [Test]
        public void LargeIncrementTest()
        {
            var slider = GetSlider();
            slider.Value = FixNumberForWinforms(5);
            slider.LargeIncrement();
            Assert.That(slider.Value, Is.EqualTo(FixNumberForWinforms(9)));
        }

        [Test]
        public void LargeDecrementTest()
        {
            var slider = GetSlider();
            slider.Value = FixNumberForWinforms(5);
            slider.LargeDecrement();
            Assert.That(slider.Value, Is.EqualTo(FixNumberForWinforms(1)));
        }

        private Slider GetSlider()
        {
            var element = App.GetMainWindow(Uia3Automation).FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId("Slider")).AsSlider();
            return element;
        }

        /// <summary>
        /// The range of the slider is 0-10, but in UIA 3.0 Winforms,
        /// the range is always 0-100, so we fix this here
        /// </summary>
        private double FixNumberForWinforms(double number)
        {
            if (ApplicationType == TestApplicationType.Wpf)
            {
                return number;
            }
            return number * 10;
        }
    }
}
