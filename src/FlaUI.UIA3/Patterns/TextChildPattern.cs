using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Patterns
{
    public class TextChildPattern : PatternBase<UIA.IUIAutomationTextChildPattern>, ITextChildPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TextChildPatternId, "TextChild", AutomationObjectIds.IsTextChildPatternAvailableProperty);

        public TextChildPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationTextChildPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public AutomationElement TextContainer
        {
            get
            {
                var nativeElement = Com.Call(() => NativePattern.TextContainer);
                return AutomationElementConverter.NativeToManaged((UIA3Automation)FrameworkAutomationElement.Automation, nativeElement);
            }
        }

        public ITextRange TextRange
        {
            get
            {
                var nativeRange = Com.Call(() => NativePattern.TextRange);
                return TextRangeConverter.NativeToManaged((UIA3Automation)FrameworkAutomationElement.Automation, nativeRange);
            }
        }
    }
}
