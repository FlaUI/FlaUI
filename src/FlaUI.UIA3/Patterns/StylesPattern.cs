using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Patterns
{
    public class StylesPattern : StylesPatternBase<UIA.IUIAutomationStylesPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_StylesPatternId, "Styles", AutomationObjectIds.IsStylesPatternAvailableProperty);
        public static readonly PropertyId ExtendedPropertiesProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesExtendedPropertiesPropertyId, "ExtendedProperties");
        public static readonly PropertyId FillColorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillColorPropertyId, "FillColor");
        public static readonly PropertyId FillPatternColorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillPatternColorPropertyId, "FillPatternColor");
        public static readonly PropertyId FillPatternStyleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillPatternStylePropertyId, "FillPatternStyle");
        public static readonly PropertyId ShapeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesShapePropertyId, "Shape");
        public static readonly PropertyId StyleIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesStyleIdPropertyId, "StyleId").SetConverter((a, o) => StyleTypeConverter.ToStyleType(o));
        public static readonly PropertyId StyleNameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesStyleNamePropertyId, "StyleName");

        public StylesPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationStylesPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        // TODO: Any way to implement that?
        //public void GetCachedExtendedPropertiesAsArray(IntPtr propertyArray, out int propertyCount){}
        //public void GetCurrentExtendedPropertiesAsArray(IntPtr propertyArray, out int propertyCount){}
    }

    public class StylesPatternProperties : IStylesPatternProperties
    {
        public PropertyId ExtendedProperties => StylesPattern.ExtendedPropertiesProperty;
        public PropertyId FillColor => StylesPattern.FillColorProperty;
        public PropertyId FillPatternColor => StylesPattern.FillPatternColorProperty;
        public PropertyId FillPatternStyle => StylesPattern.FillPatternStyleProperty;
        public PropertyId Shape => StylesPattern.ShapeProperty;
        public PropertyId StyleId => StylesPattern.StyleIdProperty;
        public PropertyId StyleName => StylesPattern.StyleNameProperty;
    }
}
