using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            if (session.App == null)
            {
                throw WebDriverResponseException.UnsupportedOperation("Close window not supported for Root app");
            }
            session.App.GetMainWindow(session.Automation).Close();
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
