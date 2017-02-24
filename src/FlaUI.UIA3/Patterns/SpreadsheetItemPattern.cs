using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SpreadsheetItemPattern : PatternBase<UIA.IUIAutomationSpreadsheetItemPattern>, ISpreadsheetItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SpreadsheetItemPatternId, "SpreadsheetItem", AutomationObjectIds.IsSpreadsheetItemPatternAvailableProperty);
        public static readonly PropertyId FormulaProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SpreadsheetItemFormulaPropertyId, "Formula");
        public static readonly PropertyId AnnotationObjectsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SpreadsheetItemAnnotationObjectsPropertyId, "AnnotationObjects");
        public static readonly PropertyId AnnotationTypesProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SpreadsheetItemAnnotationTypesPropertyId, "AnnotationTypes").SetConverter((a, o) => AnnotationTypeConverter.ToAnnotationTypeArray(o));

        public SpreadsheetItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationSpreadsheetItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ISpreadsheetItemPatternProperties Properties => Automation.PropertyLibrary.SpreadsheetItem;

        public string Formula => Get<string>(FormulaProperty);

        public AutomationElement[] AnnotationObjects
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(AnnotationObjectsProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public AnnotationType[] AnnotationTypes => Get<AnnotationType[]>(AnnotationTypesProperty);
    }

    public class SpreadsheetItemPatternProperties : ISpreadsheetItemPatternProperties
    {
        public PropertyId FormulaProperty => SpreadsheetItemPattern.FormulaProperty;
        public PropertyId AnnotationObjectsProperty => SpreadsheetItemPattern.AnnotationObjectsProperty;
        public PropertyId AnnotationTypesProperty => SpreadsheetItemPattern.AnnotationTypesProperty;
    }
}
