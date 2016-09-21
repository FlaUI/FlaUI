using System.Collections.Generic;

namespace FlaUI.UIA3.Conditions
{
    public abstract class JunctionConditionBase : ConditionBase
    {
        protected JunctionConditionBase()
        {
            Conditions = new List<ConditionBase>();
        }

        public List<ConditionBase> Conditions { get; private set; }

        public int ChildCount
        {
            get { return Conditions.Count; }
        }
    }
}