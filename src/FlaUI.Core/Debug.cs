using System;
using System.Text;
using FlaUI.Core.AutomationElements.Infrastructure;

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
                stringBuilder.AppendLine();
                Details(stringBuilder, automationElement, String.Empty);
                return stringBuilder.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private static void Details(StringBuilder stringBuilder, AutomationElement automationElement, string displayPadding)
        {
            const string tab = "  ";
            WriteDetail(automationElement, stringBuilder, displayPadding);
            DisplayPattern(automationElement, stringBuilder, displayPadding);
            var children = automationElement.FindAllChildren();
            foreach (var child in children)
            {
                Details(stringBuilder, child, displayPadding + tab + tab);
            }
        }

        private static void WriteDetail(AutomationElement automationElement, StringBuilder stringBuilder, string displayPadding)
        {
            WriteDetail(stringBuilder, "AutomationId: " + automationElement.Current.AutomationId, displayPadding);
            WriteDetail(stringBuilder, "ControlType: " + automationElement.Current.ControlType, displayPadding);
            WriteDetail(stringBuilder, "Name: " + automationElement.Current.Name, displayPadding);
            WriteDetail(stringBuilder, "HelpText: " + automationElement.Current.HelpText, displayPadding);
            WriteDetail(stringBuilder, "Bounding rectangle: " + automationElement.Current.BoundingRectangle, displayPadding);
            WriteDetail(stringBuilder, "ClassName: " + automationElement.Current.ClassName, displayPadding);
            WriteDetail(stringBuilder, "IsOffScreen: " + automationElement.Current.IsOffscreen, displayPadding);
            WriteDetail(stringBuilder, "FrameworkId: " + automationElement.Current.FrameworkId, displayPadding);
            WriteDetail(stringBuilder, "ProcessId: " + automationElement.Current.ProcessId, displayPadding);
            stringBuilder.AppendLine();
        }

        private static void WriteDetail(StringBuilder stringBuilder, string message, string padding)
        {
            stringBuilder.AppendLine(padding + message);
        }

        private static void DisplayPattern(AutomationElement automationElement, StringBuilder stringBuilder, string displayPadding)
        {
            var supportedPatterns = automationElement.BasicAutomationElement.GetSupportedPatterns();
            foreach (var automationPattern in supportedPatterns)
            {
                stringBuilder.Append(displayPadding).AppendLine(automationPattern.ToString());
            }
            stringBuilder.AppendLine();
        }
    }
}
