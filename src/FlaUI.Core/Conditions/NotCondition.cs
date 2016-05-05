using interop.UIAutomationCore;

namespace FlaUI.Core.Conditions
{
    public class NotCondition : ConditionBase<IUIAutomationNotCondition>
    {
        public NotCondition(IUIAutomationNotCondition nativeCondition)
            : base(nativeCondition)
        {
        }

        public ICondition Condition
        {
            get { return ConditionFactory.NativeToManaged(NativeCondition.GetChild()); }
        }
    }
}
