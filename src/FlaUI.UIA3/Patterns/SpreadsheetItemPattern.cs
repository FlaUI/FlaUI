using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SpreadsheetItemPattern : PatternBaseWithInformation<UIA.IUIAutomationSpreadsheetItemPattern, SpreadsheetItemPatternInformation>, ISpreadsheetItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SpreadsheetItemPatternId, "SpreadsheetItem");
        public static readonly PropertyId FormulaProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SpreadsheetItemFormulaPropertyId, "Formula");
        public static readonly PropertyId AnnotationObjectsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SpreadsheetItemAnnotationObjectsPropertyId, "AnnotationObjects");
        public static readonly PropertyId AnnotationTypesProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SpreadsheetItemAnnotationTypesPropertyId, "AnnotationTypes").SetConverter(AnnotationTypeConverter.ToAnnotationTypeArray);

        public SpreadsheetItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationSpreadsheetItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ISpreadsheetItemPatternInformation IPatternWithInformation<ISpreadsheetItemPatternInformation>.Cached => Cached;

        ISpreadsheetItemPatternInformation IPatternWithInformation<ISpreadsheetItemPatternInformation>.Current => Current;

        public ISpreadsheetItemPatternProperties Properties => Automation.PropertyLibrary.SpreadsheetItem;

        protected override SpreadsheetItemPatternInformation CreateInformation(bool cached)
        {
            return new SpreadsheetItemPatternInformation(BasicAutomationElement, cached);
        }
    }

    public class SpreadsheetItemPatternInformation : InformationBase, ISpreadsheetItemPatternInformation
    {
        public SpreadsheetItemPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public string Formula => Get<string>(SpreadsheetItemPattern.FormulaProperty);

        public AutomationElement[] AnnotationObjects
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(SpreadsheetItemPattern.AnnotationObjectsProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public AnnotationType[] AnnotationTypes => Get<AnnotationType[]>(SpreadsheetItemPattern.AnnotationTypesProperty);
    }

    public class SpreadsheetItemPatternProperties : ISpreadsheetItemPatternProperties
    {
        public PropertyId FormulaProperty => SpreadsheetItemPattern.FormulaProperty;
        public PropertyId AnnotationObjectsProperty => SpreadsheetItemPattern.AnnotationObjectsProperty;
        public PropertyId AnnotationTypesProperty => SpreadsheetItemPattern.AnnotationTypesProperty;
    }
}
