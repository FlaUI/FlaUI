using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ItemContainerPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_ItemContainerPatternId, "ItemContainer");

        internal ItemContainerPattern(AutomationElement automationElement, IUIAutomationItemContainerPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public IUIAutomationItemContainerPattern NativePattern
        {
            get { return (IUIAutomationItemContainerPattern)base.NativePattern; }
        }

        public AutomationElement FindItemByProperty(AutomationElement startAfter, PropertyId property, object value)
        {
            var foundNativeElement = ComCallWrapper.Call(() =>
                NativePattern.FindItemByProperty(
                    startAfter == null ? null : startAfter.NativeElement,
                    property == null ? 0 : property.Id, NativeValueConverter.ToNative(value)));
            return ToAutomationElement(foundNativeElement);
        }
    }
}
