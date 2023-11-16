using FlaUI.Core.AutomationElements;
using System;

namespace FlaUI.WebDriver
{
    public class KnownElement
    {
        public KnownElement(AutomationElement element)
        {
            Element = element;
            ElementReference = Guid.NewGuid().ToString();
        }

        public string ElementReference { get; set; }
        public AutomationElement Element { get; }
    }
}
