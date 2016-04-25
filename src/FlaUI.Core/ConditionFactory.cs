using interop.UIAutomationCore;
using System.Collections.Generic;
using System.Linq;

namespace FlaUI.Core
{
    public class ConditionFactory
    {
        private readonly IUIAutomation _automation;

        public ConditionFactory(IUIAutomation automation)
        {
            _automation = automation;
        }

        public IUIAutomationAndCondition CreateAndCondition(IUIAutomationCondition condition1, IUIAutomationCondition condition2)
        {
            return (IUIAutomationAndCondition)_automation.CreateAndCondition(condition1, condition2);
        }

        public IUIAutomationAndCondition CreateAndConditionFromArray(IEnumerable<IUIAutomationCondition> conditions)
        {
            return (IUIAutomationAndCondition)_automation.CreateAndConditionFromArray(conditions.ToArray());
        }

        public IUIAutomationOrCondition CreateOrCondition(IUIAutomationCondition condition1, IUIAutomationCondition condition2)
        {
            return (IUIAutomationOrCondition)_automation.CreateAndCondition(condition1, condition2);
        }

        public IUIAutomationOrCondition CreateOrConditionFromArray(IEnumerable<IUIAutomationCondition> conditions)
        {
            return (IUIAutomationOrCondition)_automation.CreateAndConditionFromArray(conditions.ToArray());
        }

        public IUIAutomationBoolCondition CreateTrueCondition()
        {
            return (IUIAutomationBoolCondition)_automation.CreateTrueCondition();
        }

        public IUIAutomationBoolCondition CreateFalseCondition()
        {
            return (IUIAutomationBoolCondition)_automation.CreateFalseCondition();
        }

        public IUIAutomationNotCondition CreateNotCondition(IUIAutomationCondition condition)
        {
            return (IUIAutomationNotCondition)_automation.CreateNotCondition(condition);
        }

        public IUIAutomationPropertyCondition CreatePropertyCondition(int propertyId, object value)
        {
            return (IUIAutomationPropertyCondition)_automation.CreatePropertyCondition(propertyId, value);
        }

        public IUIAutomationPropertyCondition CreatePropertyCondition(int propertyId, object value, PropertyConditionFlags flags)
        {
            return (IUIAutomationPropertyCondition)_automation.CreatePropertyConditionEx(propertyId, value, flags);
        }
    }
}
