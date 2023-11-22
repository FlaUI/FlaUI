using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using System.Linq;
using FlaUI.Core.AutomationElements;

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
            var session = GetActiveSession(sessionId);
            return await FindElementFrom(() => session.CurrentWindow, findElementRequest, session);
        }

        [HttpPost("element/{elementId}/element")]
        public async Task<ActionResult> FindElementFromElement([FromRoute] string sessionId, [FromRoute] string elementId, [FromBody] FindElementRequest findElementRequest)
        {
            var session = GetActiveSession(sessionId);
            var element = GetElement(session, elementId);
            return await FindElementFrom(() => element, findElementRequest, session);
        }

        [HttpPost("elements")]
        public async Task<ActionResult> FindElements([FromRoute] string sessionId, [FromBody] FindElementRequest findElementRequest)
        {
            var session = GetActiveSession(sessionId);
            return await FindElementsFrom(() => session.CurrentWindow, findElementRequest, session);
        }

        [HttpPost("element/{elementId}/elements")]
        public async Task<ActionResult> FindElementsFromElement([FromRoute] string sessionId, [FromRoute] string elementId, [FromBody] FindElementRequest findElementRequest)
        {
            var session = GetActiveSession(sessionId);
            var element = GetElement(session, elementId);
            return await FindElementsFrom(() => element, findElementRequest, session);
        }

        private static async Task<ActionResult> FindElementFrom(Func<AutomationElement> startNode, FindElementRequest findElementRequest, Session session)
        {
            var condition = GetCondition(session.Automation.ConditionFactory, findElementRequest.Using, findElementRequest.Value);
            AutomationElement? element = await Wait.Until(() => startNode().FindFirstDescendant(condition), element => element != null, session.ImplicitWaitTimeout);

            if (element == null)
            {
                return NoSuchElement(findElementRequest);
            }

            var knownElement = session.GetOrAddKnownElement(element);
            return await Task.FromResult(WebDriverResult.Success(new FindElementResponse
            {
                ElementReference = knownElement.ElementReference,
            }));
        }

        private static async Task<ActionResult> FindElementsFrom(Func<AutomationElement> startNode, FindElementRequest findElementRequest, Session session)
        {
            var condition = GetCondition(session.Automation.ConditionFactory, findElementRequest.Using, findElementRequest.Value);
            AutomationElement[] elements = await Wait.Until(() => startNode().FindAllDescendants(condition), elements => elements.Length > 0, session.ImplicitWaitTimeout);

            if (elements.Length == 0)
            {
                return NoSuchElement(findElementRequest);
            }

            var knownElements = elements.Select(session.GetOrAddKnownElement);
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
                    throw WebDriverResponseException.UnsupportedOperation($"Selector strategy '{@using}' is not supported");
            }
        }

        private static ActionResult NoSuchElement(FindElementRequest findElementRequest)
        {
            return WebDriverResult.NotFound(new ErrorResponse()
            {
                ErrorCode = "no such element",
                Message = $"No element found with selector '{findElementRequest.Using}' and value '{findElementRequest.Value}'"
            });
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
