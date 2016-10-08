using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDockPattern : IPatternWithInformation<IDockPatternInformation>
    {
        IDockPatternProperties Properties { get; }
        void SetDockPosition(DockPosition dockPos);
    }

    public interface IDockPatternInformation : IPatternInformation
    {
        DockPosition DockPosition { get; }
    }

    public interface IDockPatternProperties
    {
        PropertyId DockPositionProperty { get; }
    }
}
