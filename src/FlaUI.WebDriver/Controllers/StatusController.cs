using FlaUI.WebDriver.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlaUI.WebDriver.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetStatus()
        {
            return WebDriverResult.Success(new StatusResponse()
            {
                Ready = true,
                Message = "Hello World!"
            });
        }
    }
}
