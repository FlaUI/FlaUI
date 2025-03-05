#if !NET35
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ItemContainerPattern : PatternBase<UIA.ItemContainerPattern>, IItemContainerPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ItemContainerPattern.Pattern.Id, "ItemContainer", AutomationObjectIds.IsItemContainerPatternAvailableProperty);

        public ItemContainerPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.ItemContainerPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public AutomationElement FindItemByProperty(AutomationElement? startAfter, PropertyId? property, object? value)
        {
            var foundNativeElement = NativePattern.FindItemByProperty(
                    startAfter?.ToNative(),
                    property == null ? null : UIA.AutomationProperty.LookupById(property.Id), ValueConverter.ToNative(value));
            return AutomationElementConverter.NativeToManaged((UIA2Automation)FrameworkAutomationElement.Automation, foundNativeElement);
        }
    }
}
#endif
