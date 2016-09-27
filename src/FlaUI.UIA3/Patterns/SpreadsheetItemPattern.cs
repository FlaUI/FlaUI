using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SpreadsheetItemPattern : PatternBaseWithInformation<SpreadsheetItemInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SpreadsheetItemPatternId, "SpreadsheetItem");
        public static readonly PropertyId FormulaProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SpreadsheetItemFormulaPropertyId, "Formula");
        public static readonly PropertyId AnnotationObjectsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SpreadsheetItemAnnotationObjectsPropertyId, "AnnotationObjects");
        public static readonly PropertyId AnnotationTypesProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SpreadsheetItemAnnotationTypesPropertyId, "AnnotationTypes").SetConverter(NativeValueConverter.ToAnnotationTypes);

        internal SpreadsheetItemPattern(Element automationElement, UIA.IUIAutomationSpreadsheetItemPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new SpreadsheetItemInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationSpreadsheetItemPattern NativePattern
        {
            get { return (UIA.IUIAutomationSpreadsheetItemPattern)base.NativePattern; }
        }
    }

    public class SpreadsheetItemInformation : InformationBase
    {
        public SpreadsheetItemInformation(Element automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public string Formula
        {
            get { return Get<string>(SpreadsheetItemPattern.FormulaProperty); }
        }

        public Element[] AnnotationObjects
        {
            get { return NativeElementArrayToElements(SpreadsheetItemPattern.AnnotationObjectsProperty); }
        }

        public AnnotationType[] AnnotationTypes
        {
            get { return Get<AnnotationType[]>(SpreadsheetItemPattern.AnnotationTypesProperty); }
        }
    }
}
