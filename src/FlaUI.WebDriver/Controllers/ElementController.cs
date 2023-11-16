using FlaUI.Core.AutomationElements;
using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FlaUI.WebDriver.Controllers
{
    [Route("session/{sessionId}/[controller]")]
    [ApiController]
    public class ElementController : ControllerBase
    {
        private readonly ILogger<ElementController> _logger;
        private readonly ISessionRepository _sessionRepository;

        public ElementController(ILogger<ElementController> logger, ISessionRepository sessionRepository)
        {
            _logger = logger;
            _sessionRepository = sessionRepository;
        }

        [HttpGet("active")]
        public async Task<ActionResult> GetActiveElement([FromRoute] string sessionId)
        {
            var session = GetSession(sessionId);
            var element = session.AddKnownElement(session.Automation.FocusedElement());
            return await Task.FromResult(WebDriverResult.Success(new FindElementResponse()
            {
                ElementReference = element.ElementReference
            }));
        }

        [HttpGet("{elementId}/displayed")]
        public async Task<ActionResult> IsElementDisplayed([FromRoute] string sessionId, [FromRoute] string elementId)
        {
            var session = GetSession(sessionId);
            var element = GetElement(session, elementId);
            return await Task.FromResult(WebDriverResult.Success(!element.IsOffscreen));
        }

        [HttpPost("{elementId}/click")]
        public async Task<ActionResult> ElementClick([FromRoute] string sessionId, [FromRoute] string elementId)
        {
            var session = GetSession(sessionId);
            var element = GetElement(session, elementId);

            ScrollElementContainerIntoView(element);
            if (!await Wait.Until(() => !element.IsOffscreen, session.ImplicitWaitTimeout))
            {
                return ElementNotInteractable(elementId);
            }
            element.Click();

            return WebDriverResult.Success();
        }

        [HttpPost("{elementId}/clear")]
        public async Task<ActionResult> ElementClear([FromRoute] string sessionId, [FromRoute] string elementId)
        {
            var session = GetSession(sessionId);
            var element = GetElement(session, elementId);

            element.AsTextBox().Text = "";

            return await Task.FromResult(WebDriverResult.Success());
        }

        [HttpGet("{elementId}/text")]
        public async Task<ActionResult> GetElementText([FromRoute] string sessionId, [FromRoute] string elementId)
        {
            var session = GetSession(sessionId);
            var element = GetElement(session, elementId);

            var text = element.Patterns.Value.PatternOrDefault?.Value?.ValueOrDefault;
            if (text == null)
            {
                text = element.Patterns.Text.PatternOrDefault?.DocumentRange?.GetText(int.MaxValue);
            }
            if (text == null)
            {
                text = element.Name;
            }

            return await Task.FromResult(WebDriverResult.Success(text));
        }

        [HttpPost("{elementId}/value")]
        public async Task<ActionResult> ElementSendKeys([FromRoute] string sessionId, [FromRoute] string elementId, [FromBody] ElementSendKeysRequest elementSendKeysRequest)
        {
            var session = GetSession(sessionId);
            var element = GetElement(session, elementId);

            ScrollElementContainerIntoView(element);
            if (!await Wait.Until(() => !element.IsOffscreen, session.ImplicitWaitTimeout))
            {
                return ElementNotInteractable(elementId);
            }
            element.AsTextBox().Text = elementSendKeysRequest.Text;

            return WebDriverResult.Success();
        }

        private static void ScrollElementContainerIntoView(AutomationElement element)
        {
            element.Patterns.ScrollItem.PatternOrDefault?.ScrollIntoView();
        }

        private static ActionResult ElementNotInteractable(string elementId)
        {
            return WebDriverResult.BadRequest(new ErrorResponse()
            {
                ErrorCode = "element not interactable",
                Message = $"Element with ID {elementId} is off screen"
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
