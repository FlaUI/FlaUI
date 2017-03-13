using System;
using FlaUI.Core.Definitions;
using FlaUI.Core.Exceptions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FlaUI.Core.UITests
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.Custom)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Custom)]
    public class GetterTests : UITestBase
    {
        public GetterTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
        {
        }

        protected override Application StartApplication()
        {
            return Application.Launch("notepad.exe");
        }

        #region Pattern
        [Test]
        public void CorrectPattern()
        {
            var mainWindow = App.GetMainWindow(Automation);
            Assert.That(mainWindow, Is.Not.Null);
            var windowPattern = mainWindow.BasicAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.WindowPattern);
            Assert.That(windowPattern, Is.Not.Null);
        }

        [Test]
        public void CorrectPatternCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Patterns.Add(Automation.PatternLibrary.WindowPattern);
            using (cacheRequest.Activate())
            {
                var mainWindow = App.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                var windowPattern = mainWindow.BasicAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.WindowPattern);
                Assert.That(windowPattern, Is.Not.Null);
            }
        }

        [Test]
        public void UnsupportedPattern()
        {
            var mainWindow = App.GetMainWindow(Automation);
            Assert.That(mainWindow, Is.Not.Null);
            ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.ExpandCollapsePattern);
            Assert.That(testDelegate, Throws.TypeOf<PatternNotSupportedException>().With.Message.Contains("ExpandCollapse"));
        }

        [Test]
        public void UnsupportedPatternCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Patterns.Add(Automation.PatternLibrary.ExpandCollapsePattern);
            using (cacheRequest.Activate())
            {
                var mainWindow = App.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.ExpandCollapsePattern);
                Assert.That(testDelegate, Throws.TypeOf<PatternNotSupportedException>().With.Message.Contains("ExpandCollapse"));
            }
        }

        [Test]
        public void CorrectPatternUncached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Patterns.Add(Automation.PatternLibrary.ExpandCollapsePattern);
            using (cacheRequest.Activate())
            {
                var mainWindow = App.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.WindowPattern);
                Assert.That(testDelegate, Throws.TypeOf<PatternNotCachedException>().With.Message.Contains("Window"));
            }
        }

        [Test]
        public void UnsupportedPatternUnCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Patterns.Add(Automation.PatternLibrary.WindowPattern);
            using (cacheRequest.Activate())
            {
                var mainWindow = App.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.ExpandCollapsePattern);
                Assert.That(testDelegate, Throws.TypeOf<PatternNotCachedException>().With.Message.Contains("ExpandCollapse"));
            }
        }
        #endregion Pattern

        #region Property
        [Test]
        public void CorrectProperty()
        {
            var mainWindow = App.GetMainWindow(Automation);
            Assert.That(mainWindow, Is.Not.Null);
            var windowProperty = mainWindow.BasicAutomationElement.GetPropertyValue(Automation.PropertyLibrary.Window.CanMaximize);
            Assert.That(windowProperty, Is.Not.Null);
        }

        [Test]
        public void CorrectPropertyCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Properties.Add(Automation.PropertyLibrary.Window.CanMaximize);
            using (cacheRequest.Activate())
            {
                var mainWindow = App.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                var windowProperty = mainWindow.BasicAutomationElement.GetPropertyValue(Automation.PropertyLibrary.Window.CanMaximize);
                Assert.That(windowProperty, Is.Not.Null);
            }
        }

        [Test]
        public void UnsupportedProperty()
        {
            var mainWindow = App.GetMainWindow(Automation);
            Assert.That(mainWindow, Is.Not.Null);
            ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetPropertyValue(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
            Assert.That(testDelegate, Throws.TypeOf<PropertyNotSupportedException>().With.Message.Contains("ExpandCollapseState"));
        }

        [Test]
        public void UnsupportedPropertyCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Properties.Add(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
            using (cacheRequest.Activate())
            {
                var mainWindow = App.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetPropertyValue(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
                Assert.That(testDelegate, Throws.TypeOf<PropertyNotSupportedException>().With.Message.Contains("ExpandCollapseState"));
            }
        }

        [Test]
        public void CorrectPropertyUncached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Properties.Add(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
            using (cacheRequest.Activate())
            {
                var mainWindow = App.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetPropertyValue(Automation.PropertyLibrary.Window.CanMaximize);
                Assert.That(testDelegate, Throws.TypeOf<PropertyNotCachedException>().With.Message.Contains("CanMaximize"));
            }
        }

        [Test]
        public void UnsupportedPropertyUnCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Properties.Add(Automation.PropertyLibrary.Window.CanMaximize);
            using (cacheRequest.Activate())
            {
                var mainWindow = App.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetPropertyValue(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
                Assert.That(testDelegate, Throws.TypeOf<PropertyNotCachedException>().With.Message.Contains("ExpandCollapseState"));
            }
        }
        #endregion Property
    }
}
