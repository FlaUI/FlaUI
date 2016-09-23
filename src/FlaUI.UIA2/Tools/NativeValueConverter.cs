using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Shapes;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Tools
{
    public static class NativeValueConverter
    {
        public static Element[] NativeArrayToManaged(UIA2Automation automation, UIA.AutomationElementCollection nativeElements)
        {
            if (nativeElements == null) { return new Element[0]; }
            var retArray = new Element[nativeElements.Count];
            for (var i = 0; i < nativeElements.Count; i++)
            {
                var nativeElement = nativeElements[i];
                var automationObject = automation.WrapNativeElement(nativeElement);
                retArray[i] = new Element(automationObject);
            }
            return retArray;
        }

        public static Element NativeToManaged(UIA2Automation automation, UIA.AutomationElement nativeElement)
        {
            var automationObject = automation.WrapNativeElement(nativeElement);
            return nativeElement == null ? null : new Element(automationObject);
        }

        public static object ToPoint(object point)
        {
            var origValue = (System.Windows.Point)point;
            if (point == null) { return null; }
            return new Point(origValue.X, origValue.Y);
        }
    }
}
