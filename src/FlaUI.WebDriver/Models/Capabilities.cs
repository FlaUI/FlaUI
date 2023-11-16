using System.Collections.Generic;

namespace FlaUI.WebDriver.Models
{
    public class Capabilities
    {
        public Dictionary<string, string>? AlwaysMatch { get; set; }
        public List<Dictionary<string, string>>? FirstMatch { get; set; }
    }
}
