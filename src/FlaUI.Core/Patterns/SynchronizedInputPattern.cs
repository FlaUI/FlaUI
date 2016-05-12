using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class SynchronizedInputPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_SynchronizedInputPatternId, "SynchronizedInput");
        public static readonly EventId DiscardedEvent = EventId.Register(UIA.UIA_EventIds.UIA_InputDiscardedEventId, "Discarded");
        public static readonly EventId ReachedOtherElementEvent = EventId.Register(UIA.UIA_EventIds.UIA_InputReachedOtherElementEventId, "ReachedOtherElement");
        public static readonly EventId ReachedTargetEvent = EventId.Register(UIA.UIA_EventIds.UIA_InputReachedTargetEventId, "ReachedTarget");

        internal SynchronizedInputPattern(AutomationElement automationElement, UIA.IUIAutomationSynchronizedInputPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public UIA.IUIAutomationSynchronizedInputPattern NativePattern
        {
            get { return (UIA.IUIAutomationSynchronizedInputPattern)base.NativePattern; }
        }

        public void Cancel()
        {
            ComCallWrapper.Call(() => NativePattern.Cancel());
        }

        public void StartListening(SynchronizedInputType inputType)
        {
            ComCallWrapper.Call(() => NativePattern.StartListening((UIA.SynchronizedInputType)inputType));
        }
    }
}
