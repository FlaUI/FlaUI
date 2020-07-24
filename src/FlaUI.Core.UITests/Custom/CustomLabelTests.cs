using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.UITests.TestFramework;
using FlaUI.Custom;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Custom
{
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class CustomLabelTests : UITestBase
    {
        public static CustomProperty ForegroundProperty = new CustomProperty(new Guid("e679d5ff-ec48-47d0-b2b6-a76f7a1ac9cc"), "Foreground", PropertyType.String);
        public static CustomProperty BackgroundProperty = new CustomProperty(new Guid("f267b0eb-f4ea-4724-b7e0-347bded70c40"), "Background", PropertyType.String);

        private PropertyId prop1;
        private PropertyId prop2;

        private Label customLabel;

        public CustomLabelTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
            Registrar.RegisterPropertyInUIA3(ForegroundProperty);
            Registrar.RegisterPropertyInUIA3(BackgroundProperty);

            prop1 = PropertyId.Register(automationType, ForegroundProperty.Id, ForegroundProperty.Name);
            prop2 = PropertyId.Register(automationType, BackgroundProperty.Id, BackgroundProperty.Name);
        }

        [OneTimeSetUp]
        public void SelectLabel()
        {
            RestartApplication();
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(2);
            customLabel = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("customLabel")).AsLabel();
        }

        [Test]
        public void LabelColorTest()
        {
            var foreground = customLabel.FrameworkAutomationElement.GetPropertyValue(prop1);
            var background = customLabel.FrameworkAutomationElement.GetPropertyValue(prop2);

            TestContext.Progress.WriteLine(foreground);
            TestContext.Progress.WriteLine(background);
        }
    }
}
