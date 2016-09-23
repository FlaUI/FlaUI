using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class InvokePattern : PatternBase<UIA.IUIAutomationInvokePattern>, IInvokePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_InvokePatternId, "Invoke");
        public static readonly EventId InvokedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Invoke_InvokedEventId, "Invoked");

        public InvokePattern(AutomationObjectBase automationObject, UIA.IUIAutomationInvokePattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        public void Invoke()
        {
            ComCallWrapper.Call(() => NativePattern.Invoke());
        }
    }
}
