using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class InvokePattern : PatternBase<IUIAutomationInvokePattern>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_InvokePatternId, "Invoke");
        public static readonly AutomationEvent InvokedEvent = AutomationEvent.Register(UIA_EventIds.UIA_Invoke_InvokedEventId, "Invoked");

        internal InvokePattern(AutomationElement automationElement, IUIAutomationInvokePattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public void Invoke()
        {
            ComCallWrapper.Call(() => NativePattern.Invoke());
        }
    }
}
