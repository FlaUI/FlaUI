using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class SynchronizedInputPattern : PatternBase<IUIAutomationSynchronizedInputPattern>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_SynchronizedInputPatternId, "SynchronizedInput");
        public static readonly AutomationEvent DiscardedEvent = AutomationEvent.Register(UIA_EventIds.UIA_InputDiscardedEventId, "Discarded");
        public static readonly AutomationEvent ReachedOtherElementEvent = AutomationEvent.Register(UIA_EventIds.UIA_InputReachedOtherElementEventId, "ReachedOtherElement");
        public static readonly AutomationEvent ReachedTargetEvent = AutomationEvent.Register(UIA_EventIds.UIA_InputReachedTargetEventId, "ReachedTarget");

        internal SynchronizedInputPattern(AutomationElement automationElement, IUIAutomationSynchronizedInputPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public void Cancel()
        {
            ComCallWrapper.Call(() => NativePattern.Cancel());
        }

        public void StartListening(Definitions.SynchronizedInputType inputType)
        {
            ComCallWrapper.Call(() => NativePattern.StartListening((SynchronizedInputType)inputType));
        }
    }
}
