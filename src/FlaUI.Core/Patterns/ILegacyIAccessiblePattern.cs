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
        int ChildId { get; }
        string DefaultAction { get; }
        string Description { get; }
        string Help { get; }
        string KeyboardShortcut { get; }
        string Name { get; }
        AccessibilityRole Role { get; }
        AutomationElement[] Selection { get; }
        AccessibilityState State { get; }
        string Value { get; }
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
}
