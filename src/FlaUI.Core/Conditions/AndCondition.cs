using System.Collections.Generic;

namespace FlaUI.Core.Conditions
{
    /// <summary>
    /// A condition used to group two conditions together with an "and".
    /// </summary>
    public class AndCondition : JunctionConditionBase
    {
        /// <summary>
        /// Creates a new <see cref="AndCondition" /> based on two conditions.
        /// </summary>
        /// <param name="condition1">The first condition.</param>
        /// <param name="condition2">The second condition.</param>
        public AndCondition(ConditionBase condition1, ConditionBase condition2)
            : base(new[] { condition1, condition2 })
        {
        }

        /// <summary>
        /// Creates a new <see cref="AndCondition" /> based on a list of conditions.
        /// </summary>
        /// <param name="conditions">The list of conditions.</param>
        public AndCondition(IEnumerable<ConditionBase> conditions)
            : base(conditions)
        {
        }

        /// <summary>
        /// Creates a new <see cref="AndCondition" /> based on a list of conditions.
        /// </summary>
        /// <param name="conditions">The list of conditions.</param>
        public AndCondition(params ConditionBase[] conditions)
            : base(conditions)
        {
        }

        /// <inheritdoc />
        protected override string JunctionOperator => "AND";
    }
}
