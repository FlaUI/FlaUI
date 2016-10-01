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
            return String.Format("BOOL: {0}", BooleanValue);
        }
    }
}
