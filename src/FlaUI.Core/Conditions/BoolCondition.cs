using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Conditions
{
    public class BoolCondition : ConditionBase<IUIAutomationBoolCondition>
    {
        internal BoolCondition(IUIAutomationBoolCondition nativeCondition)
            : base(nativeCondition)
        {
        }

        public bool BooleanValue
        {
            get { return NativeCondition.BooleanValue.ToBool(); }
        }
    }
}
