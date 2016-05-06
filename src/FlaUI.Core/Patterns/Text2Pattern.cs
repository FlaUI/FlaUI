using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class Text2Pattern : TextPattern
    {
        public new static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_TextPattern2Id, "Text2");

        public IUIAutomationTextPattern2 ExtendedNativePattern { get; private set; }

        internal Text2Pattern(AutomationElement automationElement, IUIAutomationTextPattern2 nativePattern)
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

        public TextRange RangeFromAnnotation(AutomationElement annotation)
        {
            var nativeElement = ComCallWrapper.Call(() => ExtendedNativePattern.RangeFromAnnotation(annotation.NativeElement));
            return NativeValueConverter.NativeToManaged(Automation, nativeElement);
        }
    }
}
