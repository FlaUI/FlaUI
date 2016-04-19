using interop.UIAutomationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaUI.Core.Elements
{
    public abstract class ElementBase
    {
        public IUIAutomationElement NativeElement { get; private set; }

        protected ElementBase(IUIAutomationElement nativeElement)
        {
            NativeElement = nativeElement;
        }
    }
}
