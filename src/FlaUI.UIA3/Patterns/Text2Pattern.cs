using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class Text2Pattern : TextPattern
    {
        public new static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_TextPattern2Id, "Text2");

        public UIA.IUIAutomationTextPattern2 ExtendedNativePattern { get; private set; }

        internal Text2Pattern(Element automationElement, UIA.IUIAutomationTextPattern2 nativePattern)
            : base(automationElement, nativePattern)
        {
            ExtendedNativePattern = nativePattern;
        }

        public TextRange GetCaretRange(out bool isActive)
        {
            var rawIsActive = 0;
            var nativeTextRange = ComCallWrapper.Call(() => ExtendedNativePattern.GetCaretRange(out rawIsActive));
            isActive = (rawIsActive != 0);
            return NativeValueConverter.NativeToManaged(Automation, nativeTextRange);
        }

        public TextRange RangeFromAnnotation(Element annotation)
        {
            var nativeElement = ComCallWrapper.Call(() => ExtendedNativePattern.RangeFromAnnotation(annotation.NativeElement));
            return NativeValueConverter.NativeToManaged(Automation, nativeElement);
        }
    }
}
