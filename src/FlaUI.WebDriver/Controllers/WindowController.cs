using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlaUI.WebDriver.Controllers
{
    [Route("session/{sessionId}/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly ILogger<WindowController> _logger;
        private readonly ISessionRepository _sessionRepository;

        public WindowController(ILogger<WindowController> logger, ISessionRepository sessionRepository)
        {
            _logger = logger;
            _sessionRepository = sessionRepository;
        }

        [HttpDelete]
        public async Task<ActionResult> CloseWindow([FromRoute] string sessionId)
        {
            var session = GetSession(sessionId);
            if (session.App == null || session.App.HasExited)
            {
                throw WebDriverResponseException.NoWindowsOpenForSession();
            }

            var currentWindow = session.CurrentWindow;
            session.RemoveKnownWindow(currentWindow);
            currentWindow.Close();

            // When closing the last window of the application, the `GetAllTopLevelWindows` function times out with an exception
            // Therefore wait for some time
            await Wait.Until(() => session.App.HasExited, TimeSpan.FromMilliseconds(2000));

            var remainingWindowHandles = GetWindowHandles(session).ToArray();
            if (!remainingWindowHandles.Any())
            {
                _sessionRepository.Delete(session);
                session.Dispose();
                _logger.LogInformation("Closed last window of session and therefore deleted session with ID {SessionId}", sessionId);
            }
            else
            {
                var mainWindow = session.App.GetMainWindow(session.Automation);
                session.CurrentWindow = mainWindow;
                _logger.LogInformation("Switching back to window with title {WindowTitle} (handle {WindowHandle})", mainWindow.Title, session.CurrentWindowHandle);
            }
            return await Task.FromResult(WebDriverResult.Success(remainingWindowHandles));
        }

        [HttpGet("handles")]
        public async Task<ActionResult> GetWindowHandles([FromRoute] string sessionId)
        {
            var session = GetSession(sessionId);
            var windowHandles = GetWindowHandles(session);
            return await Task.FromResult(WebDriverResult.Success(windowHandles));
        }

        [HttpGet]
        public async Task<ActionResult> GetWindowHandle([FromRoute] string sessionId)
        {
            var session = GetSession(sessionId);
            return await Task.FromResult(WebDriverResult.Success(session.CurrentWindowHandle));
        }

        [HttpPost]
        public async Task<ActionResult> SwitchWindow([FromRoute] string sessionId, [FromBody] SwitchWindowRequest switchWindowRequest)
        {
            var session = GetSession(sessionId);
            if (session.App == null)
            {
                throw WebDriverResponseException.UnsupportedOperation("Close window not supported for Root app");
            }
            var window = session.FindKnownWindowByWindowHandle(switchWindowRequest.Handle);
            if (window == null)
            {
                throw WebDriverResponseException.WindowNotFoundByHandle(switchWindowRequest.Handle);
            }
            session.CurrentWindow = window;
            _logger.LogInformation("Session {SessionId}: Switched to window with title {WindowTitle} (handle {WindowHandle})", sessionId, window.Title, switchWindowRequest.Handle);
            return await Task.FromResult(WebDriverResult.Success());
        }

        private IEnumerable<string> GetWindowHandles(Session session)
        {
            if (session.App == null)
            {
                throw WebDriverResponseException.UnsupportedOperation("Window operations not supported for Root app");
            }
            if (session.App.HasExited)
            {
                return Enumerable.Empty<string>();
            }
            if (session.App.GetMainWindow(session.Automation, TimeSpan.Zero) == null)
            {
                return Enumerable.Empty<string>();
            }
            var knownWindows = session.App.GetAllTopLevelWindows(session.Automation)
                .SelectMany(topLevelWindow => topLevelWindow.ModalWindows.Prepend(topLevelWindow))
                .Select(session.GetOrAddKnownWindow);
            return knownWindows.Select(knownWindows => knownWindows.WindowHandle);
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
