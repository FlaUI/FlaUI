namespace FlaUI.Core.EventHandlers
{
    public abstract class EventHandlerBase
    {
        public AutomationBase Automation { get; private set; }

        protected EventHandlerBase(AutomationBase automation)
        {
            Automation = automation;
        }
    }
}
