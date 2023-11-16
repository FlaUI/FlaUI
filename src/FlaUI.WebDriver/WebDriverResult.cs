using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FlaUI.WebDriver
{
    public static class WebDriverResult
    {
        public static ActionResult Success<T>(T value)
        {
            return new OkObjectResult(new ResponseWithValue<T>(value));
        }

        public static ActionResult Success()
        {
            return new OkObjectResult(new ResponseWithValue<string?>(null));
        }

        public static ActionResult BadRequest(ErrorResponse errorResponse)
        {
            return new BadRequestObjectResult(new ResponseWithValue<ErrorResponse>(errorResponse));
        }

        public static ActionResult NotFound(ErrorResponse errorResponse)
        {
            return new NotFoundObjectResult(new ResponseWithValue<ErrorResponse>(errorResponse));
        }

        public static ActionResult Error(ErrorResponse errorResponse)
        {
            return new ObjectResult(new ResponseWithValue<ErrorResponse>(errorResponse))
            {
                StatusCode = 500
            };
        }
    }
}
