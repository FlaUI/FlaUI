using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ItemContainerPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_ItemContainerPatternId, "ItemContainer");

        internal ItemContainerPattern(AutomationElement automationElement, UIA.IUIAutomationItemContainerPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public new UIA.IUIAutomationItemContainerPattern NativePattern
        {
            get { return (UIA.IUIAutomationItemContainerPattern)base.NativePattern; }
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
