using System.Text.Json.Serialization;

namespace FlaUI.WebDriver.Models
{
    public class FindElementResponse
    {
        /// <summary>
        /// See https://www.w3.org/TR/webdriver2/#dfn-web-element-identifier
        /// </summary>
        [JsonPropertyName("element-6066-11e4-a52e-4f735466cecf")]
        public string ElementReference { get; set; } = null!;
    }
}
