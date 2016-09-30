using FlaUI.Core.Elements.Infrastructure;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class TreeWalker
    {
        public UIA3Automation Automation { get; private set; }
        public UIA.IUIAutomationTreeWalker NativeTreeWalker { get; private set; }

        public TreeWalker(UIA3Automation automation)
        {
            Automation = automation;
            NativeTreeWalker = automation.NativeAutomation.ControlViewWalker;
        }

        //public Element GetParent(Element element)
        //{
        //    var parent = NativeTreeWalker.GetParentElement(element.NativeElement);
        //    return parent == null ? null : new Element(Automation, parent);
        //}

        //public Element GetFirstChild(Element element)
        //{
        //    var child = NativeTreeWalker.GetFirstChildElement(element.NativeElement);
        //    return child == null ? null : new Element(Automation, child);
        //}

        //public Element GetLastChild(Element element)
        //{
        //    var child = NativeTreeWalker.GetLastChildElement(element.NativeElement);
        //    return child == null ? null : new Element(Automation, child);
        //}

        //public Element GetNextSibling(Element element)
        //{
        //    var child = NativeTreeWalker.GetNextSiblingElement(element.NativeElement);
        //    return child == null ? null : new Element(Automation, child);
        //}

        //public Element GetPreviousSibling(Element element)
        //{
        //    var child = NativeTreeWalker.GetPreviousSiblingElement(element.NativeElement);
        //    return child == null ? null : new Element(Automation, child);
        //}
    }
}
