using System;
using FlaUI.Core.Definitions;
using FlaUI.Core.Exceptions;
using FlaUI.Core.UITests.TestFramework;
using FlaUI.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FlaUI.Core.UITests
{
    [TestFixture(AutomationType.UIA2)]
    [TestFixture(AutomationType.UIA3)]
    public class GetterTests : FlaUITestBase
    {
        public AutomationType AutomationType { get; }

        protected override ApplicationStartMode ApplicationStartMode => ApplicationStartMode.OncePerFixture;

        public GetterTests(AutomationType automationType)
        {
            AutomationType = automationType;
        }

        protected override AutomationBase GetAutomation()
        {
            return UtilityMethods.GetAutomation(AutomationType);
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
            mainWindow.Should().NotBeNull();
            var windowPattern = mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.WindowPattern);
            windowPattern.Should().NotBeNull();
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
                mainWindow.Should().NotBeNull();
                var windowPattern = mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.WindowPattern);
                windowPattern.Should().NotBeNull();
            }
        }

        [Test]
        public void UnsupportedPattern()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            mainWindow.Should().NotBeNull(); 

            Action act = () => mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary
              .ExpandCollapsePattern);
            act.Should().Throw<PatternNotSupportedException>()
              .Where(x => x.Message.Contains("ExpandCollapse"));
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
                mainWindow.Should().NotBeNull();
                Action act = () => mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.ExpandCollapsePattern);
                act.Should().Throw<PatternNotSupportedException>()
                  .Where(x => x.Message.Contains("ExpandCollapse"));
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
                mainWindow.Should().NotBeNull();
                Action act = () => mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.WindowPattern);
                act.Should().Throw<PatternNotCachedException>()
                  .Where(x => x.Message.Contains("Window"));
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
                mainWindow.Should().NotBeNull();
                Action act = () => mainWindow.FrameworkAutomationElement.GetNativePattern<object>(Automation.PatternLibrary.ExpandCollapsePattern);
                act.Should().Throw<PatternNotCachedException>()
                  .Where(x => x.Message.Contains("ExpandCollapse"));
            }
        }
        #endregion Pattern

        #region Property Tests
        [Test]
        public void CorrectProperty()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            mainWindow.Should().NotBeNull();
            var windowProperty = mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.Window.CanMaximize);
            windowProperty.Should().NotBeNull();
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
                mainWindow.Should().NotBeNull();
                var windowProperty = mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.Window.CanMaximize);
                windowProperty.Should().NotBeNull();
            }
        }

        [Test]
        public void UnsupportedProperty()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            mainWindow.Should().NotBeNull();
            Action act = () => mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
            act.Should().Throw<PropertyNotSupportedException>()
              .Where(x => x.Message.Contains("ExpandCollapseState"));
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
                mainWindow.Should().NotBeNull();
                Action act = () => mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
                act.Should().Throw<PropertyNotSupportedException>()
                  .Where(x => x.Message.Contains("ExpandCollapseState"));
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
                mainWindow.Should().NotBeNull();
                Action act = () => mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.Window.CanMaximize);
                act.Should().Throw<PropertyNotCachedException>()
                  .Where(x => x.Message.Contains("CanMaximize"));
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
                mainWindow.Should().NotBeNull();
                Action act = () => mainWindow.FrameworkAutomationElement.GetPropertyValue(Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
                act.Should().Throw<PropertyNotCachedException>()
                  .Where(x => x.Message.Contains("ExpandCollapseState"));
            }
        }
        #endregion Property
    }
}
