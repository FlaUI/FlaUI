using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IMultipleViewPattern : IPatternWithInformation<IMultipleViewPatternInformation>
    {
        IMultipleViewPatternProperties Properties { get; }
        string GetViewName(int view);
        void SetCurrentView(int view);
    }

    public interface IMultipleViewPatternInformation : IPatternInformation
    {
        int CurrentView { get; }
        int[] SupportedViews { get; }
    }

    public interface IMultipleViewPatternProperties
    {
        PropertyId CurrentViewProperty { get; }
        PropertyId SupportedViewsProperty { get; }
    }
}
