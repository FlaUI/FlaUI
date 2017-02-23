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
    }
}
