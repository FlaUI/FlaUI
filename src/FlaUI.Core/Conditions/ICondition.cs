using interop.UIAutomationCore;

namespace FlaUI.Core.Conditions
{
    public interface ICondition
    {
        IUIAutomationCondition NativeCondition { get; }
    }
}
