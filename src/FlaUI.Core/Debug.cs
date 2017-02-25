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
            var allChildren = parent.FindAllChildren(cf => cf.ByControlType(element.Info.ControlType));
            var currentItemText = $"{element.Info.ControlType}";
            if (allChildren.Length > 1)
            {
                // There is more than one matching child, find out the index
                var indexInParent = 1; // Index starts with 1
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
                cr.Add(automationElement.Properties.AutomationId);
                cr.Add(automationElement.Properties.ControlType);
                cr.Add(automationElement.Properties.Name);
                cr.Add(automationElement.Properties.HelpText);
                cr.Add(automationElement.Properties.BoundingRectangle);
                cr.Add(automationElement.Properties.ClassName);
                cr.Add(automationElement.Properties.IsOffscreen);
                cr.Add(automationElement.Properties.FrameworkId);
                cr.Add(automationElement.Properties.ProcessId);
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
            WriteWithPadding(stringBuilder, "AutomationId: " + automationElement.Info.AutomationId, displayPadding);
            WriteWithPadding(stringBuilder, "ControlType: " + automationElement.Info.ControlType, displayPadding);
            WriteWithPadding(stringBuilder, "Name: " + automationElement.Info.Name, displayPadding);
            WriteWithPadding(stringBuilder, "HelpText: " + automationElement.Info.HelpText, displayPadding);
            WriteWithPadding(stringBuilder, "Bounding rectangle: " + automationElement.Info.BoundingRectangle, displayPadding);
            WriteWithPadding(stringBuilder, "ClassName: " + automationElement.Info.ClassName, displayPadding);
            WriteWithPadding(stringBuilder, "IsOffScreen: " + automationElement.Info.IsOffscreen, displayPadding);
            WriteWithPadding(stringBuilder, "FrameworkId: " + automationElement.Info.FrameworkId, displayPadding);
            WriteWithPadding(stringBuilder, "ProcessId: " + automationElement.Info.ProcessId, displayPadding);
        }

        private static void WritePattern(AutomationElement automationElement, StringBuilder stringBuilder, string displayPadding)
        {
            var availablePatterns = automationElement.GetAvailablePatterns();
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
