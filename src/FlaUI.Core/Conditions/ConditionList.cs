using System.Collections.Generic;

namespace FlaUI.Core.Conditions
{
    public class ConditionList : List<ConditionBase>
    {
        public ConditionList(params ConditionBase[] conditions)
        {
            AddRange(conditions);
        }
    }
}
