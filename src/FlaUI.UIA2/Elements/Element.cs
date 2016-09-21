using FlaUI.Core.Elements;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Elements
{
    public class Element : ElementBase<UIA2Automation>
    {
        /// <summary>
        /// Native object for the ui element
        /// </summary>
        public UIA.AutomationElement NativeElement { get; private set; }

        public Element(UIA2Automation automation, UIA.AutomationElement nativeElement) : base(automation)
        {
            NativeElement = nativeElement;
        }

        protected override object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var ignoreDefaultValue = !useDefaultIfNotSupported;
            var property = UIA.AutomationProperty.LookupById(propertyId);
            var returnValue = cached ?
                NativeElement.GetCachedPropertyValue(property, ignoreDefaultValue) :
                NativeElement.GetCurrentPropertyValue(property, ignoreDefaultValue);
            return returnValue;
        }
    }
}
