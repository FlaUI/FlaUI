using System;
using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Patterns
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class InvokePatternTests : FlaUITestBase
    {
        public InvokePatternTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void InvokeWithEventTest()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            var tabItem = tab.TabItems[0];
            var button = tabItem.FindFirstDescendant(cf => cf.ByAutomationId("InvokableButton"));
            Assert.That(button, Is.Not.Null);
            var origButtonText = button.Properties.Name.Value;
            var invokePattern = button.Patterns.Invoke.Pattern;
            Assert.That(invokePattern, Is.Not.Null);
            var invokeFired = false;
            var waitHandle = new ManualResetEventSlim(false);
            var registeredEvent = button.RegisterAutomationEvent(invokePattern.EventIds.InvokedEvent, TreeScope.Element, (element, id) =>
            {
                invokeFired = true;
                waitHandle.Set();
            });
            invokePattern.Invoke();
            var waitResult = waitHandle.Wait(TimeSpan.FromSeconds(1));
            Assert.That(waitResult, Is.True);
            Assert.That(button.Properties.Name, Is.Not.EqualTo(origButtonText));
            Assert.That(invokeFired, Is.True);
            registeredEvent.Dispose();
        }
    }
}
