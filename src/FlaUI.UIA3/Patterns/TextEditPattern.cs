using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TextEditPattern : TextPattern
    {
        public new static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TextEditPatternId, "TextEdit");
        public static readonly EventId ConversionTargetChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_TextEdit_ConversionTargetChangedEventId, "ConversionTargetChanged");
        public static readonly EventId TextChangedEvent2 = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_TextEdit_TextChangedEventId, "TextChanged");

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
