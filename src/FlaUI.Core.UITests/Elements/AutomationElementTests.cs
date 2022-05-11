using System;
using FlaUI.Core.Definitions;
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
    public class AutomationElementTests : UITestBase
    {
        public AutomationElementTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void ParentTest()
        {
            RestartApplication();
            var window = Application.GetMainWindow(Automation);
            var child = window.FindFirstChild();
            child.Parent.ControlType.Should().Be(ControlType.Window);
        }

        [Test]
        public void IsAvailableTest()
        {
            RestartApplication();
            var window = Application.GetMainWindow(Automation);
            window.IsAvailable.Should().BeTrue();
            window.Close();
            Retry.WhileTrue(() => window.IsAvailable, TimeSpan.FromSeconds(1));
            window.IsAvailable.Should().BeFalse();
        }
    }
}