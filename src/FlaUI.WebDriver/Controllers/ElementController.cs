using FlaUI.Core.AutomationElements;
using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
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
            var session = GetActiveSession(sessionId);
            var element = session.GetOrAddKnownElement(session.Automation.FocusedElement());
            return await Task.FromResult(WebDriverResult.Success(new FindElementResponse()
            {
                ElementReference = element.ElementReference
            }));
        }

        [HttpGet("{elementId}/displayed")]
        public async Task<ActionResult> IsElementDisplayed([FromRoute] string sessionId, [FromRoute] string elementId)
        {
            var session = GetActiveSession(sessionId);
            var element = GetElement(session, elementId);
            return await Task.FromResult(WebDriverResult.Success(!element.IsOffscreen));
        }

        [HttpPost("{elementId}/click")]
        public async Task<ActionResult> ElementClick([FromRoute] string sessionId, [FromRoute] string elementId)
        {
            var session = GetActiveSession(sessionId);
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
            var session = GetActiveSession(sessionId);
            var element = GetElement(session, elementId);

            element.AsTextBox().Text = "";

            return await Task.FromResult(WebDriverResult.Success());
        }

        [HttpGet("{elementId}/text")]
        public async Task<ActionResult> GetElementText([FromRoute] string sessionId, [FromRoute] string elementId)
        {
            var session = GetActiveSession(sessionId);
            var element = GetElement(session, elementId);

            string text;
            if (element.Patterns.Text.IsSupported)
            {
                text = element.Patterns.Text.Pattern.DocumentRange.GetText(int.MaxValue);
            }
            else
            {
                text = GetRenderedText(element);
            }

            return await Task.FromResult(WebDriverResult.Success(text));
        }

        private static string GetRenderedText(AutomationElement element)
        {
            var result = new StringBuilder();
            AddRenderedText(element, result);
            return result.ToString();
        }

        private static void AddRenderedText(AutomationElement element, StringBuilder stringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(element.Name))
            {
                if(stringBuilder.Length > 0)
                {
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append(element.Name);
            }
            foreach (var child in element.FindAllChildren())
            {
                if (child.Properties.ClassName.ValueOrDefault == "TextBlock")
                {
                    // Text blocks set the `Name` of their parent element already
                    continue;
                }
                AddRenderedText(child, stringBuilder);
            }
        }

        [HttpGet("{elementId}/selected")]
        public async Task<ActionResult> IsElementSelected([FromRoute] string sessionId, [FromRoute] string elementId)
        {
            var session = GetActiveSession(sessionId);
            var element = GetElement(session, elementId);
            var isSelected = false;
            if (element.Patterns.SelectionItem.IsSupported)
            {
                isSelected = element.Patterns.SelectionItem.PatternOrDefault.IsSelected.ValueOrDefault;
            }
            else if (element.Patterns.Toggle.IsSupported)
            {
                isSelected = element.Patterns.Toggle.PatternOrDefault.ToggleState.ValueOrDefault == Core.Definitions.ToggleState.On;
            }
            return await Task.FromResult(WebDriverResult.Success(isSelected));
        }

        [HttpPost("{elementId}/value")]
        public async Task<ActionResult> ElementSendKeys([FromRoute] string sessionId, [FromRoute] string elementId, [FromBody] ElementSendKeysRequest elementSendKeysRequest)
        {
            var session = GetActiveSession(sessionId);
            var element = GetElement(session, elementId);

            ScrollElementContainerIntoView(element);
            if (!await Wait.Until(() => !element.IsOffscreen, session.ImplicitWaitTimeout))
            {
                return ElementNotInteractable(elementId);
            }
            element.AsTextBox().Text = elementSendKeysRequest.Text;

            return WebDriverResult.Success();
        }

        [HttpGet("{elementId}/rect")]
        public async Task<ActionResult> GetElementRect([FromRoute] string sessionId, [FromRoute] string elementId)
        {
            var session = GetSession(sessionId);
            var element = GetElement(session, elementId);
            var elementBoundingRect = element.BoundingRectangle;
            var elementRect = new ElementRect
            {
                X = elementBoundingRect.X,
                Y = elementBoundingRect.Y,
                Width = elementBoundingRect.Width,
                Height = elementBoundingRect.Height
            };
            return await Task.FromResult(WebDriverResult.Success(elementRect));
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
