using FlaUI.Core.AutomationElements;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITextChildPattern : IPattern
    {
        AutomationElement TextContainer { get; }
        ITextRange TextRange { get; }
    }
}
