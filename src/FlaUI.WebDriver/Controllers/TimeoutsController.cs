using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FlaUI.WebDriver.Controllers
{
    [ApiController]
    [Route("session/{sessionId}/[controller]")]
    public class TimeoutsController : ControllerBase
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly ILogger<TimeoutsController> _logger;

        public TimeoutsController(ISessionRepository sessionRepository, ILogger<TimeoutsController> logger) 
        {
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetTimeouts([FromRoute] string sessionId)
        {
            var session = GetSession(sessionId);
            return await Task.FromResult(WebDriverResult.Success(session.TimeoutsConfiguration));
        }

        [HttpPost]
        public async Task<ActionResult> SetTimeouts([FromRoute] string sessionId, [FromBody] TimeoutsConfiguration timeoutsConfiguration)
        {
            var session = GetSession(sessionId);
            _logger.LogInformation("Setting timeouts to {Timeouts} (session {SessionId})", timeoutsConfiguration, session.SessionId);

            session.TimeoutsConfiguration = timeoutsConfiguration;

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
