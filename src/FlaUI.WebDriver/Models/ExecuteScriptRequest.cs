using System.Collections.Generic;

namespace FlaUI.WebDriver.Models
{
    public class ExecuteScriptRequest
    {
        public string Script { get; set; } = null!;
        public List<Dictionary<string, string>> Args { get; set; } = new List<Dictionary<string, string>>();
    }
}
