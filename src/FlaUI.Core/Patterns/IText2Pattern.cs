using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IText2Pattern
    {
        ITextRange GetCaretRange(out bool isActive);
        ITextRange RangeFromAnnotation(AutomationElement annotation);
    }
}
