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
            Application app;
            switch (ApplicationType)
            {
                case TestApplicationType.WinForms:
                    app = Application.Launch(GetTestApplicationPath("WinFormsApplication"));
                    break;
                case TestApplicationType.Wpf:
                    app = Application.Launch(GetTestApplicationPath("WpfApplication"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            app.WaitWhileMainHandleIsMissing();
            return app;
        }

        private static string GetTestApplicationPath(string projectName)
        {
            var targetFrameworkDirectory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            var configurationDirectory = targetFrameworkDirectory.Parent;
            var binDirectory = configurationDirectory?.Parent;
            var uiTestsProjectDirectory = binDirectory?.Parent;
            var srcDirectory = uiTestsProjectDirectory?.Parent;
            if (configurationDirectory == null || binDirectory == null || srcDirectory == null)
            {
                throw new DirectoryNotFoundException($"Could not determine the repository layout from '{targetFrameworkDirectory.FullName}'.");
            }

            var applicationPath = Path.Combine(
                srcDirectory.FullName,
                "TestApplications",
                projectName,
                "bin",
                configurationDirectory.Name,
                targetFrameworkDirectory.Name,
                projectName + ".exe");

            if (!File.Exists(applicationPath))
            {
                throw new FileNotFoundException($"The {projectName} test application was not built for the current test target.", applicationPath);
            }
            return applicationPath;
        }
    }
}
