using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlaUI.WebDriver.Controllers
{
    [ApiController]
    [Route("session/{sessionId}/[controller]")]
    public class TimeoutsController : ControllerBase
    {
        private readonly ISessionRepository _sessionRepository;

        public TimeoutsController(ISessionRepository sessionRepository) 
        {
            _sessionRepository = sessionRepository;
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
