using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class InvokePattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_InvokePatternId, "Invoke");
        public static readonly EventId InvokedEvent = EventId.Register(UIA.UIA_EventIds.UIA_Invoke_InvokedEventId, "Invoked");

        internal InvokePattern(AutomationElement automationElement, UIA.IUIAutomationInvokePattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public new UIA.IUIAutomationInvokePattern NativePattern
        {
            get { return (UIA.IUIAutomationInvokePattern)base.NativePattern; }
        }

        public void Invoke()
        {
            ComCallWrapper.Call(() => NativePattern.Invoke());
        }
    }
}
