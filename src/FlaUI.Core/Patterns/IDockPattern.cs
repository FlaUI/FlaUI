using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDockPattern : IPattern
    {
        IDockPatternProperties Properties { get; }
        DockPosition DockPosition { get; }
        void SetDockPosition(DockPosition dockPos);
    }

    public interface IDockPatternProperties
    {
        PropertyId DockPositionProperty { get; }
    }
}
