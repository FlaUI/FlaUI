using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Identifiers;

namespace FlaUI.UIA2
{
    public class UIA2AutomationElementPatternAvailabilityProperties : IAutomationElementPatternAvailabilityProperties
    {
        public PropertyId IsAnnotationPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsDockPatternAvailable => AutomationObjectIds.IsDockPatternAvailableProperty;
        public PropertyId IsDragPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsDropTargetPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsExpandCollapsePatternAvailable => AutomationObjectIds.IsExpandCollapsePatternAvailableProperty;
        public PropertyId IsGridItemPatternAvailable => AutomationObjectIds.IsGridItemPatternAvailableProperty;
        public PropertyId IsGridPatternAvailable => AutomationObjectIds.IsGridPatternAvailableProperty;
        public PropertyId IsInvokePatternAvailable => AutomationObjectIds.IsInvokePatternAvailableProperty;
#if NET35
        public PropertyId IsItemContainerPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
#else
        public PropertyId IsItemContainerPatternAvailable => AutomationObjectIds.IsItemContainerPatternAvailableProperty;
#endif
        public PropertyId IsLegacyIAccessiblePatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsMultipleViewPatternAvailable => AutomationObjectIds.IsMultipleViewPatternAvailableProperty;
        public PropertyId IsObjectModelPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsRangeValuePatternAvailable => AutomationObjectIds.IsRangeValuePatternAvailableProperty;
        public PropertyId IsScrollItemPatternAvailable => AutomationObjectIds.IsScrollItemPatternAvailableProperty;
        public PropertyId IsScrollPatternAvailable => AutomationObjectIds.IsScrollPatternAvailableProperty;
        public PropertyId IsSelectionItemPatternAvailable => AutomationObjectIds.IsSelectionItemPatternAvailableProperty;
        public PropertyId IsSelectionPatternAvailable => AutomationObjectIds.IsSelectionPatternAvailableProperty;
        public PropertyId IsSpreadsheetPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsSpreadsheetItemPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsStylesPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
#if NET35
        public PropertyId IsSynchronizedInputPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
#else
        public PropertyId IsSynchronizedInputPatternAvailable => AutomationObjectIds.IsSynchronizedInputPatternAvailableProperty;
#endif
        public PropertyId IsTableItemPatternAvailable => AutomationObjectIds.IsTableItemPatternAvailableProperty;
        public PropertyId IsTablePatternAvailable => AutomationObjectIds.IsTablePatternAvailableProperty;
        public PropertyId IsTextChildPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsTextEditPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsTextPatternAvailable => AutomationObjectIds.IsTextPatternAvailableProperty;
        public PropertyId IsTextPattern2Available { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsTogglePatternAvailable => AutomationObjectIds.IsTogglePatternAvailableProperty;
        public PropertyId IsTransformPatternAvailable => AutomationObjectIds.IsTransformPatternAvailableProperty;
        public PropertyId IsTransformPattern2Available { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsValuePatternAvailable => AutomationObjectIds.IsValuePatternAvailableProperty;
#if NET35
        public PropertyId IsVirtualizedItemPatternAvailable { get { throw new NotSupportedByUIA2Exception(); } }
#else
        public PropertyId IsVirtualizedItemPatternAvailable => AutomationObjectIds.IsVirtualizedItemPatternAvailableProperty;
#endif
        public PropertyId IsWindowPatternAvailable => AutomationObjectIds.IsWindowPatternAvailableProperty;

        public PropertyId[] AllForCurrentFramework => new[] {
            IsDockPatternAvailable,
            IsExpandCollapsePatternAvailable,
            IsGridItemPatternAvailable,
            IsGridPatternAvailable,
            IsInvokePatternAvailable,
#if !NET35
            IsItemContainerPatternAvailable,
#endif
            IsMultipleViewPatternAvailable,
            IsRangeValuePatternAvailable,
            IsScrollItemPatternAvailable,
            IsScrollPatternAvailable,
            IsSelectionItemPatternAvailable,
            IsSelectionPatternAvailable,
#if !NET35
            IsSynchronizedInputPatternAvailable,
#endif
            IsTableItemPatternAvailable,
            IsTablePatternAvailable,
            IsTextPatternAvailable,
            IsTogglePatternAvailable,
            IsTransformPatternAvailable,
            IsValuePatternAvailable,
#if !NET35
            IsVirtualizedItemPatternAvailable,
#endif
            IsWindowPatternAvailable
        };
    }
}