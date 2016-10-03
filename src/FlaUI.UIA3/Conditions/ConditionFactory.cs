﻿using FlaUI.Core.Conditions;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;

namespace FlaUI.UIA3.Conditions
{
    /// <summary>
    /// Helper class with some commonly used conditions
    /// </summary>
    public static class ConditionFactory
    {
        public static PropertyCondition ByText(string text)
        {
            return new PropertyCondition(AutomationElement.NameProperty, text);
        }

        public static PropertyCondition ByAutomationId(string automationId)
        {
            return new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
        }

        public static PropertyCondition ByControlType(ControlType controlType)
        {
            return new PropertyCondition(AutomationElement.ControlTypeProperty, controlType);
        }

        public static PropertyCondition ByClassName(string className)
        {
            return new PropertyCondition(AutomationElement.ClassNameProperty, className);
        }

        /// <summary>
        /// Searches for a Menu/MenuBar
        /// </summary>
        public static OrCondition Menu()
        {
            return new OrCondition(ByControlType(ControlType.Menu), ByControlType(ControlType.MenuBar));
        }
    }
}
