using System.Collections.Generic;

namespace FlaUI.WebDriver.Models
{
    public class CreateSessionRequest
    {
        public Capabilities Capabilities { get; set; } = new Capabilities();
    }
}
