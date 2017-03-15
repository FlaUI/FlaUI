using FlaUI.Core;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3AutomationElement : AutomationElementBase
    {
        public UIA3AutomationElement(UIA3Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation)
        {
            NativeElement = nativeElement;
        }

        /// <summary>
        /// Native object for the ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement { get; private set; }

        protected override object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var ignoreDefaultValue = useDefaultIfNotSupported ? 0 : 1;
            var returnValue = cached ?
                NativeElement.GetCachedPropertyValueEx(propertyId, ignoreDefaultValue) :
                NativeElement.GetCurrentPropertyValueEx(propertyId, ignoreDefaultValue);
            return returnValue;
        }

        protected override IAutomationElementInformation CreateInformation(bool cached)
        {
            return new AutomationElementInformation(this, cached);
        }
    }
}
