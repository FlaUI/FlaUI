using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Input;
using FlaUI.Core.Shapes;
using NUnit.Framework;

namespace FlaUI.Core.UITests.TestFramework
{
    /// <summary>
    /// Various helpful methods
    /// </summary>
    public static class TestUtilities
    {
        /// <summary>
        /// Closes the given window and invokes the "Don't save" button
        /// </summary>
        public static void CloseWindowWithDontSave(Window window)
        {
            window.Close();
            Helpers.WaitUntilInputIsProcessed();
            var modal = window.GetModalWindows();
            var dontSaveButton = modal[0].FindFirst(TreeScope.Descendants, window.AutomationObject.Automation.ConditionFactory.ByAutomationId("CommandButton_7")).AsButton();
            dontSaveButton.Invoke();
        }

        public static void AssertPointsAreSame(Point p1, Point p2, double variance = 0)
        {
            Assert.That(p1.X, Is.EqualTo(p2.X).Within(variance));
            Assert.That(p1.Y, Is.EqualTo(p2.Y).Within(variance));
        }
    }
}
