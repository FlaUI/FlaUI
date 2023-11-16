using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FlaUI.WebDriver.Models
{
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public string ErrorCode { get; set; } = "unknown error";
        public string Message { get; set; } = "";
        public string StackTrace { get; set; } = "";
    }
}