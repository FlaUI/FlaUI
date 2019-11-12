using System;
using System.Collections.Generic;
using System.Linq;

namespace FlaUI.Core.Conditions
{
    /// <summary>
    /// Base class for a junction condition.
    /// </summary>
    public abstract class JunctionConditionBase : ConditionBase
    {
        /// <summary>
        /// Creates a new instance of a junction condition.
        /// </summary>
        protected JunctionConditionBase()
        {
            Conditions = new List<ConditionBase>();
        }

        /// <summary>
        /// Creates a new instance of a junction condition and adds the given conditions.
        /// </summary>
        /// <param name="conditions">The conditions to add to the junction.</param>
        protected JunctionConditionBase(IEnumerable<ConditionBase> conditions) : this()
        {
            Conditions.AddRange(conditions);
        }

        /// <summary>
        /// Returns the inner conditions.
        /// </summary>
        public List<ConditionBase> Conditions { get; }

        /// <summary>
        /// Gets the number of conditions in this junction condition.
        /// </summary>
        public int ChildCount => Conditions.Count;

        /// <summary>
        /// Gets the operator used for the junction.
        /// </summary>
        protected abstract string JunctionOperator { get; }

        /// <inheritdoc />
        public override string ToString()
        {
#if NET35
            var conditions = String.Join($" {JunctionOperator} ", Conditions.Select(c => c.ToString()).ToArray());
#else
            var conditions = String.Join($" {JunctionOperator} ", Conditions.Select(c => c.ToString()));
#endif
            return $"({conditions})";
        }
    }
}
