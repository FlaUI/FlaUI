using System.Collections.Generic;

namespace FlaUI.WebDriver.Models
{
    public class ActionsRequest
    {
        public List<ActionSequence> Actions { get; set; } = new List<ActionSequence>();
    }
}
