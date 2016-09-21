using FlaUI.Core;

namespace FlaUI.UIA3.EventHandlers
{
    internal abstract class EventHandlerBase
    {
        public Automation Automation { get; private set; }

        protected EventHandlerBase(Automation automation)
        {
            Automation = automation;
        }
    }
}
