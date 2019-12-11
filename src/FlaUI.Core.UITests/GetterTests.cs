using FlaUI.Core.Definitions;
using FlaUI.Core.Exceptions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FlaUI.Core.UITests
{
    [TestFixture(AutomationType.UIA2)]
    [TestFixture(AutomationType.UIA3)]
    public class GetterTests : UITestBase
    {
        public AutomationType AutomationType { get; }

        protected override ApplicationStartMode ApplicationStartMode => ApplicationStartMode.OncePerFixture;

        public GetterTests(AutomationType automationType)
        {
            AutomationType = automationType;
        }

        protected override AutomationBase GetAutomation()
        {
            return TestUtilities.GetAutomation(AutomationType);
        }

        protected override Application StartApplication()
        {
            return Application.Launch("notepad.exe");
        }

        #region Pattern Tests
        [Test]
        public void CorrectPattern()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            Assert.That(mainWindow, Is.Not.Null);
            var windowPattern = mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.WindowPattern);
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
                var mainWindow = Application.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                var windowPattern = mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.WindowPattern);
                Assert.That(windowPattern, Is.Not.Null);
            }
        }

        [Test]
        public void UnsupportedPattern()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            Assert.That(mainWindow, Is.Not.Null);
            ActualValueDelegate<object> testDelegate = () => mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.ExpandCollapsePattern);
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
                var mainWindow = Application.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.ExpandCollapsePattern);
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
                var mainWindow = Application.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.WindowPattern);
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
                var mainWindow = Application.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.ExpandCollapsePattern);
                Assert.That(testDelegate, Throws.TypeOf<PatternNotCachedException>().With.Message.Contains("ExpandCollapse"));
            }
        }
        #endregion Pattern

        #region Property Tests
        [Test]
        public void CorrectProperty()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            Assert.That(mainWindow, Is.Not.Null);
            var windowProperty = mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.Window.CanMaximize);
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
                var mainWindow = Application.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                var windowProperty = mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.Window.CanMaximize);
                Assert.That(windowProperty, Is.Not.Null);
            }
        }

        [Test]
        public void UnsupportedProperty()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            Assert.That(mainWindow, Is.Not.Null);
            ActualValueDelegate<object> testDelegate = () => mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
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
                var mainWindow = Application.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
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
                var mainWindow = Application.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.Window.CanMaximize);
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
                var mainWindow = Application.GetMainWindow(Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
                Assert.That(testDelegate, Throws.TypeOf<PropertyNotCachedException>().With.Message.Contains("ExpandCollapseState"));
            }
        }
        #endregion Property
    }
}
