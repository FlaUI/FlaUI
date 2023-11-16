using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlaUI.WebDriver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        private readonly ISessionRepository _sessionRepository;

        public SessionController(ILogger<SessionController> logger, ISessionRepository sessionRepository)
        {
            _logger = logger;
            _sessionRepository = sessionRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewSession([FromBody] CreateSessionRequest request)
        {
            var possibleCapabilities = GetPossibleCapabilities(request);
            var matchingCapabilities = possibleCapabilities.Where(
                capabilities => capabilities.TryGetValue("platformName", out var platformName) && platformName.ToLowerInvariant() == "windows"
            );

            Core.Application? app;
            var capabilities = matchingCapabilities.FirstOrDefault();
            if (capabilities == null)
            {
                return WebDriverResult.Error(new ErrorResponse
                {
                    ErrorCode = "session not created",
                    Message = "Required capabilities did not match"
                });
            }
            if (capabilities.TryGetValue("appium:app", out var appPath))
            {
                if (appPath == "Root")
                {
                    app = null;
                }
                else
                {
                    capabilities.TryGetValue("appium:appArguments", out var appArguments);
                    app = Core.Application.Launch(appPath, appArguments);
                }
            }
            else if(capabilities.TryGetValue("appium:appTopLevelWindow", out var appTopLevelWindowString))
            {
                var appTopLevelWindow = Convert.ToInt32(appTopLevelWindowString, 16);
                var process = Process.GetProcesses().SingleOrDefault(process => process.MainWindowHandle.ToInt32() == appTopLevelWindow);
                if (process == null)
                {
                    throw WebDriverResponseException.InvalidArgument($"Process with main window handle {appTopLevelWindow} could not be found");
                }
                app = Core.Application.Attach(process);
            }
            else
            {
                throw WebDriverResponseException.InvalidArgument("Either appium:app or appium:appTopLevelWindow should be passed as a capability");
            }
            var session = new Session(app);
            _sessionRepository.Add(session);
            return await Task.FromResult(WebDriverResult.Success(new CreateSessionResponse()
            {
                SessionId = session.SessionId,
                Capabilities = capabilities
            }));
        }

        private static IEnumerable<Dictionary<string, string>> GetPossibleCapabilities(CreateSessionRequest request)
        {
            var requiredCapabilities = request.Capabilities.AlwaysMatch ?? new Dictionary<string, string>();
            var allFirstMatchCapabilities = request.Capabilities.FirstMatch ?? new List<Dictionary<string, string>>(new[] { new Dictionary<string, string>() });
            return allFirstMatchCapabilities.Select(firstMatchCapabilities => MergeCapabilities(firstMatchCapabilities, requiredCapabilities));
        }

        private static Dictionary<string, string> MergeCapabilities(Dictionary<string, string> firstMatchCapabilities, Dictionary<string, string> requiredCapabilities)
        {
            var duplicateKeys = firstMatchCapabilities.Keys.Intersect(requiredCapabilities.Keys);
            if (duplicateKeys.Any())
            {
                throw WebDriverResponseException.InvalidArgument($"Capabilities cannot be merged because there are duplicate capabilities: {string.Join(", ", duplicateKeys)}");
            }

            return firstMatchCapabilities.Concat(requiredCapabilities)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        [HttpDelete("{sessionId}")]
        public async Task<ActionResult> DeleteSession([FromRoute] string sessionId)
        {
            var session = GetSession(sessionId);
            if (session.App != null && !session.App.HasExited)
            {
                session.App.GetMainWindow(session.Automation, TimeSpan.Zero)?.Close();
            }
            _sessionRepository.Delete(session);
            session.Automation.Dispose();
            session.App?.Dispose();
            return await Task.FromResult(WebDriverResult.Success());
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