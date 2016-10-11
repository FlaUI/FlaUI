using System;
using System.Linq;
using FlaUI.Core.Conditions;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Converters
{
    public static class ConditionConverter
    {
        public static UIA.IUIAutomationCondition ToNative(UIA3Automation automation, ConditionBase condition)
        {
            var propCond = condition as PropertyCondition;
            if (propCond != null)
            {
                return automation.NativeAutomation.CreatePropertyConditionEx(propCond.Property.Id, ValueConverter.ToNative(propCond.Value), (UIA.PropertyConditionFlags)propCond.PropertyConditionFlags);
            }
            var boolCond = condition as BoolCondition;
            if (boolCond != null)
            {
                return boolCond.BooleanValue ? automation.NativeAutomation.CreateTrueCondition() : automation.NativeAutomation.CreateFalseCondition();
            }
            var notCond = condition as NotCondition;
            if (notCond != null)
            {
                return automation.NativeAutomation.CreateNotCondition(ToNative(automation, notCond.Condition));
            }
            var junctCond = condition as JunctionConditionBase;
            if (junctCond != null)
            {
                if (junctCond.ChildCount == 0)
                {
                    // No condition in the list, so just create a true condition
                    return automation.NativeAutomation.CreateTrueCondition();
                }
                if (junctCond.ChildCount == 1)
                {
                    // Only one condition in the list, so just return that one
                    return ToNative(automation, junctCond.Conditions[0]);
                }
                if (junctCond is AndCondition)
                {
                    // Create the and condition
                    return automation.NativeAutomation.CreateAndConditionFromArray(junctCond.Conditions.Select(c => ToNative(automation, c)).ToArray());
                }
                // Create the or condition
                return automation.NativeAutomation.CreateOrConditionFromArray(junctCond.Conditions.Select(c => ToNative(automation, c)).ToArray());
            }
            throw new ArgumentException("Unknown condition type");
        }
    }
}
