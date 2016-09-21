using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class InvokePattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_InvokePatternId, "Invoke");
        public static readonly EventId InvokedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Invoke_InvokedEventId, "Invoked");

        internal InvokePattern(Element automationElement, UIA.IUIAutomationInvokePattern nativePattern)
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
