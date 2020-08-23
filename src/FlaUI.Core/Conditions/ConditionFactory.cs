using FlaUI.Core.Definitions;

namespace FlaUI.Core.Conditions
{
    /// <summary>
    /// Helper class with some commonly used conditions.
    /// </summary>
    public class ConditionFactory
    {
        private readonly IPropertyLibrary _propertyLibrary;

        /// <summary>
        /// Creates a <see cref="ConditionFactory"/> with the given <see cref="IPropertyLibrary"/>.
        /// </summary>
        public ConditionFactory(IPropertyLibrary propertyLibrary)
        {
            _propertyLibrary = propertyLibrary;
        }

        /// <summary>
        /// Creates a condition to search by an automation id.
        /// </summary>
        public PropertyCondition ByAutomationId(string automationId, PropertyConditionFlags conditionFlags = PropertyConditionFlags.None)
        {
            return new PropertyCondition(_propertyLibrary.Element.AutomationId, automationId, conditionFlags);
        }

        /// <summary>
        /// Creates a condition to search by a <see cref="ControlType"/>.
        /// </summary>
        public PropertyCondition ByControlType(ControlType controlType)
        {
            return new PropertyCondition(_propertyLibrary.Element.ControlType, controlType);
        }

        /// <summary>
        /// Creates a condition to search by a class name.
        /// </summary>
        public PropertyCondition ByClassName(string className, PropertyConditionFlags conditionFlags = PropertyConditionFlags.None)
        {
            return new PropertyCondition(_propertyLibrary.Element.ClassName, className, conditionFlags);
        }

        /// <summary>
        /// Creates a condition to search by a name.
        /// </summary>
        public PropertyCondition ByName(string name, PropertyConditionFlags conditionFlags = PropertyConditionFlags.None)
        {
            return new PropertyCondition(_propertyLibrary.Element.Name, name, conditionFlags);
        }

        /// <summary>
        /// Creates a condition to search by a text (same as <see cref="ByName"/>).
        /// </summary>
        public PropertyCondition ByText(string text, PropertyConditionFlags conditionFlags = PropertyConditionFlags.None)
        {
            return ByName(text, conditionFlags);
        }

        /// <summary>
        /// Creates a condition to search by a Framework Id.
        /// </summary>
        public PropertyCondition ByFrameworkId(string frameworkId, PropertyConditionFlags conditionFlags = PropertyConditionFlags.None)
        {
            return new PropertyCondition(_propertyLibrary.Element.FrameworkId, frameworkId, conditionFlags);
        }

        /// <summary>
        /// Creates a condition to search by a Framework Type.
        /// </summary>
        public PropertyCondition ByFrameworkType(FrameworkType frameworkType)
        {
            var frameworkId = FrameworkIds.Convert(frameworkType);
            return ByFrameworkId(frameworkId);
        }

        /// <summary>
        /// Creates a condition to search by a process id.
        /// </summary>
        public PropertyCondition ByProcessId(int processId)
        {
            return new PropertyCondition(_propertyLibrary.Element.ProcessId, processId);
        }

        /// <summary>
        /// Creates a condition to search by a localized control type.
        /// </summary>
        public PropertyCondition ByLocalizedControlType(string localizedControlType, PropertyConditionFlags conditionFlags = PropertyConditionFlags.None)
        {
            return new PropertyCondition(_propertyLibrary.Element.LocalizedControlType, localizedControlType, conditionFlags);
        }

        /// <summary>
        /// Creates a condition to search by a help text.
        /// </summary>
        public PropertyCondition ByHelpText(string helpText, PropertyConditionFlags conditionFlags = PropertyConditionFlags.None)
        {
            return new PropertyCondition(_propertyLibrary.Element.HelpText, helpText, conditionFlags);
        }

        /// <summary>
        /// Creates a condition to search by a value.
        /// </summary>
        public PropertyCondition ByValue(string value, , PropertyConditionFlags conditionFlags = PropertyConditionFlags.None)
        {
            return new PropertyCondition(_propertyLibrary.Value.Value, value, conditionFlags);
        }

        /// <summary>
        /// Searches for a Menu/MenuBar.
        /// </summary>
        public OrCondition Menu()
        {
            return new OrCondition(ByControlType(ControlType.Menu), ByControlType(ControlType.MenuBar));
        }

        /// <summary>
        /// Searches for a DataGrid/List.
        /// </summary>
        public OrCondition Grid()
        {
            return new OrCondition(ByControlType(ControlType.DataGrid), ByControlType(ControlType.List));
        }

        /// <summary>
        /// Searches for a horizontal scrollbar.
        /// </summary>
        public AndCondition HorizontalScrollBar()
        {
            return new AndCondition(
                ByControlType(ControlType.ScrollBar),
                new OrCondition(
                    // WPF
                    ByAutomationId("HorizontalScrollBar"),
                    // WinForms UIA2
                    ByAutomationId("Horizontal ScrollBar"),
                    // WinForms UIA3
                    ByAutomationId("NonClientHorizontalScrollBar")
                )
            );
        }

        /// <summary>
        /// Searches for a vertical scrollbar.
        /// </summary>
        public AndCondition VerticalScrollBar()
        {
            return new AndCondition(
                ByControlType(ControlType.ScrollBar),
                new OrCondition(
                    // WPF
                    ByAutomationId("VerticalScrollBar"),
                    // WinForms UIA2
                    ByAutomationId("Vertical ScrollBar"),
                    // WinForms UIA3
                    ByAutomationId("NonClientVerticalScrollBar")
                )
            );
        }
    }
}
