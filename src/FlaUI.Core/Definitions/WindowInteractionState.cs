namespace FlaUI.Core.Definitions
{
    public enum WindowInteractionState
    {
        Running = 0,
        Closing = 1,
        ReadyForUserInteraction = 2,
        BlockedByModalWindow = 3,
        NotResponding = 4
    }
}
