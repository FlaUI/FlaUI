using System;
using System.Collections.Generic;
using System.Linq;

namespace FlaUI.UIA3.Conditions
{
    public class OrCondition : JunctionConditionBase
    {
        public OrCondition(ConditionBase condition1, ConditionBase condition2)
            : this(new[] { condition1, condition2 })
        {
        }

        public OrCondition(IEnumerable<ConditionBase> conditions)
        {
            Conditions.AddRange(conditions);
        }

        public override string ToString()
        {
            return String.Format("({0})", String.Join(" OR ", Conditions.Select(c => c.ToString())));
        }
    }
}
