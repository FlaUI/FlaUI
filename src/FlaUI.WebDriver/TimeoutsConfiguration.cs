using System.Text.Json.Serialization;

namespace FlaUI.WebDriver
{
    public class TimeoutsConfiguration
    {
        [JsonPropertyName("script")]
        public int? ScriptTimeoutMs { get; set; } = 30000;
        [JsonPropertyName("pageLoad")]
        public int PageLoadTimeoutMs { get; set; } = 300000;
        [JsonPropertyName("implicit")]
        public int ImplicitWaitTimeoutMs { get; set; } = 0;
    }
}
