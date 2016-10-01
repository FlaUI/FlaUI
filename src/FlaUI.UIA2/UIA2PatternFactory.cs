using FlaUI.Core;
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
            throw new System.NotImplementedException();
        }

        public IInvokePattern GetInvokePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.InvokePattern>(UIA.InvokePattern.Pattern);
            return nativePattern == null ? null : new InvokePattern(AutomationObject, nativePattern);
        }

        public ISelectionItemPattern GetSelectionItemPattern()
        {
            throw new System.NotImplementedException();
        }

        public ITogglePattern GetTogglePattern()
        {
            throw new System.NotImplementedException();
        }

        public ITransform2Pattern GetTransform2Pattern()
        {
            throw new System.NotImplementedException();
        }

        public ITransformPattern GetTransformPattern()
        {
            throw new System.NotImplementedException();
        }

        public IValuePattern GetValuePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.ValuePattern>(UIA.ValuePattern.Pattern);
            return nativePattern == null ? null : new ValuePattern(AutomationObject, nativePattern);
        }

        public IVirtualizedItemPattern GetVirtualizedItemPattern()
        {
            throw new System.NotImplementedException();
        }

        public IWindowPattern GetWindowPattern()
        {
            throw new System.NotImplementedException();
        }

        private T GetNativePatternAs<T>(UIA.AutomationPattern pattern) where T : UIA.BasePattern
        {
            var nativePattern = AutomationObject.NativeElement.GetCurrentPattern(pattern);
            return (T)nativePattern;
        }
    }
}
