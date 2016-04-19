using interop.UIAutomationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaUI.Core.Elements
{
    public class Window : ElementBase
    {
        public string Title
        {
            get
            {
                return NativeElement.CurrentName;
            }
        }

        public Window(IUIAutomationElement nativeElement) : base(nativeElement) { }
    }
}
