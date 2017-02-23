using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IExpandCollapsePattern : IPattern
    {
        IExpandCollapsePatternProperties Properties { get; }
        ExpandCollapseState ExpandCollapseState { get; }
        void Collapse();
        void Expand();
    }

    public interface IExpandCollapsePatternProperties
    {
        PropertyId ExpandCollapseStateProperty { get; }
    }
}
