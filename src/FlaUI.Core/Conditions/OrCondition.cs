using System.Collections.Generic;

namespace FlaUI.Core.Conditions
{
    /// <summary>
    /// A condition used to group two conditions together with an "or".
    /// </summary>
    public class OrCondition : JunctionConditionBase
    {
        /// <summary>
        /// Creates a new <see cref="OrCondition" /> based on two conditions.
        /// </summary>
        /// <param name="condition1">The first condition.</param>
        /// <param name="condition2">The second condition.</param>
        public OrCondition(ConditionBase condition1, ConditionBase condition2)
            : this(new[] { condition1, condition2 })
        {
        }

        /// <summary>
        /// Creates a new <see cref="OrCondition" /> based on a list of conditions.
        /// </summary>
        /// <param name="conditions">The list of conditions.</param>
        public OrCondition(IEnumerable<ConditionBase> conditions)
            : base(conditions)
        {
        }

        /// <summary>
        /// Creates a new <see cref="OrCondition" /> based on a list of conditions.
        /// </summary>
        /// <param name="conditions">The list of conditions.</param>
        public OrCondition(params ConditionBase[] conditions)
            : base(conditions)
        {
        }

        /// <inheritdoc />
        protected override string JunctionOperator => "OR";
    }
}
