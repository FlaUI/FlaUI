using interop.UIAutomationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaUI.Core.Elements
{
    public class Button : ElementBase
    {
        public Button(IUIAutomationElement nativeElement) : base(nativeElement) { }
    }
}
