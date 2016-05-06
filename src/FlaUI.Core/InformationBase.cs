using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

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
        protected T Get<T>(PropertyId property)
        {
            return AutomationElement.SafeGetPropertyValue<T>(property, Cached);
        }

        protected AutomationElement[] NativeElementArrayToElements(PropertyId property)
        {
            var nativeElements = Get<IUIAutomationElementArray>(property);
            return NativeValueConverter.NativeArrayToManaged(AutomationElement.Automation, nativeElements);
        }

        protected AutomationElement NativeElementToElement(PropertyId property)
        {
            var nativeElement = Get<IUIAutomationElement>(property);
            return NativeValueConverter.NativeToManaged(AutomationElement.Automation, nativeElement);
        }
    }
}
