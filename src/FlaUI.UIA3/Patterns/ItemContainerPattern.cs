using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Patterns
{
    public class ItemContainerPattern : PatternBase<UIA.IUIAutomationItemContainerPattern>, IItemContainerPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ItemContainerPatternId, "ItemContainer", AutomationObjectIds.IsItemContainerPatternAvailableProperty);

        public ItemContainerPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationItemContainerPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public AutomationElement FindItemByProperty(AutomationElement? startAfter, PropertyId? property, object? value)
        {
            var foundNativeElement = Com.Call(() =>
                NativePattern.FindItemByProperty(
                    startAfter?.ToNative(),
                    property?.Id ?? 0, ValueConverter.ToNative(value)));
            return AutomationElementConverter.NativeToManaged((UIA3Automation)FrameworkAutomationElement.Automation, foundNativeElement);
        }
    }
}
