using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class SpreadsheetItemPattern : PatternBaseWithInformation<IUIAutomationSpreadsheetItemPattern, SpreadsheetItemInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_SpreadsheetItemPatternId, "SpreadsheetItem");
        public static readonly PropertyId FormulaProperty = PropertyId.Register(UIA_PropertyIds.UIA_SpreadsheetItemFormulaPropertyId, "Formula");
        public static readonly PropertyId AnnotationObjectsProperty = PropertyId.Register(UIA_PropertyIds.UIA_SpreadsheetItemAnnotationObjectsPropertyId, "AnnotationObjects");
        public static readonly PropertyId AnnotationTypesProperty = PropertyId.Register(UIA_PropertyIds.UIA_SpreadsheetItemAnnotationTypesPropertyId, "AnnotationTypes").SetConverter(NativeValueConverter.ToAnnotationTypes);

        internal SpreadsheetItemPattern(AutomationElement automationElement, IUIAutomationSpreadsheetItemPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new SpreadsheetItemInformation(element, cached))
        {
        }
    }

    public class SpreadsheetItemInformation : InformationBase
    {
        public SpreadsheetItemInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public string Formula
        {
            get { return Get<string>(SpreadsheetItemPattern.FormulaProperty); }
        }

        public AutomationElement[] AnnotationObjects
        {
            get { return NativeElementArrayToElements(SpreadsheetItemPattern.AnnotationObjectsProperty); }
        }

        public AnnotationType[] AnnotationTypes
        {
            get { return Get<AnnotationType[]>(SpreadsheetItemPattern.AnnotationTypesProperty); }
        }
    }
}
