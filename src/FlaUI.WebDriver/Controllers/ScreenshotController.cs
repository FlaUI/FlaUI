using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using System;
using FlaUI.Core.AutomationElements;
using System.Drawing;

namespace FlaUI.WebDriver.Controllers
{
    [Route("session/{sessionId}")]
    [ApiController]
    public class ScreenshotController : ControllerBase
    {
        private readonly ILogger<ScreenshotController> _logger;
        private readonly ISessionRepository _sessionRepository;

        public ScreenshotController(ILogger<ScreenshotController> logger, ISessionRepository sessionRepository)
        {
            _logger = logger;
            _sessionRepository = sessionRepository;
        }

        [HttpGet("screenshot")]
        public async Task<ActionResult> TakeScreenshot([FromRoute] string sessionId)
        {
            var session = GetActiveSession(sessionId);
            var currentWindow = session.CurrentWindow;
            _logger.LogInformation("Taking screenshot of window with title {WindowTitle}", currentWindow.Title);
            using var bitmap = currentWindow.Capture();
            return await Task.FromResult(WebDriverResult.Success(GetBase64Data(bitmap)));
        }

        [HttpGet("element/{elementId}/screenshot")]
        public async Task<ActionResult> TakeElementScreenshot([FromRoute] string sessionId, [FromRoute] string elementId)
        {
            var session = GetActiveSession(sessionId);
            var element = GetElement(session, elementId);
            _logger.LogInformation("Taking screenshot of element with ID {ElementId}", elementId);
            using var bitmap = element.Capture();
            return await Task.FromResult(WebDriverResult.Success(GetBase64Data(bitmap)));
        }

        private static string GetBase64Data(Bitmap bitmap)
        {
            using var memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        private AutomationElement GetElement(Session session, string elementId)
        {
            var element = session.FindKnownElementById(elementId);
            if (element == null)
            {
                throw WebDriverResponseException.ElementNotFound(elementId);
            }
            return element;
        }

        private Session GetActiveSession(string sessionId)
        {
            var session = GetSession(sessionId);
            if (session.App == null || session.App.HasExited)
            {
                throw WebDriverResponseException.NoWindowsOpenForSession();
            }
            return session;
        }

        private Session GetSession(string sessionId)
        {
            var session = _sessionRepository.FindById(sessionId);
            if (session == null)
            {
                throw WebDriverResponseException.SessionNotFound(sessionId);
            }
            return session;
        }
    }
}
