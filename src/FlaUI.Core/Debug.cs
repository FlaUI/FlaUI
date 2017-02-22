using System;
using System.Linq;
using System.Text;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;

namespace FlaUI.Core
{
    public static class Debug
    {
        /// <summary>
        /// Gets the XPath to the element until the desktop or the given root element.
        /// Warning: This is quite a heavy operation
        /// </summary>
        public static string GetXPathToElement(AutomationElement element, AutomationElement rootElement = null)
        {
            var treeWalker = element.Automation.TreeWalkerFactory.GetControlViewWalker();
            return GetXPathToElement(element, treeWalker, rootElement);
        }

        private static string GetXPathToElement(AutomationElement element, ITreeWalker treeWalker, AutomationElement rootElement = null)
        {
            var parent = treeWalker.GetParent(element);
            if (parent == null || (rootElement != null && parent.Equals(rootElement)))
            {
                return String.Empty;
            }
            // Get the index
            var allChildren = parent.FindAllChildren(cf => cf.ByControlType(element.Current.ControlType));
            var currentItemText = $"{element.Current.ControlType}";
            if (allChildren.Length > 1)
            {
                // There is more than one matching child, find out the index
                var indexInParent = 0;
                foreach (var child in allChildren)
                {
                    if (child.Equals(element))
                    {
                        break;
                    }
                    indexInParent++;
                }
                currentItemText += $"[{indexInParent}]";
            }
            return $"{GetXPathToElement(parent, treeWalker, rootElement)}/{currentItemText}";
        }

        public static string Details(AutomationElement automationElement)
        {
            try
            {
                var stringBuilder = new StringBuilder();
                var cr = new CacheRequest();
                cr.AutomationElementMode = AutomationElementMode.None;
                // Add the element properties
                cr.Add(automationElement.Properties.AutomationIdProperty);
                cr.Add(automationElement.Properties.ControlTypeProperty);
                cr.Add(automationElement.Properties.NameProperty);
                cr.Add(automationElement.Properties.HelpTextProperty);
                cr.Add(automationElement.Properties.BoundingRectangleProperty);
                cr.Add(automationElement.Properties.ClassNameProperty);
                cr.Add(automationElement.Properties.IsOffscreenProperty);
                cr.Add(automationElement.Properties.FrameworkIdProperty);
                cr.Add(automationElement.Properties.ProcessIdProperty);
                // Add the pattern availability properties
                automationElement.PatternAvailability.AllForCurrentFramework.ToList().ForEach(x=> cr.Add(x));
                cr.TreeScope = TreeScope.Subtree;
                cr.TreeFilter = new TrueCondition();
                // Activate the cache request
                using (cr.Activate())
                {
                    // Re-find the root element with caching activated
                    automationElement = automationElement.FindFirst(TreeScope.Element, new TrueCondition());
                    Details(stringBuilder, automationElement, String.Empty);
                }
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to dump info: " + ex);
                return string.Empty;
            }
        }

        private static void Details(StringBuilder stringBuilder, AutomationElement automationElement, string displayPadding)
        {
            const string indent = "    ";
            WriteDetail(automationElement, stringBuilder, displayPadding);
            WritePattern(automationElement, stringBuilder, displayPadding);
            var children = automationElement.CachedChildren;
            foreach (var child in children)
            {
                Details(stringBuilder, child, displayPadding + indent);
            }
        }

        private static void WriteDetail(AutomationElement automationElement, StringBuilder stringBuilder, string displayPadding)
        {
            WriteWithPadding(stringBuilder, "AutomationId: " + automationElement.Cached.AutomationId, displayPadding);
            WriteWithPadding(stringBuilder, "ControlType: " + automationElement.Cached.ControlType, displayPadding);
            WriteWithPadding(stringBuilder, "Name: " + automationElement.Cached.Name, displayPadding);
            WriteWithPadding(stringBuilder, "HelpText: " + automationElement.Cached.HelpText, displayPadding);
            WriteWithPadding(stringBuilder, "Bounding rectangle: " + automationElement.Cached.BoundingRectangle, displayPadding);
            WriteWithPadding(stringBuilder, "ClassName: " + automationElement.Cached.ClassName, displayPadding);
            WriteWithPadding(stringBuilder, "IsOffScreen: " + automationElement.Cached.IsOffscreen, displayPadding);
            WriteWithPadding(stringBuilder, "FrameworkId: " + automationElement.Cached.FrameworkId, displayPadding);
            WriteWithPadding(stringBuilder, "ProcessId: " + automationElement.Cached.ProcessId, displayPadding);
        }

        private static void WritePattern(AutomationElement automationElement, StringBuilder stringBuilder, string displayPadding)
        {
            var availablePatterns = automationElement.GetAvailablePatterns(true);
            foreach (var automationPattern in availablePatterns)
            {
                WriteWithPadding(stringBuilder, automationPattern.ToString(), displayPadding);
            }
            stringBuilder.AppendLine();
        }

        private static void WriteWithPadding(StringBuilder stringBuilder, string message, string padding)
        {
            stringBuilder.Append(padding).AppendLine(message);
        }
    }
}
