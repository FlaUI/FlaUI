using FlaUI.Core.Drawing;
using interop.UIAutomationCore;
using System;
using System.Drawing;

namespace FlaUI.Core.Elements
{
    public abstract class ElementBase
    {
        public IUIAutomationElement NativeElement { get; private set; }

        public IUIAutomationElement NativeElement2
        {
            get
            {
                var element2 = NativeElement as IUIAutomationElement2;
                if (element2 == null)
                {
                    throw new NotImplementedException("OS does not have IUIAutomationElement2 support.");
                }
                return element2;
            }
        }

        public IUIAutomationElement NativeElement3
        {
            get
            {
                var element3 = NativeElement as IUIAutomationElement3;
                if (element3 == null)
                {
                    throw new NotImplementedException("OS does not have IUIAutomationElement3 support.");
                }
                return element3;
            }
        }

        public Rectangle BoundingRectangle
        {
            get
            {
                var top = NativeElement.CurrentBoundingRectangle.top;
                var left = NativeElement.CurrentBoundingRectangle.left;
                var bottom = NativeElement.CurrentBoundingRectangle.bottom;
                var right = NativeElement.CurrentBoundingRectangle.right;
                return new Rectangle(left, top, right - left, bottom - top);
            }
        }

        protected ElementBase(IUIAutomationElement nativeElement)
        {
            NativeElement = nativeElement;
        }

        public ElementBase DrawHighlight()
        {
            return DrawHighlight(Color.Red);
        }

        public ElementBase DrawHighlight(Color color)
        {
            var rectangle = BoundingRectangle;
            if (rectangle != Rectangle.Empty)
            {
                new FrameRectangle(color, rectangle).Highlight();
            }
            return this;
        }
    }
}
