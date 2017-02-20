using FlaUI.Core;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Patterns;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public class UIA2PatternFactory : IPatternFactory
    {
        public UIA2BasicAutomationElement BasicAutomationElement { get; }

        internal UIA2PatternFactory(UIA2BasicAutomationElement basicAutomationElement)
        {
            BasicAutomationElement = basicAutomationElement;
        }

        public IAnnotationPattern GetAnnotationPattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IDockPattern GetDockPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.DockPattern>(DockPattern.Pattern, cached);
            return nativePattern == null ? null : new DockPattern(BasicAutomationElement, nativePattern);
        }

        public IDragPattern GetDragPattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IDropTargetPattern GetDropTargetPattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IExpandCollapsePattern GetExpandCollapsePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.ExpandCollapsePattern>(ExpandCollapsePattern.Pattern, cached);
            return nativePattern == null ? null : new ExpandCollapsePattern(BasicAutomationElement, nativePattern);
        }

        public IGridItemPattern GetGridItemPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.GridItemPattern>(GridItemPattern.Pattern, cached);
            return nativePattern == null ? null : new GridItemPattern(BasicAutomationElement, nativePattern);
        }

        public IGridPattern GetGridPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.GridPattern>(GridPattern.Pattern, cached);
            return nativePattern == null ? null : new GridPattern(BasicAutomationElement, nativePattern);
        }

        public IInvokePattern GetInvokePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.InvokePattern>(InvokePattern.Pattern, cached);
            return nativePattern == null ? null : new InvokePattern(BasicAutomationElement, nativePattern);
        }

        public IItemContainerPattern GetItemContainerPattern(bool cached = false)
        {
#if NET35
            throw new NotSupportedByUIA2Exception();
#else
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.ItemContainerPattern>(ItemContainerPattern.Pattern, cached);
            return nativePattern == null ? null : new ItemContainerPattern(BasicAutomationElement, nativePattern);
#endif
        }

        public ILegacyIAccessiblePattern GetLegacyIAccessiblePattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IMultipleViewPattern GetMultipleViewPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.MultipleViewPattern>(MultipleViewPattern.Pattern, cached);
            return nativePattern == null ? null : new MultipleViewPattern(BasicAutomationElement, nativePattern);
        }

        public IObjectModelPattern GetObjectModelPattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IRangeValuePattern GetRangeValuePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.RangeValuePattern>(RangeValuePattern.Pattern, cached);
            return nativePattern == null ? null : new RangeValuePattern(BasicAutomationElement, nativePattern);
        }

        public IScrollItemPattern GetScrollItemPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.ScrollItemPattern>(ScrollItemPattern.Pattern, cached);
            return nativePattern == null ? null : new ScrollItemPattern(BasicAutomationElement, nativePattern);
        }

        public IScrollPattern GetScrollPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.ScrollPattern>(ScrollPattern.Pattern, cached);
            return nativePattern == null ? null : new ScrollPattern(BasicAutomationElement, nativePattern);
        }

        public ISelectionItemPattern GetSelectionItemPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.SelectionItemPattern>(SelectionItemPattern.Pattern, cached);
            return nativePattern == null ? null : new SelectionItemPattern(BasicAutomationElement, nativePattern);
        }

        public ISelectionPattern GetSelectionPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.SelectionPattern>(SelectionPattern.Pattern, cached);
            return nativePattern == null ? null : new SelectionPattern(BasicAutomationElement, nativePattern);
        }

        public ISpreadsheetItemPattern GetSpreadsheetItemPattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ISpreadsheetPattern GetSpreadsheetPattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IStylesPattern GetStylesPattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ISynchronizedInputPattern GetSynchronizedInputPattern(bool cached = false)
        {
#if NET35
            throw new NotSupportedByUIA2Exception();
#else
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.SynchronizedInputPattern>(SynchronizedInputPattern.Pattern, cached);
            return nativePattern == null ? null : new SynchronizedInputPattern(BasicAutomationElement, nativePattern);
#endif
        }

        public ITableItemPattern GetTableItemPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.TableItemPattern>(TableItemPattern.Pattern, cached);
            return nativePattern == null ? null : new TableItemPattern(BasicAutomationElement, nativePattern);
        }

        public ITablePattern GetTablePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.TablePattern>(TablePattern.Pattern, cached);
            return nativePattern == null ? null : new TablePattern(BasicAutomationElement, nativePattern);
        }

        public ITextChildPattern GetTextChildPattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ITextEditPattern GetTextEditPattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IText2Pattern GetText2Pattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ITextPattern GetTextPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.TextPattern>(TextPattern.Pattern, cached);
            return nativePattern == null ? null : new TextPattern(BasicAutomationElement, nativePattern);
        }

        public ITogglePattern GetTogglePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.TogglePattern>(TogglePattern.Pattern, cached);
            return nativePattern == null ? null : new TogglePattern(BasicAutomationElement, nativePattern);
        }

        public ITransform2Pattern GetTransform2Pattern(bool cached = false)
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ITransformPattern GetTransformPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.TransformPattern>(TransformPattern.Pattern, cached);
            return nativePattern == null ? null : new TransformPattern(BasicAutomationElement, nativePattern);
        }

        public IValuePattern GetValuePattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.ValuePattern>(ValuePattern.Pattern, cached);
            return nativePattern == null ? null : new ValuePattern(BasicAutomationElement, nativePattern);
        }

        public IVirtualizedItemPattern GetVirtualizedItemPattern(bool cached = false)
        {
#if NET35
            throw new NotSupportedByUIA2Exception();
#else
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.VirtualizedItemPattern>(VirtualizedItemPattern.Pattern, cached);
            return nativePattern == null ? null : new VirtualizedItemPattern(BasicAutomationElement, nativePattern);
#endif
        }

        public IWindowPattern GetWindowPattern(bool cached = false)
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.WindowPattern>(WindowPattern.Pattern, cached);
            return nativePattern == null ? null : new WindowPattern(BasicAutomationElement, nativePattern);
        }
    }
}
