using System;

namespace FlaUI.UIA3.Conditions
{
    public class BoolCondition : ConditionBase
    {
        public BoolCondition(bool booleanValue)
        {
            BooleanValue = booleanValue;
        }

        public bool BooleanValue { get; private set; }

        public override string ToString()
        {
            return String.Format("BOOL: {0}", BooleanValue);
        }
    }
}
