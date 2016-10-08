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
            var nativePattern = GetNativePatternAs<UIA.DockPattern>(UIA.DockPattern.Pattern);
            return nativePattern == null ? null : new DockPattern(BasicAutomationElement, nativePattern);
        }

        public IExpandCollapsePattern GetExpandCollapsePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.ExpandCollapsePattern>(UIA.ExpandCollapsePattern.Pattern);
            return nativePattern == null ? null : new ExpandCollapsePattern(BasicAutomationElement, nativePattern);
        }

        public IGridItemPattern GetGridItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.GridItemPattern>(UIA.GridItemPattern.Pattern);
            return nativePattern == null ? null : new GridItemPattern(BasicAutomationElement, nativePattern);
        }

        public IGridPattern GetGridPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.GridPattern>(UIA.GridPattern.Pattern);
            return nativePattern == null ? null : new GridPattern(BasicAutomationElement, nativePattern);
        }

        public IInvokePattern GetInvokePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.InvokePattern>(UIA.InvokePattern.Pattern);
            return nativePattern == null ? null : new InvokePattern(BasicAutomationElement, nativePattern);
        }

        public IItemContainerPattern GetItemContainerPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.ItemContainerPattern>(UIA.ItemContainerPattern.Pattern);
            return nativePattern == null ? null : new ItemContainerPattern(BasicAutomationElement, nativePattern);
        }

        public IMultipleViewPattern GetMultipleViewPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.MultipleViewPattern>(UIA.MultipleViewPattern.Pattern);
            return nativePattern == null ? null : new MultipleViewPattern(BasicAutomationElement, nativePattern);
        }

        public IObjectModelPattern GetObjectModelPattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public IRangeValuePattern GetRangeValuePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.RangeValuePattern>(UIA.RangeValuePattern.Pattern);
            return nativePattern == null ? null : new RangeValuePattern(BasicAutomationElement, nativePattern);
        }

        public IScrollItemPattern GetScrollItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.ScrollItemPattern>(UIA.ScrollItemPattern.Pattern);
            return nativePattern == null ? null : new ScrollItemPattern(BasicAutomationElement, nativePattern);
        }

        public IScrollPattern GetScrollPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.ScrollPattern>(UIA.ScrollPattern.Pattern);
            return nativePattern == null ? null : new ScrollPattern(BasicAutomationElement, nativePattern);
        }

        public ISelectionItemPattern GetSelectionItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.SelectionItemPattern>(UIA.SelectionItemPattern.Pattern);
            return nativePattern == null ? null : new SelectionItemPattern(BasicAutomationElement, nativePattern);
        }

        public ISelectionPattern GetSelectionPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.SelectionPattern>(UIA.SelectionPattern.Pattern);
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

        public ISynchronizedInputPattern GetSynchronizedInputPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.SynchronizedInputPattern>(UIA.SynchronizedInputPattern.Pattern);
            return nativePattern == null ? null : new SynchronizedInputPattern(BasicAutomationElement, nativePattern);
        }

        public ITableItemPattern GetTableItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.TableItemPattern>(UIA.TableItemPattern.Pattern);
            return nativePattern == null ? null : new TableItemPattern(BasicAutomationElement, nativePattern);
        }

        public ITablePattern GetTablePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.TablePattern>(UIA.TablePattern.Pattern);
            return nativePattern == null ? null : new TablePattern(BasicAutomationElement, nativePattern);
        }

        public ITogglePattern GetTogglePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.TogglePattern>(UIA.TogglePattern.Pattern);
            return nativePattern == null ? null : new TogglePattern(BasicAutomationElement, nativePattern);
        }

        public ITransform2Pattern GetTransform2Pattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ITransformPattern GetTransformPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.TransformPattern>(UIA.TransformPattern.Pattern);
            return nativePattern == null ? null : new TransformPattern(BasicAutomationElement, nativePattern);
        }

        public IValuePattern GetValuePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.ValuePattern>(UIA.ValuePattern.Pattern);
            return nativePattern == null ? null : new ValuePattern(BasicAutomationElement, nativePattern);
        }

        public IVirtualizedItemPattern GetVirtualizedItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.VirtualizedItemPattern>(UIA.VirtualizedItemPattern.Pattern);
            return nativePattern == null ? null : new VirtualizedItemPattern(BasicAutomationElement, nativePattern);
        }

        public IWindowPattern GetWindowPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.WindowPattern>(UIA.WindowPattern.Pattern);
            return nativePattern == null ? null : new WindowPattern(BasicAutomationElement, nativePattern);
        }

        private T GetNativePatternAs<T>(UIA.AutomationPattern pattern) where T : UIA.BasePattern
        {
            object nativePattern;
            BasicAutomationElement.NativeElement.TryGetCurrentPattern(pattern, out nativePattern);
            return (T)nativePattern;
        }
    }
}
