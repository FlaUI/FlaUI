using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Identifiers;

namespace FlaUI.UIA2
{
    public partial class UIA2AutomationElementPatternAvailabilityProperties : IAutomationElementPatternAvailabilityProperties
    {
        public PropertyId IsAnnotationPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsDockPatternAvailable => AutomationObjectIds.IsDockPatternAvailableProperty;
        public PropertyId IsDragPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsDropTargetPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsExpandCollapsePatternAvailable => AutomationObjectIds.IsExpandCollapsePatternAvailableProperty;
        public PropertyId IsGridItemPatternAvailable => AutomationObjectIds.IsGridItemPatternAvailableProperty;
        public PropertyId IsGridPatternAvailable => AutomationObjectIds.IsGridPatternAvailableProperty;
        public PropertyId IsInvokePatternAvailable => AutomationObjectIds.IsInvokePatternAvailableProperty;
        public PropertyId IsLegacyIAccessiblePatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsMultipleViewPatternAvailable => AutomationObjectIds.IsMultipleViewPatternAvailableProperty;
        public PropertyId IsObjectModelPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsRangeValuePatternAvailable => AutomationObjectIds.IsRangeValuePatternAvailableProperty;
        public PropertyId IsScrollItemPatternAvailable => AutomationObjectIds.IsScrollItemPatternAvailableProperty;
        public PropertyId IsScrollPatternAvailable => AutomationObjectIds.IsScrollPatternAvailableProperty;
        public PropertyId IsSelectionItemPatternAvailable => AutomationObjectIds.IsSelectionItemPatternAvailableProperty;
        public PropertyId IsSelectionPatternAvailable => AutomationObjectIds.IsSelectionPatternAvailableProperty;
        public PropertyId IsSpreadsheetPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsSpreadsheetItemPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsStylesPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsTableItemPatternAvailable => AutomationObjectIds.IsTableItemPatternAvailableProperty;
        public PropertyId IsTablePatternAvailable => AutomationObjectIds.IsTablePatternAvailableProperty;
        public PropertyId IsTextChildPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsTextEditPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsTextPatternAvailable => AutomationObjectIds.IsTextPatternAvailableProperty;
        public PropertyId IsTextPattern2Available => PropertyId.NotSupportedByFramework;
        public PropertyId IsTogglePatternAvailable => AutomationObjectIds.IsTogglePatternAvailableProperty;
        public PropertyId IsTransformPatternAvailable => AutomationObjectIds.IsTransformPatternAvailableProperty;
        public PropertyId IsTransformPattern2Available => PropertyId.NotSupportedByFramework;
        public PropertyId IsValuePatternAvailable => AutomationObjectIds.IsValuePatternAvailableProperty;
        public PropertyId IsWindowPatternAvailable => AutomationObjectIds.IsWindowPatternAvailableProperty;

        public PropertyId[] AllForCurrentFramework => new[] {
            IsDockPatternAvailable,
            IsExpandCollapsePatternAvailable,
            IsGridItemPatternAvailable,
            IsGridPatternAvailable,
            IsInvokePatternAvailable,
            IsMultipleViewPatternAvailable,
            IsRangeValuePatternAvailable,
            IsScrollItemPatternAvailable,
            IsScrollPatternAvailable,
            IsSelectionItemPatternAvailable,
            IsSelectionPatternAvailable,
            IsTableItemPatternAvailable,
            IsTablePatternAvailable,
            IsTextPatternAvailable,
            IsTogglePatternAvailable,
            IsTransformPatternAvailable,
            IsValuePatternAvailable,
            IsWindowPatternAvailable
            // Additions from .NET 4.0
#if !NET35
            ,IsItemContainerPatternAvailable
            ,IsSynchronizedInputPatternAvailable
            ,IsVirtualizedItemPatternAvailable
#endif
        };
    }

    /// <summary>
    /// Partial class with additions from .NET 4.0
    /// </summary>
    public partial class UIA2AutomationElementPatternAvailabilityProperties
    {
#if NET35
        public PropertyId IsItemContainerPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsSynchronizedInputPatternAvailable => PropertyId.NotSupportedByFramework;
        public PropertyId IsVirtualizedItemPatternAvailable => PropertyId.NotSupportedByFramework;
#else
        public PropertyId IsItemContainerPatternAvailable => AutomationObjectIds.IsItemContainerPatternAvailableProperty;
        public PropertyId IsSynchronizedInputPatternAvailable => AutomationObjectIds.IsSynchronizedInputPatternAvailableProperty;
        public PropertyId IsVirtualizedItemPatternAvailable => AutomationObjectIds.IsVirtualizedItemPatternAvailableProperty;
#endif
    }
}