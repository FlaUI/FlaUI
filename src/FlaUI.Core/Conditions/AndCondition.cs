using interop.UIAutomationCore;

namespace FlaUI.Core.Conditions
{
    public class AndCondition : ConditionBase<IUIAutomationAndCondition>
    {
        public AndCondition(IUIAutomationAndCondition nativeCondition)
            : base(nativeCondition)
        {
        }

        public int ChildCount
        {
            get { return NativeCondition.ChildCount; }
        }

        public ICondition[] Conditions
        {
            get { return ConditionFactory.NativeToManaged(NativeCondition.GetChildren()); }
        }
    }
}
