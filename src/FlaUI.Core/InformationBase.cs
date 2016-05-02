using FlaUI.Core.Elements;

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
        /// Converts a native element array to an enumerable of <see cref="AutomationElement"/>
        /// </summary>
        protected AutomationElement[] NativeElementArrayToElements(AutomationProperty property)
        {
            var controlledElements = AutomationElement.SafeGetPropertyValue<interop.UIAutomationCore.IUIAutomationElementArray>(property, Cached);
            var retArray = new AutomationElement[controlledElements.Length];
            for (var i = 0; i < controlledElements.Length; i++)
            {
                retArray[i] = new AutomationElement(AutomationElement.Automation, controlledElements.GetElement(i));
            }
            return retArray;
        }

        /// <summary>
        /// Converts a native element to an <see cref="AutomationElement"/>
        /// </summary>
        protected AutomationElement NativeElementToElement(AutomationProperty property)
        {
            var nativeElement = AutomationElement.SafeGetPropertyValue<interop.UIAutomationCore.IUIAutomationElement>(property, Cached);
            return nativeElement == null ? null : new AutomationElement(AutomationElement.Automation, nativeElement);
        }
    }
}
