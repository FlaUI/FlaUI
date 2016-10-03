using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    /// <summary>
    /// Base class for information objects
    /// </summary>
    public abstract class InformationBase
    {
        /// <summary>
        /// The automationElement this information belongs to
        /// </summary>
        protected AutomationElement AutomationAutomationElement { get; private set; }

        /// <summary>
        /// Flag to indicate if the information is cached or not
        /// </summary>
        protected bool Cached { get; private set; }

        protected InformationBase(AutomationElement automationAutomationElement, bool cached)
        {
            AutomationAutomationElement = automationAutomationElement;
            Cached = cached;
        }

        /// <summary>
        /// Shortcut to get the property 
        /// </summary>
        protected T Get<T>(PropertyId property)
        {
            return AutomationAutomationElement.SafeGetPropertyValue<T>(property, Cached);
        }

        protected AutomationElement[] NativeElementArrayToElements(PropertyId property)
        {
            var nativeElements = Get<UIA.IUIAutomationElementArray>(property);
            return NativeValueConverter.NativeArrayToManaged(AutomationAutomationElement.Automation, nativeElements);
        }

        protected AutomationElement NativeElementToElement(PropertyId property)
        {
            var nativeElement = Get<UIA.IUIAutomationElement>(property);
            return NativeValueConverter.NativeToManaged(AutomationAutomationElement.Automation, nativeElement);
        }
    }
}
