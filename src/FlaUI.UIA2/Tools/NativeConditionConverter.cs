using System;
using System.Linq;
using FlaUI.Core.Conditions;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Tools
{
    public static class NativeConditionConverter
    {
        public static UIA.Condition ToNative(ConditionBase condition)
        {
            var propCond = condition as PropertyCondition;
            if (propCond != null)
            {
                return new UIA.PropertyCondition(UIA.AutomationProperty.LookupById(propCond.Property.Id), NativeValueConverter.ToNative(propCond.Value), (UIA.PropertyConditionFlags)propCond.PropertyConditionFlags);
            }
            var boolCond = condition as BoolCondition;
            if (boolCond != null)
            {
                return boolCond.BooleanValue ? UIA.Condition.TrueCondition : UIA.Condition.FalseCondition;
            }
            var notCond = condition as NotCondition;
            if (notCond != null)
            {
                return new UIA.NotCondition(ToNative(notCond.Condition));
            }
            var junctCond = condition as JunctionConditionBase;
            if (junctCond != null)
            {
                if (junctCond.ChildCount == 0)
                {
                    // No condition in the list, so just create a true condition
                    return UIA.Condition.TrueCondition;
                }
                if (junctCond.ChildCount == 1)
                {
                    // Only one condition in the list, so just return that one
                    return ToNative(junctCond.Conditions[0]);
                }
                if (junctCond is AndCondition)
                {
                    // Create the and condition
                    return new UIA.AndCondition(junctCond.Conditions.Select(ToNative).ToArray());
                }
                // Create the or condition
                return new UIA.OrCondition(junctCond.Conditions.Select(ToNative).ToArray());
            }
            throw new ArgumentException("Unknown condition type");
        }
    }
}
