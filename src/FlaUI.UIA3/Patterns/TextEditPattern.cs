using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TextEditPattern : TextPattern, ITextEditPattern
    {
        public new static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TextEditPatternId, "TextEdit");
        public static readonly EventId ConversionTargetChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_TextEdit_ConversionTargetChangedEventId, "ConversionTargetChanged");
        public static readonly EventId TextChangedEvent2 = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_TextEdit_TextChangedEventId, "TextChanged");

        public TextEditPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTextPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ExtendedNativePattern = (UIA.IUIAutomationTextEditPattern)NativePattern;
            Events = new TextEditPatternEvents();
        }

        public UIA.IUIAutomationTextEditPattern ExtendedNativePattern { get; }

        public new ITextEditPatternEvents Events { get; }

        public ITextRange GetActiveComposition()
        {
            var nativeRange = ComCallWrapper.Call(() => ExtendedNativePattern.GetActiveComposition());
            return ValueConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeRange);
        }

        public ITextRange GetConversionTarget()
        {
            var nativeRange = ComCallWrapper.Call(() => ExtendedNativePattern.GetConversionTarget());
            return ValueConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeRange);
        }
    }

    public class TextEditPatternEvents : ITextEditPatternEvents
    {
        public EventId ConversionTargetChangedEvent => TextEditPattern.ConversionTargetChangedEvent;
        public EventId TextChangedEvent2 => TextEditPattern.TextChangedEvent2;
    }
}
