using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class TextEditPattern : TextPattern
    {
        public new static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_TextEditPatternId, "TextEdit");
        public static readonly EventId ConversionTargetChangedEvent = EventId.Register(UIA_EventIds.UIA_TextEdit_ConversionTargetChangedEventId, "ConversionTargetChanged");
        public static readonly EventId TextChangedEvent2 = EventId.Register(UIA_EventIds.UIA_TextEdit_TextChangedEventId, "TextChanged");

        public IUIAutomationTextEditPattern ExtendedNativePattern { get; private set; }

        internal TextEditPattern(AutomationElement automationElement, IUIAutomationTextEditPattern nativePattern)
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
