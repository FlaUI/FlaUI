using FlaUI.Core;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Patterns;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public class UIA2PatternFactory : IPatternFactory
    {
        public UIA2AutomationObject AutomationObject { get; }

        internal UIA2PatternFactory(UIA2AutomationObject automationObject)
        {
            AutomationObject = automationObject;
        }

        public IExpandCollapsePattern GetExpandCollapsePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.ExpandCollapsePattern>(UIA.ExpandCollapsePattern.Pattern);
            return nativePattern == null ? null : new ExpandCollapsePattern(AutomationObject, nativePattern);
        }

        public IInvokePattern GetInvokePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.InvokePattern>(UIA.InvokePattern.Pattern);
            return nativePattern == null ? null : new InvokePattern(AutomationObject, nativePattern);
        }

        public IRangeValuePattern GetRangeValuePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.RangeValuePattern>(UIA.RangeValuePattern.Pattern);
            return nativePattern == null ? null : new RangeValuePattern(AutomationObject, nativePattern);
        }

        public ISelectionItemPattern GetSelectionItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.SelectionItemPattern>(UIA.SelectionItemPattern.Pattern);
            return nativePattern == null ? null : new SelectionItemPattern(AutomationObject, nativePattern);
        }

        public ITogglePattern GetTogglePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.TogglePattern>(UIA.TogglePattern.Pattern);
            return nativePattern == null ? null : new TogglePattern(AutomationObject, nativePattern);
        }

        public ITransform2Pattern GetTransform2Pattern()
        {
            throw new NotSupportedByUIA2Exception();
        }

        public ITransformPattern GetTransformPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.TransformPattern>(UIA.TransformPattern.Pattern);
            return nativePattern == null ? null : new TransformPattern(AutomationObject, nativePattern);
        }

        public IValuePattern GetValuePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.ValuePattern>(UIA.ValuePattern.Pattern);
            return nativePattern == null ? null : new ValuePattern(AutomationObject, nativePattern);
        }

        public IVirtualizedItemPattern GetVirtualizedItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.VirtualizedItemPattern>(UIA.VirtualizedItemPattern.Pattern);
            return nativePattern == null ? null : new VirtualizedItemPattern(AutomationObject, nativePattern);
        }

        public IWindowPattern GetWindowPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.WindowPattern>(UIA.WindowPattern.Pattern);
            return nativePattern == null ? null : new WindowPattern(AutomationObject, nativePattern);
        }

        private T GetNativePatternAs<T>(UIA.AutomationPattern pattern) where T : UIA.BasePattern
        {
            object nativePattern;
            AutomationObject.NativeElement.TryGetCurrentPattern(pattern, out nativePattern);
            return (T)nativePattern;
        }
    }
}
