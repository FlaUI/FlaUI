using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core
{
    public interface IBasicCacheRequest
    {
        AutomationElementMode AutomationElementMode { get; set; }

        ConditionBase TreeFilter { get; set; }

        TreeScope TreeScope { get; set; }

        void Add(PatternId pattern);

        void Add(PropertyId property);

        IBasicCacheRequest Clone();
    }
}
