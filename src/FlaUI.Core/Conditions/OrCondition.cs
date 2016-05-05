using interop.UIAutomationCore;

namespace FlaUI.Core.Conditions
{
    public class OrCondition : ConditionBase<IUIAutomationOrCondition>
    {
        internal OrCondition(IUIAutomationOrCondition nativeCondition)
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
