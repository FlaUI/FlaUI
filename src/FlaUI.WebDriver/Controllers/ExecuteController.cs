using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace FlaUI.WebDriver.Controllers
{
    [Route("session/{sessionId}/[controller]")]
    [ApiController]
    public class ExecuteController : ControllerBase
    {
        private readonly ILogger<ExecuteController> _logger;
        private readonly ISessionRepository _sessionRepository;

        public ExecuteController(ISessionRepository sessionRepository, ILogger<ExecuteController> logger)
        {
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        [HttpPost("sync")]
        public async Task<ActionResult> ExecuteScript([FromRoute] string sessionId, [FromBody] ExecuteScriptRequest executeScriptRequest)
        {
            var session = GetSession(sessionId);
            switch (executeScriptRequest.Script)
            {
                case "powerShell":
                    return await ExecutePowerShellScript(session, executeScriptRequest);
                default:
                    throw WebDriverResponseException.UnsupportedOperation("Only 'powerShell' scripts are supported");
            }
        }
        private async Task<ActionResult> ExecutePowerShellScript(Session session, ExecuteScriptRequest executeScriptRequest)
        {
            if (executeScriptRequest.Args.Count != 1)
            {
                throw WebDriverResponseException.InvalidArgument($"Expected an array of exactly 1 arguments for the PowerShell script, but got {executeScriptRequest.Args.Count} arguments");
            }
            var powerShellArgs = executeScriptRequest.Args[0];
            if (!powerShellArgs.TryGetValue("command", out var powerShellCommand))
            {
                throw WebDriverResponseException.InvalidArgument("Expected a \"command\" property of the first argument for the PowerShell script");
            }

            _logger.LogInformation("Executing PowerShell command {Command} (session {SessionId})", powerShellCommand, session.SessionId);

            var processStartInfo = new ProcessStartInfo("powershell.exe", $"-Command \"{powerShellCommand.Replace("\"", "\\\"")}\"")
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };
            using var process = Process.Start(processStartInfo);
            using var cancellationTokenSource = new CancellationTokenSource();
            if (session.ScriptTimeout.HasValue)
            {
                cancellationTokenSource.CancelAfter(session.ScriptTimeout.Value);
            }
            await process!.WaitForExitAsync(cancellationTokenSource.Token);
            if (process.ExitCode != 0)
            {
                var error = await process.StandardError.ReadToEndAsync();
                return WebDriverResult.BadRequest(new ErrorResponse()
                {
                    ErrorCode = "script error",
                    Message = $"Script failed with exit code {process.ExitCode}: {error}"
                });
            }
            var result = await process.StandardOutput.ReadToEndAsync();
            return WebDriverResult.Success(result);
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
