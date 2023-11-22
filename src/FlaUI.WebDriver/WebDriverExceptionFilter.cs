using Microsoft.AspNetCore.Mvc.Filters;
using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;
using FlaUI.Core.Logging;
using Microsoft.Extensions.Logging;
using System.Windows.Forms.Design;
using Microsoft.Extensions.DependencyInjection;

namespace FlaUI.WebDriver
{
    public class WebDriverResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is WebDriverResponseException exception)
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<WebDriverResponseExceptionFilter>>();
                logger.LogError(exception, "Returning WebDriver error response with error code {ErrorCode}", exception.ErrorCode);

                context.Result = new ObjectResult(new ResponseWithValue<ErrorResponse>(new ErrorResponse { ErrorCode = exception.ErrorCode, Message = exception.Message })) {
                    StatusCode = exception.StatusCode
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
