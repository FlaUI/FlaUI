using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITextChildPattern
    {
        AutomationElement TextContainer { get; }
        ITextRange TextRange { get; }
    }
}
