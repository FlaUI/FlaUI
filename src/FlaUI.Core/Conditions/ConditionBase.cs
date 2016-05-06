using interop.UIAutomationCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlaUI.Core.Conditions
{
    /// <summary>
    /// Base class for the conditions
    /// </summary>
    public abstract class ConditionBase
    {
        /// <summary>
        /// Adds the given condition with an "and"
        /// </summary>
        public AndCondition And(ConditionBase newCondition)
        {
            // Check if this condition is already an and condition
            var thisCondition = this as AndCondition;
            if (thisCondition != null)
            {
                // If so, just add the new one
                var newConditions = new List<ConditionBase>(thisCondition.ChildCount + 1);
                newConditions.AddRange(thisCondition.Conditions);
                newConditions.Add(newCondition);
                return new AndCondition(newConditions);
            }
            // It is not, so pack it into an and condition
            return new AndCondition(this, newCondition);
        }

        /// <summary>
        /// Adds the given condition with an "or"
        /// </summary>
        public OrCondition Or(ConditionBase newCondition)
        {
            // Check if this condition is already an or condition
            var thisCondition = this as OrCondition;
            if (thisCondition != null)
            {
                // If so, just add the new one
                var newConditions = new List<ConditionBase>(thisCondition.ChildCount + 1);
                newConditions.AddRange(thisCondition.Conditions);
                newConditions.Add(newCondition);
                return new OrCondition(newConditions);
            }
            // It is not, so pack it into an or condition
            return new OrCondition(this, newCondition);
        }

        /// <summary>
        /// Packs this condition into a not condition
        /// </summary>
        public NotCondition Not()
        {
            return new NotCondition(this);
        }

        /// <summary>
        /// Converts this condition to a native condition
        /// </summary>
        public IUIAutomationCondition ToNative(Automation automation)
        {
            var propCond = this as PropertyCondition;
            if (propCond != null)
            {
                return automation.NativeAutomation.CreatePropertyConditionEx(propCond.Property.Id, propCond.Value, (PropertyConditionFlags)propCond.PropertyConditionFlags);
            }
            var boolCond = this as BoolCondition;
            if (boolCond != null)
            {
                return boolCond.BooleanValue ? automation.NativeAutomation.CreateTrueCondition() : automation.NativeAutomation.CreateFalseCondition();
            }
            var notCond = this as NotCondition;
            if (notCond != null)
            {
                return automation.NativeAutomation.CreateNotCondition(notCond.ToNative(automation));
            }
            var junctCond = this as JunctionConditionBase;
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
                    return junctCond.Conditions[0].ToNative(automation);
                }
                if (junctCond is AndCondition)
                {
                    // Create the and condition
                    return automation.NativeAutomation.CreateAndConditionFromArray(junctCond.Conditions.Select(c => c.ToNative(automation)).ToArray());
                }
                // Create the or condition
                return automation.NativeAutomation.CreateOrConditionFromArray(junctCond.Conditions.Select(c => c.ToNative(automation)).ToArray());
            }
            throw new ArgumentException("Unknown condition type");
        }
    }
}
