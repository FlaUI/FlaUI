using interop.UIAutomationCore;

namespace FlaUI.Core.Conditions
{
    public abstract class ConditionBase<TCond> : ICondition
    // Note: this is not allowed since this forces the user to also
    // add a reference to the assembly with the type IUIAutomationCondition
    //where TCond : IUIAutomationCondition
    {
        /// <summary>
        /// Implements <see cref="ICondition.NativeCondition"/>
        /// </summary>
        IUIAutomationCondition ICondition.NativeCondition
        {
            get { return (IUIAutomationCondition)NativeCondition; }
        }

        /// <summary>
        /// The typed native condition
        /// </summary>
        public TCond NativeCondition { get; private set; }

        protected ConditionBase(TCond nativeCondition)
        {
            NativeCondition = nativeCondition;
        }
    }
}
