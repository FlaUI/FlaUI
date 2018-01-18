using Accessibility;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Patterns
{
    public interface ILegacyIAccessiblePattern : IPattern
    {
        ILegacyIAccessiblePatternPropertyIds PropertyIds { get; }

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

    public interface ILegacyIAccessiblePatternPropertyIds
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
        where TNativePattern : class
    {
        private AutomationProperty<int> _childId;
        private AutomationProperty<string> _defaultAction;
        private AutomationProperty<string> _description;
        private AutomationProperty<string> _help;
        private AutomationProperty<string> _keyboardShortcut;
        private AutomationProperty<string> _name;
        private AutomationProperty<AccessibilityRole> _role;
        private AutomationProperty<AutomationElement[]> _selection;
        private AutomationProperty<AccessibilityState> _state;
        private AutomationProperty<string> _value;

        protected LegacyIAccessiblePatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ILegacyIAccessiblePatternPropertyIds PropertyIds => Automation.PropertyLibrary.LegacyIAccessible;

        public AutomationProperty<int> ChildId => GetOrCreate(ref _childId, PropertyIds.ChildId);
        public AutomationProperty<string> DefaultAction => GetOrCreate(ref _defaultAction, PropertyIds.DefaultAction);
        public AutomationProperty<string> Description => GetOrCreate(ref _description, PropertyIds.Description);
        public AutomationProperty<string> Help => GetOrCreate(ref _help, PropertyIds.Help);
        public AutomationProperty<string> KeyboardShortcut => GetOrCreate(ref _keyboardShortcut, PropertyIds.KeyboardShortcut);
        public AutomationProperty<string> Name => GetOrCreate(ref _name, PropertyIds.Name);
        public AutomationProperty<AccessibilityRole> Role => GetOrCreate(ref _role, PropertyIds.Role);
        public AutomationProperty<AutomationElement[]> Selection => GetOrCreate(ref _selection, PropertyIds.Selection);
        public AutomationProperty<AccessibilityState> State => GetOrCreate(ref _state, PropertyIds.State);
        public AutomationProperty<string> Value => GetOrCreate(ref _value, PropertyIds.Value);

        public abstract void DoDefaultAction();
        public abstract IAccessible GetIAccessible();
        public abstract void Select(int flagsSelect);
        public abstract void SetValue(string value);
    }
}
