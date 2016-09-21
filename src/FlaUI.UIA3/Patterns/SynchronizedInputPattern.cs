using FlaUI.Core.Tools;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SynchronizedInputPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_SynchronizedInputPatternId, "SynchronizedInput");
        public static readonly EventId DiscardedEvent = EventId.Register(UIA.UIA_EventIds.UIA_InputDiscardedEventId, "Discarded");
        public static readonly EventId ReachedOtherElementEvent = EventId.Register(UIA.UIA_EventIds.UIA_InputReachedOtherElementEventId, "ReachedOtherElement");
        public static readonly EventId ReachedTargetEvent = EventId.Register(UIA.UIA_EventIds.UIA_InputReachedTargetEventId, "ReachedTarget");

        internal SynchronizedInputPattern(Element automationElement, UIA.IUIAutomationSynchronizedInputPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public new UIA.IUIAutomationSynchronizedInputPattern NativePattern
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
