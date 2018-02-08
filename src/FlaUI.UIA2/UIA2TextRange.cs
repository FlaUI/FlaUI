using System;
using System.Linq;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.UIA2.Converters;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public class UIA2TextRange : ITextRange
    {
        public UIA2Automation Automation { get; }

        public UIA.Text.TextPatternRange NativeRange { get; }

        public UIA2TextRange(UIA2Automation automation, UIA.Text.TextPatternRange nativeRange)
        {
            Automation = automation;
            NativeRange = nativeRange;
        }

        public void AddToSelection()
        {
            NativeRange.AddToSelection();
        }

        public ITextRange Clone()
        {
            var clonedTextRangeNative = NativeRange.Clone();
            return TextRangeConverter.NativeToManaged(Automation, clonedTextRangeNative);
        }

        public bool Compare(ITextRange range)
        {
            var nativeRange = ToNativeRange(range);
            return NativeRange.Compare(nativeRange);
        }

        public int CompareEndpoints(TextPatternRangeEndpoint srcEndPoint, ITextRange targetRange, TextPatternRangeEndpoint targetEndPoint)
        {
            var nativeRange = ToNativeRange(targetRange);
            return NativeRange.CompareEndpoints((UIA.Text.TextPatternRangeEndpoint)srcEndPoint, nativeRange, (UIA.Text.TextPatternRangeEndpoint)targetEndPoint);
        }

        public void ExpandToEnclosingUnit(TextUnit textUnit)
        {
            NativeRange.ExpandToEnclosingUnit((UIA.Text.TextUnit)textUnit);
        }

        public ITextRange FindAttribute(TextAttributeId attribute, object value, bool backward)
        {
            var nativeValue = ValueConverter.ToNative(value);
            var nativeAttribute = UIA.AutomationTextAttribute.LookupById(attribute.Id);
            var nativeTextRange = NativeRange.FindAttribute(nativeAttribute, nativeValue, backward);
            return TextRangeConverter.NativeToManaged(Automation, nativeTextRange);
        }

        public ITextRange FindText(string text, bool backward, bool ignoreCase)
        {
            var nativeTextRange = NativeRange.FindText(text, backward, ignoreCase);
            return TextRangeConverter.NativeToManaged(Automation, nativeTextRange);
        }

        public object GetAttributeValue(TextAttributeId attribute)
        {
            var nativeAttribute = UIA.AutomationTextAttribute.LookupById(attribute.Id);
            var nativeValue = NativeRange.GetAttributeValue(nativeAttribute);
            return attribute.Convert<object>(Automation, nativeValue);
        }

        public Rectangle[] GetBoundingRectangles()
        {
            var unrolledRects = NativeRange.GetBoundingRectangles();
            return unrolledRects?.Select(r => (Rectangle)ValueConverter.ToRectangle(r)).ToArray();
        }

        public AutomationElement[] GetChildren()
        {
            var nativeChildren = NativeRange.GetChildren();
            return AutomationElementConverter.NativeArrayToManaged(Automation, nativeChildren);
        }

        public AutomationElement GetEnclosingElement()
        {
            var nativeElement = NativeRange.GetEnclosingElement();
            return AutomationElementConverter.NativeToManaged(Automation, nativeElement);
        }

        public string GetText(int maxLength)
        {
            return NativeRange.GetText(maxLength);
        }

        public int Move(TextUnit unit, int count)
        {
            return NativeRange.Move((UIA.Text.TextUnit)unit, count);
        }

        public void MoveEndpointByRange(TextPatternRangeEndpoint srcEndPoint, ITextRange targetRange, TextPatternRangeEndpoint targetEndPoint)
        {
            var nativeRange = ToNativeRange(targetRange);
            NativeRange.MoveEndpointByRange((UIA.Text.TextPatternRangeEndpoint)srcEndPoint, nativeRange, (UIA.Text.TextPatternRangeEndpoint)targetEndPoint);
        }

        public int MoveEndpointByUnit(TextPatternRangeEndpoint endpoint, TextUnit unit, int count)
        {
            return NativeRange.MoveEndpointByUnit((UIA.Text.TextPatternRangeEndpoint)endpoint, (UIA.Text.TextUnit)unit, count);
        }

        public void RemoveFromSelection()
        {
            NativeRange.RemoveFromSelection();
        }

        public void ScrollIntoView(bool alignToTop)
        {
            NativeRange.ScrollIntoView(alignToTop);
        }

        public void Select()
        {
            NativeRange.Select();
        }

        protected UIA.Text.TextPatternRange ToNativeRange(ITextRange range)
        {
            var concreteTextRange = range as UIA2TextRange;
            if (concreteTextRange == null)
            {
                throw new Exception("TextRange is no UIA2 TextRange");
            }
            return concreteTextRange.NativeRange;
        }
    }
}
