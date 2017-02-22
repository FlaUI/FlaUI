using System;
using System.Threading;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Patterns
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class InvokePatternTests : UITestBase
    {
        public InvokePatternTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void InvokeWithEventTest()
        {
            var mainWindow = App.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            var tabItem = tab.TabItems[0];
            var button = tabItem.FindFirstDescendant(cf => cf.ByAutomationId("InvokableButton"));
            Assert.That(button, Is.Not.Null);
            var origButtonText = button.Information.Name;
            var invokePattern = button.PatternFactory.GetInvokePattern();
            Assert.That(invokePattern, Is.Not.Null);
            var invokeFired = false;
            var waitHandle = new ManualResetEventSlim(false);
            var registeredEvent = button.RegisterEvent(invokePattern.Events.InvokedEvent, TreeScope.Element, (element, id) =>
            {
                invokeFired = true;
                waitHandle.Set();
            });
            invokePattern.Invoke();
            var waitResult = waitHandle.Wait(TimeSpan.FromSeconds(1));
            Assert.That(waitResult, Is.True);
            Assert.That(button.Information.Name, Is.Not.EqualTo(origButtonText));
            Assert.That(invokeFired, Is.True);
            button.RemoveAutomationEventHandler(invokePattern.Events.InvokedEvent, registeredEvent);
        }
    }
}
