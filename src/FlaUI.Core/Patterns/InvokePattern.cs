using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class InvokePattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_InvokePatternId, "Invoke");
        public static readonly EventId InvokedEvent = EventId.Register(UIA_EventIds.UIA_Invoke_InvokedEventId, "Invoked");

        internal InvokePattern(AutomationElement automationElement, IUIAutomationInvokePattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public IUIAutomationInvokePattern NativePattern
        {
            get { return (IUIAutomationInvokePattern)base.NativePattern; }
        }

        public void Invoke()
        {
            ComCallWrapper.Call(() => NativePattern.Invoke());
        }
    }
}
