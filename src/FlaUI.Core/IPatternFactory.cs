using FlaUI.Core.Patterns;

namespace FlaUI.Core
{
    public interface IPatternFactory
    {
        IAnnotationPattern GetAnnotationPattern(bool cached = false);
        IDockPattern GetDockPattern(bool cached = false);
        IDragPattern GetDragPattern(bool cached = false);
        IDropTargetPattern GetDropTargetPattern(bool cached = false);
        IExpandCollapsePattern GetExpandCollapsePattern(bool cached = false);
        IGridItemPattern GetGridItemPattern(bool cached = false);
        IGridPattern GetGridPattern(bool cached = false);
        IInvokePattern GetInvokePattern(bool cached = false);
        IItemContainerPattern GetItemContainerPattern(bool cached = false);
        ILegacyIAccessiblePattern GetLegacyIAccessiblePattern(bool cached = false);
        IMultipleViewPattern GetMultipleViewPattern(bool cached = false);
        IObjectModelPattern GetObjectModelPattern(bool cached = false);
        IRangeValuePattern GetRangeValuePattern(bool cached = false);
        IScrollItemPattern GetScrollItemPattern(bool cached = false);
        IScrollPattern GetScrollPattern(bool cached = false);
        ISelectionItemPattern GetSelectionItemPattern(bool cached = false);
        ISelectionPattern GetSelectionPattern(bool cached = false);
        ISpreadsheetItemPattern GetSpreadsheetItemPattern(bool cached = false);
        ISpreadsheetPattern GetSpreadsheetPattern(bool cached = false);
        IStylesPattern GetStylesPattern(bool cached = false);
        ISynchronizedInputPattern GetSynchronizedInputPattern(bool cached = false);
        ITableItemPattern GetTableItemPattern(bool cached = false);
        ITablePattern GetTablePattern(bool cached = false);
        ITextChildPattern GetTextChildPattern(bool cached = false);
        ITextEditPattern GetTextEditPattern(bool cached = false);
        IText2Pattern GetText2Pattern(bool cached = false);
        ITextPattern GetTextPattern(bool cached = false);
        ITogglePattern GetTogglePattern(bool cached = false);
        ITransform2Pattern GetTransform2Pattern(bool cached = false);
        ITransformPattern GetTransformPattern(bool cached = false);
        IValuePattern GetValuePattern(bool cached = false);
        IVirtualizedItemPattern GetVirtualizedItemPattern(bool cached = false);
        IWindowPattern GetWindowPattern(bool cached = false);
    }
}
