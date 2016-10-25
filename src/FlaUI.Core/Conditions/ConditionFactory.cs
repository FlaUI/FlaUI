using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;

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
            return new PropertyCondition(_propertyLibrary.Element.AutomationIdProperty, automationId);
        }

        public PropertyCondition ByControlType(ControlType controlType)
        {
            return new PropertyCondition(_propertyLibrary.Element.ControlTypeProperty, controlType);
        }

        public PropertyCondition ByClassName(string className)
        {
            return new PropertyCondition(_propertyLibrary.Element.ClassNameProperty, className);
        }

        public PropertyCondition ByName(string name)
        {
            return new PropertyCondition(_propertyLibrary.Element.NameProperty, name);
        }

        public PropertyCondition ByText(string text)
        {
            return ByName(text);
        }

        public PropertyCondition ByProcessId(int processId)
        {
            return new PropertyCondition(_propertyLibrary.Element.ProcessIdProperty, processId);
        }

        public PropertyCondition ByLocalizedControlType(string localizedControlType)
        {
           return new PropertyCondition(_propertyLibrary.Element.LocalizedControlTypeProperty, localizedControlType);
        }

        public PropertyCondition ByHelpTextProperty(string helpText)
        {
           return new PropertyCondition(_propertyLibrary.Element.HelpTextProperty, helpText);  
        }

        /// <summary>
        /// Searches for a Menu/MenuBar
        /// </summary>
        public OrCondition Menu()
        {
            return new OrCondition(ByControlType(ControlType.Menu), ByControlType(ControlType.MenuBar));
        }

        /// <summary>
        /// Searches for a DataGrid/List
        /// </summary>
        public OrCondition ListView()
        {
            return new OrCondition(ByControlType(ControlType.DataGrid), ByControlType(ControlType.List));
        }

        public OrCondition HScrollBar()
        {
            return new OrCondition(ByControlType(ControlType.ScrollBar), ByName(TranslatableStrings.HorizontalScrollBar));
        }

        public OrCondition VScrollBar()
        {
            return new OrCondition(ByControlType(ControlType.ScrollBar), ByName(TranslatableStrings.VerticalScrollBar));
        }
    }
}
