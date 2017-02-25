using Accessibility;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Patterns
{
    public interface ILegacyIAccessiblePattern : IPattern
    {
        ILegacyIAccessiblePatternProperties Properties { get; }

        AutomationProperty<int> ChildId { get; }
        AutomationProperty<string> DefaultAction { get; }
        AutomationProperty<string> Description { get; }
        AutomationProperty<string> Help { get; }
        AutomationProperty<string> KeyboardShortcut { get; }
        AutomationProperty<string> Name { get; }
        AutomationProperty<AccessibilityRole> Role { get; }
        AutomationProperty<AutomationElement[]> Selection { get; }
        AutomationProperty<AccessibilityState> State { get; }
        AutomationProperty<string> Value { get; }

        void DoDefaultAction();
        IAccessible GetIAccessible();
        void Select(int flagsSelect);
        void SetValue(string value);
    }

    public interface ILegacyIAccessiblePatternProperties
    {
        PropertyId ChildId { get; }
        PropertyId DefaultAction { get; }
        PropertyId Description { get; }
        PropertyId Help { get; }
        PropertyId KeyboardShortcut { get; }
        PropertyId Name { get; }
        PropertyId Role { get; }
        PropertyId Selection { get; }
        PropertyId State { get; }
        PropertyId Value { get; }
    }

    public abstract class LegacyIAccessiblePatternBase<TNativePattern> : PatternBase<TNativePattern>, ILegacyIAccessiblePattern
    {
        protected LegacyIAccessiblePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ChildId = new AutomationProperty<int>(() => Properties.ChildId, BasicAutomationElement);
            DefaultAction = new AutomationProperty<string>(() => Properties.DefaultAction, BasicAutomationElement);
            Description = new AutomationProperty<string>(() => Properties.Description, BasicAutomationElement);
            Help = new AutomationProperty<string>(() => Properties.Help, BasicAutomationElement);
            KeyboardShortcut = new AutomationProperty<string>(() => Properties.KeyboardShortcut, BasicAutomationElement);
            Name = new AutomationProperty<string>(() => Properties.Name, BasicAutomationElement);
            Role = new AutomationProperty<AccessibilityRole>(() => Properties.Role, BasicAutomationElement);
            Selection = new AutomationProperty<AutomationElement[]>(() => Properties.Selection, BasicAutomationElement);
            State = new AutomationProperty<AccessibilityState>(() => Properties.State, BasicAutomationElement);
            Value = new AutomationProperty<string>(() => Properties.Value, BasicAutomationElement);
        }

        public ILegacyIAccessiblePatternProperties Properties => Automation.PropertyLibrary.LegacyIAccessible;

        public AutomationProperty<int> ChildId { get; }
        public AutomationProperty<string> DefaultAction { get; }
        public AutomationProperty<string> Description { get; }
        public AutomationProperty<string> Help { get; }
        public AutomationProperty<string> KeyboardShortcut { get; }
        public AutomationProperty<string> Name { get; }
        public AutomationProperty<AccessibilityRole> Role { get; }
        public AutomationProperty<AutomationElement[]> Selection { get; }
        public AutomationProperty<AccessibilityState> State { get; }
        public AutomationProperty<string> Value { get; }

        public abstract void DoDefaultAction();
        public abstract IAccessible GetIAccessible();
        public abstract void Select(int flagsSelect);
        public abstract void SetValue(string value);
    }
}
