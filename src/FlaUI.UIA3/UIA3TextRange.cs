using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3TextRange : ITextRange
    {
        public UIA3Automation Automation { get; }

        public UIA.IUIAutomationTextRange NativeRange { get; }

        internal UIA3TextRange(UIA3Automation automation, UIA.IUIAutomationTextRange nativeRange)
        {
            Automation = automation;
            NativeRange = nativeRange;
        }

        public void AddToSelection()
        {
            ComCallWrapper.Call(() => NativeRange.AddToSelection());
        }

        public ITextRange Clone()
        {
            var clonedTextRangeNative = ComCallWrapper.Call(() => NativeRange.Clone());
            return TextRangeConverter.NativeToManaged(Automation, clonedTextRangeNative);
        }

        public bool Compare(ITextRange range)
        {
            var nativeRange = ToNativeRange(range);
            return ComCallWrapper.Call(() => NativeRange.Compare(nativeRange)) != 0;
        }

        public int CompareEndpoints(TextPatternRangeEndpoint srcEndPoint, ITextRange targetRange, TextPatternRangeEndpoint targetEndPoint)
        {
            var nativeRange = ToNativeRange(targetRange);
            return ComCallWrapper.Call(() => NativeRange.CompareEndpoints((UIA.TextPatternRangeEndpoint)srcEndPoint, nativeRange, (UIA.TextPatternRangeEndpoint)targetEndPoint));
        }

        public void ExpandToEnclosingUnit(TextUnit textUnit)
        {
            ComCallWrapper.Call(() => NativeRange.ExpandToEnclosingUnit((UIA.TextUnit)textUnit));
        }

        public ITextRange FindAttribute(TextAttributeId attribute, object value, bool backward)
        {
            var nativeValue = ValueConverter.ToNative(value);
            var nativeTextRange = ComCallWrapper.Call(() => NativeRange.FindAttribute(attribute.Id, nativeValue, backward.ToInt()));
            return TextRangeConverter.NativeToManaged(Automation, nativeTextRange);
        }

        public ITextRange FindText(string text, bool backward, bool ignoreCase)
        {
            var nativeTextRange = ComCallWrapper.Call(() => NativeRange.FindText(text, backward.ToInt(), ignoreCase.ToInt()));
            return TextRangeConverter.NativeToManaged(Automation, nativeTextRange);
        }

        public object GetAttributeValue(TextAttributeId attribute)
        {
            var nativeValue = ComCallWrapper.Call(() => NativeRange.GetAttributeValue(attribute.Id));
            return attribute.Convert<object>(Automation, nativeValue);
        }

        public Rectangle[] GetBoundingRectangles()
        {
            var unrolledRects = ComCallWrapper.Call(() => NativeRange.GetBoundingRectangles());
            if (unrolledRects == null)
            {
                return null;
            }
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
            return AutomationElementConverter.NativeArrayToManaged(Automation, nativeChildren);
        }

        public AutomationElement GetEnclosingElement()
        {
            var nativeElement = ComCallWrapper.Call(() => NativeRange.GetEnclosingElement());
            return AutomationElementConverter.NativeToManaged(Automation, nativeElement);
        }

        public string GetText(int maxLength)
        {
            return ComCallWrapper.Call(() => NativeRange.GetText(maxLength));
        }

        public int Move(TextUnit unit, int count)
        {
            return ComCallWrapper.Call(() => NativeRange.Move((UIA.TextUnit)unit, count));
        }

        public void MoveEndpointByRange(TextPatternRangeEndpoint srcEndPoint, ITextRange targetRange, TextPatternRangeEndpoint targetEndPoint)
        {
            var nativeRange = ToNativeRange(targetRange);
            ComCallWrapper.Call(() => NativeRange.MoveEndpointByRange((UIA.TextPatternRangeEndpoint)srcEndPoint, nativeRange, (UIA.TextPatternRangeEndpoint)targetEndPoint));
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

        public UIA3TextRange2 AsTextRange2()
        {
            var nativeRange2 = (UIA.IUIAutomationTextRange2)NativeRange;
            return TextRangeConverter.NativeToManaged(Automation, nativeRange2);
        }

        protected UIA.IUIAutomationTextRange ToNativeRange(ITextRange range)
        {
            var concreteTextRange = range as UIA3TextRange;
            if (concreteTextRange == null)
            {
                throw new Exception("TextRange is no UIA3 TextRange");
            }
            return concreteTextRange.NativeRange;
        }
    }
}
