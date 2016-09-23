using FlaUI.Core.Conditions;
using FlaUI.UIA3.Definitions;

namespace FlaUI.UIA3.Conditions
{
    /// <summary>
    /// Helper class with some commonly used conditions
    /// </summary>
    public static class ConditionFactory
    {
        public static PropertyCondition ByText(string text)
        {
            return new PropertyCondition(AutomationObjectIds.NameProperty, text);
        }

        public static PropertyCondition ByAutomationId(string automationId)
        {
            return new PropertyCondition(AutomationObjectIds.AutomationIdProperty, automationId);
        }

        public static PropertyCondition ByControlType(ControlType controlType)
        {
            return new PropertyCondition(AutomationObjectIds.ControlTypeProperty, controlType);
        }

        public static PropertyCondition ByClassName(string className)
        {
            return new PropertyCondition(AutomationObjectIds.ClassNameProperty, className);
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
