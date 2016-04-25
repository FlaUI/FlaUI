using FlaUI.Core.Definitions;
using interop.UIAutomationCore;

namespace FlaUI.Core
{
    /// <summary>
    /// Factory for the various patterns
    /// </summary>
    public class PatternFactory
    {
        private readonly IUIAutomationElement _automationElement;

        public PatternFactory(IUIAutomationElement automationElement)
        {
            _automationElement = automationElement;
        }

        /// <summary>
        /// Generic method to get any pattern and cast it to the desired type
        /// </summary>
        public T GetPatternAs<T>(PatternType patternType)
        {
            var pattern = _automationElement.GetCurrentPattern((int)patternType);
            return (T)pattern;
        }

        public IUIAutomationAnnotationPattern GetAnnotationPattern()
        {
            return GetPatternAs<IUIAutomationAnnotationPattern>(PatternType.Annotation);
        }

        public IUIAutomationDockPattern GetDockPattern()
        {
            return GetPatternAs<IUIAutomationDockPattern>(PatternType.Dock);
        }

        public IUIAutomationDragPattern GetDragPattern()
        {
            return GetPatternAs<IUIAutomationDragPattern>(PatternType.Drag);
        }

        public IUIAutomationDropTargetPattern GetDropTargetPattern()
        {
            return GetPatternAs<IUIAutomationDropTargetPattern>(PatternType.DropTarget);
        }

        public IUIAutomationExpandCollapsePattern GetExpandCollapsePattern()
        {
            return GetPatternAs<IUIAutomationExpandCollapsePattern>(PatternType.ExpandCollapse);
        }

        public IUIAutomationGridItemPattern GetGridItemPattern()
        {
            return GetPatternAs<IUIAutomationGridItemPattern>(PatternType.GridItem);
        }

        public IUIAutomationGridPattern GetGridPattern()
        {
            return GetPatternAs<IUIAutomationGridPattern>(PatternType.Grid);
        }

        public IUIAutomationInvokePattern GetInvokePattern()
        {
            return GetPatternAs<IUIAutomationInvokePattern>(PatternType.Invoke);
        }

        public IUIAutomationItemContainerPattern GetItemContainerPattern()
        {
            return GetPatternAs<IUIAutomationItemContainerPattern>(PatternType.ItemContainer);
        }

        public IUIAutomationLegacyIAccessiblePattern GetLegacyIAccessiblePattern()
        {
            return GetPatternAs<IUIAutomationLegacyIAccessiblePattern>(PatternType.LegacyIAccessible);
        }

        public IUIAutomationMultipleViewPattern GetMultipleViewPattern()
        {
            return GetPatternAs<IUIAutomationMultipleViewPattern>(PatternType.MultipleView);
        }

        public IUIAutomationObjectModelPattern GetObjectModelPattern()
        {
            return GetPatternAs<IUIAutomationObjectModelPattern>(PatternType.ObjectModel);
        }

        public IUIAutomationRangeValuePattern GetRangeValuePattern()
        {
            return GetPatternAs<IUIAutomationRangeValuePattern>(PatternType.RangeValue);
        }

        public IUIAutomationScrollItemPattern GetScrollItemPattern()
        {
            return GetPatternAs<IUIAutomationScrollItemPattern>(PatternType.ScrollItem);
        }

        public IUIAutomationScrollPattern GetScrollPattern()
        {
            return GetPatternAs<IUIAutomationScrollPattern>(PatternType.Scroll);
        }

        public IUIAutomationSelectionItemPattern GetSelectionItemPattern()
        {
            return GetPatternAs<IUIAutomationSelectionItemPattern>(PatternType.SelectionItem);
        }

        public IUIAutomationSelectionPattern GetSelectionPattern()
        {
            return GetPatternAs<IUIAutomationSelectionPattern>(PatternType.Selection);
        }

        public IUIAutomationSpreadsheetItemPattern GetSpreadsheetItemPattern()
        {
            return GetPatternAs<IUIAutomationSpreadsheetItemPattern>(PatternType.SpreadsheetItem);
        }

        public IUIAutomationSpreadsheetPattern GetSpreadsheetPattern()
        {
            return GetPatternAs<IUIAutomationSpreadsheetPattern>(PatternType.Spreadsheet);
        }

        public IUIAutomationStylesPattern GetStylesPattern()
        {
            return GetPatternAs<IUIAutomationStylesPattern>(PatternType.Styles);
        }

        public IUIAutomationSynchronizedInputPattern GetSynchronizedInputPattern()
        {
            return GetPatternAs<IUIAutomationSynchronizedInputPattern>(PatternType.SynchronizedInput);
        }

        public IUIAutomationTableItemPattern GetTableItemPattern()
        {
            return GetPatternAs<IUIAutomationTableItemPattern>(PatternType.TableItem);
        }

        public IUIAutomationTablePattern GetTablePattern()
        {
            return GetPatternAs<IUIAutomationTablePattern>(PatternType.Table);
        }

        public IUIAutomationTextChildPattern GetTextChildPattern()
        {
            return GetPatternAs<IUIAutomationTextChildPattern>(PatternType.TextChild);
        }

        public IUIAutomationTextEditPattern GetTextEditPattern()
        {
            return GetPatternAs<IUIAutomationTextEditPattern>(PatternType.TextEdit);
        }

        public IUIAutomationTextPattern2 GetText2Pattern()
        {
            return GetPatternAs<IUIAutomationTextPattern2>(PatternType.Text2);
        }

        public IUIAutomationTextPattern GetTextPattern()
        {
            return GetPatternAs<IUIAutomationTextPattern>(PatternType.Text);
        }

        public IUIAutomationTogglePattern GetTogglePattern()
        {
            return GetPatternAs<IUIAutomationTogglePattern>(PatternType.Toggle);
        }

        public IUIAutomationTransformPattern2 GetTransform2Pattern()
        {
            return GetPatternAs<IUIAutomationTransformPattern2>(PatternType.Transform2);
        }

        public IUIAutomationTransformPattern GetTransformPattern()
        {
            return GetPatternAs<IUIAutomationTransformPattern>(PatternType.Transform);
        }

        public IUIAutomationValuePattern GetValuePattern()
        {
            return GetPatternAs<IUIAutomationValuePattern>(PatternType.Value);
        }

        public IUIAutomationVirtualizedItemPattern GetVirtualizedItemPattern()
        {
            return GetPatternAs<IUIAutomationVirtualizedItemPattern>(PatternType.VirtualizedItem);
        }

        public IUIAutomationWindowPattern GetWindowPattern()
        {
            return GetPatternAs<IUIAutomationWindowPattern>(PatternType.Window);
        }
    }
}
