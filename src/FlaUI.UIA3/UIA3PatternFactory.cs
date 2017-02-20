using FlaUI.Core;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Patterns;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3PatternFactory : IPatternFactory
    {
        public UIA3BasicAutomationElement BasicAutomationElement { get; }

        internal UIA3PatternFactory(UIA3BasicAutomationElement basicAutomationElement)
        {
            BasicAutomationElement = basicAutomationElement;
        }

        public IAnnotationPattern GetAnnotationPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationAnnotationPattern>(AnnotationPattern.Pattern, cached);
            return nativePattern == null ? null : new AnnotationPattern(BasicAutomationElement, nativePattern);
        }

        public IDockPattern GetDockPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationDockPattern>(DockPattern.Pattern, cached);
            return nativePattern == null ? null : new DockPattern(BasicAutomationElement, nativePattern);
        }

        public IDragPattern GetDragPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationDragPattern>(DragPattern.Pattern, cached);
            return nativePattern == null ? null : new DragPattern(BasicAutomationElement, nativePattern);
        }

        public IDropTargetPattern GetDropTargetPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationDropTargetPattern>(DropTargetPattern.Pattern, cached);
            return nativePattern == null ? null : new DropTargetPattern(BasicAutomationElement, nativePattern);
        }

        public IExpandCollapsePattern GetExpandCollapsePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationExpandCollapsePattern>(ExpandCollapsePattern.Pattern, cached);
            return nativePattern == null ? null : new ExpandCollapsePattern(BasicAutomationElement, nativePattern);
        }

        public IGridItemPattern GetGridItemPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationGridItemPattern>(GridItemPattern.Pattern, cached);
            return nativePattern == null ? null : new GridItemPattern(BasicAutomationElement, nativePattern);
        }

        public IGridPattern GetGridPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationGridPattern>(GridPattern.Pattern, cached);
            return nativePattern == null ? null : new GridPattern(BasicAutomationElement, nativePattern);
        }

        public IInvokePattern GetInvokePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationInvokePattern>(InvokePattern.Pattern, cached);
            return nativePattern == null ? null : new InvokePattern(BasicAutomationElement, nativePattern);
        }

        public IItemContainerPattern GetItemContainerPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationItemContainerPattern>(ItemContainerPattern.Pattern, cached);
            return nativePattern == null ? null : new ItemContainerPattern(BasicAutomationElement, nativePattern);
        }

        public ILegacyIAccessiblePattern GetLegacyIAccessiblePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationLegacyIAccessiblePattern>(LegacyIAccessiblePattern.Pattern, cached);
            return nativePattern == null ? null : new LegacyIAccessiblePattern(BasicAutomationElement, nativePattern);
        }

        public IMultipleViewPattern GetMultipleViewPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationMultipleViewPattern>(MultipleViewPattern.Pattern, cached);
            return nativePattern == null ? null : new MultipleViewPattern(BasicAutomationElement, nativePattern);
        }

        public IObjectModelPattern GetObjectModelPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationObjectModelPattern>(ObjectModelPattern.Pattern, cached);
            return nativePattern == null ? null : new ObjectModelPattern(BasicAutomationElement, nativePattern);
        }

        public IRangeValuePattern GetRangeValuePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationRangeValuePattern>(RangeValuePattern.Pattern, cached);
            return nativePattern == null ? null : new RangeValuePattern(BasicAutomationElement, nativePattern);
        }

        public IScrollItemPattern GetScrollItemPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationScrollItemPattern>(ScrollItemPattern.Pattern, cached);
            return nativePattern == null ? null : new ScrollItemPattern(BasicAutomationElement, nativePattern);
        }

        public IScrollPattern GetScrollPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationScrollPattern>(ScrollPattern.Pattern, cached);
            return nativePattern == null ? null : new ScrollPattern(BasicAutomationElement, nativePattern);
        }

        public ISelectionItemPattern GetSelectionItemPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationSelectionItemPattern>(SelectionItemPattern.Pattern, cached);
            return nativePattern == null ? null : new SelectionItemPattern(BasicAutomationElement, nativePattern);
        }

        public ISelectionPattern GetSelectionPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationSelectionPattern>(SelectionPattern.Pattern, cached);
            return nativePattern == null ? null : new SelectionPattern(BasicAutomationElement, nativePattern);
        }

        public ISpreadsheetItemPattern GetSpreadsheetItemPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationSpreadsheetItemPattern>(SpreadsheetItemPattern.Pattern, cached);
            return nativePattern == null ? null : new SpreadsheetItemPattern(BasicAutomationElement, nativePattern);
        }

        public ISpreadsheetPattern GetSpreadsheetPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationSpreadsheetPattern>(SpreadsheetPattern.Pattern, cached);
            return nativePattern == null ? null : new SpreadsheetPattern(BasicAutomationElement, nativePattern);
        }

        public IStylesPattern GetStylesPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationStylesPattern>(StylesPattern.Pattern, cached);
            return nativePattern == null ? null : new StylesPattern(BasicAutomationElement, nativePattern);
        }

        public ISynchronizedInputPattern GetSynchronizedInputPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationSynchronizedInputPattern>(SynchronizedInputPattern.Pattern, cached);
            return nativePattern == null ? null : new SynchronizedInputPattern(BasicAutomationElement, nativePattern);
        }

        public ITableItemPattern GetTableItemPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationTableItemPattern>(TableItemPattern.Pattern, cached);
            return nativePattern == null ? null : new TableItemPattern(BasicAutomationElement, nativePattern);
        }

        public ITablePattern GetTablePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationTablePattern>(TablePattern.Pattern, cached);
            return nativePattern == null ? null : new TablePattern(BasicAutomationElement, nativePattern);
        }

        public ITextChildPattern GetTextChildPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationTextChildPattern>(TextChildPattern.Pattern, cached);
            return nativePattern == null ? null : new TextChildPattern(BasicAutomationElement, nativePattern);
        }

        public ITextEditPattern GetTextEditPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationTextEditPattern>(TextEditPattern.Pattern, cached);
            return nativePattern == null ? null : new TextEditPattern(BasicAutomationElement, nativePattern);
        }

        public IText2Pattern GetText2Pattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationTextPattern2>(Text2Pattern.Pattern, cached);
            return nativePattern == null ? null : new Text2Pattern(BasicAutomationElement, nativePattern);
        }

        public ITextPattern GetTextPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationTextPattern>(TextPattern.Pattern, cached);
            return nativePattern == null ? null : new TextPattern(BasicAutomationElement, nativePattern);
        }

        public ITogglePattern GetTogglePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationTogglePattern>(TogglePattern.Pattern, cached);
            return nativePattern == null ? null : new TogglePattern(BasicAutomationElement, nativePattern);
        }

        public ITransform2Pattern GetTransform2Pattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationTransformPattern2>(Transform2Pattern.Pattern, cached);
            return nativePattern == null ? null : new Transform2Pattern(BasicAutomationElement, nativePattern);
        }

        public ITransformPattern GetTransformPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationTransformPattern>(TransformPattern.Pattern, cached);
            return nativePattern == null ? null : new TransformPattern(BasicAutomationElement, nativePattern);
        }

        public IValuePattern GetValuePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationValuePattern>(ValuePattern.Pattern, cached);
            return nativePattern == null ? null : new ValuePattern(BasicAutomationElement, nativePattern);
        }

        public IVirtualizedItemPattern GetVirtualizedItemPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationVirtualizedItemPattern>(VirtualizedItemPattern.Pattern, cached);
            return nativePattern == null ? null : new VirtualizedItemPattern(BasicAutomationElement, nativePattern);
        }

        public IWindowPattern GetWindowPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.IUIAutomationWindowPattern>(WindowPattern.Pattern, cached);
            return nativePattern == null ? null : new WindowPattern(BasicAutomationElement, nativePattern);
        }
    }
}
