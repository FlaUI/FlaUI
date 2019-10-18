#if NETFRAMEWORK
using Accessibility;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public partial interface ILegacyIAccessiblePattern
    {
        IAccessible GetIAccessible();
    }

    public abstract partial class LegacyIAccessiblePatternBase<TNativePattern> : PatternBase<TNativePattern>,
        ILegacyIAccessiblePattern
        where TNativePattern : class
    {
        public abstract IAccessible GetIAccessible();
    }
}
#endif
