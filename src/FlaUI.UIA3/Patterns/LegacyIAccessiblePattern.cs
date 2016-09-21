using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using IAccessible = Accessibility.IAccessible;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class LegacyIAccessiblePattern : PatternBaseWithInformation<LegacyIAccessiblePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_LegacyIAccessiblePatternId, "LegacyIAccessible");
        public static readonly PropertyId ChildIdProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LegacyIAccessibleChildIdPropertyId, "ChildId");
        public static readonly PropertyId DefaultActionProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LegacyIAccessibleDefaultActionPropertyId, "DefaultAction");
        public static readonly PropertyId DescriptionProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LegacyIAccessibleDescriptionPropertyId, "Description");
        public static readonly PropertyId HelpProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LegacyIAccessibleHelpPropertyId, "Help");
        public static readonly PropertyId KeyboardShortcutProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LegacyIAccessibleKeyboardShortcutPropertyId, "KeyboardShortcut");
        public static readonly PropertyId NameProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LegacyIAccessibleNamePropertyId, "Name");
        public static readonly PropertyId RoleProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LegacyIAccessibleRolePropertyId, "Role");
        public static readonly PropertyId SelectionProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LegacyIAccessibleSelectionPropertyId, "Selection");
        public static readonly PropertyId StateProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LegacyIAccessibleStatePropertyId, "State");
        public static readonly PropertyId ValueProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LegacyIAccessibleValuePropertyId, "Value");

        internal LegacyIAccessiblePattern(AutomationElement automationElement, UIA.IUIAutomationLegacyIAccessiblePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new LegacyIAccessiblePatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationLegacyIAccessiblePattern NativePattern
        {
            get { return (UIA.IUIAutomationLegacyIAccessiblePattern)base.NativePattern; }
        }

        public void DoDefaultAction()
        {
            ComCallWrapper.Call(() => NativePattern.DoDefaultAction());
        }

        public IAccessible GetIAccessible()
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            return ComCallWrapper.Call(() => (IAccessible)NativePattern.GetIAccessible());
        }

        public void Select(int flagsSelect)
        {
            ComCallWrapper.Call(() => NativePattern.Select(flagsSelect));
        }

        public void SetValue(string value)
        {
            ComCallWrapper.Call(() => NativePattern.SetValue(value));
        }
    }

    public class LegacyIAccessiblePatternInformation : InformationBase
    {
        public LegacyIAccessiblePatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public int ChildId
        {
            get { return Get<int>(LegacyIAccessiblePattern.ChildIdProperty); }
        }

        public string DefaultAction
        {
            get { return Get<string>(LegacyIAccessiblePattern.DefaultActionProperty); }
        }

        public string Description
        {
            get { return Get<string>(LegacyIAccessiblePattern.DescriptionProperty); }
        }

        public string Help
        {
            get { return Get<string>(LegacyIAccessiblePattern.HelpProperty); }
        }

        public string KeyboardShortcut
        {
            get { return Get<string>(LegacyIAccessiblePattern.KeyboardShortcutProperty); }
        }

        public string Name
        {
            get { return Get<string>(LegacyIAccessiblePattern.NameProperty); }
        }

        public uint Role
        {
            get { return Get<uint>(LegacyIAccessiblePattern.RoleProperty); }
        }

        public AutomationElement[] Selection
        {
            get { return NativeElementArrayToElements(LegacyIAccessiblePattern.SelectionProperty); }
        }

        public uint State
        {
            get { return Get<uint>(LegacyIAccessiblePattern.StateProperty); }
        }

        public string Value
        {
            get { return Get<string>(LegacyIAccessiblePattern.ValueProperty); }
        }
    }
}
