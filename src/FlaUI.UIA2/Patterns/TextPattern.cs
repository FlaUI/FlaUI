using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Shapes;
using FlaUI.UIA2.Converters;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class TextPattern : PatternBase<UIA.TextPattern>, ITextPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TextPattern.Pattern.Id, "Text");
        public static readonly EventId TextChangedEvent = EventId.Register(AutomationType.UIA2, UIA.TextPattern.TextChangedEvent.Id, "TextChanged");
        public static readonly EventId TextSelectionChangedEvent = EventId.Register(AutomationType.UIA2, UIA.TextPattern.TextSelectionChangedEvent.Id, "TextSelectionChanged");

        public TextPattern(BasicAutomationElementBase basicAutomationElement, UIA.TextPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Events = new TextPatternEvents();
        }

        public ITextPatternEvents Events { get; }

        public ITextRange DocumentRange
        {
            get
            {
                var nativeRange = NativePattern.DocumentRange;
                return ValueConverter.NativeToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeRange);
            }
        }

        public SupportedTextSelection SupportedTextSelection
        {
            get
            {
                var nativeObject = NativePattern.SupportedTextSelection;
                return (SupportedTextSelection)nativeObject;
            }
        }

        public ITextRange[] GetSelection()
        {
            var nativeRanges = NativePattern.GetSelection();
            return ValueConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeRanges);
        }

        public ITextRange[] GetVisibleRanges()
        {
            var nativeRanges = NativePattern.GetVisibleRanges();
            return ValueConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeRanges);
        }

        public ITextRange RangeFromChild(AutomationElement child)
        {
            var nativeChild = ValueConverter.ToNative(child);
            var nativeRange = NativePattern.RangeFromChild(nativeChild);
            return ValueConverter.NativeToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeRange);
        }

        public ITextRange RangeFromPoint(Point point)
        {
            var nativeRange = NativePattern.RangeFromPoint(ValueConverter.ToNative(point));
            return ValueConverter.NativeToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeRange);
        }
    }

    public class TextPatternEvents : ITextPatternEvents
    {
        public EventId TextChangedEvent => TextPattern.TextChangedEvent;
        public EventId TextSelectionChangedEvent => TextPattern.TextSelectionChangedEvent;
    }
}
