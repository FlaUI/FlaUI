using FlaUI.Core.Identifiers;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public interface IAutomationElementPatternAvailabilityProperties
    {
        PropertyId IsAnnotationPatternAvailableProperty{ get; }
        PropertyId IsDockPatternAvailableProperty{ get; }
        PropertyId IsDragPatternAvailableProperty{ get; }
        PropertyId IsDropTargetPatternAvailableProperty{ get; }
        PropertyId IsExpandCollapsePatternAvailableProperty{ get; }
        PropertyId IsGridItemPatternAvailableProperty{ get; }
        PropertyId IsGridPatternAvailableProperty{ get; }
        PropertyId IsInvokePatternAvailableProperty{ get; }
        PropertyId IsItemContainerPatternAvailableProperty{ get; }
        PropertyId IsLegacyIAccessiblePatternAvailableProperty{ get; }
        PropertyId IsMultipleViewPatternAvailableProperty{ get; }
        PropertyId IsObjectModelPatternAvailableProperty{ get; }
        PropertyId IsRangeValuePatternAvailableProperty{ get; }
        PropertyId IsScrollItemPatternAvailableProperty{ get; }
        PropertyId IsScrollPatternAvailableProperty{ get; }
        PropertyId IsSelectionItemPatternAvailableProperty{ get; }
        PropertyId IsSelectionPatternAvailableProperty{ get; }
        PropertyId IsSpreadsheetPatternAvailableProperty{ get; }
        PropertyId IsSpreadsheetItemPatternAvailableProperty{ get; }
        PropertyId IsStylesPatternAvailableProperty{ get; }
        PropertyId IsSynchronizedInputPatternAvailableProperty{ get; }
        PropertyId IsTableItemPatternAvailableProperty{ get; }
        PropertyId IsTablePatternAvailableProperty{ get; }
        PropertyId IsTextChildPatternAvailableProperty{ get; }
        PropertyId IsTextEditPatternAvailableProperty{ get; }
        PropertyId IsTextPatternAvailableProperty{ get; }
        PropertyId IsTextPattern2AvailableProperty{ get; }
        PropertyId IsTogglePatternAvailableProperty{ get; }
        PropertyId IsTransformPatternAvailableProperty{ get; }
        PropertyId IsTransformPattern2AvailableProperty{ get; }
        PropertyId IsValuePatternAvailableProperty{ get; }
        PropertyId IsVirtualizedItemPatternAvailableProperty{ get; }
        PropertyId IsWindowPatternAvailableProperty{ get; }

        PropertyId[] AllForCurrentFramework { get; }
    }
}
