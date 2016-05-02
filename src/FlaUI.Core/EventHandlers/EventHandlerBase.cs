namespace FlaUI.Core.EventHandlers
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
