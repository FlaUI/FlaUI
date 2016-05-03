using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class LegacyIAccessiblePattern : PatternBaseWithInformation<IUIAutomationLegacyIAccessiblePattern, LegacyIAccessiblePatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_LegacyIAccessiblePatternId, "LegacyIAccessible");
        public static readonly AutomationProperty ChildIdProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LegacyIAccessibleChildIdPropertyId, "ChildId");
        public static readonly AutomationProperty DefaultActionProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LegacyIAccessibleDefaultActionPropertyId, "DefaultAction");
        public static readonly AutomationProperty DescriptionProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LegacyIAccessibleDescriptionPropertyId, "Description");
        public static readonly AutomationProperty HelpProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LegacyIAccessibleHelpPropertyId, "Help");
        public static readonly AutomationProperty KeyboardShortcutProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LegacyIAccessibleKeyboardShortcutPropertyId, "KeyboardShortcut");
        public static readonly AutomationProperty NameProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LegacyIAccessibleNamePropertyId, "Name");
        public static readonly AutomationProperty RoleProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LegacyIAccessibleRolePropertyId, "Role");
        public static readonly AutomationProperty SelectionProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LegacyIAccessibleSelectionPropertyId, "Selection");
        public static readonly AutomationProperty StateProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LegacyIAccessibleStatePropertyId, "State");
        public static readonly AutomationProperty ValueProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LegacyIAccessibleValuePropertyId, "Value");

        internal LegacyIAccessiblePattern(AutomationElement automationElement, IUIAutomationLegacyIAccessiblePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new LegacyIAccessiblePatternInformation(element, cached))
        {
        }

        public void DoDefaultAction()
        {
            ComCallWrapper.Call(() => NativePattern.DoDefaultAction());
        }

        public Accessibility.IAccessible GetIAccessible()
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            return ComCallWrapper.Call(() => (Accessibility.IAccessible)NativePattern.GetIAccessible());
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
