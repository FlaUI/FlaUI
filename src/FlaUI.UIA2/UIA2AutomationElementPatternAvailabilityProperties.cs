using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Identifiers;

namespace FlaUI.UIA2
{
    public class UIA2AutomationElementPatternAvailabilityProperties : IAutomationElementPatternAvailabilityProperties
    {
        public PropertyId IsAnnotationPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsDockPatternAvailableProperty => AutomationObjectIds.IsDockPatternAvailableProperty;
        public PropertyId IsDragPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsDropTargetPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsExpandCollapsePatternAvailableProperty => AutomationObjectIds.IsExpandCollapsePatternAvailableProperty;
        public PropertyId IsGridItemPatternAvailableProperty => AutomationObjectIds.IsGridItemPatternAvailableProperty;
        public PropertyId IsGridPatternAvailableProperty => AutomationObjectIds.IsGridPatternAvailableProperty;
        public PropertyId IsInvokePatternAvailableProperty => AutomationObjectIds.IsInvokePatternAvailableProperty;
#if NET35
        public PropertyId IsItemContainerPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
#else
        public PropertyId IsItemContainerPatternAvailableProperty => AutomationObjectIds.IsItemContainerPatternAvailableProperty;
#endif
        public PropertyId IsLegacyIAccessiblePatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsMultipleViewPatternAvailableProperty => AutomationObjectIds.IsMultipleViewPatternAvailableProperty;
        public PropertyId IsObjectModelPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsRangeValuePatternAvailableProperty => AutomationObjectIds.IsRangeValuePatternAvailableProperty;
        public PropertyId IsScrollItemPatternAvailableProperty => AutomationObjectIds.IsScrollItemPatternAvailableProperty;
        public PropertyId IsScrollPatternAvailableProperty => AutomationObjectIds.IsScrollPatternAvailableProperty;
        public PropertyId IsSelectionItemPatternAvailableProperty => AutomationObjectIds.IsSelectionItemPatternAvailableProperty;
        public PropertyId IsSelectionPatternAvailableProperty => AutomationObjectIds.IsSelectionPatternAvailableProperty;
        public PropertyId IsSpreadsheetPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsSpreadsheetItemPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsStylesPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
#if NET35
        public PropertyId IsSynchronizedInputPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
#else
        public PropertyId IsSynchronizedInputPatternAvailableProperty => AutomationObjectIds.IsSynchronizedInputPatternAvailableProperty;
#endif
        public PropertyId IsTableItemPatternAvailableProperty => AutomationObjectIds.IsTableItemPatternAvailableProperty;
        public PropertyId IsTablePatternAvailableProperty => AutomationObjectIds.IsTablePatternAvailableProperty;
        public PropertyId IsTextChildPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsTextEditPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsTextPatternAvailableProperty => AutomationObjectIds.IsTextPatternAvailableProperty;
        public PropertyId IsTextPattern2AvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsTogglePatternAvailableProperty => AutomationObjectIds.IsTogglePatternAvailableProperty;
        public PropertyId IsTransformPatternAvailableProperty => AutomationObjectIds.IsTransformPatternAvailableProperty;
        public PropertyId IsTransformPattern2AvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
        public PropertyId IsValuePatternAvailableProperty => AutomationObjectIds.IsValuePatternAvailableProperty;
#if NET35
        public PropertyId IsVirtualizedItemPatternAvailableProperty { get { throw new NotSupportedByUIA2Exception(); } }
#else
        public PropertyId IsVirtualizedItemPatternAvailableProperty => AutomationObjectIds.IsVirtualizedItemPatternAvailableProperty;
#endif
        public PropertyId IsWindowPatternAvailableProperty => AutomationObjectIds.IsWindowPatternAvailableProperty;

        public PropertyId[] AllForCurrentFramework => new[] {
            IsDockPatternAvailableProperty,
            IsExpandCollapsePatternAvailableProperty,
            IsGridItemPatternAvailableProperty,
            IsGridPatternAvailableProperty,
            IsInvokePatternAvailableProperty,
#if !NET35
            IsItemContainerPatternAvailableProperty,
#endif
            IsMultipleViewPatternAvailableProperty,
            IsRangeValuePatternAvailableProperty,
            IsScrollItemPatternAvailableProperty,
            IsScrollPatternAvailableProperty,
            IsSelectionItemPatternAvailableProperty,
            IsSelectionPatternAvailableProperty,
#if !NET35
            IsSynchronizedInputPatternAvailableProperty,
#endif
            IsTableItemPatternAvailableProperty,
            IsTablePatternAvailableProperty,
            IsTextPatternAvailableProperty,
            IsTogglePatternAvailableProperty,
            IsTransformPatternAvailableProperty,
            IsValuePatternAvailableProperty,
#if !NET35
            IsVirtualizedItemPatternAvailableProperty,
#endif
            IsWindowPatternAvailableProperty
        };
    }
}