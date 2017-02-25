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
        PropertyId ChildIdProperty { get; }
        PropertyId DefaultActionProperty { get; }
        PropertyId DescriptionProperty { get; }
        PropertyId HelpProperty { get; }
        PropertyId KeyboardShortcutProperty { get; }
        PropertyId NameProperty { get; }
        PropertyId RoleProperty { get; }
        PropertyId SelectionProperty { get; }
        PropertyId StateProperty { get; }
        PropertyId ValueProperty { get; }
    }

    public abstract class LegacyIAccessiblePatternBase<TNativePattern> : PatternBase<TNativePattern>, ILegacyIAccessiblePattern
    {
        protected LegacyIAccessiblePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ChildId = new AutomationProperty<int>(() => Properties.ChildIdProperty, BasicAutomationElement);
            DefaultAction = new AutomationProperty<string>(() => Properties.DefaultActionProperty, BasicAutomationElement);
            Description = new AutomationProperty<string>(() => Properties.DescriptionProperty, BasicAutomationElement);
            Help = new AutomationProperty<string>(() => Properties.HelpProperty, BasicAutomationElement);
            KeyboardShortcut = new AutomationProperty<string>(() => Properties.KeyboardShortcutProperty, BasicAutomationElement);
            Name = new AutomationProperty<string>(() => Properties.NameProperty, BasicAutomationElement);
            Role = new AutomationProperty<AccessibilityRole>(() => Properties.RoleProperty, BasicAutomationElement);
            Selection = new AutomationProperty<AutomationElement[]>(() => Properties.SelectionProperty, BasicAutomationElement);
            State = new AutomationProperty<AccessibilityState>(() => Properties.StateProperty, BasicAutomationElement);
            Value = new AutomationProperty<string>(() => Properties.ValueProperty, BasicAutomationElement);
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
