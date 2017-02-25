using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class InvokePattern : InvokePatternBase<UIA.InvokePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.InvokePattern.Pattern.Id, "Invoke", AutomationObjectIds.IsInvokePatternAvailableProperty);
        public static readonly EventId InvokedEvent = EventId.Register(AutomationType.UIA2, UIA.InvokePattern.InvokedEvent.Id, "Invoked");

        public InvokePattern(BasicAutomationElementBase basicAutomationElement, UIA.InvokePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public override void Invoke()
        {
            NativePattern.Invoke();
        }
    }

    public class InvokePatternEvents : IInvokePatternEvents
    {
        public EventId InvokedEvent => InvokePattern.InvokedEvent;
    }
}
