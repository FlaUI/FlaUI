using FlaUI.Core.Definitions;
using System.Collections.Generic;
using FlaUI.UIA3.Definitions;

namespace FlaUInspect.Models
{
    public class Element
    {
        public Element()
        {
            Children = new List<Element>();
        }

        public string Name { get; set; }
        public string AutomationId { get; set; }
        public ControlType ControlType { get; set; }
        public List<Element> Children { get; set; }
    }
}
