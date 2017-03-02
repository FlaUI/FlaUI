using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class InvokePattern : InvokePatternBase<UIA.IUIAutomationInvokePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_InvokePatternId, "Invoke", AutomationObjectIds.IsInvokePatternAvailableProperty);
        public static readonly EventId InvokedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Invoke_InvokedEventId, "Invoked");

        public InvokePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationInvokePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public override void Invoke()
        {
            ComCallWrapper.Call(() => NativePattern.Invoke());
        }
    }

    public class InvokePatternEvents : IInvokePatternEvents
    {
        public EventId InvokedEvent => InvokePattern.InvokedEvent;
    }
}
