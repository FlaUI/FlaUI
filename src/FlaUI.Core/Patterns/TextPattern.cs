using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class TextPattern : PatternBase<IUIAutomationTextPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_TextPatternId, "Text");
        public static readonly EventId TextChangedEvent = EventId.Register(UIA_EventIds.UIA_Text_TextChangedEventId, "TextChanged");
        public static readonly EventId TextSelectionChangedEvent = EventId.Register(UIA_EventIds.UIA_Text_TextSelectionChangedEventId, "TextSelectionChanged");

        internal TextPattern(AutomationElement automationElement, IUIAutomationTextPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public TextRange DocumentRange
        {
            get
            {
                var nativeRange = ComCallWrapper.Call(() => NativePattern.DocumentRange);
                return NativeValueConverter.NativeToManaged(Automation, nativeRange);
            }
        }

        public Definitions.SupportedTextSelection SupportedTextSelection
        {
            get
            {
                var nativeObject = ComCallWrapper.Call(() => NativePattern.SupportedTextSelection);
                return (Definitions.SupportedTextSelection)nativeObject;
            }
        }

        public TextRange[] GetSelection()
        {
            var nativeRanges = ComCallWrapper.Call(() => NativePattern.GetSelection());
            return NativeValueConverter.NativeArrayToManaged(Automation, nativeRanges);
        }

        public TextRange[] GetVisibleRanges()
        {
            var nativeRanges = ComCallWrapper.Call(() => NativePattern.GetVisibleRanges());
            return NativeValueConverter.NativeArrayToManaged(Automation, nativeRanges);
        }

        public TextRange RangeFromChild(AutomationElement child)
        {
            var nativeRange = ComCallWrapper.Call(() => NativePattern.RangeFromChild(child.NativeElement));
            return NativeValueConverter.NativeToManaged(Automation, nativeRange);
        }

        public TextRange RangeFromPoint(Point point)
        {
            var nativeRange = ComCallWrapper.Call(() => NativePattern.RangeFromPoint(point));
            return NativeValueConverter.NativeToManaged(Automation, nativeRange);
        }
    }
}
