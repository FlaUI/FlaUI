using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using System.Linq;

namespace FlaUI.WebDriver.Controllers
{
    [Route("session/{sessionId}")]
    [ApiController]
    public class FindElementsController : ControllerBase
    {
        private readonly ILogger<FindElementsController> _logger;
        private readonly ISessionRepository _sessionRepository;

        public FindElementsController(ILogger<FindElementsController> logger, ISessionRepository sessionRepository)
        {
            _logger = logger;
            _sessionRepository = sessionRepository;
        }

        [HttpPost("element")]
        public async Task<ActionResult> FindElement([FromRoute] string sessionId, [FromBody] FindElementRequest findElementRequest)
        {
            var session = GetSession(sessionId);
            if (session.App == null)
            {
                throw WebDriverResponseException.UnsupportedOperation("Finding elements from Root is not supported");
            }
            var window = session.App.GetMainWindow(session.Automation);
            var condition = GetCondition(session.Automation.ConditionFactory, findElementRequest.Using, findElementRequest.Value);
            var element = await Wait.Until(() => window.FindFirstDescendant(condition), element => element != null, session.ImplicitWaitTimeout);
            if (element == null)
            {
                return NoSuchElement(findElementRequest);
            }

            var knownElement = session.AddKnownElement(element);
            return await Task.FromResult(WebDriverResult.Success(new FindElementResponse
            {
                ElementReference = knownElement.ElementReference,
            }));
        }

        [HttpPost("elements")]
        public async Task<ActionResult> FindElements([FromRoute] string sessionId, [FromBody] FindElementRequest findElementRequest)
        {
            var session = GetSession(sessionId);
            if (session.App == null)
            {
                throw WebDriverResponseException.UnsupportedOperation("Finding elements from Root is not supported");
            }
            var window = session.App.GetMainWindow(session.Automation);
            var condition = GetCondition(session.Automation.ConditionFactory, findElementRequest.Using, findElementRequest.Value);
            var elements = await Wait.Until(() => window.FindAllDescendants(condition), element => element.Length > 0, session.ImplicitWaitTimeout);
            if (elements.Length == 0)
            {
                return NoSuchElement(findElementRequest);
            }

            var knownElements = elements.Select(session.AddKnownElement);
            return await Task.FromResult(WebDriverResult.Success(
            
                knownElements.Select(knownElement => new FindElementResponse()
                {
                    ElementReference = knownElement.ElementReference
                }).ToArray()
            ));
        }

        private static PropertyCondition GetCondition(ConditionFactory conditionFactory, string @using, string value)
        {
            switch (@using)
            {
                case "accessibility id":
                    return conditionFactory.ByAutomationId(value);
                case "name":
                    return conditionFactory.ByName(value);
                case "class name":
                    return conditionFactory.ByClassName(value);
                case "link text":
                    return conditionFactory.ByText(value);
                case "partial link text":
                    return conditionFactory.ByText(value, PropertyConditionFlags.MatchSubstring);
                case "tag name":
                    return conditionFactory.ByControlType(Enum.Parse<ControlType>(value));
                default:
                    throw WebDriverResponseException.UnsupportedOperation($"Selector strategy {@using} is not supported");
            }
        }

        private static ActionResult NoSuchElement(FindElementRequest findElementRequest)
        {
            return WebDriverResult.NotFound(new ErrorResponse()
            {
                ErrorCode = "no such element",
                Message = $"No element found with selector {findElementRequest.Using} and value {findElementRequest.Value}"
            });
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
