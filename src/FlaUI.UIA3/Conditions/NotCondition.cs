using System;

namespace FlaUI.UIA3.Conditions
{
    public class NotCondition : ConditionBase
    {
        public ConditionBase Condition { get; private set; }

        public NotCondition(ConditionBase condition)
        {
            Condition = condition;
        }

        public override string ToString()
        {
            return String.Format("NOT ({0})", Condition);
        }
    }
}
