using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class SpreadsheetItemPattern : PatternBaseWithInformation<IUIAutomationSpreadsheetItemPattern, SpreadsheetItemInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_SpreadsheetItemPatternId, "SpreadsheetItem");
        public static readonly AutomationProperty FormulaProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_SpreadsheetItemFormulaPropertyId, "Formula");
        public static readonly AutomationProperty AnnotationObjectsProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_SpreadsheetItemAnnotationObjectsPropertyId, "AnnotationObjects");
        public static readonly AutomationProperty AnnotationTypesProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_SpreadsheetItemAnnotationTypesPropertyId, "AnnotationTypes").SetConverter(NativeValueConverter.ToAnnotationTypes);

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
