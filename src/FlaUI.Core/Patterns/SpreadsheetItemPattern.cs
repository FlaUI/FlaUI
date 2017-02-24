using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISpreadsheetItemPattern : IPattern
    {
        ISpreadsheetItemPatternProperties Properties { get; }
        string Formula { get; }
        AutomationElement[] AnnotationObjects { get; }
        AnnotationType[] AnnotationTypes { get; }
    }

    public interface ISpreadsheetItemPatternProperties
    {
        PropertyId FormulaProperty { get; }
        PropertyId AnnotationObjectsProperty { get; }
        PropertyId AnnotationTypesProperty { get; }
    }
}
