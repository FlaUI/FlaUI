using FlaUI.Core.Definitions;
using System.Collections.Generic;

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
