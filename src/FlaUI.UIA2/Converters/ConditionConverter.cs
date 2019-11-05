using System;
using System.Linq;
using FlaUI.Core.Conditions;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Converters
{
    /// <summary>
    /// Class which helps converting conditions between native and FlaUIs conditions.
    /// </summary>
    public static class ConditionConverter
    {
        /// <summary>
        /// Converts a FlaUI <see cref="ConditionBase"/> to a native condition.
        /// </summary>
        /// <param name="condition">The condition to convert.</param>
        /// <returns>The native condition.</returns>
        public static UIA.Condition ToNative(ConditionBase condition)
        {
            if (condition is PropertyCondition propCond)
            {
                return new UIA.PropertyCondition(UIA.AutomationProperty.LookupById(propCond.Property.Id), ValueConverter.ToNative(propCond.Value), (UIA.PropertyConditionFlags)propCond.PropertyConditionFlags);
            }
            if (condition is BoolCondition boolCond)
            {
                return boolCond.BooleanValue ? UIA.Condition.TrueCondition : UIA.Condition.FalseCondition;
            }
            if (condition is NotCondition notCond)
            {
                return new UIA.NotCondition(ToNative(notCond.Condition));
            }
            if (condition is JunctionConditionBase junctionCondition)
            {
                if (junctionCondition.ChildCount == 0)
                {
                    // No condition in the list, so just create a true condition
                    return UIA.Condition.TrueCondition;
                }
                if (junctionCondition.ChildCount == 1)
                {
                    // Only one condition in the list, so just return that one
                    return ToNative(junctionCondition.Conditions[0]);
                }
                if (junctionCondition is AndCondition)
                {
                    // Create the and condition
                    return new UIA.AndCondition(junctionCondition.Conditions.Select(ToNative).ToArray());
                }
                // Create the or condition
                return new UIA.OrCondition(junctionCondition.Conditions.Select(ToNative).ToArray());
            }
            throw new ArgumentException("Unknown condition type");
        }
    }
}
