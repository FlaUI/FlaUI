using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITextChildPattern : IPattern
    {
        AutomationElement TextContainer { get; }
        ITextRange TextRange { get; }
    }
}
