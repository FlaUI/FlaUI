using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class ComboBox : AutomationElement
    {
        public ComboBox(Automation automation, IUIAutomationElement nativeElement)
            : base(automation, nativeElement)
        {
        }

        public AutomationElement EditElement { get; set; }
    }
}
