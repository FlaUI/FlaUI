using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Identifiers;

namespace FlaUI.UIA3
{
    public class UIA3AutomationElementPatternAvailabilityProperties : IAutomationElementPatternAvailabilityProperties
    {
        public PropertyId IsAnnotationPatternAvailableProperty => AutomationObjectIds.IsAnnotationPatternAvailableProperty;
        public PropertyId IsDockPatternAvailableProperty => AutomationObjectIds.IsDockPatternAvailableProperty;
        public PropertyId IsDragPatternAvailableProperty => AutomationObjectIds.IsDragPatternAvailableProperty;
        public PropertyId IsDropTargetPatternAvailableProperty => AutomationObjectIds.IsDropTargetPatternAvailableProperty;
        public PropertyId IsExpandCollapsePatternAvailableProperty => AutomationObjectIds.IsExpandCollapsePatternAvailableProperty;
        public PropertyId IsGridItemPatternAvailableProperty => AutomationObjectIds.IsGridItemPatternAvailableProperty;
        public PropertyId IsGridPatternAvailableProperty => AutomationObjectIds.IsGridPatternAvailableProperty;
        public PropertyId IsInvokePatternAvailableProperty => AutomationObjectIds.IsInvokePatternAvailableProperty;
        public PropertyId IsItemContainerPatternAvailableProperty => AutomationObjectIds.IsItemContainerPatternAvailableProperty;
        public PropertyId IsLegacyIAccessiblePatternAvailableProperty => AutomationObjectIds.IsLegacyIAccessiblePatternAvailableProperty;
        public PropertyId IsMultipleViewPatternAvailableProperty => AutomationObjectIds.IsMultipleViewPatternAvailableProperty;
        public PropertyId IsObjectModelPatternAvailableProperty => AutomationObjectIds.IsObjectModelPatternAvailableProperty;
        public PropertyId IsRangeValuePatternAvailableProperty => AutomationObjectIds.IsRangeValuePatternAvailableProperty;
        public PropertyId IsScrollItemPatternAvailableProperty => AutomationObjectIds.IsScrollItemPatternAvailableProperty;
        public PropertyId IsScrollPatternAvailableProperty => AutomationObjectIds.IsScrollPatternAvailableProperty;
        public PropertyId IsSelectionItemPatternAvailableProperty => AutomationObjectIds.IsSelectionItemPatternAvailableProperty;
        public PropertyId IsSelectionPatternAvailableProperty => AutomationObjectIds.IsSelectionPatternAvailableProperty;
        public PropertyId IsSpreadsheetPatternAvailableProperty => AutomationObjectIds.IsSpreadsheetPatternAvailableProperty;
        public PropertyId IsSpreadsheetItemPatternAvailableProperty => AutomationObjectIds.IsSpreadsheetItemPatternAvailableProperty;
        public PropertyId IsStylesPatternAvailableProperty => AutomationObjectIds.IsStylesPatternAvailableProperty;
        public PropertyId IsSynchronizedInputPatternAvailableProperty => AutomationObjectIds.IsSynchronizedInputPatternAvailableProperty;
        public PropertyId IsTableItemPatternAvailableProperty => AutomationObjectIds.IsTableItemPatternAvailableProperty;
        public PropertyId IsTablePatternAvailableProperty => AutomationObjectIds.IsTablePatternAvailableProperty;
        public PropertyId IsTextChildPatternAvailableProperty => AutomationObjectIds.IsTextChildPatternAvailableProperty;
        public PropertyId IsTextEditPatternAvailableProperty => AutomationObjectIds.IsTextEditPatternAvailableProperty;
        public PropertyId IsTextPatternAvailableProperty => AutomationObjectIds.IsTextPatternAvailableProperty;
        public PropertyId IsTextPattern2AvailableProperty => AutomationObjectIds.IsTextPattern2AvailableProperty;
        public PropertyId IsTogglePatternAvailableProperty => AutomationObjectIds.IsTogglePatternAvailableProperty;
        public PropertyId IsTransformPatternAvailableProperty => AutomationObjectIds.IsTransformPatternAvailableProperty;
        public PropertyId IsTransformPattern2AvailableProperty => AutomationObjectIds.IsTransformPattern2AvailableProperty;
        public PropertyId IsValuePatternAvailableProperty => AutomationObjectIds.IsValuePatternAvailableProperty;
        public PropertyId IsVirtualizedItemPatternAvailableProperty => AutomationObjectIds.IsVirtualizedItemPatternAvailableProperty;
        public PropertyId IsWindowPatternAvailableProperty => AutomationObjectIds.IsWindowPatternAvailableProperty;

        public PropertyId[] AllForCurrentFramework => new[] {
            IsAnnotationPatternAvailableProperty,
            IsDockPatternAvailableProperty,
            IsDragPatternAvailableProperty,
            IsDropTargetPatternAvailableProperty,
            IsExpandCollapsePatternAvailableProperty,
            IsGridItemPatternAvailableProperty,
            IsGridPatternAvailableProperty,
            IsInvokePatternAvailableProperty,
            IsItemContainerPatternAvailableProperty,
            IsLegacyIAccessiblePatternAvailableProperty,
            IsMultipleViewPatternAvailableProperty,
            IsObjectModelPatternAvailableProperty,
            IsRangeValuePatternAvailableProperty,
            IsScrollItemPatternAvailableProperty,
            IsScrollPatternAvailableProperty,
            IsSelectionItemPatternAvailableProperty,
            IsSelectionPatternAvailableProperty,
            IsSpreadsheetPatternAvailableProperty,
            IsSpreadsheetItemPatternAvailableProperty,
            IsStylesPatternAvailableProperty,
            IsSynchronizedInputPatternAvailableProperty,
            IsTableItemPatternAvailableProperty,
            IsTablePatternAvailableProperty,
            IsTextChildPatternAvailableProperty,
            IsTextEditPatternAvailableProperty,
            IsTextPatternAvailableProperty,
            IsTextPattern2AvailableProperty,
            IsTogglePatternAvailableProperty,
            IsTransformPatternAvailableProperty,
            IsTransformPattern2AvailableProperty,
            IsValuePatternAvailableProperty,
            IsVirtualizedItemPatternAvailableProperty,
            IsWindowPatternAvailableProperty
        };
    }
}