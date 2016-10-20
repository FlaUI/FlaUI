using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TextChildPattern : PatternBase<UIA.IUIAutomationTextChildPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TextChildPatternId, "TextChild");

        public TextChildPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTextChildPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public AutomationElement TextContainer
        {
            get
            {
                var nativeElement = ComCallWrapper.Call(() => NativePattern.TextContainer);
                return ValueConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public ITextRange TextRange
        {
            get
            {
                var nativeRange = ComCallWrapper.Call(() => NativePattern.TextRange);
                return ValueConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeRange);
            }
        }
    }
}
