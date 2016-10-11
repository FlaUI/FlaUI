using Accessibility;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class LegacyIAccessiblePattern : PatternBaseWithInformation<UIA.IUIAutomationLegacyIAccessiblePattern, LegacyIAccessiblePatternInformation>, ILegacyIAccessiblePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_LegacyIAccessiblePatternId, "LegacyIAccessible");
        public static readonly PropertyId ChildIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleChildIdPropertyId, "ChildId");
        public static readonly PropertyId DefaultActionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleDefaultActionPropertyId, "DefaultAction");
        public static readonly PropertyId DescriptionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleDescriptionPropertyId, "Description");
        public static readonly PropertyId HelpProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleHelpPropertyId, "Help");
        public static readonly PropertyId KeyboardShortcutProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleKeyboardShortcutPropertyId, "KeyboardShortcut");
        public static readonly PropertyId NameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleNamePropertyId, "Name");
        public static readonly PropertyId RoleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleRolePropertyId, "Role");
        public static readonly PropertyId SelectionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleSelectionPropertyId, "Selection");
        public static readonly PropertyId StateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleStatePropertyId, "State");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LegacyIAccessibleValuePropertyId, "Value");

        public LegacyIAccessiblePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationLegacyIAccessiblePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Properties = new LegacyIAccessiblePatternProperties();
        }

        ILegacyIAccessiblePatternInformation IPatternWithInformation<ILegacyIAccessiblePatternInformation>.Cached => Cached;

        ILegacyIAccessiblePatternInformation IPatternWithInformation<ILegacyIAccessiblePatternInformation>.Current => Current;

        public ILegacyIAccessiblePatternProperties Properties { get; }

        protected override LegacyIAccessiblePatternInformation CreateInformation(bool cached)
        {
            return new LegacyIAccessiblePatternInformation(BasicAutomationElement, cached);
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

    public class LegacyIAccessiblePatternInformation : InformationBase, ILegacyIAccessiblePatternInformation
    {
        public LegacyIAccessiblePatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public int ChildId => Get<int>(LegacyIAccessiblePattern.ChildIdProperty);

        public string DefaultAction => Get<string>(LegacyIAccessiblePattern.DefaultActionProperty);

        public string Description => Get<string>(LegacyIAccessiblePattern.DescriptionProperty);

        public string Help => Get<string>(LegacyIAccessiblePattern.HelpProperty);

        public string KeyboardShortcut => Get<string>(LegacyIAccessiblePattern.KeyboardShortcutProperty);

        public string Name => Get<string>(LegacyIAccessiblePattern.NameProperty);

        public uint Role => Get<uint>(LegacyIAccessiblePattern.RoleProperty);

        public AutomationElement[] Selection
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(LegacyIAccessiblePattern.SelectionProperty);
                return ValueConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public uint State => Get<uint>(LegacyIAccessiblePattern.StateProperty);

        public string Value => Get<string>(LegacyIAccessiblePattern.ValueProperty);
    }

    public class LegacyIAccessiblePatternProperties : ILegacyIAccessiblePatternProperties
    {
        public PropertyId ChildIdProperty => LegacyIAccessiblePattern.ChildIdProperty;
        public PropertyId DefaultActionProperty => LegacyIAccessiblePattern.DefaultActionProperty;
        public PropertyId DescriptionProperty => LegacyIAccessiblePattern.DescriptionProperty;
        public PropertyId HelpProperty => LegacyIAccessiblePattern.HelpProperty;
        public PropertyId KeyboardShortcutProperty => LegacyIAccessiblePattern.KeyboardShortcutProperty;
        public PropertyId NameProperty => LegacyIAccessiblePattern.NameProperty;
        public PropertyId RoleProperty => LegacyIAccessiblePattern.RoleProperty;
        public PropertyId SelectionProperty => LegacyIAccessiblePattern.SelectionProperty;
        public PropertyId StateProperty => LegacyIAccessiblePattern.StateProperty;
        public PropertyId ValueProperty => LegacyIAccessiblePattern.ValueProperty;
    }
}
