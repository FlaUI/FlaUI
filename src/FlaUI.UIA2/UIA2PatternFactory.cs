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

        public IAnnotationPattern GetAnnotationPattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IDockPattern GetDockPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.DockPattern>(DockPattern.Pattern);
            return nativePattern == null ? null : new DockPattern(BasicAutomationElement, nativePattern);
        }

        public IDragPattern GetDragPattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IDropTargetPattern GetDropTargetPattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IExpandCollapsePattern GetExpandCollapsePattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.ExpandCollapsePattern>(ExpandCollapsePattern.Pattern);
            return nativePattern == null ? null : new ExpandCollapsePattern(BasicAutomationElement, nativePattern);
        }

        public IGridItemPattern GetGridItemPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.GridItemPattern>(GridItemPattern.Pattern);
            return nativePattern == null ? null : new GridItemPattern(BasicAutomationElement, nativePattern);
        }

        public IGridPattern GetGridPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.GridPattern>(GridPattern.Pattern);
            return nativePattern == null ? null : new GridPattern(BasicAutomationElement, nativePattern);
        }

        public IInvokePattern GetInvokePattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.InvokePattern>(InvokePattern.Pattern);
            return nativePattern == null ? null : new InvokePattern(BasicAutomationElement, nativePattern);
        }

        public IItemContainerPattern GetItemContainerPattern()
        {
#if NET35
            throw new NotSupportedByUIA2Exception();
#else
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.ItemContainerPattern>(ItemContainerPattern.Pattern);
            return nativePattern == null ? null : new ItemContainerPattern(BasicAutomationElement, nativePattern);
#endif
        }

        public ILegacyIAccessiblePattern GetLegacyIAccessiblePattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IMultipleViewPattern GetMultipleViewPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.MultipleViewPattern>(MultipleViewPattern.Pattern);
            return nativePattern == null ? null : new MultipleViewPattern(BasicAutomationElement, nativePattern);
        }

        public IObjectModelPattern GetObjectModelPattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IRangeValuePattern GetRangeValuePattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.RangeValuePattern>(RangeValuePattern.Pattern);
            return nativePattern == null ? null : new RangeValuePattern(BasicAutomationElement, nativePattern);
        }

        public IScrollItemPattern GetScrollItemPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.ScrollItemPattern>(ScrollItemPattern.Pattern);
            return nativePattern == null ? null : new ScrollItemPattern(BasicAutomationElement, nativePattern);
        }

        public IScrollPattern GetScrollPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.ScrollPattern>(ScrollPattern.Pattern);
            return nativePattern == null ? null : new ScrollPattern(BasicAutomationElement, nativePattern);
        }

        public ISelectionItemPattern GetSelectionItemPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.SelectionItemPattern>(SelectionItemPattern.Pattern);
            return nativePattern == null ? null : new SelectionItemPattern(BasicAutomationElement, nativePattern);
        }

        public ISelectionPattern GetSelectionPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.SelectionPattern>(SelectionPattern.Pattern);
            return nativePattern == null ? null : new SelectionPattern(BasicAutomationElement, nativePattern);
        }

        public ISpreadsheetItemPattern GetSpreadsheetItemPattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ISpreadsheetPattern GetSpreadsheetPattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IStylesPattern GetStylesPattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ISynchronizedInputPattern GetSynchronizedInputPattern()
        {
#if NET35
            throw new NotSupportedByUIA2Exception();
#else
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.SynchronizedInputPattern>(SynchronizedInputPattern.Pattern);
            return nativePattern == null ? null : new SynchronizedInputPattern(BasicAutomationElement, nativePattern);
#endif
        }

        public ITableItemPattern GetTableItemPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.TableItemPattern>(TableItemPattern.Pattern);
            return nativePattern == null ? null : new TableItemPattern(BasicAutomationElement, nativePattern);
        }

        public ITablePattern GetTablePattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.TablePattern>(TablePattern.Pattern);
            return nativePattern == null ? null : new TablePattern(BasicAutomationElement, nativePattern);
        }

        public ITextChildPattern GetTextChildPattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ITextEditPattern GetTextEditPattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IText2Pattern GetText2Pattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ITextPattern GetTextPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.TextPattern>(TextPattern.Pattern);
            return nativePattern == null ? null : new TextPattern(BasicAutomationElement, nativePattern);
        }

        public ITogglePattern GetTogglePattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.TogglePattern>(TogglePattern.Pattern);
            return nativePattern == null ? null : new TogglePattern(BasicAutomationElement, nativePattern);
        }

        public ITransform2Pattern GetTransform2Pattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ITransformPattern GetTransformPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.TransformPattern>(TransformPattern.Pattern);
            return nativePattern == null ? null : new TransformPattern(BasicAutomationElement, nativePattern);
        }

        public IValuePattern GetValuePattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.ValuePattern>(ValuePattern.Pattern);
            return nativePattern == null ? null : new ValuePattern(BasicAutomationElement, nativePattern);
        }

        public IVirtualizedItemPattern GetVirtualizedItemPattern()
        {
#if NET35
            throw new NotSupportedByUIA2Exception();
#else
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.VirtualizedItemPattern>(VirtualizedItemPattern.Pattern);
            return nativePattern == null ? null : new VirtualizedItemPattern(BasicAutomationElement, nativePattern);
#endif
        }

        public IWindowPattern GetWindowPattern()
        {
            var nativePattern = BasicAutomationElement.GetNativePattern<UIA.WindowPattern>(WindowPattern.Pattern);
            return nativePattern == null ? null : new WindowPattern(BasicAutomationElement, nativePattern);
        }
    }
}
