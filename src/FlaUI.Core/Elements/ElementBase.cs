using interop.UIAutomationCore;
using System;
using System.Windows;
using System.Windows.Media;
using FlaUI.Core.Tools;

namespace FlaUI.Core.Elements
{
    /// <summary>
    /// Basic class for a wrapped ui element
    /// </summary>
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

        public Automation Automation { get; private set; }

        public PatternFactory PatternFactory { get; private set; }

        public Rect BoundingRectangle
        {
            get
            {
                return NativeElement.CurrentBoundingRectangle.ToRect();
            }
        }

        /// <summary>
        /// Constructor for a basic ui element
        /// </summary>
        /// <param name="automation">The automation instance where this element belongs to</param>
        /// <param name="nativeElement">The native element this instance wrapps</param>
        protected ElementBase(Automation automation, IUIAutomationElement nativeElement)
        {
            Automation = automation;
            NativeElement = nativeElement;
            PatternFactory = new PatternFactory(nativeElement);
        }

        public ElementBase DrawHighlight()
        {
            return DrawHighlight(Colors.Red);
        }

        public ElementBase DrawHighlight(Color color)
        {
            var rectangle = BoundingRectangle;
            if (rectangle != Rect.Empty)
            {
                Automation.OverlayManager.ShowBlocking(rectangle, color);
            }
            return this;
        }
    }
}
