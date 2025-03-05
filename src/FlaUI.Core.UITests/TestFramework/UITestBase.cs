using System;
using System.IO;
using FlaUI.TestUtilities;
using NUnit.Framework;

namespace FlaUI.Core.UITests.TestFramework
{
    /// <summary>
    /// Base class for UI Tests with FlaUI test applications.
    /// </summary>
    public class UITestBase : FlaUITestBase
    {
        protected UITestBase(AutomationType automationType, TestApplicationType appType)
        {
            AutomationType = automationType;
            ApplicationType = appType;
        }

        protected AutomationType AutomationType { get; }

        protected TestApplicationType ApplicationType { get; }

        protected override ApplicationStartMode ApplicationStartMode => ApplicationStartMode.OncePerFixture;

        protected override AutomationBase GetAutomation()
        {
            return UtilityMethods.GetAutomation(AutomationType);
        }

        protected override Application StartApplication()
        {
            string basePath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\..\..\TestApplications\");

            Application app;
            switch (ApplicationType)
            {
                case TestApplicationType.WinForms:
                    app = Application.Launch(Path.Combine(basePath, @"WinFormsApplication\bin\Debug\net48\WinFormsApplication.exe"));
                    break;
                case TestApplicationType.Wpf:
                    app = Application.Launch(Path.Combine(basePath, @"WpfApplication\bin\Debug\net9.0-windows\WpfApplication.exe"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            app.WaitWhileMainHandleIsMissing();
            return app;
        }
    }
}
