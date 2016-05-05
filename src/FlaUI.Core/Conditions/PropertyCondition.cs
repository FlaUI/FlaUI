using FlaUI.Core.Identifiers;
using interop.UIAutomationCore;

namespace FlaUI.Core.Conditions
{
    public class PropertyCondition : ConditionBase<IUIAutomationPropertyCondition>
    {
        public PropertyCondition(IUIAutomationPropertyCondition nativeCondition)
            : base(nativeCondition)
        {
        }

        public Definitions.PropertyConditionFlags PropertyConditionFlags
        {
            get { return (Definitions.PropertyConditionFlags)NativeCondition.PropertyConditionFlags; }

        }

        public PropertyId Property
        {
            get { return PropertyId.Find(NativeCondition.propertyId); }
        }

        public object PropertyValue
        {
            get { return NativeCondition.PropertyValue; }
        }
    }
}
