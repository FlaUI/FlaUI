using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IExpandCollapsePattern : IPatternWithInformation<IExpandCollapsePatternInformation>
    {
        void Collapse();
        void Expand();
    }

    public interface IExpandCollapsePatternInformation : IPatternInformation
    {
        ExpandCollapseState ExpandCollapseState { get; }
    }

    public interface IExpandCollapsePatternProperties
    {
        PropertyId ExpandCollapseStateProperty { get; }
    }
}
