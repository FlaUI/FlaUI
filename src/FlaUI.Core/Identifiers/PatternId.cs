namespace FlaUI.Core.Identifiers
{
    /// <summary>
    /// A wrapper around the pattern ids
    /// </summary>
    public class PatternId : IdentifierBase
    {
        /// <summary>
        /// Fixed PatternId which is used for patterns that are not supported by the framework.
        /// </summary>
        public static readonly PatternId NotSupportedByFramework = new PatternId(-1, "Not supported", null);

        public PatternId(int id, string name, PropertyId? availabilityProperty)
            : base(id, name)
        {
            AvailabilityProperty = availabilityProperty;
        }

        /// <summary>
        /// Property which can be used to check for the patterns availability on an element
        /// </summary>
        public PropertyId? AvailabilityProperty { get; private set; }

        public static PatternId Register(AutomationType automationType, int id, string name, PropertyId availabilityProperty)
        {
            return RegisterPattern(automationType, id, name, availabilityProperty);
        }

        public static PatternId Find(AutomationType automationType, int id)
        {
            return FindPattern(automationType, id);
        }
    }
}
