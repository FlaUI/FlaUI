using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core
{
    public interface ICacheRequest
    {
        AutomationElementMode AutomationElementMode { get; set; }

        ConditionBase TreeFilter { get; set; }

        TreeScope TreeScope { get; set; }

        void AddPattern(PatternId pattern);

        void AddProperty(PropertyId property);

        ICacheRequest Clone();
    }
}
