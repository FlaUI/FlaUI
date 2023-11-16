using System;

namespace FlaUI.WebDriver
{
    public class WebDriverResponseException : Exception
    {
        private WebDriverResponseException(string message, string errorCode, int statusCode) : base(message)
        {
            ErrorCode = errorCode;
            StatusCode = statusCode;
        }

        public int StatusCode { get; set; } = 500;
        public string ErrorCode { get; set; } = "unknown error";

        public static WebDriverResponseException UnknownError(string message) => new WebDriverResponseException(message, "unknown error", 500);

        public static WebDriverResponseException UnsupportedOperation(string message) => new WebDriverResponseException(message, "unsupported operation", 500);

        public static WebDriverResponseException InvalidArgument(string message) => new WebDriverResponseException(message, "invalid argument", 400);

        public static WebDriverResponseException SessionNotFound(string sessionId) => new WebDriverResponseException($"No active session with ID {sessionId}", "invalid session id", 404);

        public static WebDriverResponseException ElementNotFound(string elementId) => new WebDriverResponseException($"No element found with ID {elementId}", "no such element", 404);
    }
}
