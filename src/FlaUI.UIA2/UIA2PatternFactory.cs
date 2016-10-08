using System;
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
