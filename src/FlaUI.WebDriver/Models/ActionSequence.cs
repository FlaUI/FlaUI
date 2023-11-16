using System.Collections.Generic;

namespace FlaUI.WebDriver.Models
{
    public class ActionSequence
    {
        public string Id { get; set; } = null!;
        public string Type { get; set; } = null!;
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public List<ActionItem> Actions { get; set; } = new List<ActionItem>();
    }
}
