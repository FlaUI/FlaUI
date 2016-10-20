using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Extensions;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TextPattern : PatternBase<UIA.IUIAutomationTextPattern>, ITextPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TextPatternId, "Text");
        public static readonly EventId TextChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Text_TextChangedEventId, "TextChanged");
        public static readonly EventId TextSelectionChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Text_TextSelectionChangedEventId, "TextSelectionChanged");

        public TextPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTextPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Events = new TextPatternEvents();
        }

        public ITextPatternEvents Events { get; }

        public ITextRange DocumentRange
        {
            get
            {
                var nativeRange = ComCallWrapper.Call(() => NativePattern.DocumentRange);
                return ValueConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeRange);
            }
        }

        public SupportedTextSelection SupportedTextSelection
        {
            get
            {
                var nativeObject = ComCallWrapper.Call(() => NativePattern.SupportedTextSelection);
                return (SupportedTextSelection)nativeObject;
            }
        }

        public ITextRange[] GetSelection()
        {
            var nativeRanges = ComCallWrapper.Call(() => NativePattern.GetSelection());
            return ValueConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeRanges);
        }

        public ITextRange[] GetVisibleRanges()
        {
            var nativeRanges = ComCallWrapper.Call(() => NativePattern.GetVisibleRanges());
            return ValueConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeRanges);
        }

        public ITextRange RangeFromChild(AutomationElement child)
        {
            var nativeChild = ValueConverter.ToNative(child);
            var nativeRange = ComCallWrapper.Call(() => NativePattern.RangeFromChild(nativeChild));
            return ValueConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeRange);
        }

        public ITextRange RangeFromPoint(Point point)
        {
            var nativeRange = ComCallWrapper.Call(() => NativePattern.RangeFromPoint(point.ToTagPoint()));
            return ValueConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeRange);
        }
    }

    public class TextPatternEvents : ITextPatternEvents
    {
        public EventId TextChangedEvent => TextPattern.TextChangedEvent;
        public EventId TextSelectionChangedEvent => TextPattern.TextSelectionChangedEvent;
    }
}
