using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TextEditPattern : TextPattern
    {
        public new static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_TextEditPatternId, "TextEdit");
        public static readonly EventId ConversionTargetChangedEvent = EventId.Register(UIA.UIA_EventIds.UIA_TextEdit_ConversionTargetChangedEventId, "ConversionTargetChanged");
        public static readonly EventId TextChangedEvent2 = EventId.Register(UIA.UIA_EventIds.UIA_TextEdit_TextChangedEventId, "TextChanged");

        public UIA.IUIAutomationTextEditPattern ExtendedNativePattern { get; private set; }

        internal TextEditPattern(Element automationElement, UIA.IUIAutomationTextEditPattern nativePattern)
            : base(automationElement, nativePattern)
        {
            ExtendedNativePattern = nativePattern;
        }

        public TextRange GetActiveComposition()
        {
            var nativeTextRange = ComCallWrapper.Call(() => ExtendedNativePattern.GetActiveComposition());
            return NativeValueConverter.NativeToManaged(Automation, nativeTextRange);
        }

        public TextRange GetConversionTarget()
        {
            var nativeTextRange = ComCallWrapper.Call(() => ExtendedNativePattern.GetConversionTarget());
            return NativeValueConverter.NativeToManaged(Automation, nativeTextRange);
        }
    }
}
