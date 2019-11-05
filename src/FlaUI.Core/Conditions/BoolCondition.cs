namespace FlaUI.Core.Conditions
{
    /// <summary>
    /// Represents a boolean condition.
    /// </summary>
    public class BoolCondition : ConditionBase
    {
        /// <summary>
        /// Creates a new instance of a boolean condition with the given boolean value.
        /// </summary>
        /// <param name="booleanValue">The boolean value of this condition.</param>
        public BoolCondition(bool booleanValue)
        {
            BooleanValue = booleanValue;
        }

        /// <summary>
        /// Gets the boolean value for this condition.
        /// </summary>
        public bool BooleanValue { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"BOOL: {BooleanValue}";
        }
    }

    /// <summary>
    /// A boolean condition that has is "true".
    /// </summary>
    public sealed class TrueCondition : BoolCondition
    {
        private TrueCondition() : base(true)
        {
        }

        /// <summary>
        /// The default instance for a <see cref="TrueCondition"/>.
        /// </summary>
        public static TrueCondition Default { get; } = new TrueCondition();
    }

    /// <summary>
    /// A boolean condition that has is "false".
    /// </summary>
    public sealed class FalseCondition : BoolCondition
    {
        private FalseCondition() : base(false)
        {
        }

        /// <summary>
        /// The default instance for a <see cref="FalseCondition"/>.
        /// </summary>
        public static FalseCondition Default { get; } = new FalseCondition();
    }
}
