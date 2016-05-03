using System.Globalization;
using FlaUI.Core.Elements;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core
{
    public class TextRange
    {
        public Automation Automation { get; private set; }

        public IUIAutomationTextRange NativeRange { get; private set; }

        internal TextRange(Automation automation, IUIAutomationTextRange nativeRange)
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
            return new TextRange(Automation, clonedTextRangeNative);
        }

        public int Compare(TextRange range)
        {
            return ComCallWrapper.Call(() => NativeRange.Compare(range.NativeRange));
        }

        public int CompareEndpoints(Definitions.TextPatternRangeEndpoint srcEndPoint, TextRange targetRange, Definitions.TextPatternRangeEndpoint targetEndPoint)
        {
            return ComCallWrapper.Call(() => NativeRange.CompareEndpoints((TextPatternRangeEndpoint)srcEndPoint, targetRange.NativeRange, (TextPatternRangeEndpoint)targetEndPoint));
        }

        public void ExpandToEnclosingUnit(Definitions.TextUnit textUnit)
        {
            ComCallWrapper.Call(() => NativeRange.ExpandToEnclosingUnit((TextUnit)textUnit));
        }

        public TextRange FindAttribute(AutomationTextAttribute attribute, object value, bool backward)
        {
            if (value is CultureInfo)
            {
                value = ((CultureInfo)value).LCID;
            }
            var nativeTextRange = ComCallWrapper.Call(() => NativeRange.FindAttribute(attribute.Id, value, backward.ToInt()));
            return new TextRange(Automation, nativeTextRange);
        }

        public TextRange FindText(string text, bool backward, bool ignoreCase)
        {
            var nativeTextRange = ComCallWrapper.Call(() => NativeRange.FindText(text, backward.ToInt(), ignoreCase.ToInt()));
            return new TextRange(Automation, nativeTextRange);
        }

        public object GetAttributeValue(AutomationTextAttribute attribute)
        {
            var valueAsObject = ComCallWrapper.Call(() => NativeRange.GetAttributeValue(attribute.Id));
            // TODO: Casting?
            return valueAsObject;
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

        public AutomationElement[] GetChildren()
        {
            var nativeChildren = ComCallWrapper.Call(() => NativeRange.GetChildren());
            return NativeValueConverter.NativeElementArrayToElements(Automation, nativeChildren);
        }

        public AutomationElement GetEnclosingElement()
        {
            var nativeElement = ComCallWrapper.Call(() => NativeRange.GetEnclosingElement());
            return NativeValueConverter.NativeElementToElement(Automation, nativeElement);
        }

        public string GetText(int maxLength)
        {
            return ComCallWrapper.Call(() => NativeRange.GetText(maxLength));
        }

        public int Move(Definitions.TextUnit unit, int count)
        {
            return ComCallWrapper.Call(() => NativeRange.Move((TextUnit)unit, count));
        }

        public void MoveEndpointByRange(Definitions.TextPatternRangeEndpoint srcEndPoint, TextRange targetRange, Definitions.TextPatternRangeEndpoint targetEndPoint)
        {
            ComCallWrapper.Call(() => NativeRange.MoveEndpointByRange((TextPatternRangeEndpoint)srcEndPoint, targetRange.NativeRange, (TextPatternRangeEndpoint)targetEndPoint));
        }

        public int MoveEndpointByUnit(Definitions.TextPatternRangeEndpoint endpoint, Definitions.TextUnit unit, int count)
        {
            return ComCallWrapper.Call(() => NativeRange.MoveEndpointByUnit((TextPatternRangeEndpoint)endpoint, (TextUnit)unit, count));
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
    }
}
