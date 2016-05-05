using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class TextChildPattern : PatternBase<IUIAutomationTextChildPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_TextChildPatternId, "TextChild");

        internal TextChildPattern(AutomationElement automationElement, IUIAutomationTextChildPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public AutomationElement TextContainer
        {
            get
            {
                var nativeElement = ComCallWrapper.Call(() => NativePattern.TextContainer);
                return ToAutomationElement(nativeElement);
            }
        }

        public TextRange TextRange
        {
            get
            {
                var nativeRange = ComCallWrapper.Call(() => NativePattern.TextRange);
                return NativeValueConverter.NativeToManaged(Automation, nativeRange);
            }
        }
    }
}
