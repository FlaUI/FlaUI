using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class TextPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_TextPatternId, "Text");
        public static readonly EventId TextChangedEvent = EventId.Register(UIA.UIA_EventIds.UIA_Text_TextChangedEventId, "TextChanged");
        public static readonly EventId TextSelectionChangedEvent = EventId.Register(UIA.UIA_EventIds.UIA_Text_TextSelectionChangedEventId, "TextSelectionChanged");

        internal TextPattern(AutomationElement automationElement, UIA.IUIAutomationTextPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public UIA.IUIAutomationTextPattern NativePattern
        {
            get { return (UIA.IUIAutomationTextPattern)base.NativePattern; }
        }

        public TextRange DocumentRange
        {
            get
            {
                var nativeRange = ComCallWrapper.Call(() => NativePattern.DocumentRange);
                return NativeValueConverter.NativeToManaged(Automation, nativeRange);
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
