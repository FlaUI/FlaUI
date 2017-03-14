using System;
using Accessibility;
using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Patterns
{
    public class LegacyIAccessiblePattern : LegacyIAccessiblePatternBase<UIA.IUIAutomationLegacyIAccessiblePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_LegacyIAccessiblePatternId, "LegacyIAccessible", AutomationObjectIds.IsLegacyIAccessiblePatternAvailableProperty);
        public static readonly PropertyId ChildIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleChildIdPropertyId, "ChildId");
        public static readonly PropertyId DefaultActionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleDefaultActionPropertyId, "DefaultAction");
        public static readonly PropertyId DescriptionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleDescriptionPropertyId, "Description");
        public static readonly PropertyId HelpProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleHelpPropertyId, "Help");
        public static readonly PropertyId KeyboardShortcutProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleKeyboardShortcutPropertyId, "KeyboardShortcut");
        public static readonly PropertyId NameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleNamePropertyId, "Name");
        public static readonly PropertyId RoleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleRolePropertyId, "Role").SetConverter((a, o) => (AccessibilityRole)Convert.ToUInt32(o));
        public static readonly PropertyId SelectionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleSelectionPropertyId, "Selection").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId StateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleStatePropertyId, "State").SetConverter((a, o) => (AccessibilityState)Convert.ToUInt32(o));
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleValuePropertyId, "Value");

        public LegacyIAccessiblePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationLegacyIAccessiblePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public override void DoDefaultAction()
        {
            ComCallWrapper.Call(() => NativePattern.DoDefaultAction());
        }

        public override IAccessible GetIAccessible()
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            return ComCallWrapper.Call(() => (IAccessible)NativePattern.GetIAccessible());
        }

        public override void Select(int flagsSelect)
        {
            ComCallWrapper.Call(() => NativePattern.Select(flagsSelect));
        }

        public override void SetValue(string value)
        {
            ComCallWrapper.Call(() => NativePattern.SetValue(value));
        }
    }

    public class LegacyIAccessiblePatternProperties : ILegacyIAccessiblePatternProperties
    {
        public PropertyId ChildId => LegacyIAccessiblePattern.ChildIdProperty;
        public PropertyId DefaultAction => LegacyIAccessiblePattern.DefaultActionProperty;
        public PropertyId Description => LegacyIAccessiblePattern.DescriptionProperty;
        public PropertyId Help => LegacyIAccessiblePattern.HelpProperty;
        public PropertyId KeyboardShortcut => LegacyIAccessiblePattern.KeyboardShortcutProperty;
        public PropertyId Name => LegacyIAccessiblePattern.NameProperty;
        public PropertyId Role => LegacyIAccessiblePattern.RoleProperty;
        public PropertyId Selection => LegacyIAccessiblePattern.SelectionProperty;
        public PropertyId State => LegacyIAccessiblePattern.StateProperty;
        public PropertyId Value => LegacyIAccessiblePattern.ValueProperty;
    }
}
