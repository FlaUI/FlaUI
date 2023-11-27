using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
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
                    Message = "Required capabilities did not match. Capability `platformName` with value `windows` is required"
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
                    try
                    {
                        var processStartInfo = new ProcessStartInfo(appPath, appArguments ?? "");
                        app = Core.Application.Launch(processStartInfo);
                    }
                    catch(Exception e)
                    {
                        throw WebDriverResponseException.InvalidArgument($"Starting app '{appPath}' with arguments '{appArguments}' threw an exception: {e.Message}");
                    }
                }
            }
            else if(capabilities.TryGetValue("appium:appTopLevelWindow", out var appTopLevelWindowString))
            {
                Process process = GetProcessByMainWindowHandle(appTopLevelWindowString);
                app = Core.Application.Attach(process);
            }
            else if (capabilities.TryGetValue("appium:appTopLevelWindowTitleMatch", out var appTopLevelWindowTitleMatch))
            {
                Process? process = GetProcessByMainWindowTitle(appTopLevelWindowTitleMatch);
                app = Core.Application.Attach(process);
            }
            else
            {
                throw WebDriverResponseException.InvalidArgument("One of appium:app, appium:appTopLevelWindow or appium:appTopLevelWindowTitleMatch must be passed as a capability");
            }
            var session = new Session(app);
            _sessionRepository.Add(session);
            _logger.LogInformation("Created session with ID {SessionId} and capabilities {Capabilities}", session.SessionId, capabilities);
            return await Task.FromResult(WebDriverResult.Success(new CreateSessionResponse()
            {
                SessionId = session.SessionId,
                Capabilities = capabilities
            }));
        }

        private static Process GetProcessByMainWindowTitle(string appTopLevelWindowTitleMatch)
        {
            Regex appMainWindowTitleRegex;
            try
            {
                appMainWindowTitleRegex = new Regex(appTopLevelWindowTitleMatch);
            } 
            catch(ArgumentException e)
            {
                throw WebDriverResponseException.InvalidArgument($"Capability appium:appTopLevelWindowTitleMatch '{appTopLevelWindowTitleMatch}' is not a valid regular expression: {e.Message}");
            }
            var processes = Process.GetProcesses().Where(process => appMainWindowTitleRegex.IsMatch(process.MainWindowTitle)).ToArray();
            if (processes.Length == 0)
            {
                throw WebDriverResponseException.InvalidArgument($"Process with main window title matching '{appTopLevelWindowTitleMatch}' could not be found");
            }
            else if (processes.Length > 1)
            {
                throw WebDriverResponseException.InvalidArgument($"Found multiple ({processes.Length}) processes with main window title matching '{appTopLevelWindowTitleMatch}'");
            }
            return processes[0];
        }

        private static Process GetProcessByMainWindowHandle(string appTopLevelWindowString)
        {
            int appTopLevelWindow;
            try
            {
                appTopLevelWindow = Convert.ToInt32(appTopLevelWindowString, 16);
            }
            catch (Exception)
            {
                throw WebDriverResponseException.InvalidArgument($"Capability appium:appTopLevelWindow '{appTopLevelWindowString}' is not a valid hexadecimal string");
            }
            if (appTopLevelWindow == 0)
            {
                throw WebDriverResponseException.InvalidArgument($"Capability appium:appTopLevelWindow '{appTopLevelWindowString}' should not be zero");
            }
            var process = Process.GetProcesses().SingleOrDefault(process => process.MainWindowHandle.ToInt32() == appTopLevelWindow);
            if (process == null)
            {
                throw WebDriverResponseException.InvalidArgument($"Process with main window handle {appTopLevelWindowString} could not be found");
            }
            return process;
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
            _sessionRepository.Delete(session);
            session.Dispose();
            _logger.LogInformation("Deleted session with ID {SessionId}", sessionId);
            return await Task.FromResult(WebDriverResult.Success());
        }

        [HttpGet("{sessionId}/title")]
        public async Task<ActionResult> GetTitle([FromRoute] string sessionId)
        {
            var session = GetSession(sessionId);
            var title = session.CurrentWindow.Title;
            return await Task.FromResult(WebDriverResult.Success(title));
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