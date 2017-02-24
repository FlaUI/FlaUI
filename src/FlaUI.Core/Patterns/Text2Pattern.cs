using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IText2Pattern : ITextPattern
    {
        ITextRange GetCaretRange(out bool isActive);
        ITextRange RangeFromAnnotation(AutomationElement annotation);
    }
}
