using System;
using System.Drawing;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.UIA2;
using FlaUI.UIA3;
using NUnit.Framework;

namespace FlaUI.Core.UITests.TestFramework
{
    /// <summary>
    /// Various helpful methods.
    /// </summary>
    public static class UtilityMethods
    {
        public static AutomationBase GetAutomation(AutomationType automationType)
        {
            // Get and validate the version
            var uiaVersion = GetUiaVersion(automationType);
            if ((automationType == AutomationType.UIA2 && uiaVersion != AutomationType.UIA2) ||
                (automationType == AutomationType.UIA3 && uiaVersion != AutomationType.UIA3))
            {
                Assert.Inconclusive($"UIA parameter set to {uiaVersion} but automation of type {automationType} is requested");
            }

            switch (automationType)
            {
                case AutomationType.UIA2:
                    return new UIA2Automation();
                case AutomationType.UIA3:
                    return new UIA3Automation();
                default:
                    throw new ArgumentOutOfRangeException(nameof(automationType), automationType, null);
            }
        }

        public static AutomationType GetUiaVersion(AutomationType defaultIfNonExistent)
        {
            if (!TestContext.Parameters.Exists("uia"))
            {
                return defaultIfNonExistent;
            }
            var uiaVersion = Convert.ToInt32(TestContext.Parameters["uia"]);
            switch (uiaVersion)
            {
                case 2:
                    return AutomationType.UIA2;
                case 3:
                    return AutomationType.UIA3;
                default:
                    throw new ArgumentOutOfRangeException("uia", uiaVersion, null);
            }
        }

        public static void IgnoreOnUIA2()
        {
            if (GetUiaVersion(AutomationType.UIA3) != AutomationType.UIA3)
            {
                Assert.Ignore("Only run test in UIA3 context");
            }
        }

        /// <summary>
        /// Closes the given window and invokes the "Don't save" button
        /// </summary>
        public static void CloseWindowWithDontSave(Window window)
        {
            window.Close();
            Wait.UntilInputIsProcessed();
            var modalWindows = Retry.WhileEmpty(() => window.ModalWindows, TimeSpan.FromSeconds(1)).Result;
            Button dontSaveButton;
            if (Tools.OperatingSystem.IsWindows11())
            {
                dontSaveButton = modalWindows[0].FindFirstDescendant("SecondaryButton").AsButton();
            }
            else
            {
                dontSaveButton = modalWindows[0].FindFirstDescendant(cf => cf.ByAutomationId("CommandButton_7")).AsButton();
            }
            dontSaveButton.Invoke();
        }

        public static void AssertPointsAreSame(Point p1, Point p2, double variance = 0)
        {
            Assert.That(p1.X, Is.EqualTo(p2.X).Within(variance));
            Assert.That(p1.Y, Is.EqualTo(p2.Y).Within(variance));
        }
    }
}
