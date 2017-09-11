using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    /// <summary>
    /// Class for an UIA2 <see cref="IInvokePattern"/>.
    /// </summary>
    public class InvokePattern : InvokePatternBase<UIA.InvokePattern>
    {
        /// <summary>
        /// The <see cref="PatternId"/> for this pattern.
        /// </summary>
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.InvokePattern.Pattern.Id, "Invoke", AutomationObjectIds.IsInvokePatternAvailableProperty);

        /// <summary>
        /// The <see cref="EventId"/> for the invoked event.
        /// </summary>
        public static readonly EventId InvokedEvent = EventId.Register(AutomationType.UIA2, UIA.InvokePattern.InvokedEvent.Id, "Invoked");

        /// <summary>
        /// Creates an UIA2 <see cref="IInvokePattern"/>.
        /// </summary>
        public InvokePattern(BasicAutomationElementBase basicAutomationElement, UIA.InvokePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        /// <inheritdoc />
        public override void Invoke()
        {
            NativePattern.Invoke();
        }
    }

    /// <summary>
    /// Class for UIA2 <see cref="IInvokePatternEvents"/>.
    /// </summary>
    public class InvokePatternEvents : IInvokePatternEvents
    {
        /// <inheritdoc />
        public EventId InvokedEvent => InvokePattern.InvokedEvent;
    }
}
