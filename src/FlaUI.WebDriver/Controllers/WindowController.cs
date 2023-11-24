using FlaUI.Core.AutomationElements;
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

            // When closing the last window of the application, the `GetAllTopLevelWindows` function times out with an exception
            // Therefore retrieve windows before closing the current one
            // https://github.com/FlaUI/FlaUI/issues/596
            var windowHandlesBeforeClose = GetWindowHandles(session).ToArray();

            var currentWindow = session.CurrentWindow;
            session.RemoveKnownWindow(currentWindow);
            currentWindow.Close();

            var remainingWindowHandles = windowHandlesBeforeClose.Except(new[] { session.CurrentWindowHandle } );
            if (!remainingWindowHandles.Any())
            {
                _sessionRepository.Delete(session);
                session.Dispose();
                _logger.LogInformation("Closed last window of session and therefore deleted session with ID {SessionId}", sessionId);
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

            if(session.FindKnownWindowByWindowHandle(session.CurrentWindowHandle) == null)
            {
                throw WebDriverResponseException.WindowNotFoundByHandle(session.CurrentWindowHandle);
            }

            return await Task.FromResult(WebDriverResult.Success(session.CurrentWindowHandle));
        }

        [HttpPost]
        public async Task<ActionResult> SwitchToWindow([FromRoute] string sessionId, [FromBody] SwitchWindowRequest switchWindowRequest)
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
            window.SetForeground();

            _logger.LogInformation("Switched to window with title {WindowTitle} (handle {WindowHandle}) (session {SessionId})", window.Title, switchWindowRequest.Handle, session.SessionId);
            return await Task.FromResult(WebDriverResult.Success());
        }

        [HttpGet("rect")]
        public async Task<ActionResult> GetWindowRect([FromRoute] string sessionId)
        {
            var session = GetSession(sessionId);
            return await Task.FromResult(WebDriverResult.Success(GetWindowRect(session.CurrentWindow)));
        }

        [HttpPost("rect")]
        public async Task<ActionResult> SetWindowRect([FromRoute] string sessionId, [FromBody] WindowRect windowRect)
        {
            var session = GetSession(sessionId);

            if(!session.CurrentWindow.Patterns.Transform.IsSupported)
            {
                throw WebDriverResponseException.UnsupportedOperation("Cannot transform the current window");
            }

            if (windowRect.Width != null && windowRect.Height != null)
            {
                if (!session.CurrentWindow.Patterns.Transform.Pattern.CanResize)
                {
                    throw WebDriverResponseException.UnsupportedOperation("Cannot resize the current window");
                }
                session.CurrentWindow.Patterns.Transform.Pattern.Resize(windowRect.Width.Value, windowRect.Height.Value);
            }

            if (windowRect.X != null && windowRect.Y != null)
            {
                if (!session.CurrentWindow.Patterns.Transform.Pattern.CanMove)
                {
                    throw WebDriverResponseException.UnsupportedOperation("Cannot move the current window");
                }
                session.CurrentWindow.Move(windowRect.X.Value, windowRect.Y.Value);
            }

            return await Task.FromResult(WebDriverResult.Success(GetWindowRect(session.CurrentWindow)));
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
            var mainWindow = session.App.GetMainWindow(session.Automation, TimeSpan.Zero);
            if (mainWindow == null)
            {
                return Enumerable.Empty<string>();
            }

            // GetAllTopLevelWindows sometimes times out, so we return only the main window and modal windows
            // https://github.com/FlaUI/FlaUI/issues/596
            var knownWindows = mainWindow.ModalWindows.Prepend(mainWindow)
                .Select(session.GetOrAddKnownWindow);
            return knownWindows.Select(knownWindows => knownWindows.WindowHandle);
        }

        private WindowRect GetWindowRect(Window window)
        {
            var boundingRectangle = window.BoundingRectangle;
            return new WindowRect
            {
                X = boundingRectangle.X, 
                Y = boundingRectangle.Y,
                Width = boundingRectangle.Width,
                Height = boundingRectangle.Height
            };
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
