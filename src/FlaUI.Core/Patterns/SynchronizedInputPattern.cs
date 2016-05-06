using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;
using SynchronizedInputType = FlaUI.Core.Definitions.SynchronizedInputType;

namespace FlaUI.Core.Patterns
{
    public class SynchronizedInputPattern : PatternBase<IUIAutomationSynchronizedInputPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_SynchronizedInputPatternId, "SynchronizedInput");
        public static readonly EventId DiscardedEvent = EventId.Register(UIA_EventIds.UIA_InputDiscardedEventId, "Discarded");
        public static readonly EventId ReachedOtherElementEvent = EventId.Register(UIA_EventIds.UIA_InputReachedOtherElementEventId, "ReachedOtherElement");
        public static readonly EventId ReachedTargetEvent = EventId.Register(UIA_EventIds.UIA_InputReachedTargetEventId, "ReachedTarget");

        internal SynchronizedInputPattern(AutomationElement automationElement, IUIAutomationSynchronizedInputPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public void Cancel()
        {
            ComCallWrapper.Call(() => NativePattern.Cancel());
        }

        public void StartListening(SynchronizedInputType inputType)
        {
            ComCallWrapper.Call(() => NativePattern.StartListening((interop.UIAutomationCore.SynchronizedInputType)inputType));
        }
    }
}
