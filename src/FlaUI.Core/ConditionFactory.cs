using FlaUI.Core.Conditions;
using FlaUI.Core.Identifiers;
using interop.UIAutomationCore;
using System;
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

        public AndCondition CreateAndCondition(ICondition condition1, ICondition condition2)
        {
            return new AndCondition((IUIAutomationAndCondition)_automation.CreateAndCondition(condition1.NativeCondition, condition2.NativeCondition));
        }

        public AndCondition CreateAndConditionFromArray(IEnumerable<ICondition> conditions)
        {
            return new AndCondition((IUIAutomationAndCondition)_automation.CreateAndConditionFromArray(conditions.Select(c => c.NativeCondition).ToArray()));
        }

        public OrCondition CreateOrCondition(ICondition condition1, ICondition condition2)
        {
            return new OrCondition((IUIAutomationOrCondition)_automation.CreateAndCondition(condition1.NativeCondition, condition2.NativeCondition));
        }

        public OrCondition CreateOrConditionFromArray(IEnumerable<ICondition> conditions)
        {
            return new OrCondition((IUIAutomationOrCondition)_automation.CreateAndConditionFromArray(conditions.Select(c => c.NativeCondition).ToArray()));
        }

        public BoolCondition CreateTrueCondition()
        {
            return new BoolCondition((IUIAutomationBoolCondition)_automation.CreateTrueCondition());
        }

        public BoolCondition CreateFalseCondition()
        {
            return new BoolCondition((IUIAutomationBoolCondition)_automation.CreateFalseCondition());
        }

        public NotCondition CreateNotCondition(ICondition condition)
        {
            return new NotCondition((IUIAutomationNotCondition)_automation.CreateNotCondition(condition.NativeCondition));
        }

        public PropertyCondition CreatePropertyCondition(PropertyId property, object value)
        {
            return new PropertyCondition((IUIAutomationPropertyCondition)_automation.CreatePropertyCondition(property.Id, value));
        }

        public PropertyCondition CreatePropertyCondition(PropertyId property, object value, Definitions.PropertyConditionFlags flags)
        {
            return new PropertyCondition((IUIAutomationPropertyCondition)_automation.CreatePropertyConditionEx(property.Id, value, (PropertyConditionFlags)flags));
        }

        /// <summary>
        /// Converts a native condition to a managed condition
        /// </summary>
        internal static ICondition NativeToManaged(IUIAutomationCondition nativeCondition)
        {
            if (nativeCondition is IUIAutomationBoolCondition)
                return new BoolCondition((IUIAutomationBoolCondition)nativeCondition);
            if (nativeCondition is IUIAutomationAndCondition)
                return new AndCondition((IUIAutomationAndCondition)nativeCondition);
            if (nativeCondition is IUIAutomationOrCondition)
                return new OrCondition((IUIAutomationOrCondition)nativeCondition);
            if (nativeCondition is IUIAutomationNotCondition)
                return new NotCondition((IUIAutomationNotCondition)nativeCondition);
            if (nativeCondition is IUIAutomationPropertyCondition)
                return new PropertyCondition((IUIAutomationPropertyCondition)nativeCondition);
            throw new ArgumentException("nativeCondition");
        }

        /// <summary>
        /// Converts an array of native condtions to an array of managed conditions
        /// </summary>
        internal static ICondition[] NativeToManaged(IUIAutomationCondition[] conditions)
        {
            var managedConditions = new ICondition[conditions.Length];
            for (var i = 0; i < conditions.Length; ++i)
            {
                managedConditions[i] = NativeToManaged(conditions[i]);
            }
            return managedConditions;
        }
    }
}
