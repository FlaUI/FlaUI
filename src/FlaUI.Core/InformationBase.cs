using FlaUI.Core.Elements;
using FlaUI.Core.Tools;

namespace FlaUI.Core
{
    /// <summary>
    /// Base class for information objects
    /// </summary>
    public abstract class InformationBase
    {
        /// <summary>
        /// The element this information belongs to
        /// </summary>
        protected AutomationElement AutomationElement { get; private set; }

        /// <summary>
        /// Flag to indicate if the information is cached or not
        /// </summary>
        protected bool Cached { get; private set; }

        protected InformationBase(AutomationElement automationElement, bool cached)
        {
            AutomationElement = automationElement;
            Cached = cached;
        }

        /// <summary>
        /// Shortcut to get the property 
        /// </summary>
        protected T Get<T>(AutomationProperty property)
        {
            return AutomationElement.SafeGetPropertyValue<T>(property, Cached);
        }

        protected AutomationElement[] NativeElementArrayToElements(AutomationProperty property)
        {
            var nativeElements = Get<interop.UIAutomationCore.IUIAutomationElementArray>(property);
            return NativeValueConverter.NativeElementArrayToElements(AutomationElement.Automation, nativeElements);
        }

        protected AutomationElement NativeElementToElement(AutomationProperty property)
        {
            var nativeElement = Get<interop.UIAutomationCore.IUIAutomationElement>(property);
            return NativeValueConverter.NativeElementToElement(AutomationElement.Automation, nativeElement);
        }
    }
}
