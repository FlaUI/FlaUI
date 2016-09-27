using System.Collections.Generic;

namespace FlaUI.Core.Conditions
{
    /// <summary>
    /// Base class for the conditions
    /// </summary>
    public abstract class ConditionBase
    {
        /// <summary>
        /// Adds the given condition with an "and"
        /// </summary>
        public AndCondition And(ConditionBase newCondition)
        {
            // Check if this condition is already an and condition
            var thisCondition = this as AndCondition;
            if (thisCondition != null)
            {
                // If so, just add the new one
                var newConditions = new List<ConditionBase>(thisCondition.ChildCount + 1);
                newConditions.AddRange(thisCondition.Conditions);
                newConditions.Add(newCondition);
                return new AndCondition(newConditions);
            }
            // It is not, so pack it into an and condition
            return new AndCondition(this, newCondition);
        }

        /// <summary>
        /// Adds the given condition with an "or"
        /// </summary>
        public OrCondition Or(ConditionBase newCondition)
        {
            // Check if this condition is already an or condition
            var thisCondition = this as OrCondition;
            if (thisCondition != null)
            {
                // If so, just add the new one
                var newConditions = new List<ConditionBase>(thisCondition.ChildCount + 1);
                newConditions.AddRange(thisCondition.Conditions);
                newConditions.Add(newCondition);
                return new OrCondition(newConditions);
            }
            // It is not, so pack it into an or condition
            return new OrCondition(this, newCondition);
        }

        /// <summary>
        /// Packs this condition into a not condition
        /// </summary>
        public NotCondition Not()
        {
            return new NotCondition(this);
        }
    }
}
