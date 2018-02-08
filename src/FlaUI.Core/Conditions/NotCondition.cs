namespace FlaUI.Core.Conditions
{
    public class NotCondition : ConditionBase
    {
        public ConditionBase Condition { get; }

        public NotCondition(ConditionBase condition)
        {
            Condition = condition;
        }

        public override string ToString()
        {
            return $"NOT ({Condition})";
        }
    }
}
