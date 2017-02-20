using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
#if !NET35
    public class SynchronizedInputPattern : PatternBase<UIA.SynchronizedInputPattern>, ISynchronizedInputPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.SynchronizedInputPattern.Pattern.Id, "SynchronizedInput", AutomationObjectIds.IsSynchronizedInputPatternAvailableProperty);
        public static readonly EventId DiscardedEvent = EventId.Register(AutomationType.UIA2, UIA.SynchronizedInputPattern.InputDiscardedEvent.Id, "Discarded");
        public static readonly EventId ReachedOtherElementEvent = EventId.Register(AutomationType.UIA2, UIA.SynchronizedInputPattern.InputReachedOtherElementEvent.Id, "ReachedOtherElement");
        public static readonly EventId ReachedTargetEvent = EventId.Register(AutomationType.UIA2, UIA.SynchronizedInputPattern.InputReachedTargetEvent.Id, "ReachedTarget");

        public SynchronizedInputPattern(BasicAutomationElementBase basicAutomationElement, UIA.SynchronizedInputPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ISynchronizedInputPatternEvents Events => Automation.EventLibrary.SynchronizedInput;

        public void Cancel()
        {
            NativePattern.Cancel();
        }

        public void StartListening(SynchronizedInputType inputType)
        {
            NativePattern.StartListening((UIA.SynchronizedInputType)inputType);
        }
    }

    public class SynchronizedInputPatternEvents : ISynchronizedInputPatternEvents
    {
        public EventId DiscardedEvent => SynchronizedInputPattern.DiscardedEvent;
        public EventId ReachedOtherElementEvent => SynchronizedInputPattern.ReachedOtherElementEvent;
        public EventId ReachedTargetEvent => SynchronizedInputPattern.ReachedTargetEvent;
    }
#endif
}
