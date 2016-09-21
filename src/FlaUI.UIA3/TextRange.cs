using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class TextRange
    {
        public UIA3Automation Automation { get; private set; }

        public UIA.IUIAutomationTextRange NativeRange { get; private set; }

        internal TextRange(UIA3Automation automation, UIA.IUIAutomationTextRange nativeRange)
        {
            Automation = automation;
            NativeRange = nativeRange;
        }

        public void AddToSelection()
        {
            ComCallWrapper.Call(() => NativeRange.AddToSelection());
        }

        public TextRange Clone()
        {
            var clonedTextRangeNative = ComCallWrapper.Call(() => NativeRange.Clone());
            return NativeValueConverter.NativeToManaged(Automation, clonedTextRangeNative);
        }

        public int Compare(TextRange range)
        {
            return ComCallWrapper.Call(() => NativeRange.Compare(range.NativeRange));
        }

        public int CompareEndpoints(TextPatternRangeEndpoint srcEndPoint, TextRange targetRange, TextPatternRangeEndpoint targetEndPoint)
        {
            return ComCallWrapper.Call(() => NativeRange.CompareEndpoints((UIA.TextPatternRangeEndpoint)srcEndPoint, targetRange.NativeRange, (UIA.TextPatternRangeEndpoint)targetEndPoint));
        }

        public void ExpandToEnclosingUnit(TextUnit textUnit)
        {
            ComCallWrapper.Call(() => NativeRange.ExpandToEnclosingUnit((UIA.TextUnit)textUnit));
        }

        public TextRange FindAttribute(TextAttributeId attribute, object value, bool backward)
        {
            var nativeValue = NativeValueConverter.ToNative(value);
            var nativeTextRange = ComCallWrapper.Call(() => NativeRange.FindAttribute(attribute.Id, nativeValue, backward.ToInt()));
            return NativeValueConverter.NativeToManaged(Automation, nativeTextRange);
        }

        public TextRange FindText(string text, bool backward, bool ignoreCase)
        {
            var nativeTextRange = ComCallWrapper.Call(() => NativeRange.FindText(text, backward.ToInt(), ignoreCase.ToInt()));
            return NativeValueConverter.NativeToManaged(Automation, nativeTextRange);
        }

        public object GetAttributeValue(TextAttributeId attribute)
        {
            var nativeValue = ComCallWrapper.Call(() => NativeRange.GetAttributeValue(attribute.Id));
            return attribute.Convert<object>(nativeValue);
        }

        public Rectangle[] GetBoundingRectangles()
        {
            var unrolledRects = ComCallWrapper.Call(() => NativeRange.GetBoundingRectangles());
            if (unrolledRects == null) { return null; }
            // If unrolledRects is somehow not a multiple of 4, we still will not 
            // overrun it, since (x / 4) * 4 <= x for C# integer math.
            var result = new Rectangle[unrolledRects.Length / 4];
            for (var i = 0; i < result.Length; i++)
            {
                var j = i * 4;
                result[i] = new Rectangle(unrolledRects[j], unrolledRects[j + 1], unrolledRects[j + 2], unrolledRects[j + 3]);
            }
            return result;
        }

        public Element[] GetChildren()
        {
            var nativeChildren = ComCallWrapper.Call(() => NativeRange.GetChildren());
            return NativeValueConverter.NativeArrayToManaged(Automation, nativeChildren);
        }

        public Element GetEnclosingElement()
        {
            var nativeElement = ComCallWrapper.Call(() => NativeRange.GetEnclosingElement());
            return NativeValueConverter.NativeToManaged(Automation, nativeElement);
        }

        public string GetText(int maxLength)
        {
            return ComCallWrapper.Call(() => NativeRange.GetText(maxLength));
        }

        public int Move(TextUnit unit, int count)
        {
            return ComCallWrapper.Call(() => NativeRange.Move((UIA.TextUnit)unit, count));
        }

        public void MoveEndpointByRange(TextPatternRangeEndpoint srcEndPoint, TextRange targetRange, TextPatternRangeEndpoint targetEndPoint)
        {
            ComCallWrapper.Call(() => NativeRange.MoveEndpointByRange((UIA.TextPatternRangeEndpoint)srcEndPoint, targetRange.NativeRange, (UIA.TextPatternRangeEndpoint)targetEndPoint));
        }

        public int MoveEndpointByUnit(TextPatternRangeEndpoint endpoint, TextUnit unit, int count)
        {
            return ComCallWrapper.Call(() => NativeRange.MoveEndpointByUnit((UIA.TextPatternRangeEndpoint)endpoint, (UIA.TextUnit)unit, count));
        }

        public void RemoveFromSelection()
        {
            ComCallWrapper.Call(() => NativeRange.RemoveFromSelection());
        }

        public void ScrollIntoView(bool alignToTop)
        {
            ComCallWrapper.Call(() => NativeRange.ScrollIntoView(alignToTop.ToInt()));
        }

        public void Select()
        {
            ComCallWrapper.Call(() => NativeRange.Select());
        }

        public TextRange2 AsTextRange2()
        {
            var nativeRange2 = (UIA.IUIAutomationTextRange2)NativeRange;
            return NativeValueConverter.NativeToManaged(Automation, nativeRange2);
        }
    }
}
