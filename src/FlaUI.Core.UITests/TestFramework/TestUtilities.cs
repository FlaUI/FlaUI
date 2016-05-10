using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Input;

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
            var dontSaveButton = modal[0].FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId("CommandButton_7")).AsButton();
            dontSaveButton.Invoke();
        }
    }
}
