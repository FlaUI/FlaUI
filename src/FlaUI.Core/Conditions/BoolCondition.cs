using System;

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

    public class TrueCondition : BoolCondition
    {
        public TrueCondition() : base(true)
        {
        }
    }

    public class FalseCondition : BoolCondition
    {
        public FalseCondition() : base(false)
        {
        }
    }
}
