using System.Collections.Generic;

namespace FlaUI.WebDriver.Models
{
    public class CreateSessionResponse
    {
        public string SessionId { get; set; } = null!;
        public Dictionary<string, string> Capabilities { get; set; } = new Dictionary<string, string>();
    }
}
