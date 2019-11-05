namespace FlaUI.Core.Conditions
{
    /// <summary>
    /// A condition that negates a given condition.
    /// </summary>
    public class NotCondition : ConditionBase
    {
        /// <summary>
        /// Gets the inner condition that should be negated.
        /// </summary>
        public ConditionBase Condition { get; }

        /// <summary>
        /// Creates a new instance of a <see cref="NotCondition"/> which negates the given condition.
        /// </summary>
        /// <param name="condition">The condition that should be negated.</param>
        public NotCondition(ConditionBase condition)
        {
            Condition = condition;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"NOT ({Condition})";
        }
    }
}
