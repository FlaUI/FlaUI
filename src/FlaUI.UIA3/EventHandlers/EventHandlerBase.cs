namespace FlaUI.UIA3.EventHandlers
{
    internal abstract class EventHandlerBase
    {
        public UIA3Automation Automation { get; private set; }

        protected EventHandlerBase(UIA3Automation automation)
        {
            Automation = automation;
        }
    }
}
