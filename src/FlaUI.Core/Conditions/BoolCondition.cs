namespace FlaUI.Core.Conditions
{
    public class BoolCondition : ConditionBase
    {
        public BoolCondition(bool booleanValue)
        {
            BooleanValue = booleanValue;
        }

        public bool BooleanValue { get; }

        public override string ToString()
        {
            return $"BOOL: {BooleanValue}";
        }
    }

    public sealed class TrueCondition : BoolCondition
    {
        private TrueCondition() : base(true)
        {
        }

        public static TrueCondition Default { get; } = new TrueCondition();
    }

    public sealed class FalseCondition : BoolCondition
    {
        private FalseCondition() : base(false)
        {
        }

        public static FalseCondition Default { get; } = new FalseCondition();
    }
}
