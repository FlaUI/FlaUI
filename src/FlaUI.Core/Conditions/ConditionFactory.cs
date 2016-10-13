using FlaUI.Core.Definitions;

namespace FlaUI.Core.Conditions
{
    /// <summary>
    /// Helper class with some commonly used conditions
    /// </summary>
    public class ConditionFactory
    {
        private readonly IPropertyLibray _propertyLibrary;

        public ConditionFactory(IPropertyLibray propertyLibrary)
        {
            _propertyLibrary = propertyLibrary;
        }

        public PropertyCondition ByAutomationId(string automationId)
        {
            return new PropertyCondition(_propertyLibrary.Generic.AutomationIdProperty, automationId);
        }

        public PropertyCondition ByControlType(ControlType controlType)
        {
            return new PropertyCondition(_propertyLibrary.Generic.ControlTypeProperty, controlType);
        }

        public PropertyCondition ByClassName(string className)
        {
            return new PropertyCondition(_propertyLibrary.Generic.ClassNameProperty, className);
        }

        public PropertyCondition ByName(string name)
        {
            return new PropertyCondition(_propertyLibrary.Generic.NameProperty, name);
        }

        public PropertyCondition ByText(string text)
        {
            return ByName(text);
        }

        public PropertyCondition ByProcessId(int processId)
        {
            return new PropertyCondition(_propertyLibrary.Generic.ProcessIdProperty, processId);
        }

        /// <summary>
        /// Searches for a Menu/MenuBar
        /// </summary>
        public OrCondition Menu()
        {
            return new OrCondition(ByControlType(ControlType.Menu), ByControlType(ControlType.MenuBar));
        }
    }
}
