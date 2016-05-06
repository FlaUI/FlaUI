using System;
using System.Collections.Generic;
using System.Linq;

namespace FlaUI.Core.Conditions
{
    public class AndCondition : JunctionConditionBase
    {
        public AndCondition(ConditionBase condition1, ConditionBase condition2)
            : this(new[] { condition1, condition2 })
        {
        }

        public AndCondition(IEnumerable<ConditionBase> conditions)
        {
            Conditions.AddRange(conditions);
        }

        public override string ToString()
        {
            return String.Format("({0})", String.Join(" AND ", Conditions.Select(c => c.ToString())));
        }
    }
}
